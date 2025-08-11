using RobotAppGame;
using RobotViewModels;

namespace RobotAppUIWinForms
{
    public partial class StartScreenForm : Form
    {
        private readonly ViewModel _viewModel;

        private StartScreenMenuControl startScreenMenuControl;

        public StartScreenForm(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            startScreenMenuControl = new StartScreenMenuControl();
            Controls.Add(startScreenMenuControl);

            startScreenMenuControl.StartGameRequested += StartScreenMenu_Hide;
        }

        private void StartScreenMenu_Hide(object sender, EventArgs e)
        {
            Controls.Remove(startScreenMenuControl);
            startScreenMenuControl.Dispose();
            Hide();
            CreatingRobotScreenForm creatingRobotScreen = new(_viewModel);
            creatingRobotScreen.Show();
        }
    }
}
