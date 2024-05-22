using System.Data.OleDb;

namespace Farm_Management
{
    public partial class Form2 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\FarmDatabase.accdb;Persist Security Info=False;";

        public Form2()
        {
            InitializeComponent();
            pictureBoxLogo.Load(@"Resources\Logo.png");
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
        }

        // Buttons

        private void CreateAccount(object sender, EventArgs e)
        {
            if (CheckValidCredentials() == true && CheckPasswordsMatch() == true)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand createAccount = new OleDbCommand("INSERT INTO Accounts ([Username],[Password]) VALUES (@Username,@Password)", connection))
                    {
                        createAccount.Parameters.AddWithValue("@Username", txtUsername.Text.ToLower());
                        createAccount.Parameters.AddWithValue("@Password", txtPassword.Text);
                        createAccount.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        // Validation Checks

        private bool CheckValidCredentials()
        {
            if (CheckUsernameNotAlreadyExists() == true && CheckValidUsername() == true && CheckValidPassword() == true)
                return true;

            return false;
        }

        private bool CheckUsernameNotAlreadyExists()
        {
            int result = -1;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand findUsername = new OleDbCommand("SELECT COUNT ([Username]) FROM Accounts WHERE Username=@Username", connection))
                {
                    findUsername.Parameters.AddWithValue("@Username", txtUsername.Text.ToLower());
                    result = (int)findUsername.ExecuteScalar();
                }
            }

            if (result == 0)
                return true;
            else
            {
                MessageBox.Show("Username Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckValidUsername()
        {
            if (CheckValidUsernameLength() == true && CheckAlphabeticalOnly(txtUsername) == true)
                return true;
            else
            {
                MessageBox.Show("Invalid Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckValidUsernameLength()
        {
            if (txtUsername.Text.Length < 4 || txtUsername.Text.Length > 16)
                return false;

            return true;
        }

        private bool CheckAlphabeticalOnly(TextBox txtBox)
        {
            if (txtBox.Text.All(char.IsLetter) == true)
                return true;

            return false;
        }

        private bool CheckValidPassword()
        {
            if (CheckValidPasswordLength() == true && CheckAlphabeticalOnly(txtPassword) == false)
                return true;
            else
            {
                MessageBox.Show("Invalid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckValidPasswordLength()
        {
            if (txtPassword.Text.Length < 8)
                return false;

            return true;
        }

        private bool CheckPasswordsMatch()
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
                return true;
            else
            {
                MessageBox.Show("Passwords do not Match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
