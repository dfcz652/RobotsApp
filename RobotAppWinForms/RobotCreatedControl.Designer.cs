namespace RobotAppGame
{
    partial class RobotCreatedControl
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
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 16F);
            button1.ForeColor = Color.FromArgb(255, 192, 128);
            button1.Location = new Point(293, 225);
            button1.Name = "button1";
            button1.Size = new Size(202, 50);
            button1.TabIndex = 10;
            button1.Text = "Create enemy";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 16F);
            label1.ForeColor = Color.FromArgb(255, 192, 128);
            label1.Location = new Point(74, 78);
            label1.Name = "label1";
            label1.Size = new Size(648, 37);
            label1.TabIndex = 11;
            label1.Text = "Soldier, your robot is created, now create your enemy";
            // 
            // RobotCreatedControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "RobotCreatedControl";
            Size = new Size(800, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
    }
}
