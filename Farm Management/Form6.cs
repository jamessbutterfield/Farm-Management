using Classes.LinkedList;
using Classes.Part;
using Classes.Job;
using System.Data.OleDb;
using Classes.Vehicle;

namespace Farm_Management
{
    public partial class Form6 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\FarmDatabase.accdb;Persist Security Info=False;";

        public static Form6? instance;

        public LinkedList? SelectedParts;
        private Vehicle? SelectedVehicle;
        private bool JobCompleted;

        private Job? JobToEdit;

        public Form6(Job? JobToEdit, Vehicle? VehicleToEdit)
        {
            InitializeComponent();
            pictureBoxLogo.Load(@"Resources\Logo.png");
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
            this.JobToEdit = JobToEdit;
            SelectedVehicle = VehicleToEdit;
            instance = this;
            SelectedParts = new LinkedList();
            btnCreateOrEdit.Click += EditJob;
            btnCreateOrEdit.Text = "EDIT JOB";
            Text = "Edit Job";
            if (JobToEdit?.GetStatus() == true)
                JobCompleted = true;
            JobCompleted = false;
            AutoFillDetails();
        }

        public Form6()
        {
            InitializeComponent();
            pictureBoxLogo.Load(@"Resources\Logo.png");
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
            instance = this;
            SelectedParts = new LinkedList();
            btnCreateOrEdit.Click += CreateJob;
            HideEditMode();
            JobCompleted = false;
        }

        // Buttons

        private void CreateJob(object sender, EventArgs e)
        {
            if (CheckSufficientDetailsEntered() == true)
            {
                int JobID = GenerateNewJobID();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand createJob = new OleDbCommand("INSERT INTO Jobs ([JobID],[VehicleID],[Title],[Description],[DateCreated],[HoursOrMilesStart],[HoursOrMilesComplete],[UserCreated]) VALUES (@JobID,@VehicleID,@Title,@Description,@DateCreated,@HoursOrMilesStart,@HoursOrMilesComplete,@UserCreated)", connection))
                    {
                        createJob.Parameters.AddWithValue("@JobID", JobID);
                        createJob.Parameters.AddWithValue("@VehicleID", Form3.instance?.SelectedVehicle?.GetVehicleID());
                        createJob.Parameters.AddWithValue("@Title", txtJobTitle.Text);
                        createJob.Parameters.AddWithValue("@Description", txtJobDescription.Text);
                        createJob.Parameters.AddWithValue("@DateCreated", DateTime.Today);
                        if (Form3.instance?.SelectedVehicle?.GetVehicleType() == "Tractor")
                            createJob.Parameters.AddWithValue("@HoursOrMilesStart", int.Parse(Form5.instance?.SelectedVehicle.GetAllVehicleDetails().GetItem(11)));
                        else
                            createJob.Parameters.AddWithValue("@HoursOrMilesStart", int.Parse(Form5.instance?.SelectedVehicle.GetAllVehicleDetails().GetItem(10)));
                        createJob.Parameters.AddWithValue("@HoursOrMilesComplete", 0);
                        createJob.Parameters.AddWithValue("@UserCreated", Form3.instance?.CurrentUser?.GetUsername());
                        createJob.ExecuteNonQuery();
                    }

                    if (SelectedParts?.Count() != 0)
                    {
                        for (int i = 1; i <= SelectedParts?.Count(); i++)
                        {
                            using (OleDbCommand addPart = new OleDbCommand("INSERT INTO JobParts ([JobID],[PartID]) VALUES (@JobID,@PartID)", connection))
                            {
                                addPart.Parameters.AddWithValue("@JobID", JobID);
                                addPart.Parameters.AddWithValue("@PartID", SelectedParts.GetPart(i).GetPartID());
                                addPart.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("Job Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form5.instance?.PopulateIncompleteJobs(sender, e);
                Form5.instance?.RefreshJobInformationPanel();
                Close();
            }
        }

        private void EditJob(object sender, EventArgs e)
        {
            if (JobCompleted == true)
            {
                if (CheckSufficientDetailsToComplete() == true)
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        using (OleDbCommand editJob = new OleDbCommand("UPDATE Jobs SET Title=@Title,Description=@Description,DateCompleted=@DateCompleted,Status=TRUE,HoursOrMilesComplete=@HoursOrMilesComplete WHERE JobID=@JobID", connection))
                        {
                            editJob.Parameters.AddWithValue("@Title", txtJobTitle.Text);
                            editJob.Parameters.AddWithValue("@Description", txtJobDescription.Text);
                            editJob.Parameters.AddWithValue("@DateCompleted", DateTime.Today);
                            editJob.Parameters.AddWithValue("@HoursOrMilesComplete", int.Parse(txtVehicleHoursOrMiles.Text));
                            editJob.Parameters.AddWithValue("@JobID", JobToEdit?.GetJobID());
                            editJob.ExecuteNonQuery();
                        }

                        using (OleDbCommand deleteExistingParts = new OleDbCommand("DELETE FROM JobParts WHERE JobID=@JobID", connection))
                        {
                            deleteExistingParts.Parameters.AddWithValue("@JobID", JobToEdit?.GetJobID());
                            deleteExistingParts.ExecuteNonQuery();
                        }

                        if (SelectedParts?.Count() != 0)
                        {
                            for (int i = 1; i <= SelectedParts?.Count(); i++)
                            {
                                using (OleDbCommand addPart = new OleDbCommand("INSERT INTO JobParts ([JobID],[PartID]) VALUES (@JobID,@PartID)", connection))
                                {
                                    addPart.Parameters.AddWithValue("@JobID", JobToEdit?.GetJobID());
                                    addPart.Parameters.AddWithValue("@PartID", SelectedParts.GetPart(i).GetPartID());
                                    addPart.ExecuteNonQuery();
                                }
                            }
                        }

                        if (SelectedVehicle?.GetVehicleType() == "Tractor")
                        {
                            using (OleDbCommand updateVehicleHours = new OleDbCommand("UPDATE Vehicles SET Hours=@Hours WHERE VehicleID=@VehicleID", connection))
                            {
                                updateVehicleHours.Parameters.AddWithValue("@Hours", int.Parse(txtVehicleHoursOrMiles.Text));
                                updateVehicleHours.Parameters.AddWithValue("@VehicleID", SelectedVehicle.GetVehicleID());
                                updateVehicleHours.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (OleDbCommand updateVehicleMiles = new OleDbCommand("UPDATE Vehicles SET Miles=@Miles WHERE VehicleID=@VehicleID", connection))
                            {
                                updateVehicleMiles.Parameters.AddWithValue("@VehicleID", SelectedVehicle?.GetVehicleID());
                                updateVehicleMiles.Parameters.AddWithValue("@Miles", int.Parse(txtVehicleHoursOrMiles.Text));
                                updateVehicleMiles.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Job Edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form5.instance?.PopulateIncompleteJobs(sender, e);
                    Form5.instance?.RefreshJobInformationPanel();
                    Form5.instance?.RefreshSelectedVehicle();
                    Close();
                }
            }
            else
            {
                if (CheckSufficientDetailsEntered() == true)
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        using (OleDbCommand editJob = new OleDbCommand("UPDATE Jobs SET Title=@Title, Description=@Description, DateCompleted=NULL, Status=FALSE, HoursOrMilesComplete=@HoursOrMilesComplete WHERE JobID=@JobID", connection))
                        {
                            editJob.Parameters.AddWithValue("@Title", txtJobTitle.Text);
                            editJob.Parameters.AddWithValue("@Description", txtJobDescription.Text);
                            editJob.Parameters.AddWithValue("@HoursOrMilesComplete", 0);
                            editJob.Parameters.AddWithValue("@JobID", JobToEdit?.GetJobID());
                            editJob.ExecuteNonQuery();
                        }

                        using (OleDbCommand deleteExistingParts = new OleDbCommand("DELETE FROM JobParts WHERE JobID=@JobID", connection))
                        {
                            deleteExistingParts.Parameters.AddWithValue("@JobID", JobToEdit?.GetJobID());
                            deleteExistingParts.ExecuteNonQuery();
                        }

                        if (SelectedParts?.Count() != 0)
                        {
                            for (int i = 1; i <= SelectedParts?.Count(); i++)
                            {
                                using (OleDbCommand addPart = new OleDbCommand("INSERT INTO JobParts ([JobID],[PartID]) VALUES (@JobID,@PartID)", connection))
                                {
                                    addPart.Parameters.AddWithValue("@JobID", JobToEdit?.GetJobID());
                                    addPart.Parameters.AddWithValue("@PartID", SelectedParts.GetPart(i).GetPartID());
                                    addPart.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    MessageBox.Show("Job Edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form5.instance?.PopulateIncompleteJobs(sender, e);
                    Form5.instance?.RefreshJobInformationPanel();
                    Close();
                }
            }
        }

        private void AddPart(object sender, EventArgs e)
        {
            using (Form7 form7 = new Form7())
                form7.ShowDialog();
        }

        private void RemovePart(object sender, EventArgs e)
        {
            if (listBoxParts.SelectedItem != null)
            {
                Part PartToRemove = ConvertSelectedPartToPart(listBoxParts.SelectedItem.ToString());
                SelectedParts?.RemovePart(PartToRemove.GetPartID());
                AddPartsToListBox(SelectedParts);
            }
            else
                MessageBox.Show("Please select a Part", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Form Events

        private void RefreshJobInformationPanel(object sender, FormClosedEventArgs e)
        {
            Form5.instance?.RefreshJobInformationPanel();
        }

        // Edit Mode

        private void CompleteJob(object sender, EventArgs e)
        {
            if (checkBoxJobComplete.Checked == true)
            {
                if (CheckVehicleHoursOrMilesToComplete() == true)
                    JobCompleted = true;
                else
                    checkBoxJobComplete.Checked = false;
            }
            else
            {
                txtVehicleHoursOrMiles.Text = "";
                JobCompleted = false;
            }
        }

        private void AutoFillDetails()
        {
            txtJobTitle.Text = JobToEdit?.GetTitle();
            txtJobDescription.Text = JobToEdit?.GetDescription();
            SelectedParts = JobToEdit?.GetParts();
            if (JobToEdit?.GetStatus() == true)
            {
                txtVehicleHoursOrMiles.Text = JobToEdit.GetHoursOrMilesComplete().ToString();
                checkBoxJobComplete.Checked = true;
            }
            AddPartsToListBox(SelectedParts);
        }

        private void HideEditMode()
        {
            txtVehicleHoursOrMiles.Visible = false;
            labelHoursOrMiles.Visible = false;
            labelJobComplete.Visible = false;
            checkBoxJobComplete.Visible = false;
        }

        // Creating Job

        public void AddPartsToListBox(LinkedList? Parts)
        {
            listBoxParts.Items.Clear();

            for (int i = 1; i <= Parts?.Count(); i++)
            {
                listBoxParts.Items.Add($"{Parts.GetPart(i).GetName()} [{Parts.GetPart(i).GetNumber()}]");
            }
        }

        private int GenerateNewJobID()
        {
            int Result = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand generateJobID = new OleDbCommand("SELECT TOP 1 [JobID] FROM Jobs ORDER BY JobID DESC", connection))
                {
                    using (OleDbDataReader reader = generateJobID.ExecuteReader())
                    {
                        if (reader.Read())
                            Result = Convert.ToInt32(reader[0]);
                    }
                }
            }

            return Result + 1;
        }

        private Part GetPart(string PartNumber)
        {
            int PartID = 0;
            string PartName = "";
            double Price = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getPart = new OleDbCommand("SELECT * FROM Parts WHERE PartNumber=@PartNumber", connection))
                {
                    getPart.Parameters.AddWithValue("@PartNumber", PartNumber);
                    using (OleDbDataReader reader = getPart.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PartID = reader.GetInt32(0);
                            PartName = reader.GetString(1);
                            Price = reader.GetDouble(3);
                        }
                    }
                }
            }

            Part part = new Part(PartID, PartName, PartNumber, Price);
            return part;
        }

        private Part ConvertSelectedPartToPart(string? SelectedItem)
        {
            int StartIndex = 0;
            
            for (int i = 0; i < SelectedItem?.Length; i++)
            {
                if (SelectedItem[i] == '[')
                    StartIndex = i + 1;
            }

            string PartNumber = "";

            for (int j = StartIndex; j < SelectedItem?.Length - 1; j++)
            {
                PartNumber += SelectedItem?[j];
            }

            return GetPart(PartNumber);
        }

        // Validation Checks

        private bool CheckSufficientDetailsEntered()
        {
            if (CheckTitle() == true && CheckDescription() == true && CheckVehicleHoursOrMiles() == true)
                return true;

            return false;
        }

        private bool CheckSufficientDetailsToComplete()
        {
            if (CheckTitle() == true && CheckDescription() == true && CheckVehicleHoursOrMilesToComplete() == true && CheckChecboxChecked() == true)
                return true;

            return false;
        }

        private bool CheckChecboxChecked()
        {
            if (checkBoxJobComplete.Checked == true)
                return true;

            return false;
        }

        private bool CheckTitle()
        {
            if (txtJobTitle.Text == "")
            {
                MessageBox.Show("Job Title must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckDescription()
        {
            if (txtJobDescription.Text == "")
            {
                MessageBox.Show("Job Description must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckVehicleHoursOrMiles()
        {
            if (txtVehicleHoursOrMiles.Text == "")
                return true;
            else
            {
                try
                {
                    int hoursOrMiles = int.Parse(txtVehicleHoursOrMiles.Text);
                }
                catch
                {
                    MessageBox.Show("Vehicle Hours or Miles must be an Integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool CheckVehicleHoursOrMilesToComplete()
        {
            if (txtVehicleHoursOrMiles.Text == "")
            {
                MessageBox.Show("Please enter Vehicle Hours or Miles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    int hoursOrMiles = int.Parse(txtVehicleHoursOrMiles.Text);
                }
                catch
                {
                    MessageBox.Show("Vehicle Hours or Miles must be an Integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (CheckValidVehicleHoursOrMiles(SelectedVehicle) == false)
                return false;

            return true;
        }

        private bool CheckValidVehicleHoursOrMiles(Vehicle? vehicle)
        {
            LinkedList vehicleDetails = vehicle.GetAllVehicleDetails();

            int Hours = 0;
            int Miles = 0;

            if (vehicle.GetVehicleType() == "Tractor")
            {
                Hours = int.Parse(vehicleDetails.GetItem(11));
                if (int.Parse(txtVehicleHoursOrMiles.Text) < Hours)
                {
                    MessageBox.Show("Vehicle Hours cannot be less than its current Hours", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                Miles = int.Parse(vehicleDetails.GetItem(10));
                if (int.Parse(txtVehicleHoursOrMiles.Text) < Miles)
                {
                    MessageBox.Show("Vehicle Miles cannot be less than its current Miles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}
