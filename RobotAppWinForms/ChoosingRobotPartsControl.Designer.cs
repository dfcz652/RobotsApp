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
            armsComboBox = new ComboBox();
            pictureBox4 = new PictureBox();
            bodiesComboBox = new ComboBox();
            coresComboBox = new ComboBox();
            legsComboBox = new ComboBox();
            partsRichTextBox = new RichTextBox();
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
            label1.Location = new Point(108, 0);
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
            label2.Location = new Point(108, 66);
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
            label3.Location = new Point(596, 66);
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
            label4.Location = new Point(596, 251);
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
            label5.Location = new Point(101, 251);
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
            createRobotButton.Location = new Point(326, 284);
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
            pictureBox1.Location = new Point(176, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 63);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(687, 55);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 63);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(176, 251);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(51, 49);
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // armsComboBox
            // 
            armsComboBox.FormattingEnabled = true;
            armsComboBox.Location = new Point(91, 124);
            armsComboBox.Name = "armsComboBox";
            armsComboBox.Size = new Size(185, 28);
            armsComboBox.TabIndex = 13;
            armsComboBox.SelectedIndexChanged += comboBoxParts_SelectedIndexChanged;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(686, 251);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(50, 49);
            pictureBox4.TabIndex = 14;
            pictureBox4.TabStop = false;
            // 
            // bodiesComboBox
            // 
            bodiesComboBox.FormattingEnabled = true;
            bodiesComboBox.Location = new Point(551, 124);
            bodiesComboBox.Name = "bodiesComboBox";
            bodiesComboBox.Size = new Size(185, 28);
            bodiesComboBox.TabIndex = 15;
            bodiesComboBox.SelectedIndexChanged += comboBoxParts_SelectedIndexChanged;
            // 
            // coresComboBox
            // 
            coresComboBox.FormattingEnabled = true;
            coresComboBox.Location = new Point(91, 306);
            coresComboBox.Name = "coresComboBox";
            coresComboBox.Size = new Size(185, 28);
            coresComboBox.TabIndex = 16;
            coresComboBox.SelectedIndexChanged += comboBoxParts_SelectedIndexChanged;
            // 
            // legsComboBox
            // 
            legsComboBox.FormattingEnabled = true;
            legsComboBox.Location = new Point(551, 306);
            legsComboBox.Name = "legsComboBox";
            legsComboBox.Size = new Size(185, 28);
            legsComboBox.TabIndex = 17;
            legsComboBox.SelectedIndexChanged += comboBoxParts_SelectedIndexChanged;
            // 
            // partsRichTextBox
            // 
            partsRichTextBox.Location = new Point(317, 77);
            partsRichTextBox.Name = "partsRichTextBox";
            partsRichTextBox.Size = new Size(197, 134);
            partsRichTextBox.TabIndex = 18;
            partsRichTextBox.Text = "";
            // 
            // ChoosingRobotPartsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(partsRichTextBox);
            Controls.Add(legsComboBox);
            Controls.Add(coresComboBox);
            Controls.Add(bodiesComboBox);
            Controls.Add(pictureBox4);
            Controls.Add(armsComboBox);
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
            Size = new Size(763, 468);
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
        private ComboBox armsComboBox;
        private PictureBox pictureBox4;
        private ComboBox bodiesComboBox;
        private ComboBox coresComboBox;
        private ComboBox legsComboBox;
        private RichTextBox partsRichTextBox;
    }
}
