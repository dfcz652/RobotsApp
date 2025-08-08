namespace RobotAppGame
{
    public partial class StartScreenMenuControl : UserControl
    {
        public event EventHandler StartGameRequested;

        public StartScreenMenuControl()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartGameRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
