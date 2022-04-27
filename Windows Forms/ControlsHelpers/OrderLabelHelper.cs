using static System.Windows.Forms.Control;

namespace Windows_Forms.ControlsHelpers
{
    public static class OrderLabelHelper
    {
        private static int _labelHeight = 28;

        public static Label CreateOrderNumberLabel(string text, int ordersCount, int parentWidth)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = false;
            label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label.Size = new Size(parentWidth - SystemInformation.VerticalScrollBarWidth * 2, _labelHeight);
            label.Location = CalcOrderLabelLocation(ordersCount);

            return label;
        }

        public static void UpdateLabelsPositions(ControlCollection controls)
        {
            for (int i = 0; i < controls.Count; i++)
                controls[i].Location = CalcOrderLabelLocation(i);
        }

        private static Point CalcOrderLabelLocation(int i)
        {
            return new Point(0, i * _labelHeight - i);
        }
    }
}
