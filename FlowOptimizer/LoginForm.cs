using System;
using System.Windows.Forms;

namespace FlowOptimizer
{
    public partial class LoginForm : Form
    {
        public bool IsAuthenticated { get; private set; } = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string key = this.keyTextBox.Text;
            if (Modules.Auth.ValidateKey(key))
            {
                Modules.Auth.SaveHwid(Modules.HWID.Generate());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid key.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
