using CurrencyConverter.Models;
using CurrencyConverter.Services;

using static CurrencyConverter.Models.UserModel;

namespace CurrencyConverter
{
    public partial class LoginView : Form
    {
        private ServiceCollection _services;
        public LoginView(ServiceCollection services)
        {
            InitializeComponent();

            _services = services;
            usernameComboBox.DataSource = Enum.GetValues(typeof(Usernames));
        }

        private void buttonShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTextBox.PasswordChar = (char)0;
        }

        private void buttonShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTextBox.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Validate password 
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Το Password δεν μπορεί να είναι κενό", "Σφάλμα σύνδεσης", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            UserModel user = new UserModel();
            user.Username = (Usernames)usernameComboBox.SelectedValue;
            user.Password = passwordTextBox.Text;

            if (_services.UserService.Get(usernameComboBox.Text) == null)
            {
                try
                {
                    _services.UserService.Add(user);
                    MainView mainView = new MainView(_services, user);
                    mainView.Show();
                    this.Close();
                    return;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Σφάλμα σύνδεσης", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (_services.UserService.ValidateUser(user))
            {
                MainView mainView = new MainView(_services, user);
                mainView.ShowDialog();
            }
            else
                MessageBox.Show("Λάθος Username ή Password.", "Σφάλμα σύνδεσης", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loginButton_Click(loginButton, new EventArgs());
        }
    }
}
