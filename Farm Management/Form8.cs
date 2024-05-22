using System.Data.OleDb;

namespace Farm_Management
{
    public partial class Form8 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\FarmDatabase.accdb;Persist Security Info=False;";

        public Form8()
        {
            InitializeComponent();
            pictureBoxLogo.Load(@"Resources\Logo.png");
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
        }

        // Buttons

        private void CreatePart(object sender, EventArgs e)
        {
            if (CheckSufficientDetailsEntered() == true)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand createPart = new OleDbCommand("INSERT INTO Parts ([PartName],[PartNumber],[Price]) VALUES (@PartName,@PartNumber,@Price)", connection))
                    {
                        createPart.Parameters.AddWithValue("@PartName", txtPartName.Text);
                        createPart.Parameters.AddWithValue("@PartNumber", txtPartNumber.Text.ToUpper());
                        createPart.Parameters.AddWithValue("@Price", float.Parse(txtPrice.Text));
                        createPart.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Part Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form7.instance?.PopulateListBox();
                Close();
            }
        }

        // Validation Checks

        private bool CheckSufficientDetailsEntered()
        {
            if (CheckPartExists() == false && CheckPartName() == true && CheckPartNumber() == true && CheckPrice() == true)
                return true;

            return false;
        }

        private bool CheckPartExists()
        {
            int result = -1;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand checkPartExists = new OleDbCommand("SELECT COUNT ([PartNumber]) FROM Parts WHERE PartNumber=@PartNumber", connection))
                {
                    checkPartExists.Parameters.AddWithValue("@PartNumber", txtPartNumber.Text.ToUpper());
                    result = (int) checkPartExists.ExecuteScalar();
                }
            }

            if (result == 0)
                return false;
            else
            {
                MessageBox.Show("Part Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private bool CheckPartName()
        {
            if (txtPartName.Text == "")
            {
                MessageBox.Show("Part Name must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckPartNumber()
        {
            if (txtPartNumber.Text == "")
            {
                MessageBox.Show("Part Number must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckPrice()
        {
            if (txtPrice.Text == "")
            {
                MessageBox.Show("Price must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    float price = float.Parse(txtPrice.Text);
                }
                catch
                {
                    MessageBox.Show("Price must contain no alphabetical characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}
