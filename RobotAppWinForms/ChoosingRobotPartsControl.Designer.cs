namespace RobotAppGame
{
    partial class ChoosingRobotPartsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoosingRobotPartsControl));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            createRobotButton = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            characteristicsToolTip = new ToolTip(components);
            armsListBox = new ListBox();
            bodiesListBox = new ListBox();
            coresListBox = new ListBox();
            legsListBox = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 16F);
            label1.ForeColor = Color.FromArgb(255, 192, 128);
            label1.Location = new Point(338, 0);
            label1.Name = "label1";
            label1.Size = new Size(584, 37);
            label1.TabIndex = 0;
            label1.Text = "Need to choose your robot parts. Choose wisely";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 16F);
            label2.ForeColor = Color.FromArgb(255, 192, 128);
            label2.Location = new Point(244, 81);
            label2.Name = "label2";
            label2.Size = new Size(77, 37);
            label2.TabIndex = 1;
            label2.Text = "Arms";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 16F);
            label3.ForeColor = Color.FromArgb(255, 192, 128);
            label3.Location = new Point(885, 90);
            label3.Name = "label3";
            label3.Size = new Size(96, 37);
            label3.TabIndex = 3;
            label3.Text = "Bodies";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI", 16F);
            label4.ForeColor = Color.FromArgb(255, 192, 128);
            label4.Location = new Point(908, 367);
            label4.Name = "label4";
            label4.Size = new Size(71, 37);
            label4.TabIndex = 5;
            label4.Text = "Legs";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI", 16F);
            label5.ForeColor = Color.FromArgb(255, 192, 128);
            label5.Location = new Point(244, 367);
            label5.Name = "label5";
            label5.Size = new Size(84, 37);
            label5.TabIndex = 6;
            label5.Text = "Cores";
            // 
            // createRobotButton
            // 
            createRobotButton.BackColor = Color.Transparent;
            createRobotButton.Cursor = Cursors.Hand;
            createRobotButton.FlatAppearance.BorderColor = Color.Black;
            createRobotButton.FlatAppearance.BorderSize = 0;
            createRobotButton.FlatStyle = FlatStyle.Flat;
            createRobotButton.Font = new Font("Segoe UI", 16F);
            createRobotButton.ForeColor = Color.FromArgb(255, 192, 128);
            createRobotButton.Location = new Point(544, 539);
            createRobotButton.Name = "createRobotButton";
            createRobotButton.Size = new Size(179, 50);
            createRobotButton.TabIndex = 9;
            createRobotButton.Text = "Create robot";
            createRobotButton.UseVisualStyleBackColor = false;
            createRobotButton.Click += CreateRobotButton_Click;
            createRobotButton.MouseEnter += CreateRobotButton_MouseEnter;
            createRobotButton.MouseLeave += CreateRobotButton_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(322, 81);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 63);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(974, 81);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 63);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(322, 367);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(51, 49);
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(974, 355);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(50, 49);
            pictureBox4.TabIndex = 14;
            pictureBox4.TabStop = false;
            // 
            // characteristicsToolTip
            // 
            characteristicsToolTip.OwnerDraw = true;
            characteristicsToolTip.Draw += characteristicsToolTip_Draw;
            // 
            // armsListBox
            // 
            armsListBox.FormattingEnabled = true;
            armsListBox.Location = new Point(176, 150);
            armsListBox.Name = "armsListBox";
            armsListBox.Size = new Size(260, 144);
            armsListBox.TabIndex = 19;
            armsListBox.MouseMove += armsListBox_MouseMove;
            // 
            // bodiesListBox
            // 
            bodiesListBox.FormattingEnabled = true;
            bodiesListBox.Location = new Point(831, 150);
            bodiesListBox.Name = "bodiesListBox";
            bodiesListBox.Size = new Size(242, 144);
            bodiesListBox.TabIndex = 20;
            bodiesListBox.MouseMove += bodiesListBox_MouseMove;
            // 
            // coresListBox
            // 
            coresListBox.FormattingEnabled = true;
            coresListBox.Location = new Point(176, 422);
            coresListBox.Name = "coresListBox";
            coresListBox.Size = new Size(260, 144);
            coresListBox.TabIndex = 21;
            coresListBox.MouseMove += coresListBox_MouseMove;
            // 
            // legsListBox
            // 
            legsListBox.FormattingEnabled = true;
            legsListBox.Location = new Point(831, 422);
            legsListBox.Name = "legsListBox";
            legsListBox.Size = new Size(242, 144);
            legsListBox.TabIndex = 22;
            legsListBox.MouseMove += legsListBox_MouseMove;
            // 
            // ChoosingRobotPartsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(legsListBox);
            Controls.Add(coresListBox);
            Controls.Add(bodiesListBox);
            Controls.Add(armsListBox);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(createRobotButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ChoosingRobotPartsControl";
            Size = new Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button createRobotButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private ToolTip characteristicsToolTip;
        private ListBox armsListBox;
        private ListBox bodiesListBox;
        private ListBox coresListBox;
        private ListBox legsListBox;
    }
}
