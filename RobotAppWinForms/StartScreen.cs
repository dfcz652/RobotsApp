using RobotAppGame;
using RobotViewModels;

namespace RobotAppUIWinForms
{
    public partial class StartScreen : Form
    {
        private readonly ViewModel _viewModel;

        private StartScreenMenuControl startScreenMenuControl;

        public StartScreen(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            startScreenMenuControl = new StartScreenMenuControl();
            startScreenMenuControl.Dock = DockStyle.Fill;
            Controls.Add(startScreenMenuControl);

            startScreenMenuControl.StartButtonClicked += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreatingRobotScreen creatingRobotScreen = new(_viewModel);
            creatingRobotScreen.Show();
            Hide();
        }
    }
}
