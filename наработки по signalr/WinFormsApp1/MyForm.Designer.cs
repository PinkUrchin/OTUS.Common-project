namespace Draw
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            colorDialog1 = new ColorDialog();
            colorlbl = new Label();
            numericUpDown1 = new NumericUpDown();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            button1 = new Button();
            button2 = new Button();
            radioButton4 = new RadioButton();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1640, 1186);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // colorlbl
            // 
            colorlbl.BackColor = Color.Black;
            colorlbl.BorderStyle = BorderStyle.FixedSingle;
            colorlbl.Location = new Point(6, 9);
            colorlbl.Margin = new Padding(4, 0, 4, 0);
            colorlbl.Name = "colorlbl";
            colorlbl.Size = new Size(59, 56);
            colorlbl.TabIndex = 1;
            colorlbl.Click += colorlbl_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(463, 14);
            numericUpDown1.Margin = new Padding(4, 5, 4, 5);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(100, 27);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // radioButton1
            // 
            radioButton1.Appearance = Appearance.Button;
            radioButton1.AutoSize = true;
            radioButton1.Image = (Image)resources.GetObject("radioButton1.Image");
            radioButton1.Location = new Point(72, 9);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(56, 56);
            radioButton1.TabIndex = 7;
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.Appearance = Appearance.Button;
            radioButton2.AutoSize = true;
            radioButton2.Image = (Image)resources.GetObject("radioButton2.Image");
            radioButton2.Location = new Point(134, 9);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(56, 56);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.Appearance = Appearance.Button;
            radioButton3.AutoSize = true;
            radioButton3.Image = (Image)resources.GetObject("radioButton3.Image");
            radioButton3.Location = new Point(196, 9);
            radioButton3.Margin = new Padding(3, 4, 3, 4);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(56, 56);
            radioButton3.TabIndex = 9;
            radioButton3.TabStop = true;
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(323, 10);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(59, 56);
            button1.TabIndex = 10;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(388, 10);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(59, 56);
            button2.TabIndex = 11;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // radioButton4
            // 
            radioButton4.Appearance = Appearance.Button;
            radioButton4.AutoSize = true;
            radioButton4.Checked = true;
            radioButton4.Image = (Image)resources.GetObject("radioButton4.Image");
            radioButton4.Location = new Point(261, 9);
            radioButton4.Margin = new Padding(3, 4, 3, 4);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(56, 56);
            radioButton4.TabIndex = 12;
            radioButton4.TabStop = true;
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(colorlbl);
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(radioButton3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1640, 79);
            panel1.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1640, 1186);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(378, 428);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OnlinePaint";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ColorDialog colorDialog1;
        private Label colorlbl;
        private NumericUpDown numericUpDown1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Button button1;
        private Button button2;
        private RadioButton radioButton4;
        private Panel panel1;
    }
}

