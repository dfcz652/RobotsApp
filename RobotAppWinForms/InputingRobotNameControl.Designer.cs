namespace RobotAppGame
{
    partial class InputingRobotNameControl
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
            label1 = new Label();
            AcceptButton = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 16F);
            label1.ForeColor = Color.FromArgb(255, 224, 192);
            label1.Location = new Point(326, 117);
            label1.Name = "label1";
            label1.Size = new Size(560, 37);
            label1.TabIndex = 1;
            label1.Text = "Need to create a new machine for you, soldier";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // AcceptButton
            // 
            AcceptButton.BackColor = Color.Blue;
            AcceptButton.Cursor = Cursors.Hand;
            AcceptButton.FlatAppearance.BorderColor = Color.Black;
            AcceptButton.FlatAppearance.BorderSize = 3;
            AcceptButton.Font = new Font("Segoe UI", 16F);
            AcceptButton.ForeColor = Color.LightSteelBlue;
            AcceptButton.Location = new Point(518, 449);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(237, 80);
            AcceptButton.TabIndex = 6;
            AcceptButton.Text = "Accept";
            AcceptButton.UseVisualStyleBackColor = false;
            AcceptButton.Click += AcceptButton_Click;
            AcceptButton.MouseEnter += AcceptButton_MouseEnter;
            AcceptButton.MouseLeave += AcceptButton_MouseLeave;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Highlight;
            textBox1.Font = new Font("Segoe UI", 16F);
            textBox1.ForeColor = Color.Black;
            textBox1.Location = new Point(518, 272);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(237, 43);
            textBox1.TabIndex = 5;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 16F);
            label2.ForeColor = Color.FromArgb(255, 224, 192);
            label2.Location = new Point(468, 198);
            label2.Name = "label2";
            label2.Size = new Size(331, 37);
            label2.TabIndex = 4;
            label2.Text = "Give your machine a name";
            // 
            // InputingRobotNameControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(AcceptButton);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InputingRobotNameControl";
            Size = new Size(1280, 720);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button AcceptButton;
        private TextBox textBox1;
        private Label label2;
    }
}
