using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DAWRPC
{
    // https://stackoverflow.com/a/5427121

    public static class Prompt
    {
        public static int ShowDialog(string text, string caption, int previousValue = 1000)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            NumericUpDown numericUpDown = new NumericUpDown() { Left = 50, Top = 50, Width = 400, Minimum = 1000, Maximum = 100000000, Value = previousValue };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(numericUpDown);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? Convert.ToInt32(numericUpDown.Value) : 0;
        }
    }
}
