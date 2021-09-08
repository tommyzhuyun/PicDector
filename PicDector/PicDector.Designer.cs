
namespace PicDector
{
    partial class PicDector
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RangerCheck = new System.Windows.Forms.RadioButton();
            this.ThresholdCheck = new System.Windows.Forms.RadioButton();
            this.NoneCheck = new System.Windows.Forms.RadioButton();
            this.OnTop = new System.Windows.Forms.CheckBox();
            this.Stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BlueCheck = new System.Windows.Forms.RadioButton();
            this.GreenCheck = new System.Windows.Forms.RadioButton();
            this.RedCheck = new System.Windows.Forms.RadioButton();
            this.BtnCheck = new System.Windows.Forms.RadioButton();
            this.ValCheck = new System.Windows.Forms.RadioButton();
            this.SatCheck = new System.Windows.Forms.RadioButton();
            this.HueCheck = new System.Windows.Forms.RadioButton();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ColorFilter = new System.Windows.Forms.RadioButton();
            this.ColorNormal = new System.Windows.Forms.RadioButton();
            this.ColorInversion = new System.Windows.Forms.CheckBox();
            this.ColorLine = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Chiruda = new System.Windows.Forms.Label();
            this.Hint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorLine)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "选择区域";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Start_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 535);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(360, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 128;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.RangerCheck);
            this.panel1.Controls.Add(this.ThresholdCheck);
            this.panel1.Controls.Add(this.NoneCheck);
            this.panel1.Location = new System.Drawing.Point(12, 378);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 71);
            this.panel1.TabIndex = 5;
            // 
            // RangerCheck
            // 
            this.RangerCheck.AutoSize = true;
            this.RangerCheck.Location = new System.Drawing.Point(3, 47);
            this.RangerCheck.Name = "RangerCheck";
            this.RangerCheck.Size = new System.Drawing.Size(47, 16);
            this.RangerCheck.TabIndex = 2;
            this.RangerCheck.Text = "范围";
            this.RangerCheck.UseVisualStyleBackColor = true;
            // 
            // ThresholdCheck
            // 
            this.ThresholdCheck.AutoSize = true;
            this.ThresholdCheck.Location = new System.Drawing.Point(3, 25);
            this.ThresholdCheck.Name = "ThresholdCheck";
            this.ThresholdCheck.Size = new System.Drawing.Size(47, 16);
            this.ThresholdCheck.TabIndex = 1;
            this.ThresholdCheck.Text = "阈值";
            this.ThresholdCheck.UseVisualStyleBackColor = true;
            // 
            // NoneCheck
            // 
            this.NoneCheck.AutoSize = true;
            this.NoneCheck.Checked = true;
            this.NoneCheck.Location = new System.Drawing.Point(3, 3);
            this.NoneCheck.Name = "NoneCheck";
            this.NoneCheck.Size = new System.Drawing.Size(47, 16);
            this.NoneCheck.TabIndex = 0;
            this.NoneCheck.TabStop = true;
            this.NoneCheck.Text = "原始";
            this.NoneCheck.UseVisualStyleBackColor = true;
            // 
            // OnTop
            // 
            this.OnTop.AutoSize = true;
            this.OnTop.Checked = true;
            this.OnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnTop.Location = new System.Drawing.Point(229, 416);
            this.OnTop.Name = "OnTop";
            this.OnTop.Size = new System.Drawing.Size(57, 16);
            this.OnTop.TabIndex = 4;
            this.OnTop.Text = "OnTop";
            this.OnTop.UseVisualStyleBackColor = true;
            this.OnTop.CheckedChanged += new System.EventHandler(this.OnTop_CheckedChanged);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(289, 409);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(83, 28);
            this.Stop.TabIndex = 5;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "0FPS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.BlueCheck);
            this.panel2.Controls.Add(this.GreenCheck);
            this.panel2.Controls.Add(this.RedCheck);
            this.panel2.Controls.Add(this.BtnCheck);
            this.panel2.Controls.Add(this.ValCheck);
            this.panel2.Controls.Add(this.SatCheck);
            this.panel2.Controls.Add(this.HueCheck);
            this.panel2.Location = new System.Drawing.Point(131, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 156);
            this.panel2.TabIndex = 6;
            // 
            // BlueCheck
            // 
            this.BlueCheck.AutoSize = true;
            this.BlueCheck.Location = new System.Drawing.Point(3, 135);
            this.BlueCheck.Name = "BlueCheck";
            this.BlueCheck.Size = new System.Drawing.Size(46, 16);
            this.BlueCheck.TabIndex = 6;
            this.BlueCheck.Text = "Blue";
            this.BlueCheck.UseVisualStyleBackColor = true;
            this.BlueCheck.CheckedChanged += new System.EventHandler(this.ChannelCheck_CheckedChanged);
            // 
            // GreenCheck
            // 
            this.GreenCheck.AutoSize = true;
            this.GreenCheck.Location = new System.Drawing.Point(3, 113);
            this.GreenCheck.Name = "GreenCheck";
            this.GreenCheck.Size = new System.Drawing.Size(53, 16);
            this.GreenCheck.TabIndex = 5;
            this.GreenCheck.Text = "Green";
            this.GreenCheck.UseVisualStyleBackColor = true;
            this.GreenCheck.CheckedChanged += new System.EventHandler(this.ChannelCheck_CheckedChanged);
            // 
            // RedCheck
            // 
            this.RedCheck.AutoSize = true;
            this.RedCheck.Location = new System.Drawing.Point(3, 91);
            this.RedCheck.Name = "RedCheck";
            this.RedCheck.Size = new System.Drawing.Size(43, 16);
            this.RedCheck.TabIndex = 4;
            this.RedCheck.Text = "Red";
            this.RedCheck.UseVisualStyleBackColor = true;
            this.RedCheck.CheckedChanged += new System.EventHandler(this.ChannelCheck_CheckedChanged);
            // 
            // BtnCheck
            // 
            this.BtnCheck.AutoSize = true;
            this.BtnCheck.Checked = true;
            this.BtnCheck.Location = new System.Drawing.Point(3, 69);
            this.BtnCheck.Name = "BtnCheck";
            this.BtnCheck.Size = new System.Drawing.Size(78, 16);
            this.BtnCheck.TabIndex = 3;
            this.BtnCheck.TabStop = true;
            this.BtnCheck.Text = "Brightness";
            this.BtnCheck.UseVisualStyleBackColor = true;
            this.BtnCheck.CheckedChanged += new System.EventHandler(this.ChannelCheck_CheckedChanged);
            // 
            // ValCheck
            // 
            this.ValCheck.AutoSize = true;
            this.ValCheck.Location = new System.Drawing.Point(3, 47);
            this.ValCheck.Name = "ValCheck";
            this.ValCheck.Size = new System.Drawing.Size(52, 16);
            this.ValCheck.TabIndex = 2;
            this.ValCheck.Text = "Value";
            this.ValCheck.UseVisualStyleBackColor = true;
            this.ValCheck.CheckedChanged += new System.EventHandler(this.ChannelCheck_CheckedChanged);
            // 
            // SatCheck
            // 
            this.SatCheck.AutoSize = true;
            this.SatCheck.Location = new System.Drawing.Point(3, 25);
            this.SatCheck.Name = "SatCheck";
            this.SatCheck.Size = new System.Drawing.Size(75, 16);
            this.SatCheck.TabIndex = 1;
            this.SatCheck.Text = "Saturation";
            this.SatCheck.UseVisualStyleBackColor = true;
            this.SatCheck.CheckedChanged += new System.EventHandler(this.ChannelCheck_CheckedChanged);
            // 
            // HueCheck
            // 
            this.HueCheck.AutoSize = true;
            this.HueCheck.Location = new System.Drawing.Point(3, 3);
            this.HueCheck.Name = "HueCheck";
            this.HueCheck.Size = new System.Drawing.Size(43, 16);
            this.HueCheck.TabIndex = 0;
            this.HueCheck.Text = "Hue";
            this.HueCheck.UseVisualStyleBackColor = true;
            this.HueCheck.CheckedChanged += new System.EventHandler(this.ChannelCheck_CheckedChanged);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(12, 586);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(360, 45);
            this.trackBar2.TabIndex = 8;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar2.Value = 128;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.ColorFilter);
            this.panel3.Controls.Add(this.ColorInversion);
            this.panel3.Controls.Add(this.ColorNormal);
            this.panel3.Location = new System.Drawing.Point(12, 463);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 71);
            this.panel3.TabIndex = 10;
            // 
            // ColorFilter
            // 
            this.ColorFilter.AutoSize = true;
            this.ColorFilter.Location = new System.Drawing.Point(3, 47);
            this.ColorFilter.Name = "ColorFilter";
            this.ColorFilter.Size = new System.Drawing.Size(59, 16);
            this.ColorFilter.TabIndex = 2;
            this.ColorFilter.Text = "仅过滤";
            this.ColorFilter.UseVisualStyleBackColor = true;
            // 
            // ColorNormal
            // 
            this.ColorNormal.AutoSize = true;
            this.ColorNormal.Checked = true;
            this.ColorNormal.Location = new System.Drawing.Point(3, 25);
            this.ColorNormal.Name = "ColorNormal";
            this.ColorNormal.Size = new System.Drawing.Size(59, 16);
            this.ColorNormal.TabIndex = 1;
            this.ColorNormal.TabStop = true;
            this.ColorNormal.Text = "黑白色";
            this.ColorNormal.UseVisualStyleBackColor = true;
            // 
            // ColorInversion
            // 
            this.ColorInversion.AutoSize = true;
            this.ColorInversion.Location = new System.Drawing.Point(3, 3);
            this.ColorInversion.Name = "ColorInversion";
            this.ColorInversion.Size = new System.Drawing.Size(72, 16);
            this.ColorInversion.TabIndex = 11;
            this.ColorInversion.Text = "范围反转";
            this.ColorInversion.UseVisualStyleBackColor = true;
            // 
            // ColorLine
            // 
            this.ColorLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ColorLine.Location = new System.Drawing.Point(12, 573);
            this.ColorLine.Name = "ColorLine";
            this.ColorLine.Size = new System.Drawing.Size(360, 16);
            this.ColorLine.TabIndex = 12;
            this.ColorLine.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(227, 512);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(56, 19);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(315, 512);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(56, 19);
            this.textBox2.TabIndex = 14;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Chiruda
            // 
            this.Chiruda.AutoSize = true;
            this.Chiruda.Location = new System.Drawing.Point(292, 515);
            this.Chiruda.Name = "Chiruda";
            this.Chiruda.Size = new System.Drawing.Size(17, 12);
            this.Chiruda.TabIndex = 15;
            this.Chiruda.Text = "～";
            // 
            // Hint
            // 
            this.Hint.AutoSize = true;
            this.Hint.Location = new System.Drawing.Point(270, 494);
            this.Hint.Name = "Hint";
            this.Hint.Size = new System.Drawing.Size(59, 12);
            this.Hint.TabIndex = 16;
            this.Hint.Text = "阈值/范围";
            // 
            // PicDector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 643);
            this.Controls.Add(this.Hint);
            this.Controls.Add(this.Chiruda);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ColorLine);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.OnTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "PicDector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PicDector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RangerCheck;
        private System.Windows.Forms.RadioButton ThresholdCheck;
        private System.Windows.Forms.RadioButton NoneCheck;
        private System.Windows.Forms.CheckBox OnTop;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton BlueCheck;
        private System.Windows.Forms.RadioButton GreenCheck;
        private System.Windows.Forms.RadioButton RedCheck;
        private System.Windows.Forms.RadioButton BtnCheck;
        private System.Windows.Forms.RadioButton ValCheck;
        private System.Windows.Forms.RadioButton SatCheck;
        private System.Windows.Forms.RadioButton HueCheck;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton ColorFilter;
        private System.Windows.Forms.RadioButton ColorNormal;
        private System.Windows.Forms.CheckBox ColorInversion;
        private System.Windows.Forms.PictureBox ColorLine;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Chiruda;
        private System.Windows.Forms.Label Hint;
    }
}

