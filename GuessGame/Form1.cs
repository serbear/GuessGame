using System;
using System.Windows.Forms;

namespace GuessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumber.Text, out var n))
            {
                var result = Program.GuessNumber(n);
                lblMessage.Text = result;
                txtNumber.Text = "";
            }
            else
            {
                MessageBox.Show(@"Cannot convert the given value.", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumber.SelectAll();
            }

            txtNumber.Focus();
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            btnGuess.Enabled = txtNumber.Text.Length > 0;
        }
    }
}
