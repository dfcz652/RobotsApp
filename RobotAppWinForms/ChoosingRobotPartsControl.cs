using RobotViewModels;

namespace RobotAppGame
{
    public partial class ChoosingRobotPartsControl : UserControl
    {
        private ViewModel _viewModel;

        public event EventHandler<List<string>> RobotCreated;

        int lastIndex = -1;

        public ChoosingRobotPartsControl(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            FillPartsLists();
            BindDataSources();
            HideRobotPreview();
        }

        private void BindDataSources()
        {
            allRobotCharacteristicsListBox.DataSource = _viewModel.RobotCharacteristics;
        }

        public void SetRobotName(string name)
        {
            _viewModel.RobotsNames.Add(name);
            robotNameLabel.Text = name;
        }

        private void HideRobotPreview()
        {
            leftArmPictureBox.Hide();
            rightArmPictureBox.Hide();
            bodyPictureBox.Hide();
            legsPictureBox.Hide();
            corePictureBox.Hide();
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

            if (index < 0 || index >= listBox.Items.Count)
            {
                characteristicsToolTip.Hide(listBox);
                lastIndex = -1;
                return;
            }

            if (index != lastIndex)
            {
                lastIndex = index;
                string hoveredPart = listBox.Items[index].ToString();

                string tooltipText;

                if (!string.IsNullOrEmpty(_viewModel.CurrentlySelectedPart) &&
                    _viewModel.CurrentlySelectedPart != hoveredPart)
                {
                    _viewModel.CreateAndFormatPartsComparisonReport(_viewModel.CurrentlySelectedPart, hoveredPart);
                    tooltipText = _viewModel.FormattedReport;
                }
                else
                {
                    _viewModel.GetAndFormatPartCharacteristics(hoveredPart);
                    tooltipText = _viewModel.PartInfo;
                }
                characteristicsToolTip.Show(tooltipText, listBox, e.Location);
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

        private void characteristicsToolTip_Popup(object sender, PopupEventArgs e)
        {
            string text = characteristicsToolTip.GetToolTip(e.AssociatedControl);

            using (Font monoFont = new Font("Consolas", 8.25f))
            {
                Size textSize;
                using (Graphics g = e.AssociatedControl.CreateGraphics())
                {
                    textSize = TextRenderer.MeasureText(g, text, monoFont, new Size(1000, 1000), TextFormatFlags.WordBreak);
                }
                e.ToolTipSize = new Size(textSize.Width + 10, textSize.Height + 6);
            }
        }

        private void armsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedArms = armsListBox.SelectedItem;
            if (selectedArms != null)
            {
                UpdateRobotPartAndCharacteristics("arms", selectedArms.ToString());
            }
            leftArmPictureBox.Show();
            rightArmPictureBox.Show();
        }

        private void coresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCores = coresListBox.SelectedItem;
            if (selectedCores != null)
            {
                UpdateRobotPartAndCharacteristics("core", selectedCores.ToString());
            }
            corePictureBox.Show();
        }

        private void bodiesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBodies = bodiesListBox.SelectedItem;
            if (selectedBodies != null)
            {
                UpdateRobotPartAndCharacteristics("body", selectedBodies.ToString());
            }
            bodyPictureBox.Show();
        }

        private void legsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLegs = legsListBox.SelectedItem;
            if (selectedLegs != null)
            {
                UpdateRobotPartAndCharacteristics("legs", selectedLegs.ToString());
            }
            legsPictureBox.Show();
        }

        private void UpdateRobotPartAndCharacteristics(string partType, string selectedPartName)
        {
            string robotName = _viewModel.RobotsNames.FirstOrDefault(n => n == robotNameLabel.Text);
            switch (partType)
            {
                case "arms":
                    _viewModel.UpdateRobot(existingRobotName: robotName, arms: selectedPartName);
                    break;
                case "body":
                    _viewModel.UpdateRobot(existingRobotName: robotName, body: selectedPartName);
                    break;
                case "core":
                    _viewModel.UpdateRobot(existingRobotName: robotName, core: selectedPartName);
                    break;
                case "legs":
                    _viewModel.UpdateRobot(existingRobotName: robotName, legs: selectedPartName);
                    break;
            }
        }

        private void armsListBox_MouseClick(object sender, MouseEventArgs e)//відповідальний за першу обрану частину в порівнянні
        {
            SetCurrentlySelectedPart(sender, e);
        }

        private void SetCurrentlySelectedPart(object sender, MouseEventArgs e)
        {
            var listBox = sender as ListBox;
            int index = listBox.IndexFromPoint(e.Location);

            if (index >= 0 && index < listBox.Items.Count)
            {
                _viewModel.CurrentlySelectedPart = listBox.Items[index].ToString();
            }
        }

        private void coresListBox_MouseClick(object sender, MouseEventArgs e)
        {
            SetCurrentlySelectedPart(sender, e);
        }

        private void bodiesListBox_MouseClick(object sender, MouseEventArgs e)
        {
            SetCurrentlySelectedPart(sender, e);
        }

        private void legsListBox_MouseClick(object sender, MouseEventArgs e)
        {
            SetCurrentlySelectedPart(sender, e);
        }
    }
}
