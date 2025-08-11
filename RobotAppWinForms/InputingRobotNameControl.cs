namespace RobotAppGame
{
    public partial class InputingRobotNameControl : UserControl
    {
        public event EventHandler<string> RobotNameConfirmed;

        public InputingRobotNameControl()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            RobotNameConfirmed.Invoke(this, textBox1.Text);
        }

        private void AcceptButton_MouseLeave(object sender, EventArgs e)
        {
            AcceptButton.BackColor = Color.Blue;//подумати як можна обійтись без копіпастів стилів
            AcceptButton.ForeColor = Color.Black;
            AcceptButton.FlatAppearance.BorderColor = Color.White;
            AcceptButton.FlatAppearance.BorderSize = 3;
        }

        private void AcceptButton_MouseEnter(object sender, EventArgs e)
        {
            AcceptButton.BackColor = Color.LightGreen;
            AcceptButton.ForeColor = Color.Black;
            AcceptButton.FlatAppearance.BorderColor = Color.DarkGreen;
            AcceptButton.FlatAppearance.BorderSize = 3;
        }
    }
}