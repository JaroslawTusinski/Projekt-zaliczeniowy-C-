namespace Windows_Forms.ControlsHelpers
{
    public static class ControlsItemsHelper
    {
        public static void HighlightItem(Control control, Control.ControlCollection controls)
        {
            foreach (var item in controls)
            {
                var ctrl = item as Control;
                ctrl.ForeColor = Color.Lime;
            }

            control.ForeColor = Color.Gold;
        }
    }
}
