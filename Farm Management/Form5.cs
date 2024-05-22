using Classes.Vehicle;
using Classes.User;
using Classes.LinkedList;
using Classes.Job;
using Classes.Part;
using System.Data.OleDb;

namespace Farm_Management
{
    public partial class Form5 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\FarmDatabase.accdb;Persist Security Info=False;";

        public static Form5? instance;
        
        public Vehicle? SelectedVehicle;
        private Job? SelectedJob;
        private string SelectedButton = "";
        
        public Form5(Vehicle? SelectedVehicle)
        {
            InitializeComponent();
            pictureBoxLogo.Load(@"Resources\Logo.png");
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
            this.SelectedVehicle = SelectedVehicle;
            instance = this;
        }

        // Form Events

        private void OnLoad(object sender, EventArgs e)
        {
            PopulateIncompleteJobs(sender, e);
        }

        private void RefreshVehicleInformationPanel(object sender, FormClosedEventArgs e)
        {
            Form3.instance?.RefreshInformationPanel(sender, e);
        }

        public void RefreshSelectedVehicle()
        {
            SelectedVehicle = Form3.instance?.GetVehicleDetails(SelectedVehicle.GetVehicleType(), SelectedVehicle.GetRegistration());
        }

        // Buttons

        private void CreateJob(object sender, EventArgs e)
        {
            using (Form6 form6 = new Form6())
                form6.ShowDialog();
        }

        private void EditJob(object sender, EventArgs e)
        {
            using (Form6 form6 = new Form6(SelectedJob, SelectedVehicle))
                form6.ShowDialog();
        }

        private void DeleteJob(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this job?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand deleteJobParts = new OleDbCommand("DELETE FROM JobParts WHERE JobID=@JobID", connection))
                    {
                        deleteJobParts.Parameters.AddWithValue("@JobID", SelectedJob?.GetJobID());
                        deleteJobParts.ExecuteNonQuery();
                    }

                    using (OleDbCommand deleteJob = new OleDbCommand("DELETE FROM Jobs WHERE JobID=@JobID", connection))
                    {
                        deleteJob.Parameters.AddWithValue("@JobID", SelectedJob?.GetJobID());
                        deleteJob.ExecuteNonQuery();
                    }
                }

                RefreshJobInformationPanel();
                PopulateIncompleteJobs(sender, e);
            }
        }

        // Job Information Panel

        private void DisplayJobInformation(object sender, EventArgs e)
        {
            panelJobInformation.Controls.Clear();
            
            Label labelTag = (Label) sender;
            int JobID = (int) labelTag.Tag;

            SelectedJob = GetJob(JobID, SelectedButton);

            labelPleaseSelectJob.Visible = false;

            AddTitleSection(SelectedJob.GetTitle());
            AddDescriptionSection(SelectedJob.GetDescription());
            AddPartsSection(SelectedJob.GetParts());
            if (SelectedJob.GetStatus() == true)
                AddHoursOrMilesSection(SelectedJob.GetHoursOrMilesComplete());
            AddDateAndUserSection(SelectedJob.GetUserCreated(), SelectedJob.GetDateCreated());
            if (SelectedJob.GetStatus() == true)
                AddDateCompletedValue(SelectedJob.GetDateCompleted());
            AddButtons();
        }

        public void RefreshJobInformationPanel()
        {
            panelJobInformation.Controls.Clear();
        }

        private void AddTitleSection(string Title)
        {
            Font font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label TitleLabel = new Label();
            TitleLabel.Location = new Point(19, 21);
            TitleLabel.Text = "Job Title";
            TitleLabel.ForeColor = Color.DimGray;
            TitleLabel.Height = 15;
            TitleLabel.Font = font;
            panelJobInformation.Controls.Add(TitleLabel);

            TextBox TitleTextbox = new TextBox();
            TitleTextbox.Location = new Point(19, 39);
            TitleTextbox.Width = 306;
            TitleTextbox.Height = 23;
            TitleTextbox.ForeColor = Color.DimGray;
            TitleTextbox.Font = new Font("Arial", 9);
            TitleTextbox.ReadOnly = true;
            TitleTextbox.Text = Title;
            panelJobInformation.Controls.Add(TitleTextbox);
        }

        private void AddDescriptionSection(string Description)
        {
            Font font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label DescriptionLabel = new Label();
            DescriptionLabel.Location = new Point(19, 84);
            DescriptionLabel.Text = "Job Description";
            DescriptionLabel.ForeColor = Color.DimGray;
            DescriptionLabel.Height = 15;
            DescriptionLabel.Font = font;
            panelJobInformation.Controls.Add(DescriptionLabel);

            TextBox DescriptionTextbox = new TextBox();
            DescriptionTextbox.Location = new Point(19, 102);
            DescriptionTextbox.Width = 457;
            DescriptionTextbox.Height = 152;
            DescriptionTextbox.ForeColor = Color.DimGray;
            DescriptionTextbox.Font = new Font("Arial", 9);
            DescriptionTextbox.ReadOnly = true;
            DescriptionTextbox.Text = Description;
            DescriptionTextbox.ScrollBars = ScrollBars.Vertical;
            DescriptionTextbox.Multiline = true;
            panelJobInformation.Controls.Add(DescriptionTextbox);
        }

        private void AddHoursOrMilesSection(int HoursOrMiles)
        {
            Font font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label HoursOrMilesLabel = new Label();
            HoursOrMilesLabel.Location = new Point(19, 455);
            HoursOrMilesLabel.Text = "Vehicle Hours / Miles (At Completion)";
            HoursOrMilesLabel.ForeColor = Color.DimGray;
            HoursOrMilesLabel.Width = 250;
            HoursOrMilesLabel.Height = 15;
            HoursOrMilesLabel.Font = font;
            panelJobInformation.Controls.Add(HoursOrMilesLabel);

            TextBox HoursOrMilesTextbox = new TextBox();
            HoursOrMilesTextbox.Location = new Point(19, 473);
            HoursOrMilesTextbox.Width = 101;
            HoursOrMilesTextbox.Height = 23;
            HoursOrMilesTextbox.ForeColor = Color.DimGray;
            HoursOrMilesTextbox.Font = new Font("Arial", 9);
            HoursOrMilesTextbox.ReadOnly = true;
            HoursOrMilesTextbox.Text = HoursOrMiles.ToString();
            panelJobInformation.Controls.Add(HoursOrMilesTextbox);
        }

        private void AddPartsSection(LinkedList Parts)
        {
            Font font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label PartsLabel = new Label();
            PartsLabel.Location = new Point(19, 281);
            PartsLabel.Text = "Parts";
            PartsLabel.ForeColor = Color.DimGray;
            PartsLabel.Height = 15;
            PartsLabel.Font = font;
            panelJobInformation.Controls.Add(PartsLabel);

            ListBox PartsListbox = new ListBox();
            PartsListbox.SelectionMode = SelectionMode.None;
            PartsListbox.Location = new Point(19, 299);
            PartsListbox.Font = new Font("Arial", 9);
            PartsListbox.Width = 400;
            PartsListbox.Height = 124;
            if (Parts.Count() != 0)
            {
                for (int i = 1; i <= Parts.Count(); i++)
                    PartsListbox.Items.Add($"{Parts.GetPart(i).GetName()} [{Parts.GetPart(i).GetNumber()}]");
            }
            panelJobInformation.Controls.Add(PartsListbox);
        }

        private void AddDateAndUserSection(User UserCreated, DateTime DateCreated)
        {
            Font font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label DateCreatedLabel = new Label();
            DateCreatedLabel.Location = new Point(19, 559);
            DateCreatedLabel.Text = "Date Created";
            DateCreatedLabel.ForeColor = Color.DimGray;
            DateCreatedLabel.Height = 15;
            DateCreatedLabel.Font = font;
            panelJobInformation.Controls.Add(DateCreatedLabel);

            Label DateCompletedLabel = new Label();
            DateCompletedLabel.Location = new Point(378, 559);
            DateCompletedLabel.Text = "Date Completed";
            DateCompletedLabel.ForeColor = Color.DimGray;
            DateCompletedLabel.Height = 15;
            DateCompletedLabel.Font = font;
            panelJobInformation.Controls.Add(DateCompletedLabel);

            Label UserCreatedLabel = new Label();
            UserCreatedLabel.Location = new Point(210, 559);
            UserCreatedLabel.Text = "Created By";
            UserCreatedLabel.ForeColor = Color.DimGray;
            UserCreatedLabel.Height = 15;
            UserCreatedLabel.Font = font;
            panelJobInformation.Controls.Add(UserCreatedLabel);

            Label DateCreatedValueLabel = new Label();
            DateCreatedValueLabel.Location = new Point(19, 577);
            DateCreatedValueLabel.Text = DateCreated.ToString();
            DateCreatedValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            DateCreatedValueLabel.Width = 75;
            DateCreatedValueLabel.Height = 15;
            DateCreatedValueLabel.ForeColor = Color.RoyalBlue;
            DateCreatedValueLabel.Font = font;
            panelJobInformation.Controls.Add(DateCreatedValueLabel);

            Label UserCreatedValueLabel = new Label();
            UserCreatedValueLabel.Location = new Point(195, 577);
            UserCreatedValueLabel.Text = UserCreated.GetUsername();
            UserCreatedValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            UserCreatedValueLabel.Width = 100;
            UserCreatedValueLabel.Height = 15;
            UserCreatedValueLabel.ForeColor = Color.RoyalBlue;
            UserCreatedValueLabel.Font = font;
            panelJobInformation.Controls.Add(UserCreatedValueLabel);
        }

        private void AddDateCompletedValue(DateTime DateCompleted)
        {
            Font font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label DateCompletedValueLabel = new Label();
            DateCompletedValueLabel.Location = new Point(401, 577);
            DateCompletedValueLabel.Text = DateCompleted.ToString();
            DateCompletedValueLabel.TextAlign = ContentAlignment.MiddleRight;
            DateCompletedValueLabel.Width = 75;
            DateCompletedValueLabel.Height = 15;
            DateCompletedValueLabel.ForeColor = Color.RoyalBlue;
            DateCompletedValueLabel.Font = font;
            panelJobInformation.Controls.Add(DateCompletedValueLabel);
        }

        private void AddButtons()
        {
            Font font = new Font("Segoe UI", 9, FontStyle.Bold);

            Button EditButton = new Button();
            EditButton.Text = "EDIT JOB";
            EditButton.Width = 95;
            EditButton.Height = 40;
            EditButton.Font = font;
            EditButton.ForeColor = Color.LightSeaGreen;
            EditButton.Location = new Point(267, 484);
            EditButton.Click += EditJob;
            panelJobInformation.Controls.Add(EditButton);

            Button DeleteButton = new Button();
            DeleteButton.Text = "DELETE JOB";
            DeleteButton.Width = 95;
            DeleteButton.Height = 40;
            DeleteButton.Font = font;
            DeleteButton.ForeColor = Color.Tomato;
            DeleteButton.Location = new Point(367, 484);
            DeleteButton.Click += DeleteJob;
            panelJobInformation.Controls.Add(DeleteButton);
        }

        private User GetUser(string Username)
        {
            int UserID = 0;
            string UserUsername = "";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getUser = new OleDbCommand("SELECT [AccountID],[Username] FROM Accounts WHERE Username=@Username", connection))
                {
                    getUser.Parameters.AddWithValue("@Username", Username);
                    using (OleDbDataReader reader = getUser.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserID = reader.GetInt32(0);
                            UserUsername = reader.GetString(1);
                        }
                    }
                }
            }

            User user = new User(UserUsername, UserID);
            return user;
        }

        private LinkedList GetJobParts(int JobID)
        {
            LinkedList Parts = new LinkedList();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getJobParts = new OleDbCommand("SELECT Parts.* FROM Parts,JobParts WHERE JobParts.JobID=@JobID AND JobParts.PartID=Parts.PartID", connection))
                {
                    getJobParts.Parameters.AddWithValue("@JobID", JobID);
                    using (OleDbDataReader reader = getJobParts.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Part CurrentPart = new Part(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
                            Parts.AppendPart(CurrentPart);
                        }
                    }
                }
            }

            return Parts;
        }

        // Job List

        public void PopulateIncompleteJobs(object sender, EventArgs e)
        {
            flowpanelJobList.Controls.Clear();
            SelectedButton = "Incomplete";
            btnIncompleteJobs.ForeColor = Color.DimGray;
            btnCompleteJobs.ForeColor = Color.DarkGray;
            
            if (CheckNumberOfIncompleteJobsExist() != 0)
            {
                LinkedList Jobs = GetAllIncompleteJobs();

                for (int i = 1; i <= Jobs.Count(); i++)
                {
                    Panel CurrentJobInformationPanel = CreateJobInformationPanel(Jobs.GetJob(i).GetJobID(), Jobs.GetJob(i).GetTitle(), Jobs.GetJob(i).GetDescription());
                    flowpanelJobList.Controls.Add(CurrentJobInformationPanel);
                }
            }
        }

        private void PopulateCompleteJobs(object sender, EventArgs e)
        {
            flowpanelJobList.Controls.Clear();
            SelectedButton = "Complete";
            btnCompleteJobs.ForeColor = Color.DimGray;
            btnIncompleteJobs.ForeColor = Color.DarkGray;

            if (CheckNumberOfCompleteJobsExist() != 0)
            {
                LinkedList Jobs = GetAllCompleteJobs();

                for (int i = 1; i <= Jobs.Count(); i++)
                {
                    Panel CurrentJobInformationPanel = CreateJobInformationPanel(Jobs.GetJob(i).GetJobID(), Jobs.GetJob(i).GetTitle(), Jobs.GetJob(i).GetDescription());
                    flowpanelJobList.Controls.Add(CurrentJobInformationPanel);
                }
            }
        }

        private Panel CreateJobInformationPanel(int JobID, string Title, string Description)
        {
            Panel JobInformation = new Panel();
            JobInformation.BorderStyle = BorderStyle.FixedSingle;
            JobInformation.Width = 309;
            JobInformation.Height = 80;
            JobInformation.Cursor = Cursors.Hand;

            Panel JobTitle = new Panel();
            JobTitle.Width = 309;
            JobTitle.Height = 30;
            JobTitle.Dock = DockStyle.Top;

            Panel JobDescription = new Panel();
            JobDescription.Width = 309;
            JobDescription.Height = 50;
            JobDescription.Dock = DockStyle.Bottom;

            Label JobTitleLabel = new Label();
            JobTitleLabel.Text = Title;
            JobTitleLabel.Font = new Font("Arial Rounded MT Bold", 11);
            JobTitleLabel.Dock = DockStyle.Fill;
            JobTitleLabel.AutoSize = true;
            JobTitleLabel.Tag = JobID;
            JobTitleLabel.TextAlign = ContentAlignment.TopLeft;
            JobTitleLabel.Click += DisplayJobInformation;

            Label JobDescriptionLabel = new Label();
            JobDescriptionLabel.Text = FormatJobDescription(Description);
            JobDescriptionLabel.Font = new Font("Arial", 9);
            JobDescriptionLabel.Dock = DockStyle.Fill;
            JobDescriptionLabel.Tag = JobID;
            JobDescriptionLabel.TextAlign = ContentAlignment.TopLeft;
            JobDescriptionLabel.Click += DisplayJobInformation;

            JobTitle.Controls.Add(JobTitleLabel);
            JobDescription.Controls.Add(JobDescriptionLabel);

            JobInformation.Controls.Add(JobTitle);
            JobInformation.Controls.Add(JobDescription);

            return JobInformation;
        }

        private string FormatJobDescription(string Description)
        {
            string FormattedDesription = "";

            FormattedDesription = Description.Replace("\n", " ").Replace("\r ", " ");

            if (FormattedDesription.Length >= 150)
                FormattedDesription = FormattedDesription.Substring(0, 147) + "...";

            return FormattedDesription;
        }

        private Job GetJob(int JobID, string SelectedButton)
        {
            string Title = "";
            string Description = "";
            DateTime DateCreated = DateTime.Today;
            DateTime DateCompleted = DateTime.Today;
            bool Status = false;
            int HoursOrMilesStart = 0;
            int HoursOrMilesComplete = 0;
            LinkedList Parts = new LinkedList();
            string UserCreated = "";

            if (SelectedButton == "Incomplete")
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand getJob = new OleDbCommand("SELECT [Title],[Description],[DateCreated],[Status],[HoursOrMilesStart],[HoursOrMilesComplete],[UserCreated] FROM Jobs WHERE JobID=@JobID AND Status=FALSE", connection))
                    {
                        getJob.Parameters.AddWithValue("@JobID", JobID);

                        using (OleDbDataReader reader = getJob.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Title = reader.GetString(0);
                                Description = reader.GetString(1);
                                DateCreated = reader.GetDateTime(2);
                                Status = reader.GetBoolean(3);
                                HoursOrMilesStart = reader.GetInt32(4);
                                HoursOrMilesComplete = reader.GetInt32(5);
                                Parts = GetJobParts(JobID);
                                UserCreated = reader.GetString(6);
                            }
                        }
                    }
                }

                Job job = new Job(JobID, Title, Description, DateCreated, Status, HoursOrMilesStart, HoursOrMilesComplete, Parts, GetUser(UserCreated));
                return job;
            }
            else
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand getJob = new OleDbCommand("SELECT [Title],[Description],[DateCreated],[DateCompleted],[Status],[HoursOrMilesStart],[HoursOrMilesComplete],[UserCreated] FROM Jobs WHERE JobID=@JobID AND Status=TRUE", connection))
                    {
                        getJob.Parameters.AddWithValue("@JobID", JobID);

                        using (OleDbDataReader reader = getJob.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Title = reader.GetString(0);
                                Description = reader.GetString(1);
                                DateCreated = reader.GetDateTime(2);
                                DateCompleted = reader.GetDateTime(3);
                                Status = reader.GetBoolean(4);
                                HoursOrMilesStart = reader.GetInt32(5);
                                HoursOrMilesComplete = reader.GetInt32(6);
                                Parts = GetJobParts(JobID);
                                UserCreated = reader.GetString(7);
                            }
                        }
                    }
                }

                Job job = new Job(JobID, Title, Description, DateCreated, DateCompleted, Status, HoursOrMilesStart, HoursOrMilesComplete, Parts, GetUser(UserCreated));
                return job;
            }

        }

        private LinkedList GetAllIncompleteJobs()
        {
            LinkedList Jobs = new LinkedList();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                if (txtSearch.Text == "")
                {
                    using (OleDbCommand getJob = new OleDbCommand("SELECT [JobID],[Title],[Description],[DateCreated],[Status],[HoursOrMilesStart],[HoursOrMilesComplete],[UserCreated] FROM Jobs WHERE Status=FALSE AND VehicleID=@VehicleID ORDER BY DateCreated ASC", connection))
                    {
                        getJob.Parameters.AddWithValue("@VehicleID", SelectedVehicle?.GetVehicleID());

                        using (OleDbDataReader reader = getJob.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int JobID = reader.GetInt32(0);
                                string Title = reader.GetString(1);
                                string Description = reader.GetString(2);
                                DateTime DateCreated = reader.GetDateTime(3);
                                bool Status = reader.GetBoolean(4);
                                int HoursOrMilesStart = reader.GetInt32(5);
                                int HoursOrMilesComplete = reader.GetInt32(6);
                                LinkedList Parts = GetJobParts(JobID);
                                string UserCreated = reader.GetString(7);

                                Job CurrentJob = new Job(JobID, Title, Description, DateCreated, Status, HoursOrMilesStart, HoursOrMilesComplete, Parts, GetUser(UserCreated));
                                Jobs.AppendJob(CurrentJob);
                            }
                        }
                    }
                }
                else
                {
                    using (OleDbCommand getJob = new OleDbCommand("SELECT [JobID],[Title],[Description],[DateCreated],[Status],[HoursOrMilesStart],[HoursOrMilesComplete],[UserCreated] FROM Jobs WHERE Status=FALSE AND Title LIKE '%" + txtSearch.Text + "%' AND VehicleID=@VehicleID ORDER BY DateCreated ASC", connection))
                    {
                        getJob.Parameters.AddWithValue("@VehicleID", SelectedVehicle?.GetVehicleID());

                        using (OleDbDataReader reader = getJob.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int JobID = reader.GetInt32(0);
                                string Title = reader.GetString(1);
                                string Description = reader.GetString(2);
                                DateTime DateCreated = reader.GetDateTime(3);
                                bool Status = reader.GetBoolean(4);
                                int HoursOrMilesStart = reader.GetInt32(5);
                                int HoursOrMilesComplete = reader.GetInt32(6);
                                LinkedList Parts = GetJobParts(JobID);
                                string UserCreated = reader.GetString(7);

                                Job CurrentJob = new Job(JobID, Title, Description, DateCreated, Status, HoursOrMilesStart, HoursOrMilesComplete, Parts, GetUser(UserCreated));
                                Jobs.AppendJob(CurrentJob);
                            }
                        }
                    }
                }
            }

            return Jobs;
        }

        private LinkedList GetAllCompleteJobs()
        {
            LinkedList Jobs = new LinkedList();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                if (txtSearch.Text == "")
                {
                    using (OleDbCommand getJob = new OleDbCommand("SELECT [JobID],[Title],[Description],[DateCreated],[DateCompleted],[Status],[HoursOrMilesStart],[HoursOrMilesComplete],[UserCreated] FROM Jobs WHERE Status=TRUE AND VehicleID=@VehicleID ORDER BY DateCompleted DESC", connection))
                    {
                        getJob.Parameters.AddWithValue("@VehicleID", SelectedVehicle?.GetVehicleID());

                        using (OleDbDataReader reader = getJob.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int JobID = reader.GetInt32(0);
                                string Title = reader.GetString(1);
                                string Description = reader.GetString(2);
                                DateTime DateCreated = reader.GetDateTime(3);
                                DateTime DateCompleted = reader.GetDateTime(4);
                                bool Status = reader.GetBoolean(5);
                                int HoursOrMilesStart = reader.GetInt32(6);
                                int HoursOrMilesComplete = reader.GetInt32(7);
                                LinkedList Parts = GetJobParts(JobID);
                                string UserCreated = reader.GetString(8);

                                Job CurrentJob = new Job(JobID, Title, Description, DateCreated, DateCompleted, Status, HoursOrMilesStart, HoursOrMilesComplete, Parts, GetUser(UserCreated));
                                Jobs.AppendJob(CurrentJob);
                            }
                        }
                    }
                }
                else
                {
                    using (OleDbCommand getJob = new OleDbCommand("SELECT [JobID],[Title],[Description],[DateCreated],[DateCompleted],[Status],[HoursOrMilesStart],[HoursOrMilesComplete],[UserCreated] FROM Jobs WHERE Status=TRUE AND Title LIKE '%" + txtSearch.Text + "%' AND VehicleID=@VehicleID ORDER BY DateCompleted DESC", connection))
                    {
                        getJob.Parameters.AddWithValue("@VehicleID", SelectedVehicle?.GetVehicleID());

                        using (OleDbDataReader reader = getJob.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int JobID = reader.GetInt32(0);
                                string Title = reader.GetString(1);
                                string Description = reader.GetString(2);
                                DateTime DateCreated = reader.GetDateTime(3);
                                DateTime DateCompleted = reader.GetDateTime(4);
                                bool Status = reader.GetBoolean(5);
                                int HoursOrMilesStart = reader.GetInt32(6);
                                int HoursOrMilesComplete = reader.GetInt32(7);
                                LinkedList Parts = GetJobParts(JobID);
                                string UserCreated = reader.GetString(8);

                                Job CurrentJob = new Job(JobID, Title, Description, DateCreated, DateCompleted, Status, HoursOrMilesStart, HoursOrMilesComplete, Parts, GetUser(UserCreated));
                                Jobs.AppendJob(CurrentJob);
                            }
                        }
                    }
                }
            }

            return Jobs;
        }

        private void UpdateJobList(object sender, EventArgs e)
        {
            if (SelectedButton == "Incomplete")
                PopulateIncompleteJobs(sender, e);
            else
                PopulateCompleteJobs(sender, e);
        }

        private int CheckNumberOfIncompleteJobsExist()
        {
            int result = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                if (txtSearch.Text == "")
                {
                    using (OleDbCommand getNumberOfJobs = new OleDbCommand("SELECT COUNT ([JobID]) FROM Jobs WHERE Status=FALSE", connection))
                        result = (int)getNumberOfJobs.ExecuteScalar();
                }
                else
                {
                    using (OleDbCommand getNumberOfJobs = new OleDbCommand("SELECT COUNT ([JobID]) FROM Jobs WHERE Status=FALSE AND Title LIKE '%" + txtSearch.Text + "%'", connection))
                    {
                        result = (int)getNumberOfJobs.ExecuteScalar();
                    }
                }
            }

            return result;
        }

        private int CheckNumberOfCompleteJobsExist()
        {
            int result = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                if (txtSearch.Text == "")
                {
                    using (OleDbCommand getNumberOfJobs = new OleDbCommand("SELECT COUNT ([JobID]) FROM Jobs WHERE Status=TRUE", connection))
                        result = (int)getNumberOfJobs.ExecuteScalar();
                }
                else
                {
                    using (OleDbCommand getNumberOfJobs = new OleDbCommand("SELECT COUNT ([JobID]) FROM Jobs WHERE Status=TRUE AND Title LIKE '%" + txtSearch.Text + "%'", connection))
                    {
                        result = (int)getNumberOfJobs.ExecuteScalar();
                    }
                }
            }

            return result;
        }
    }
}
