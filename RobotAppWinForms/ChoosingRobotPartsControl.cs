using System.Windows.Forms;
using RobotApp.RobotData.Base;
using RobotViewModels;

namespace RobotAppGame
{
    public partial class ChoosingRobotPartsControl : UserControl
    {
        private ViewModel _viewModel;

        public event EventHandler<List<string>> RobotCreated;

        public event EventHandler<RobotCharacteristicsBase> PartSelected;

        int lastIndex = -1;

        public ChoosingRobotPartsControl(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            FillPartsLists();
        }

        private void FillPartsLists()
        {
            armsListBox.Items.AddRange(_viewModel.ExistingArms.ToArray());
            bodiesListBox.Items.AddRange(_viewModel.ExistingBodies.ToArray());
            coresListBox.Items.AddRange(_viewModel.ExistingCores.ToArray());
            legsListBox.Items.AddRange(_viewModel.ExistingLegs.ToArray());
        }

        private void CreateRobotButton_Click(object sender, EventArgs e)
        {
            List<string> selectedItems =
            [
                armsListBox.SelectedItem.ToString(),
                bodiesListBox.SelectedItem.ToString(),
                coresListBox.SelectedItem.ToString(),
                legsListBox.SelectedItem.ToString(),
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

        private void armsListBox_MouseMove(object sender, MouseEventArgs e)
        {
            ShowTooltipWithCharacteristics(sender as ListBox, e);
        }

        private void bodiesListBox_MouseMove(object sender, MouseEventArgs e)
        {
            ShowTooltipWithCharacteristics(sender as ListBox, e);
        }

        private void coresListBox_MouseMove(object sender, MouseEventArgs e)
        {
            ShowTooltipWithCharacteristics(sender as ListBox, e);
        }

        private void legsListBox_MouseMove(object sender, MouseEventArgs e)
        {
            ShowTooltipWithCharacteristics(sender as ListBox, e);
        }

        private void ShowTooltipWithCharacteristics(ListBox listBox, MouseEventArgs e)
        {
            int index = listBox.IndexFromPoint(e.Location);

            if (index >= 0 && index < listBox.Items.Count)
            {
                if (index != lastIndex)
                {
                    lastIndex = index;
                    string itemContent = listBox.Items[index].ToString();
                    _viewModel.GetPartCharacteristics(itemContent);
                    characteristicsToolTip.Show(_viewModel.PartInfo, listBox, e.Location);
                }
            }
            else
            {
                characteristicsToolTip.Hide(listBox);
                lastIndex = -1;
            }
        }

        private void characteristicsToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            using (Font monoFont = new Font("Consolas", 8.25f))
            {
                e.Graphics.Clear(SystemColors.Info);
                e.Graphics.DrawString(e.ToolTipText, monoFont, Brushes.Black, new PointF(0, 0));
            }
        }
    }
}
