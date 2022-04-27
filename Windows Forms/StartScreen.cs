namespace Windows_Forms
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
            CloseAfter(2000);
        }

        private void CloseAfter(int miliseconds)
        {
            var counter = 0.0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;

            timer.Tick += (object sender, EventArgs e) =>
            {
                counter += timer.Interval;
                ProgressBar.Value = CalcProgres(counter, timer.Interval, miliseconds / 100);

                if (ProgressBar.Value == 100)
                {
                    timer.Stop();
                    this.Close();
                }
            };

            timer.Start();
        }

        private int CalcProgres(double counter, int step, int divider)
        {
            return (int)Math.Floor((counter + step) / divider);
        }
    }
}
