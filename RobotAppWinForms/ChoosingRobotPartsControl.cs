using RobotApp.RobotData.Base;
using RobotViewModels;

namespace RobotAppGame
{
    public partial class ChoosingRobotPartsControl : UserControl
    {
        private ViewModel _viewModel;

        public event EventHandler<List<string>> RobotCreated;

        public event EventHandler<RobotCharacteristicsBase> PartSelected;

        public ChoosingRobotPartsControl(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            FillPartsLists();
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
            RobotCreated?.Invoke(this, selectedItems);
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

        private void comboBoxParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                string selectedPart = comboBox.SelectedItem?.ToString() ?? string.Empty;
                _viewModel.GetPartCharacteristics(selectedPart);
                partsRichTextBox.Text = _viewModel.FormattedReport;
            }
        }
    }
}
