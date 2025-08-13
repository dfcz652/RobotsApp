namespace RobotAppGame
{
    partial class StartScreenMenuControl
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
            StartButton = new Button();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.BackColor = Color.Transparent;
            StartButton.Cursor = Cursors.Hand;
            StartButton.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.Font = new Font("Microsoft Sans Serif", 18F);
            StartButton.ForeColor = Color.FromArgb(0, 192, 0);
            StartButton.Location = new Point(474, 341);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(326, 81);
            StartButton.TabIndex = 1;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += startButton_Click;
            // 
            // StartScreenMenuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(StartButton);
            Name = "StartScreenMenuControl";
            Size = new Size(1280, 720);
            ResumeLayout(false);
        }

        #endregion

        private Button StartButton;
        private Button button2;
    }
}
