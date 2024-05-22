using System.Data.OleDb;
using Classes.User;

namespace Farm_Management
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\FarmDatabase.accdb;Persist Security Info=False;";

        public Form1()
        {
            InitializeComponent();
            pictureBoxLogo.Load(@"Resources\Logo.png");
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
        }

        // Form Events

        private void OnLoad(object sender, EventArgs e)
        {
            CreateTables();
        }

        // Buttons

        private void CreateAccount(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
                form2.ShowDialog();
        }

        private void Login(object sender, EventArgs e)
        {
            if (CheckAccountDetails() == true)
            {
                User currentUser = GetAccountDetails();
                Hide();
                using (Form3 form3 = new Form3(currentUser))
                    form3.ShowDialog();
                Dispose();
            }
        }

        // Validation Checks

        private bool CheckAccountDetails()
        {
            if (CheckUsernameExists() == true && CheckPasswordCorrect() == true)
                return true;

            return false;
        }

        private bool CheckUsernameExists()
        {
            int result = -1;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand findUsername = new OleDbCommand("SELECT COUNT([Username]) FROM Accounts WHERE Username=@Username", connection))
                {
                    findUsername.Parameters.AddWithValue("@Username", txtUsername.Text.ToLower());
                    result = (int)findUsername.ExecuteScalar();
                }
            }

            if (result == 0)
            {
                MessageBox.Show("Username does not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private bool CheckPasswordCorrect()
        {
            if (GetAccountPassword() == txtPassword.Text)
                return true;
            else
            {
                MessageBox.Show("Incorrect Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Database

        private string GetAccountPassword()
        {
            string password = "";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getPassword = new OleDbCommand("SELECT [Password] FROM Accounts WHERE Username=@Username", connection))
                {
                    getPassword.Parameters.AddWithValue("@Username", txtUsername.Text.ToLower());
                    password = (string)getPassword.ExecuteScalar();
                }
            }

            return password;
        }

        private User GetAccountDetails()
        {
            int AccountID = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getAccountDetails = new OleDbCommand("SELECT [AccountID] FROM Accounts WHERE Username=@Username", connection))
                {
                    getAccountDetails.Parameters.AddWithValue("@Username", txtUsername.Text.ToLower());
                    AccountID = (int)getAccountDetails.ExecuteScalar();
                }
            }

            User currentUser = new User(txtUsername.Text.ToLower(), AccountID);

            return currentUser;
        }

        private void CreateTables()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand checkAccountsTable = new OleDbCommand("SELECT * FROM Accounts", connection))
                {
                    try
                    {
                        checkAccountsTable.ExecuteNonQuery();
                    }
                    catch
                    {
                        using (OleDbCommand createAccountsTable = new OleDbCommand("CREATE TABLE Accounts([AccountID] AUTOINCREMENT PRIMARY KEY NOT NULL,[Username] VARCHAR(16) NOT NULL,[Password] VARCHAR(50) NOT NULL)", connection))
                            createAccountsTable.ExecuteNonQuery();
                    }
                }

                using (OleDbCommand checkVehiclesTable = new OleDbCommand("SELECT * FROM Vehicles", connection))
                {
                    try
                    {
                        checkVehiclesTable.ExecuteNonQuery();
                    }
                    catch
                    {
                        using (OleDbCommand createVehiclesTable = new OleDbCommand("CREATE TABLE Vehicles([VehicleID] AUTOINCREMENT PRIMARY KEY NOT NULL,[VehicleType] VARCHAR(10) NOT NULL,[Registration] VARCHAR(7) NOT NULL,[Make] VARCHAR(30) NOT NULL,[Model] VARCHAR(30) NOT NULL,[OilType] VARCHAR(50) NOT NULL,[CoolantType] VARCHAR(50) NOT NULL,[FuelType] VARCHAR(10) NOT NULL,[EngineOilLevel] DOUBLE NOT NULL,[HydraulicOilLevel] DOUBLE,[Hours] INT,[Miles] INT,[LiftingCapacity] DOUBLE,[LoadCapacity] DOUBLE)", connection))
                            createVehiclesTable.ExecuteNonQuery();
                    }
                }

                using (OleDbCommand checkJobsTable = new OleDbCommand("SELECT * FROM Jobs", connection))
                {
                    try
                    {
                        checkJobsTable.ExecuteNonQuery();
                    }
                    catch
                    {
                        using (OleDbCommand createJobsTable = new OleDbCommand("CREATE TABLE Jobs([JobID] INT PRIMARY KEY NOT NULL,[VehicleID] INT NOT NULL,[Title] VARCHAR(30) NOT NULL,[Description] MEMO NOT NULL,[DateCreated] DATETIME NOT NULL,[DateCompleted] DATETIME,[Status] BIT,[HoursOrMilesStart] INT NOT NULL,[HoursOrMilesComplete] INT,[UserCreated] VARCHAR(16) NOT NULL,FOREIGN KEY (VehicleID) REFERENCES Vehicles (VehicleID))", connection))
                            createJobsTable.ExecuteNonQuery();
                    }
                }

                using (OleDbCommand checkPartsTable = new OleDbCommand("SELECT * FROM Parts", connection))
                {
                    try
                    {
                        checkPartsTable.ExecuteNonQuery();
                    }
                    catch
                    {
                        using (OleDbCommand createPartsTable = new OleDbCommand("CREATE TABLE Parts([PartID] AUTOINCREMENT PRIMARY KEY NOT NULL,[PartName] VARCHAR(30) NOT NULL,[PartNumber] VARCHAR(25) NOT NULL,[Price] DOUBLE NOT NULL)", connection))
                            createPartsTable.ExecuteNonQuery();
                    }
                }

                using (OleDbCommand checkJobPartsTable = new OleDbCommand("SELECT * FROM JobParts", connection))
                {
                    try
                    {
                        checkJobPartsTable.ExecuteNonQuery();
                    }
                    catch
                    {
                        using (OleDbCommand createJobPartsTable = new OleDbCommand("CREATE TABLE JobParts([JobID] INT NOT NULL,[PartID] INT NOT NULL,PRIMARY KEY (JobID, PartID),FOREIGN KEY (JobID) REFERENCES Jobs (JobID),FOREIGN KEY (PartID) REFERENCES Parts (PartID))", connection))
                            createJobPartsTable.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}