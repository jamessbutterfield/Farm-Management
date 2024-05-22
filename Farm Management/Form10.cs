using Classes.Vehicle;
using Classes.LinkedList;
using System.Data.OleDb;

namespace Farm_Management
{
    public partial class Form10 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\FarmDatabase.accdb;Persist Security Info=False;";

        private bool PartsCostMode;
        private bool HoursOrMilesMode;

        public Form10()
        {
            InitializeComponent();
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
            PartsCostMode = false;
            HoursOrMilesMode = false;
        }

        // Buttons

        private void GenerateReport(object sender, EventArgs e)
        {
            if (PartsCostMode == true)
            {
                if (CheckNumberOfVehiclesSelected() == 0)
                    MessageBox.Show("Please select one or many vehicles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    using (Form9 form9 = new Form9(PartsCost(), "PartsCost"))
                        form9.ShowDialog();
                }
            }
            else if (HoursOrMilesMode == true)
            {
                if (CheckNumberOfVehiclesSelected() == 0 || CheckNumberOfVehiclesSelected() > 1)
                    MessageBox.Show("Please select a single vehicle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show($"The vehicle has done {HoursOrMilesDifference(GetSelectedVehicles().GetVehicle(1))} hours/miles in this time range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Please select an option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PartsCost(object sender, EventArgs e)
        {
            PopulateCheckBox();
            Width = 975;
            Height = 345;
            MaximumSize = new Size(975, 345);
            MinimumSize = new Size(975, 345);
            labelSelectVehicle.Text = "Select Vehicle(s):";
            checkBoxSelectAll.Enabled = true;
            PartsCostMode = true;
            HoursOrMilesMode = false;
            SetDateBoundaries();
        }

        private void HoursOrMiles(object sender, EventArgs e)
        {
            PopulateCheckBox();
            Width = 975;
            Height = 345;
            MaximumSize = new Size(975, 345);
            MinimumSize = new Size(975, 345);
            labelSelectVehicle.Text = "Select Vehicle:";
            checkBoxSelectAll.Enabled = false;
            HoursOrMilesMode = true;
            PartsCostMode = false;
            SetDateBoundaries();
        }

        private void NumberOfJobs(object sender, EventArgs e)
        {
            using (Form9 form9 = new Form9(NumberOfJobs(), "NumberOfJobs"))
                form9.ShowDialog();
        }

        // Vehicle Selection

        private LinkedList GetAllVehiclesWithCompletedJobs()
        {
            LinkedList Vehicles = new LinkedList();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getAllVehicles = new OleDbCommand("SELECT DISTINCT [VehicleType],[Registration] FROM Vehicles,Jobs WHERE Jobs.Status=TRUE AND Vehicles.VehicleID=Jobs.VehicleID", connection))
                {
                    using (OleDbDataReader reader = getAllVehicles.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehicles.AppendVehicle(ConvertRegistrationToVehicle(reader.GetString(0), reader.GetString(1)));
                        }
                    }
                }
            }

            return Vehicles;
        }

        private Vehicle ConvertRegistrationToVehicle(string VehicleType, string Registration)
        {
            int VehicleID = 0;
            string Make = "";
            string Model = "";
            string OilType = "";
            string CoolantType = "";
            string FuelType = "";
            double EngineOilLevel = 0;
            double HydraulicOilLevel = 0;
            int Hours = 0;
            int Miles = 0;
            double LiftingCapacity = 0;
            double LoadCapacity = 0;
            
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                if (VehicleType == "Tractor")
                { 
                    using (OleDbCommand getTractor = new OleDbCommand("SELECT [VehicleID],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[HydraulicOilLevel],[Hours],[LiftingCapacity],[LoadCapacity] FROM Vehicles WHERE Registration=@Registration", connection))
                    {
                        getTractor.Parameters.AddWithValue("@Registration", Registration);
                        using (OleDbDataReader reader = getTractor.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VehicleID = reader.GetInt32(0);
                                Make = reader.GetString(1);
                                Model = reader.GetString(2);
                                OilType = reader.GetString(3);
                                CoolantType = reader.GetString(4);
                                FuelType = reader.GetString(5);
                                EngineOilLevel = reader.GetDouble(6);
                                HydraulicOilLevel = reader.GetDouble(7);
                                Hours = reader.GetInt32(8);
                                LiftingCapacity = reader.GetDouble(9);
                                LoadCapacity = reader.GetDouble(10);
                            }
                        }
                    }
                }
                else if (VehicleType == "Truck")
                {
                    using (OleDbCommand getTruck = new OleDbCommand("SELECT [VehicleID],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[Miles],[LoadCapacity] FROM Vehicles WHERE Registration=@Registration", connection))
                    {
                        getTruck.Parameters.AddWithValue("@Registration", Registration);
                        using (OleDbDataReader reader = getTruck.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VehicleID = reader.GetInt32(0);
                                Make = reader.GetString(1);
                                Model = reader.GetString(2);
                                OilType = reader.GetString(3);
                                CoolantType = reader.GetString(4);
                                FuelType = reader.GetString(5);
                                EngineOilLevel = reader.GetDouble(6);
                                Miles = reader.GetInt32(7);
                                LoadCapacity = reader.GetDouble(8);
                            }
                        }
                    }
                }
                else
                {
                    using (OleDbCommand getCarOrQuadbike = new OleDbCommand("SELECT [VehicleID],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[Miles] FROM Vehicles WHERE Registration=@Registration", connection))
                    {
                        getCarOrQuadbike.Parameters.AddWithValue("@Registration", Registration);
                        using (OleDbDataReader reader = getCarOrQuadbike.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VehicleID = reader.GetInt32(0);
                                Make = reader.GetString(1);
                                Model = reader.GetString(2);
                                OilType = reader.GetString(3);
                                CoolantType = reader.GetString(4);
                                FuelType = reader.GetString(5);
                                EngineOilLevel = reader.GetDouble(6);
                                Miles = reader.GetInt32(7);
                            }
                        }
                    }
                }
            }

            if (VehicleType == "Tractor")
            {
                Tractor tractor = new Tractor(VehicleID, VehicleType, Registration, Make, Model, OilType, CoolantType, FuelType, EngineOilLevel, HydraulicOilLevel, Hours, LiftingCapacity, LoadCapacity);
                return tractor;
            }
            else if (VehicleType == "Truck")
            {
                Truck truck = new Truck(VehicleID, VehicleType, Registration, Make, Model, OilType, CoolantType, FuelType, EngineOilLevel, Miles, LoadCapacity);
                return truck;
            }
            else if (VehicleType == "Car")
            {
                Car car = new Car(VehicleID, VehicleType, Registration, Make, Model, OilType, CoolantType, FuelType, EngineOilLevel, Miles);
                return car;
            }
            else
            {
                Quadbike quadbike = new Quadbike(VehicleID, VehicleType, Registration, Make, Model, OilType, CoolantType, FuelType, EngineOilLevel, Miles);
                return quadbike;
            }
        }

        private void PopulateCheckBox()
        {
            checkedListBoxVehicles.Items.Clear();
            LinkedList Vehicles = GetAllVehiclesWithCompletedJobs();

            for (int i = 1; i <= Vehicles.Count(); i++)
            {
                checkedListBoxVehicles.Items.Add(Vehicles.GetVehicle(i).GetRegistration());
            }
        }

        private int CheckNumberOfVehiclesSelected()
        {
            return checkedListBoxVehicles.CheckedItems.Count;
        }

        private void SelectAllVehicles(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked == true)
            {
                for (int i = 0; i < checkedListBoxVehicles.Items.Count; i++)
                {
                    checkedListBoxVehicles.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBoxVehicles.Items.Count; i++)
                {
                    checkedListBoxVehicles.SetItemChecked(i, false);
                }
            }
        }

        private DateTime GetOldestJobDate()
        {
            DateTime OldestDate = DateTime.Now;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getOldestDate = new OleDbCommand("SELECT TOP 1 [DateCreated] FROM Jobs WHERE DateCompleted IS NOT NULL ORDER BY DateCreated ASC", connection))
                {
                    using (OleDbDataReader reader = getOldestDate.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            OldestDate = reader.GetDateTime(0);
                        }
                    }
                }
            }
            return OldestDate;
        }

        private DateTime GetNewestJobDate()
        {
            DateTime NewestDate = DateTime.Now;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getNewestDate = new OleDbCommand("SELECT TOP 1 [DateCompleted] FROM Jobs WHERE DateCompleted IS NOT NULL ORDER BY DateCompleted DESC", connection))
                {
                    using (OleDbDataReader reader = getNewestDate.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NewestDate = reader.GetDateTime(0);
                        }
                    }
                }
            }
            return NewestDate;
        }

        private void SetDateBoundaries()
        {
            dateTimeFrom.MinDate = GetOldestJobDate();
            dateTimeFrom.MaxDate = GetNewestJobDate();
            dateTimeTo.MinDate = GetOldestJobDate();
            dateTimeTo.MaxDate = GetNewestJobDate();
        }

        private LinkedList GetSelectedVehicles()
        {
            LinkedList AllVehicles = GetAllVehiclesWithCompletedJobs();
            LinkedList SelectedVehicles = new LinkedList();

            for (int i = 0; i < checkedListBoxVehicles.CheckedItems.Count; i++)
            {
                bool Found = false;
                int Index = 1;

                do
                {
                    if (checkedListBoxVehicles.CheckedItems[i].ToString() == AllVehicles.GetVehicle(Index).GetRegistration())
                    {
                        Found = true;
                        SelectedVehicles.AppendVehicle(AllVehicles.GetVehicle(Index));
                    }
                    else
                        Index++;
                }
                while (Found == false);
            }

            return SelectedVehicles;
        }

        // Report Generation

        private int HoursOrMilesDifference(Vehicle vehicle)
        {
            int UpperBound = 0, LowerBound = 0;
            int UpperDateOffset = (DateTime.Today - dateTimeTo.Value.Date).Days;
            int LowerDateOffset = (DateTime.Today - dateTimeFrom.Value.Date).Days;
            
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getUpperBound = new OleDbCommand("SELECT TOP 1 HoursOrMilesComplete FROM Jobs WHERE Jobs.VehicleID=@VehicleID AND Status=TRUE AND DateCompleted BETWEEN Date()-@LowerDateOffset AND Date()-@UpperDateOffset ORDER BY DateCompleted DESC, HoursOrMilesComplete DESC", connection))
                {
                    getUpperBound.Parameters.AddWithValue("@VehicleID", vehicle.GetVehicleID());
                    getUpperBound.Parameters.AddWithValue("@LowerDateOffset", LowerDateOffset);
                    getUpperBound.Parameters.AddWithValue("@UpperDateOffset", UpperDateOffset);
                    if (getUpperBound.ExecuteScalar() == null)
                        UpperBound = 0;
                    else
                        UpperBound = (int)getUpperBound.ExecuteScalar();
                }

                using (OleDbCommand getLowerBound = new OleDbCommand("SELECT TOP 1 HoursOrMilesStart FROM Jobs WHERE Jobs.VehicleID=@VehicleID AND Status=TRUE AND DateCreated BETWEEN Date()-@LowerDateOffset AND Date()-@UpperDateOffset ORDER BY DateCreated ASC, HoursOrMilesStart ASC", connection))
                {
                    getLowerBound.Parameters.AddWithValue("@VehicleID", vehicle.GetVehicleID());
                    getLowerBound.Parameters.AddWithValue("@LowerDateOffset", LowerDateOffset);
                    getLowerBound.Parameters.AddWithValue("@UpperDateOffset", UpperDateOffset);
                    if (getLowerBound.ExecuteScalar() == null)
                        LowerBound = 0;
                    else
                        LowerBound = (int)getLowerBound.ExecuteScalar();
                }
            }

            if (UpperBound == 0 || LowerBound == 0)
                return 0;
            else
                return UpperBound - LowerBound;
        }

        private LinkedList PartsCost()
        {
            LinkedList GraphData = new LinkedList();
            LinkedList SelectedVehicles = GetSelectedVehicles();

            for (int i = 1; i <= SelectedVehicles.Count(); i++)
            {
                GraphData.Append(SelectedVehicles.GetVehicle(i).GetRegistration());
                GraphData.Append(GetVehiclePartsCost(SelectedVehicles.GetVehicle(i)).ToString());
            }

            GraphData.Append(dateTimeFrom.Value.Date.ToString("dd/MM/yyyy"));
            GraphData.Append(dateTimeTo.Value.Date.ToString("dd/MM/yyyy"));

            return GraphData;
        }

        private double GetVehiclePartsCost(Vehicle vehicle)
        {
            double Cost = 0;

            int UpperDateOffset = (DateTime.Today - dateTimeTo.Value.Date).Days;
            int LowerDateOffset = (DateTime.Today - dateTimeFrom.Value.Date).Days;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getVehiclePartsCost = new OleDbCommand("SELECT SUM(Parts.Price) FROM Parts,Jobs,JobParts WHERE Jobs.VehicleID=@VehicleID AND Jobs.Status=TRUE AND Jobs.DateCreated BETWEEN Date()-@LowerDateOffset AND Date()-@UpperDateOffset AND Jobs.JobID=JobParts.JobID AND JobParts.PartID=Parts.PartID", connection))
                {
                    getVehiclePartsCost.Parameters.AddWithValue("@VehicleID", vehicle.GetVehicleID());
                    getVehiclePartsCost.Parameters.AddWithValue("@LowerDateOffset", LowerDateOffset);
                    getVehiclePartsCost.Parameters.AddWithValue("@UpperDateOffset", UpperDateOffset);

                    using (OleDbDataReader reader = getVehiclePartsCost.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            
                            if (!reader.IsDBNull(0))
                                Cost = reader.GetDouble(0);
                        }
                    }
                }
            }

            return Cost;
        }

        private LinkedList NumberOfJobs()
        {
            LinkedList GraphData = new LinkedList();
            LinkedList Vehicles = GetAllVehiclesWithCompletedJobs();

            for (int i = 1; i <= Vehicles.Count(); i++)
            {
                GraphData.Append(Vehicles.GetVehicle(i).GetRegistration());
                GraphData.Append(GetVehicleNumberOfJobs(Vehicles.GetVehicle(i)).ToString());
            }

            return GraphData;
        }

        private int GetVehicleNumberOfJobs(Vehicle vehicle)
        {
            int NumberOfJobs = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getNumberOfJobs = new OleDbCommand("SELECT COUNT ([JobID]) FROM Jobs WHERE VehicleID=@VehicleID AND Status=TRUE", connection))
                {
                    getNumberOfJobs.Parameters.AddWithValue("@VehicleID", vehicle.GetVehicleID());

                    using (OleDbDataReader reader = getNumberOfJobs.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            if (!reader.IsDBNull(0))
                                NumberOfJobs = reader.GetInt32(0);
                        }
                    }
                }
            }

            return NumberOfJobs;
        }
    }
}
