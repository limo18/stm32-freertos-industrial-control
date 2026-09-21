namespace ProyectoFinal_ICI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAnalogMeter_rpm = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.lbDigitalMeter_servo = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter_temp = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_UART = new System.Windows.Forms.Button();
            this.textBox_UART = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_sweep = new System.Windows.Forms.Button();
            this.textBox_vel = new System.Windows.Forms.TextBox();
            this.textBox_wait = new System.Windows.Forms.TextBox();
            this.Pot_button = new System.Windows.Forms.Button();
            this.lbKnob_servo = new LBSoft.IndustrialCtrls.Knobs.LBKnob();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Der_LED = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.Izq_LED = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.lbKnob_motor = new LBSoft.IndustrialCtrls.Knobs.LBKnob();
            this.label5 = new System.Windows.Forms.Label();
            this.Izq_button = new System.Windows.Forms.Button();
            this.Der_button = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.button_EPS = new System.Windows.Forms.Button();
            this.button_garfield = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button_ST = new System.Windows.Forms.Button();
            this.button_SKULL = new System.Windows.Forms.Button();
            this.button_OLED = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CAN_button = new System.Windows.Forms.Button();
            this.radioButtonAB = new System.Windows.Forms.RadioButton();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_resume = new System.Windows.Forms.Button();
            this.textBox_TMP = new System.Windows.Forms.TextBox();
            this.button_TMP = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Cancelar_LED = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 38400;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbAnalogMeter_rpm);
            this.panel1.Controls.Add(this.lbDigitalMeter_servo);
            this.panel1.Controls.Add(this.lbDigitalMeter_temp);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(228, 566);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Servo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Temperatura(ºC)";
            // 
            // lbAnalogMeter_rpm
            // 
            this.lbAnalogMeter_rpm.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter_rpm.BodyColor = System.Drawing.Color.Red;
            this.lbAnalogMeter_rpm.Location = new System.Drawing.Point(29, 402);
            this.lbAnalogMeter_rpm.MaxValue = 14D;
            this.lbAnalogMeter_rpm.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter_rpm.MinValue = 0D;
            this.lbAnalogMeter_rpm.Name = "lbAnalogMeter_rpm";
            this.lbAnalogMeter_rpm.NeedleColor = System.Drawing.Color.Yellow;
            this.lbAnalogMeter_rpm.Renderer = null;
            this.lbAnalogMeter_rpm.ScaleColor = System.Drawing.Color.White;
            this.lbAnalogMeter_rpm.ScaleDivisions = 14;
            this.lbAnalogMeter_rpm.ScaleSubDivisions = 10;
            this.lbAnalogMeter_rpm.Size = new System.Drawing.Size(155, 152);
            this.lbAnalogMeter_rpm.TabIndex = 3;
            this.lbAnalogMeter_rpm.Value = 0D;
            this.lbAnalogMeter_rpm.ViewGlass = false;
            // 
            // lbDigitalMeter_servo
            // 
            this.lbDigitalMeter_servo.BackColor = System.Drawing.Color.Transparent;
            this.lbDigitalMeter_servo.Format = "00";
            this.lbDigitalMeter_servo.Location = new System.Drawing.Point(59, 296);
            this.lbDigitalMeter_servo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigitalMeter_servo.Name = "lbDigitalMeter_servo";
            this.lbDigitalMeter_servo.Renderer = null;
            this.lbDigitalMeter_servo.Signed = false;
            this.lbDigitalMeter_servo.Size = new System.Drawing.Size(95, 69);
            this.lbDigitalMeter_servo.TabIndex = 2;
            this.lbDigitalMeter_servo.Value = 0D;
            // 
            // lbDigitalMeter_temp
            // 
            this.lbDigitalMeter_temp.BackColor = System.Drawing.Color.Transparent;
            this.lbDigitalMeter_temp.Format = "00.00";
            this.lbDigitalMeter_temp.Location = new System.Drawing.Point(34, 186);
            this.lbDigitalMeter_temp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigitalMeter_temp.Name = "lbDigitalMeter_temp";
            this.lbDigitalMeter_temp.Renderer = null;
            this.lbDigitalMeter_temp.Signed = false;
            this.lbDigitalMeter_temp.Size = new System.Drawing.Size(150, 65);
            this.lbDigitalMeter_temp.TabIndex = 1;
            this.lbDigitalMeter_temp.Value = 0D;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.button_UART);
            this.panel2.Controls.Add(this.textBox_UART);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 131);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(119, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 77);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // button_UART
            // 
            this.button_UART.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_UART.Location = new System.Drawing.Point(15, 52);
            this.button_UART.Name = "button_UART";
            this.button_UART.Size = new System.Drawing.Size(80, 28);
            this.button_UART.TabIndex = 1;
            this.button_UART.Text = "Conectar";
            this.button_UART.UseVisualStyleBackColor = false;
            this.button_UART.Click += new System.EventHandler(this.button_UART_Click);
            // 
            // textBox_UART
            // 
            this.textBox_UART.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_UART.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_UART.Location = new System.Drawing.Point(15, 21);
            this.textBox_UART.Name = "textBox_UART";
            this.textBox_UART.Size = new System.Drawing.Size(80, 22);
            this.textBox_UART.TabIndex = 0;
            this.textBox_UART.Text = "COM3";
            this.textBox_UART.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.button_sweep);
            this.panel3.Controls.Add(this.textBox_vel);
            this.panel3.Controls.Add(this.textBox_wait);
            this.panel3.Controls.Add(this.Pot_button);
            this.panel3.Controls.Add(this.lbKnob_servo);
            this.panel3.Location = new System.Drawing.Point(632, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 182);
            this.panel3.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(130, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "Velocidad:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(133, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Espera(s):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "SERVO";
            // 
            // button_sweep
            // 
            this.button_sweep.Location = new System.Drawing.Point(218, 120);
            this.button_sweep.Name = "button_sweep";
            this.button_sweep.Size = new System.Drawing.Size(89, 23);
            this.button_sweep.TabIndex = 4;
            this.button_sweep.Text = "Sweep";
            this.button_sweep.UseVisualStyleBackColor = true;
            this.button_sweep.Click += new System.EventHandler(this.button_sweep_Click);
            // 
            // textBox_vel
            // 
            this.textBox_vel.Location = new System.Drawing.Point(218, 92);
            this.textBox_vel.Name = "textBox_vel";
            this.textBox_vel.Size = new System.Drawing.Size(89, 22);
            this.textBox_vel.TabIndex = 3;
            this.textBox_vel.Text = "30";
            this.textBox_vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_wait
            // 
            this.textBox_wait.Location = new System.Drawing.Point(218, 64);
            this.textBox_wait.Name = "textBox_wait";
            this.textBox_wait.Size = new System.Drawing.Size(89, 22);
            this.textBox_wait.TabIndex = 2;
            this.textBox_wait.Text = "2";
            this.textBox_wait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pot_button
            // 
            this.Pot_button.Location = new System.Drawing.Point(218, 19);
            this.Pot_button.Name = "Pot_button";
            this.Pot_button.Size = new System.Drawing.Size(89, 23);
            this.Pot_button.TabIndex = 1;
            this.Pot_button.Text = "Pot";
            this.Pot_button.UseVisualStyleBackColor = true;
            this.Pot_button.Click += new System.EventHandler(this.Pot_button_Click);
            // 
            // lbKnob_servo
            // 
            this.lbKnob_servo.BackColor = System.Drawing.Color.Transparent;
            this.lbKnob_servo.DrawRatio = 0.5F;
            this.lbKnob_servo.IndicatorColor = System.Drawing.Color.DarkGreen;
            this.lbKnob_servo.IndicatorOffset = 10F;
            this.lbKnob_servo.KnobCenter = ((System.Drawing.PointF)(resources.GetObject("lbKnob_servo.KnobCenter")));
            this.lbKnob_servo.KnobColor = System.Drawing.Color.MintCream;
            this.lbKnob_servo.KnobRect = ((System.Drawing.RectangleF)(resources.GetObject("lbKnob_servo.KnobRect")));
            this.lbKnob_servo.Location = new System.Drawing.Point(4, 21);
            this.lbKnob_servo.MaxValue = 90F;
            this.lbKnob_servo.MinValue = 0F;
            this.lbKnob_servo.Name = "lbKnob_servo";
            this.lbKnob_servo.Renderer = null;
            this.lbKnob_servo.ScaleColor = System.Drawing.Color.Black;
            this.lbKnob_servo.Size = new System.Drawing.Size(103, 100);
            this.lbKnob_servo.StepValue = 1F;
            this.lbKnob_servo.Style = LBSoft.IndustrialCtrls.Knobs.LBKnob.KnobStyle.Circular;
            this.lbKnob_servo.TabIndex = 0;
            this.lbKnob_servo.Value = 0F;
            this.lbKnob_servo.KnobChangeValue += new LBSoft.IndustrialCtrls.Knobs.KnobChangeValue(this.lbKnob_servo_KnobChangeValue);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Der_LED);
            this.panel4.Controls.Add(this.Izq_LED);
            this.panel4.Controls.Add(this.lbKnob_motor);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.Izq_button);
            this.panel4.Controls.Add(this.Der_button);
            this.panel4.Location = new System.Drawing.Point(632, 186);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 179);
            this.panel4.TabIndex = 2;
            // 
            // Der_LED
            // 
            this.Der_LED.BackColor = System.Drawing.Color.Transparent;
            this.Der_LED.BlinkInterval = 0;
            this.Der_LED.Label = "";
            this.Der_LED.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.Der_LED.LedColor = System.Drawing.Color.LimeGreen;
            this.Der_LED.LedSize = new System.Drawing.SizeF(10F, 10F);
            this.Der_LED.Location = new System.Drawing.Point(261, 83);
            this.Der_LED.Name = "Der_LED";
            this.Der_LED.Renderer = null;
            this.Der_LED.Size = new System.Drawing.Size(21, 15);
            this.Der_LED.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.Der_LED.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.Der_LED.TabIndex = 12;
            // 
            // Izq_LED
            // 
            this.Izq_LED.BackColor = System.Drawing.Color.Transparent;
            this.Izq_LED.BlinkInterval = 0;
            this.Izq_LED.Label = "";
            this.Izq_LED.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.Izq_LED.LedColor = System.Drawing.Color.LimeGreen;
            this.Izq_LED.LedSize = new System.Drawing.SizeF(10F, 10F);
            this.Izq_LED.Location = new System.Drawing.Point(174, 83);
            this.Izq_LED.Name = "Izq_LED";
            this.Izq_LED.Renderer = null;
            this.Izq_LED.Size = new System.Drawing.Size(21, 15);
            this.Izq_LED.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.Izq_LED.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.Izq_LED.TabIndex = 11;
            // 
            // lbKnob_motor
            // 
            this.lbKnob_motor.BackColor = System.Drawing.Color.Transparent;
            this.lbKnob_motor.DrawRatio = 0.44F;
            this.lbKnob_motor.IndicatorColor = System.Drawing.Color.Red;
            this.lbKnob_motor.IndicatorOffset = 10F;
            this.lbKnob_motor.KnobCenter = ((System.Drawing.PointF)(resources.GetObject("lbKnob_motor.KnobCenter")));
            this.lbKnob_motor.KnobColor = System.Drawing.Color.Black;
            this.lbKnob_motor.KnobRect = ((System.Drawing.RectangleF)(resources.GetObject("lbKnob_motor.KnobRect")));
            this.lbKnob_motor.Location = new System.Drawing.Point(38, 49);
            this.lbKnob_motor.MaxValue = 14F;
            this.lbKnob_motor.MinValue = 0F;
            this.lbKnob_motor.Name = "lbKnob_motor";
            this.lbKnob_motor.Renderer = null;
            this.lbKnob_motor.ScaleColor = System.Drawing.Color.Green;
            this.lbKnob_motor.Size = new System.Drawing.Size(88, 111);
            this.lbKnob_motor.StepValue = 1F;
            this.lbKnob_motor.Style = LBSoft.IndustrialCtrls.Knobs.LBKnob.KnobStyle.Circular;
            this.lbKnob_motor.TabIndex = 7;
            this.lbKnob_motor.Value = 0F;
            this.lbKnob_motor.KnobChangeValue += new LBSoft.IndustrialCtrls.Knobs.KnobChangeValue(this.lbKnob_motor_KnobChangeValue);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(132, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "MOTOR";
            // 
            // Izq_button
            // 
            this.Izq_button.BackColor = System.Drawing.SystemColors.ControlText;
            this.Izq_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Izq_button.BackgroundImage")));
            this.Izq_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Izq_button.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Izq_button.Location = new System.Drawing.Point(151, 11);
            this.Izq_button.Name = "Izq_button";
            this.Izq_button.Size = new System.Drawing.Size(75, 66);
            this.Izq_button.TabIndex = 1;
            this.Izq_button.UseVisualStyleBackColor = false;
            this.Izq_button.Click += new System.EventHandler(this.Izq_button_Click);
            // 
            // Der_button
            // 
            this.Der_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Der_button.BackgroundImage")));
            this.Der_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Der_button.Location = new System.Drawing.Point(232, 11);
            this.Der_button.Name = "Der_button";
            this.Der_button.Size = new System.Drawing.Size(75, 66);
            this.Der_button.TabIndex = 0;
            this.Der_button.UseVisualStyleBackColor = true;
            this.Der_button.Click += new System.EventHandler(this.Der_button_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.button_EPS);
            this.panel5.Controls.Add(this.button_garfield);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.button_ST);
            this.panel5.Controls.Add(this.button_SKULL);
            this.panel5.Controls.Add(this.button_OLED);
            this.panel5.Location = new System.Drawing.Point(273, 46);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(243, 171);
            this.panel5.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(136, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Animaciones";
            // 
            // button_EPS
            // 
            this.button_EPS.Location = new System.Drawing.Point(136, 98);
            this.button_EPS.Name = "button_EPS";
            this.button_EPS.Size = new System.Drawing.Size(93, 23);
            this.button_EPS.TabIndex = 8;
            this.button_EPS.Text = "EPS";
            this.button_EPS.UseVisualStyleBackColor = true;
            this.button_EPS.Click += new System.EventHandler(this.button_EPS_Click);
            // 
            // button_garfield
            // 
            this.button_garfield.Location = new System.Drawing.Point(136, 37);
            this.button_garfield.Name = "button_garfield";
            this.button_garfield.Size = new System.Drawing.Size(93, 23);
            this.button_garfield.TabIndex = 7;
            this.button_garfield.Text = "GARFIELD";
            this.button_garfield.UseVisualStyleBackColor = true;
            this.button_garfield.Click += new System.EventHandler(this.button_garfield_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(66, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "PANTALLA";
            // 
            // button_ST
            // 
            this.button_ST.Location = new System.Drawing.Point(136, 69);
            this.button_ST.Name = "button_ST";
            this.button_ST.Size = new System.Drawing.Size(93, 23);
            this.button_ST.TabIndex = 2;
            this.button_ST.Text = "ST";
            this.button_ST.UseVisualStyleBackColor = true;
            this.button_ST.Click += new System.EventHandler(this.button_ST_Click);
            // 
            // button_SKULL
            // 
            this.button_SKULL.Location = new System.Drawing.Point(136, 8);
            this.button_SKULL.Name = "button_SKULL";
            this.button_SKULL.Size = new System.Drawing.Size(93, 23);
            this.button_SKULL.TabIndex = 1;
            this.button_SKULL.Text = "SKULL";
            this.button_SKULL.UseVisualStyleBackColor = true;
            this.button_SKULL.Click += new System.EventHandler(this.button_SKULL_Click);
            // 
            // button_OLED
            // 
            this.button_OLED.Location = new System.Drawing.Point(11, 53);
            this.button_OLED.Name = "button_OLED";
            this.button_OLED.Size = new System.Drawing.Size(93, 37);
            this.button_OLED.TabIndex = 0;
            this.button_OLED.Text = "DATOS";
            this.button_OLED.UseVisualStyleBackColor = true;
            this.button_OLED.Click += new System.EventHandler(this.button_OLED_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.groupBox1);
            this.panel7.Location = new System.Drawing.Point(292, 223);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(202, 133);
            this.panel7.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "CAN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CAN_button);
            this.groupBox1.Controls.Add(this.radioButtonAB);
            this.groupBox1.Controls.Add(this.radioButtonB);
            this.groupBox1.Controls.Add(this.radioButtonA);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Modo CAN:";
            // 
            // CAN_button
            // 
            this.CAN_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CAN_button.BackgroundImage")));
            this.CAN_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CAN_button.Location = new System.Drawing.Point(100, 16);
            this.CAN_button.Name = "CAN_button";
            this.CAN_button.Size = new System.Drawing.Size(75, 68);
            this.CAN_button.TabIndex = 3;
            this.CAN_button.UseVisualStyleBackColor = true;
            this.CAN_button.Click += new System.EventHandler(this.CAN_button_Click);
            // 
            // radioButtonAB
            // 
            this.radioButtonAB.AutoSize = true;
            this.radioButtonAB.Location = new System.Drawing.Point(6, 82);
            this.radioButtonAB.Name = "radioButtonAB";
            this.radioButtonAB.Size = new System.Drawing.Size(50, 20);
            this.radioButtonAB.TabIndex = 2;
            this.radioButtonAB.TabStop = true;
            this.radioButtonAB.Text = "A/B";
            this.radioButtonAB.UseVisualStyleBackColor = true;
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Location = new System.Drawing.Point(6, 56);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(37, 20);
            this.radioButtonB.TabIndex = 1;
            this.radioButtonB.TabStop = true;
            this.radioButtonB.Text = "B";
            this.radioButtonB.UseVisualStyleBackColor = true;
            // 
            // radioButtonA
            // 
            this.radioButtonA.AutoSize = true;
            this.radioButtonA.Location = new System.Drawing.Point(6, 28);
            this.radioButtonA.Name = "radioButtonA";
            this.radioButtonA.Size = new System.Drawing.Size(37, 20);
            this.radioButtonA.TabIndex = 0;
            this.radioButtonA.TabStop = true;
            this.radioButtonA.Text = "A";
            this.radioButtonA.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_cancel.BackgroundImage")));
            this.button_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_cancel.Location = new System.Drawing.Point(700, 402);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 74);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_resume
            // 
            this.button_resume.Location = new System.Drawing.Point(837, 410);
            this.button_resume.Name = "button_resume";
            this.button_resume.Size = new System.Drawing.Size(91, 58);
            this.button_resume.TabIndex = 8;
            this.button_resume.Text = "Reanudar";
            this.button_resume.UseVisualStyleBackColor = true;
            this.button_resume.Click += new System.EventHandler(this.button_resume_Click);
            // 
            // textBox_TMP
            // 
            this.textBox_TMP.Location = new System.Drawing.Point(35, 18);
            this.textBox_TMP.Name = "textBox_TMP";
            this.textBox_TMP.Size = new System.Drawing.Size(75, 22);
            this.textBox_TMP.TabIndex = 0;
            this.textBox_TMP.Text = "300";
            this.textBox_TMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_TMP
            // 
            this.button_TMP.Location = new System.Drawing.Point(35, 61);
            this.button_TMP.Name = "button_TMP";
            this.button_TMP.Size = new System.Drawing.Size(75, 23);
            this.button_TMP.TabIndex = 1;
            this.button_TMP.Text = "TMP";
            this.button_TMP.UseVisualStyleBackColor = true;
            this.button_TMP.Click += new System.EventHandler(this.button_TMP_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(28, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 16);
            this.label14.TabIndex = 2;
            this.label14.Text = "Envio TMP";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.button_TMP);
            this.panel6.Controls.Add(this.textBox_TMP);
            this.panel6.Location = new System.Drawing.Point(314, 362);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(140, 133);
            this.panel6.TabIndex = 4;
            // 
            // Cancelar_LED
            // 
            this.Cancelar_LED.BackColor = System.Drawing.Color.Transparent;
            this.Cancelar_LED.BlinkInterval = 500;
            this.Cancelar_LED.Label = "";
            this.Cancelar_LED.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.Cancelar_LED.LedColor = System.Drawing.Color.Red;
            this.Cancelar_LED.LedSize = new System.Drawing.SizeF(10F, 10F);
            this.Cancelar_LED.Location = new System.Drawing.Point(719, 487);
            this.Cancelar_LED.Name = "Cancelar_LED";
            this.Cancelar_LED.Renderer = null;
            this.Cancelar_LED.Size = new System.Drawing.Size(20, 18);
            this.Cancelar_LED.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.Cancelar_LED.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.Cancelar_LED.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(740, 489);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "ALL ACTIONS CANCELLED";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(681, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Cancelar acciones";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(820, 383);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 16);
            this.label15.TabIndex = 12;
            this.label15.Text = "Reanudar acciones";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(971, 566);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Cancelar_LED);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_resume);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyecto Final ICI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_UART;
        private System.Windows.Forms.TextBox textBox_UART;
        private System.Windows.Forms.Label label1;
        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter_rpm;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter_servo;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter_temp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_sweep;
        private System.Windows.Forms.TextBox textBox_vel;
        private System.Windows.Forms.TextBox textBox_wait;
        private System.Windows.Forms.Button Pot_button;
        private LBSoft.IndustrialCtrls.Knobs.LBKnob lbKnob_servo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Izq_button;
        private System.Windows.Forms.Button Der_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button_ST;
        private System.Windows.Forms.Button button_SKULL;
        private System.Windows.Forms.Button button_OLED;
        private System.Windows.Forms.Panel panel7;
        private LBSoft.IndustrialCtrls.Knobs.LBKnob lbKnob_motor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CAN_button;
        private System.Windows.Forms.RadioButton radioButtonAB;
        private System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.RadioButton radioButtonA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_garfield;
        private System.Windows.Forms.Button button_resume;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LBSoft.IndustrialCtrls.Leds.LBLed Der_LED;
        private LBSoft.IndustrialCtrls.Leds.LBLed Izq_LED;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button_EPS;
        private System.Windows.Forms.TextBox textBox_TMP;
        private System.Windows.Forms.Button button_TMP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel6;
        private LBSoft.IndustrialCtrls.Leds.LBLed Cancelar_LED;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
    }
}

