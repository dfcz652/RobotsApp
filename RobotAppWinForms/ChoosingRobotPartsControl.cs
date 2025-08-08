using RobotViewModels;

namespace RobotAppGame
{
    public partial class ChoosingRobotPartsControl : UserControl
    {
        public event EventHandler<List<string>> CreateRobotButton_Clicked;

        private ViewModel _viewModel;

        public ChoosingRobotPartsControl(ViewModel viewModel)
        {
            InitializeComponent();
            FillPartsLists();
            _viewModel = viewModel;
        }

        private void FillPartsLists()
        {
            armsComboBox.Items.AddRange(_viewModel.ExistingArms.ToArray());
            bodiesComboBox.Items.AddRange(_viewModel.ExistingBodies.ToArray());
            coresComboBox.Items.AddRange(_viewModel.ExistingCores.ToArray());
            legsComboBox.Items.AddRange(_viewModel.ExistingLegs.ToArray());
        }

        private void CreateRobotButton_Click(object sender, EventArgs e)
        {
            List<string> selectedItems =
            [
                armsComboBox.SelectedItem.ToString(),
                bodiesComboBox.SelectedItem.ToString(),
                coresComboBox.SelectedItem.ToString(),
                legsComboBox.SelectedItem.ToString(),
            ];
            CreateRobotButton_Clicked?.Invoke(this, selectedItems);
        }

        private void CreateRobotButton_MouseEnter(object sender, EventArgs e)
        {
            createRobotButton.BackColor = Color.LightGreen;
            createRobotButton.ForeColor = Color.Black;
            createRobotButton.FlatAppearance.BorderColor = Color.DarkGreen;
            createRobotButton.FlatAppearance.BorderSize = 3;
        }

        private void CreateRobotButton_MouseLeave(object sender, EventArgs e)
        {
            createRobotButton.BackColor = Color.Transparent;
            createRobotButton.ForeColor = Color.FromArgb(255, 192, 128);
            createRobotButton.FlatAppearance.BorderSize = 3;
        }
    }
}
