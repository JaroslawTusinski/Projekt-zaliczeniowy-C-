using Classes_Library.FileManagers;
using Classes_Library.FoodModels;
using Windows_Forms.ControlsHelpers;
using Windows_Forms.Dialogs;

namespace Windows_Forms
{
    public partial class App : Form
    {
        private NotifyIcon _notifyIcon;
        private Order _newOrder = new Order(Properties.Settings.Default.LastOrderId);
        private Dictionary<string, string> _ordersHistory = new Dictionary<string, string>();
        private Dictionary<string, Label[]> _productsLabels;
        private System.Windows.Forms.Timer _timer;
        private Control _selectedControl;
        private bool _canSetOrder = false;

        public App()
        {
            InitializeComponent();

            _notifyIcon = new NotifyIcon(new System.ComponentModel.Container());
            _productsLabels = new Dictionary<string, Label[]>
            {
                { "sandwich", new Label[] { SandwichLabel, SandwichLabel2, SandwichLabel3 } },
                { "dessert", new Label[] { DessertLabel, DessertLabel2, DessertLabel3 } },
                { "drink", new Label[] { DrinkLabel, DrinkLabel2, DrinkLabel3 } },
                { "addon", new Label[] { AddonLabel, AddonLabel2, AddonLabel3 } }
            };

            SetTimer(4);
        }

        private void SetTimer(int seconds)
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = seconds * 1000;
            _timer.Tick += (object? sender, EventArgs e) => UpdateOrdersList();
        }

        private void UpdateOrdersList()
        {
            if (WaitingOrdersContainer.Controls.Count > 0)
            {
                DisplayNotify(WaitingOrdersContainer.Controls[0].Text);
                WaitingOrdersContainer.Controls[0].Click += Label_Click;
                ReadyOrdersContainer.Controls.Add(WaitingOrdersContainer.Controls[0]);
                OrderLabelHelper.UpdateLabelsPositions(ReadyOrdersContainer.Controls);
                OrderLabelHelper.UpdateLabelsPositions(WaitingOrdersContainer.Controls);
            }

            if (WaitingOrdersContainer.Controls.Count == 0) _timer.Stop();
        }

        private void DisplayNotify(string text)
        {
            _notifyIcon.BalloonTipTitle = $"Zamówienie nr {text}";
            _notifyIcon.BalloonTipText = _ordersHistory[text];
            _notifyIcon.ShowBalloonTip(3000);
        }

        private void Label_Click(object sender, EventArgs e)
        {
            _selectedControl = sender as Control;
            ControlsItemsHelper.HighlightItem(_selectedControl, ReadyOrdersContainer.Controls);
        }

        private void wczytajDaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetListsProps();
            ResetOrderPartOfApp();
        }

        private void SetListsProps()
        {
            AddonsList.DataSource = Repository.GetAddons();
            DrinksList.DataSource = Repository.GetDrinks();
            DessertsList.DataSource = Repository.GetDesserts();
            SandwichesList.DataSource = Repository.GetSandwiches();
        }

        private void SandwichesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _newOrder.Sandwich = SandwichesList.SelectedItem as Sandwich;
            if (!_canSetOrder || _newOrder.Sandwich is null) return;

            SetProductLabelsAndSetOrderButton("sandwich", _newOrder.Sandwich.Name, _newOrder.Sandwich.Vege, _newOrder.Sandwich.Weight.ToString());
        }

        private void DessertsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _newOrder.Dessert = DessertsList.SelectedItem as Dessert;
            if (!_canSetOrder || _newOrder.Dessert is null) return;

            SetProductLabelsAndSetOrderButton("dessert", _newOrder.Dessert.Name, _newOrder.Dessert.Calories.ToString(), _newOrder.Dessert.Weight.ToString());
        }

        private void DrinksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _newOrder.Drink = DrinksList.SelectedItem as Drink;
            if (!_canSetOrder || _newOrder.Drink is null) return;

            SetProductLabelsAndSetOrderButton("drink", _newOrder.Drink.Name, _newOrder.Drink.Sugar, _newOrder.Drink.Size.ToString());
        }

        private void AddonsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _newOrder.Addon = AddonsList.SelectedItem as Addon;
            if (!_canSetOrder || _newOrder.Addon is null) return;

            SetProductLabelsAndSetOrderButton("addon", _newOrder.Addon.Name, _newOrder.Addon.Sauce, _newOrder.Addon.Volume.ToString());
        }

        private void SetProductLabelsAndSetOrderButton(string productType, string productName, string info1, string info2)
        {
            _productsLabels[productType][0].Text = productName;
            _productsLabels[productType][1].Text = info1;
            _productsLabels[productType][2].Text = info2;
            button1.Enabled = true;
            SetPriceLabel();
        }

        private void SetPriceLabel()
        {
            Price.Text = _newOrder.Price.ToString("N2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetOrderPartOfApp();
        }

        private void ResetOrderPartOfApp()
        {
            button1.Enabled = false;
            _canSetOrder = false;
            _newOrder = new Order(Properties.Settings.Default.LastOrderId);

            foreach (var labels in _productsLabels)
                foreach (var label in labels.Value)
                    label.Text = "";
            
            SandwichesList.ClearSelected();
            DessertsList.ClearSelected();
            DrinksList.ClearSelected();
            AddonsList.ClearSelected();
            SetPriceLabel();

            _canSetOrder = true;
        }

        private void ResetCustomerPartOfApp()
        {
            _timer.Stop();
            WaitingOrdersContainer.Controls.Clear();
            ReadyOrdersContainer.Controls.Clear();
            _ordersHistory = new Dictionary<string, string>();
            _selectedControl = null;
        }

        private void ResetManagerPartOfApp()
        {
            textBox1.Text = "";
        }

        private void resetujAplikacjêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastOrderId = 1;
            Properties.Settings.Default.Save();

            SandwichesList.DataSource = null;
            DessertsList.DataSource = null;
            DrinksList.DataSource = null;
            AddonsList.DataSource = null;
            Price.Text = "";

            ResetOrderPartOfApp();
            ResetCustomerPartOfApp();
            ResetManagerPartOfApp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text += Environment.NewLine;

            WaitingOrdersContainer.Controls.Add(
                OrderLabelHelper.CreateOrderNumberLabel(
                    _newOrder.Id,
                    WaitingOrdersContainer.Controls.Count,
                    WaitingOrdersContainer.Width
                )
            );

            _newOrder.DateTime = DateTime.Now;
            textBox1.Text += _newOrder.ToString();
            _ordersHistory.Add(_newOrder.Id, _newOrder.ToNotifyString());
            _newOrder = new Order(++Properties.Settings.Default.LastOrderId);

            Properties.Settings.Default.Save();
            ResetOrderPartOfApp();

            if (!_timer.Enabled)
                _timer.Start();
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            if (ReadyOrdersContainer.Controls.Count == 0) return;
            if (_selectedControl is null) _selectedControl = ReadyOrdersContainer.Controls[0];

            ReadyOrdersContainer.Controls.Remove(_selectedControl);
            OrderLabelHelper.UpdateLabelsPositions(ReadyOrdersContainer.Controls);
            _selectedControl = null;
        }

        private void zapiszEkranManageraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingDialog.SaveFileToTxt(textBox1.Text, "Zapisz historiê zamówieñ");
        }

        private void App_Load(object sender, EventArgs e)
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            _notifyIcon.Icon = (Icon)resources.GetObject("$this.Icon");
            _notifyIcon.Visible = true;
            _notifyIcon.Text = "Zamawiacz 2022";
        }
    }
}