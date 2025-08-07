namespace RobotAppGame
{
    public partial class StartScreenMenuControl : UserControl
    {
        public event EventHandler StartButtonClicked;

        public StartScreenMenuControl()
        {
            InitializeComponent();

            button1.Click += (s, e) => StartButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
