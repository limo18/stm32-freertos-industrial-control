using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoFinal_ICI.Form1;//Usamos form1

namespace ProyectoFinal_ICI
{
    public partial class Form2 : Form
    {
        int actualizar = 0;
        double ejex = 0;
        public remoto Datos {  get; set; }//Estructura actualizada desde form1
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Actualizamos medidores de datos remotos
            lbAnalogMeter_remoto.Value = Datos.rpm;
            lbDigitalMeter_servo_remoto.Value = Datos.servo;
            lbDigitalMeter_temp_remoto.Value = Datos.temp;
            if (Datos.direccion == 0)
            {
                Izq_LED_remoto.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
                Der_LED_remoto.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            }
            else if (Datos.direccion == 1)
            {
                Der_LED_remoto.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
                Izq_LED_remoto.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            }
            //*******CHARTS *******
            if (actualizar == 100)//Han pasado 50s...borramos datos existentes en charts y empezamos desde 0 segundos
            {
                actualizar = 0;
                chart_temp.Series["Temp"].Points.Clear();//Limpiamos puntos
                chart_temp.Series["Temp"].Points.AddXY(0, Datos.temp);//Partimos desde 0s 
                chart_motor.Series["RPM"].Points.Clear();
                chart_motor.Series["RPM"].Points.AddXY(0,Datos.rpm);
                chart_servo.Series["Servo"].Points.Clear();
                chart_servo.Series["Servo"].Points.AddXY(0,Datos.servo);
            }
            else
            {
                actualizar++;//Incrementamos numero de muestras en la historia
                ejex = actualizar / 2.0;//obtenemos coordenada x actualizada
                chart_temp.Series["Temp"].Points.AddXY(ejex, Datos.temp);//representamos dato en chart
                if (Datos.direccion == 0)
                {
                    chart_motor.Series["RPM"].Points.AddXY(ejex, -Datos.rpm);//Giro a la izquierda...valores negativos
                }else if (Datos.direccion == 1)
                {
                    chart_motor.Series["RPM"].Points.AddXY(ejex, Datos.rpm);//Gira a la derecha...valores positivos
                }
                chart_servo.Series["Servo"].Points.AddXY(ejex, Datos.servo);
            }
        }
    }
}
