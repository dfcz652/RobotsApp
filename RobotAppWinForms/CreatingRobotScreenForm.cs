using RobotViewModels;

namespace RobotAppGame
{
    public partial class CreatingRobotScreenForm : Form
    {
        private string _robotName;

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
            
            inputingRobotNameControl.RobotNameConfirmed += CreateAndSaveEmptyRobot_AndShowChoosingRobotParts;
            
            choosingRobotPartsControl.RobotCreated += CreateRobot;
        }

        private void CreateRobot(object? sender, List<string> selectedParts)
        {
            _viewModel.UpdateRobot(existingRobotName: _robotName, arms: selectedParts[0], body: selectedParts[1], core: selectedParts[2], legs: selectedParts[3]);
            choosingRobotPartsControl.Hide();
        }

        private void CreateAndSaveEmptyRobot_AndShowChoosingRobotParts(object sender, string name)
        {
            _robotName = name;
            _viewModel.CreateEmptyRobot(name);
            inputingRobotNameControl.Hide();
            choosingRobotPartsControl.SetRobotName(name);
            choosingRobotPartsControl.Show();
        }
    }
}
