using RobotViewModels;

namespace RobotAppGame
{
    public partial class CreatingRobotScreenForm : Form
    {
        private string robotName;

        private ViewModel _viewModel;

        private InputingRobotNameControl inputingRobotNameControl;

        private ChoosingRobotPartsControl choosingRobotPartsControl;

        public CreatingRobotScreenForm(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            inputingRobotNameControl = new InputingRobotNameControl();
            choosingRobotPartsControl = new ChoosingRobotPartsControl(viewModel);
            Controls.Add(inputingRobotNameControl);
            Controls.Add(choosingRobotPartsControl);
            
            inputingRobotNameControl.RobotNameConfirmed += SaveRobotName_AndShowChoosingRobotParts;
            choosingRobotPartsControl.CreateRobotButton_Clicked += CreateRobot;
        }

        private void CreateRobot(object? sender, List<string> selectedParts)
        {
            _viewModel.CreateRobot(robotName, selectedParts[0], selectedParts[1], selectedParts[2], selectedParts[3]);
            choosingRobotPartsControl.Hide();
        }

        private void SaveRobotName_AndShowChoosingRobotParts(object sender, string name)
        {
            robotName = name;
            inputingRobotNameControl.Hide();
            choosingRobotPartsControl.Show();
        }
    }
}
