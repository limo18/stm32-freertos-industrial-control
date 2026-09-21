using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Windows.Forms.DataVisualization.Charting;


namespace ProyectoFinal_ICI
{
    public partial class Form1 : Form
    {
        public struct remoto
        {
            public double temp;
            public byte servo;
            public byte rpm;
            public byte direccion;
        }
        //VARIABLES GLOBALES:
        double temperatura;
        byte posicion_servo = 0;
        byte motor_vel;
        byte direccion;
        bool cancelar = false;
        remoto remote = new remoto();
        public Form2 form;
        public Form1()
        {
            InitializeComponent();
            serialPort1.Encoding = System.Text.Encoding.GetEncoding("utf-8");
        }
        private void EnviarTrama(byte[] trama)
        {
            serialPort1.Write(trama, 0, trama.Length);
        }
        bool IsFormOpen(string formName)//Para saber si puedo actualizar datos remotos o no
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == formName)
                {
                    return true; // El formulario está abierto
                }
            }
            return false; // El formulario no está abierto
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] trama = new byte[4];
            if (serialPort1.IsOpen)
            {
                while (serialPort1.BytesToRead >= 4)//Quedan por leer 4 o mas bytes
                {
                    serialPort1.Read(trama, 0, 4);//Leemos puerto
                    if (trama[0] == 0x20 && trama[3] == 0xE0)
                    {
                        posicion_servo = trama[1];      //Valor servomotor
                    }
                    else if (trama[0] == 0x21 && trama[3] == 0xE0)
                    {
                        remote.servo = trama[1];        //Valor servo remoto
                    }
                    else if (trama[0] == 0x30 && trama[3] == 0xE0)
                    {
                         temperatura = (double)trama[1] + (trama[2] / 100.0); //Valor temperatura

                    }
                    else if (trama[0] == 0x31 && trama[3] == 0xE0)
                    {
                        remote.temp = (double)trama[1] + (trama[2] / 100.0);//Temperatura remota
                    }
                    else if (trama[0] == 0x40 && trama[3] == 0xE0)
                    {
                        motor_vel = trama[1];       //RPM motor
                        direccion = trama[2];       //Direccion de giro de motor
                        if(direccion == 0)
                        {
                            Izq_LED.State=LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
                            Der_LED.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
                        }else if(direccion == 1)
                        {
                            Der_LED.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
                            Izq_LED.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
                        }
                    }
                    else if (trama[0] == 0x41 && trama[3] == 0xE0)
                    {
                        remote.rpm = trama[1];  //RPM remoto
                        remote.direccion = trama[2];//Direccion de giro remota
                    }
                }
            }
        }

        private void button_UART_Click(object sender, EventArgs e)
        {
            string puerto = textBox_UART.Text.ToString();
            serialPort1.PortName = puerto;//Se configura puerto COM con el puesto en el textBox
            serialPort1.Open();//Abrimos puerto al clickar boton Abrir
            if (serialPort1.IsOpen)
            {
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible=false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Actualizamos medidores
            lbAnalogMeter_rpm.Value = motor_vel;
            lbDigitalMeter_temp.Value = temperatura;
            lbDigitalMeter_servo.Value = posicion_servo;
            //Si tenemos activado el CAN actualizamos datos remotos
            if (IsFormOpen("Form2")){
                form.Datos = remote;
            }
        }
//**********************MOTOR*************************
        private void Izq_button_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x49, 0xFF, 0xFF, 0xE0 });//Girar izquierda
            
        }

        private void Der_button_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x44, 0xFF, 0xFF, 0xE0 });//Girar derecha
        }

        private void lbKnob_motor_KnobChangeValue(object sender, LBSoft.IndustrialCtrls.Knobs.LBKnobEventArgs e)
        {
            EnviarTrama(new byte[] { 0x4D, (byte) lbKnob_motor.Value, 0xFF, 0xE0 });//Velocidad motor
        }
 //*********************SERVO*****************************
        private void lbKnob_servo_KnobChangeValue(object sender, LBSoft.IndustrialCtrls.Knobs.LBKnobEventArgs e)
        {
            EnviarTrama(new byte[] { 0x53, (byte)lbKnob_servo.Value, 0xFF, 0xE0 });//Posicion servo
        }

        private void Pot_button_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x50, 0xFF, 0xFF, 0xE0 });//Modo potenciometro
        }
        private void button_sweep_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x41, (byte)Convert.ToInt16(textBox_wait.Text), (byte)Convert.ToInt16(textBox_vel.Text), 0xE0 });
        }//Modo sweep
//******************Comando cancelar********************
        private void button_cancel_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x43, 0xFF, 0xFF, 0xE0 });//Cancelar acciones
             //Considerando que en estado de reposo, el CAN no esta activado, lo muestro de la siguiente forma
            if (IsFormOpen("Form2"))//Si los datos remotos se estan mostrando, cerramos form
            {
                form.Close(); 
            }
            //Posicionamos form1 en el centro de la pantalla
            this.StartPosition = FormStartPosition.Manual; //Posicionamiento manual
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,  // Calcular X para centrar
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2 // Calcular Y para centrar
            );
            //Si se busca que los visualizadores tambien se sigan mostrando en reposo solo hay que comentar 
            //este fragmento de codigo desde la linea 162 a la 171.
            Cancelar_LED.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;//Encendemos led actions cancelled
        }
//******************Periodo temperatura*********************
        private void button_TMP_Click(object sender, EventArgs e)
        {
            int periodo = Convert.ToInt16(textBox_TMP.Text);
            EnviarTrama(new byte[] { 0x54, (byte)(periodo>>8), (byte)periodo, 0xE0 });//Envio temperatura con periodo
        }
//**********************CAN***********************************
        private void CAN_button_Click(object sender, EventArgs e)
        {
            int width=Screen.PrimaryScreen.WorkingArea.Width;
            int height=Screen.PrimaryScreen.WorkingArea.Height;
            //Mandamos trama diferente segun modo de transmision
            if (radioButtonA.Checked)
            {
                EnviarTrama(new byte[] { 0x52, 0x00, 0xFF, 0xE0 });//Modo A
            }
            else if (radioButtonB.Checked)
            {
                EnviarTrama(new byte[] { 0x52, 0x01, 0xFF, 0xE0 });//Modo B
            }
            else if (radioButtonAB.Checked)
            {
                EnviarTrama(new byte[] { 0x52, 0x02, 0xFF, 0xE0 });//Modo AB
            }
            if (form == null || form.IsDisposed)//Si el form no se ha creado, creamos uno y lo mostramos
            {
                form = new Form2();
                form.FormClosed += (s, args) => form = null;//actualizamos estado de form
                //Situamos un form a cada lado de la pantalla para visualizar correctamente
                this.StartPosition = FormStartPosition.Manual; 
                this.Location = new Point(20, height/4);//Form1 a la izquierda
                form.StartPosition = FormStartPosition.Manual; 
                form.Location = new Point(width / 2, height/4); // Form2 a la derecha
                form.Show();//Mostramos form2
            }
            else
            {
                form.BringToFront();//Hay uno abierto...Lo mostramos en el frente
            }
        }
//*********************OLED************************************
        private void button_OLED_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x58, 0xFF, 0xFF, 0xE0 });//Mostrar datos perifericos
        }

        private void button_SKULL_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x61, 0xFF, 0xFF, 0xE0 });//Animacion calavera
        }
        private void button_garfield_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x62, 0xFF, 0xFF, 0xE0 });//Animacion garfield
        }

        private void button_ST_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x63, 0xFF, 0xFF, 0xE0 });//Animacion ST
        }
        private void button_EPS_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x64, 0xFF, 0xFF, 0xE0 });//Animacion EPS
        }

        
//******************REANUDAR TAREAS*******************************
        private void button_resume_Click(object sender, EventArgs e)
        {
            EnviarTrama(new byte[] { 0x60, 0xFF, 0xFF, 0xE0 });//Reanudamos acciones canceladas
            Cancelar_LED.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;//Apagamos led actions cancelled
        }
    }
}
