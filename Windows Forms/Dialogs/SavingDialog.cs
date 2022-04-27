namespace Windows_Forms.Dialogs
{
    public static class SavingDialog
    {
        public static void SaveFileToTxt(string data, string dialogTitle = "Save file", string fileName = null)
        {
            var dialog = new SaveFileDialog();
            if (fileName is null)
                fileName = Application.ProductName + " - " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");

            dialog.Filter = "Text files | *.txt";
            dialog.Title = dialogTitle;
            dialog.FileName = fileName;

            if (dialog.FileName != "" && dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, data);
            }
        }
    }
}
