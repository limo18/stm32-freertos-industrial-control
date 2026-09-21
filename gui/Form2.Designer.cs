namespace ProyectoFinal_ICI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea22 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea23 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea24 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_temp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_servo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_motor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbDigitalMeter_temp_remoto = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter_servo_remoto = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbAnalogMeter_remoto = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.Der_LED_remoto = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.Izq_LED_remoto = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_temp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_servo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_motor)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_temp
            // 
            this.chart_temp.BackColor = System.Drawing.Color.Peru;
            chartArea22.AxisX.Interval = 10D;
            chartArea22.AxisX.Maximum = 50D;
            chartArea22.AxisX.Minimum = 0D;
            chartArea22.AxisX.Title = "Tiempo(s)";
            chartArea22.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea22.AxisY.Title = "Temperatura (ºC)";
            chartArea22.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea22.BackColor = System.Drawing.Color.White;
            chartArea22.Name = "ChartArea1";
            chartArea22.ShadowColor = System.Drawing.Color.Silver;
            this.chart_temp.ChartAreas.Add(chartArea22);
            this.chart_temp.Location = new System.Drawing.Point(12, 33);
            this.chart_temp.Name = "chart_temp";
            this.chart_temp.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series22.ChartArea = "ChartArea1";
            series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series22.Name = "Temp";
            this.chart_temp.Series.Add(series22);
            this.chart_temp.Size = new System.Drawing.Size(291, 272);
            this.chart_temp.TabIndex = 0;
            this.chart_temp.Text = "Temperatura";
            // 
            // chart_servo
            // 
            this.chart_servo.BackColor = System.Drawing.Color.Khaki;
            chartArea23.AxisX.Interval = 10D;
            chartArea23.AxisX.Maximum = 50D;
            chartArea23.AxisX.Minimum = 0D;
            chartArea23.AxisX.Title = "Tiempo(s)";
            chartArea23.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea23.AxisY.Title = "Grados";
            chartArea23.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea23.Name = "ChartArea1";
            this.chart_servo.ChartAreas.Add(chartArea23);
            this.chart_servo.Location = new System.Drawing.Point(309, 33);
            this.chart_servo.Name = "chart_servo";
            series23.ChartArea = "ChartArea1";
            series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series23.Name = "Servo";
            this.chart_servo.Series.Add(series23);
            this.chart_servo.Size = new System.Drawing.Size(291, 272);
            this.chart_servo.TabIndex = 1;
            this.chart_servo.Text = "chart2";
            // 
            // chart_motor
            // 
            this.chart_motor.BackColor = System.Drawing.Color.Salmon;
            chartArea24.AxisX.Interval = 10D;
            chartArea24.AxisX.Maximum = 50D;
            chartArea24.AxisX.Minimum = 0D;
            chartArea24.AxisX.Title = "Tiempo(s)";
            chartArea24.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea24.AxisY.Title = "RPM";
            chartArea24.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea24.Name = "ChartArea1";
            this.chart_motor.ChartAreas.Add(chartArea24);
            this.chart_motor.Location = new System.Drawing.Point(606, 33);
            this.chart_motor.Name = "chart_motor";
            this.chart_motor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series24.ChartArea = "ChartArea1";
            series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series24.Name = "RPM";
            this.chart_motor.Series.Add(series24);
            this.chart_motor.Size = new System.Drawing.Size(291, 272);
            this.chart_motor.TabIndex = 2;
            this.chart_motor.Text = "chart3";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbDigitalMeter_temp_remoto
            // 
            this.lbDigitalMeter_temp_remoto.BackColor = System.Drawing.Color.Transparent;
            this.lbDigitalMeter_temp_remoto.Format = "000.00";
            this.lbDigitalMeter_temp_remoto.Location = new System.Drawing.Point(112, 382);
            this.lbDigitalMeter_temp_remoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigitalMeter_temp_remoto.Name = "lbDigitalMeter_temp_remoto";
            this.lbDigitalMeter_temp_remoto.Renderer = null;
            this.lbDigitalMeter_temp_remoto.Signed = false;
            this.lbDigitalMeter_temp_remoto.Size = new System.Drawing.Size(132, 59);
            this.lbDigitalMeter_temp_remoto.TabIndex = 8;
            this.lbDigitalMeter_temp_remoto.Value = 0D;
            // 
            // lbDigitalMeter_servo_remoto
            // 
            this.lbDigitalMeter_servo_remoto.BackColor = System.Drawing.Color.Transparent;
            this.lbDigitalMeter_servo_remoto.Format = "00";
            this.lbDigitalMeter_servo_remoto.Location = new System.Drawing.Point(442, 382);
            this.lbDigitalMeter_servo_remoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDigitalMeter_servo_remoto.Name = "lbDigitalMeter_servo_remoto";
            this.lbDigitalMeter_servo_remoto.Renderer = null;
            this.lbDigitalMeter_servo_remoto.Signed = false;
            this.lbDigitalMeter_servo_remoto.Size = new System.Drawing.Size(64, 59);
            this.lbDigitalMeter_servo_remoto.TabIndex = 9;
            this.lbDigitalMeter_servo_remoto.Value = 0D;
            // 
            // lbAnalogMeter_remoto
            // 
            this.lbAnalogMeter_remoto.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter_remoto.BodyColor = System.Drawing.Color.Red;
            this.lbAnalogMeter_remoto.Location = new System.Drawing.Point(688, 342);
            this.lbAnalogMeter_remoto.MaxValue = 14D;
            this.lbAnalogMeter_remoto.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter_remoto.MinValue = 0D;
            this.lbAnalogMeter_remoto.Name = "lbAnalogMeter_remoto";
            this.lbAnalogMeter_remoto.NeedleColor = System.Drawing.Color.Yellow;
            this.lbAnalogMeter_remoto.Renderer = null;
            this.lbAnalogMeter_remoto.ScaleColor = System.Drawing.Color.White;
            this.lbAnalogMeter_remoto.ScaleDivisions = 14;
            this.lbAnalogMeter_remoto.ScaleSubDivisions = 10;
            this.lbAnalogMeter_remoto.Size = new System.Drawing.Size(170, 152);
            this.lbAnalogMeter_remoto.TabIndex = 10;
            this.lbAnalogMeter_remoto.Value = 0D;
            this.lbAnalogMeter_remoto.ViewGlass = false;
            // 
            // Der_LED_remoto
            // 
            this.Der_LED_remoto.BackColor = System.Drawing.Color.Transparent;
            this.Der_LED_remoto.BlinkInterval = 500;
            this.Der_LED_remoto.Label = "Der";
            this.Der_LED_remoto.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.Der_LED_remoto.LedColor = System.Drawing.Color.LimeGreen;
            this.Der_LED_remoto.LedSize = new System.Drawing.SizeF(10F, 10F);
            this.Der_LED_remoto.Location = new System.Drawing.Point(825, 464);
            this.Der_LED_remoto.Name = "Der_LED_remoto";
            this.Der_LED_remoto.Renderer = null;
            this.Der_LED_remoto.Size = new System.Drawing.Size(33, 30);
            this.Der_LED_remoto.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.Der_LED_remoto.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.Der_LED_remoto.TabIndex = 11;
            // 
            // Izq_LED_remoto
            // 
            this.Izq_LED_remoto.BackColor = System.Drawing.Color.Transparent;
            this.Izq_LED_remoto.BlinkInterval = 0;
            this.Izq_LED_remoto.Label = "Izq";
            this.Izq_LED_remoto.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.Izq_LED_remoto.LedColor = System.Drawing.Color.LimeGreen;
            this.Izq_LED_remoto.LedSize = new System.Drawing.SizeF(10F, 10F);
            this.Izq_LED_remoto.Location = new System.Drawing.Point(666, 465);
            this.Izq_LED_remoto.Name = "Izq_LED_remoto";
            this.Izq_LED_remoto.Renderer = null;
            this.Izq_LED_remoto.Size = new System.Drawing.Size(40, 30);
            this.Izq_LED_remoto.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.Izq_LED_remoto.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.Izq_LED_remoto.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(109, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Temperatura";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(437, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Servo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(737, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "RPM";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 577);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Izq_LED_remoto);
            this.Controls.Add(this.Der_LED_remoto);
            this.Controls.Add(this.lbAnalogMeter_remoto);
            this.Controls.Add(this.lbDigitalMeter_servo_remoto);
            this.Controls.Add(this.lbDigitalMeter_temp_remoto);
            this.Controls.Add(this.chart_motor);
            this.Controls.Add(this.chart_servo);
            this.Controls.Add(this.chart_temp);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos Remoto";
            ((System.ComponentModel.ISupportInitialize)(this.chart_temp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_servo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_motor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_temp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_servo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_motor;
        private System.Windows.Forms.Timer timer1;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter_temp_remoto;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter_servo_remoto;
        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter_remoto;
        private LBSoft.IndustrialCtrls.Leds.LBLed Der_LED_remoto;
        private LBSoft.IndustrialCtrls.Leds.LBLed Izq_LED_remoto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}