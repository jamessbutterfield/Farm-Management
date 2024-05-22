using System.Data.OleDb;
using Classes.Vehicle;
using Classes.LinkedList;

namespace Farm_Management
{
    public partial class Form4 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\FarmDatabase.accdb;Persist Security Info=False;";

        private Vehicle? VehicleToEdit;
        private bool EditMode;

        public Form4(Vehicle? vehicle)
        {
            InitializeComponent();
            DisableAllTextbox();
            pictureBoxLogo.Load(@"Resources\Logo.png");
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
            EnableEditMode(vehicle);
            EditMode = true;
            btnCreateVehicle.Click += EditVehicle;
            VehicleToEdit = vehicle;
        }

        public Form4()
        {
            InitializeComponent();
            DisableAllTextbox();
            pictureBoxLogo.Load(@"Resources\Logo.png");
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
            btnCreateVehicle.Click += CreateVehicle;
            EditMode = false;
        }

        // Buttons

        private void CreateVehicle(object sender, EventArgs e)
        {
            if (CheckSufficientDetailsEntered() == true)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    if (comboBoxVehicleType.Text == "Tractor")
                    {
                        using (OleDbCommand createTractor = new OleDbCommand("INSERT INTO Vehicles ([VehicleType],[Registration],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[Hours],[HydraulicOilLevel],[LiftingCapacity],[LoadCapacity]) VALUES (@VehicleType,@Registration,@Make,@Model,@OilType,@CoolantType,@FuelType,@EngineOilLevel,@Hours,@HydraulicOilLevel,@LiftingCapacity,@LoadCapacity)", connection))
                        {
                            createTractor.Parameters.AddWithValue("@VehicleType", "Tractor");
                            createTractor.Parameters.AddWithValue("@Registration", txtRegistration.Text);
                            createTractor.Parameters.AddWithValue("@Make", txtMake.Text);
                            createTractor.Parameters.AddWithValue("@Model", txtModel.Text);
                            createTractor.Parameters.AddWithValue("@OilType", txtOilType.Text);
                            createTractor.Parameters.AddWithValue("@CoolantType", txtCoolantType.Text);
                            createTractor.Parameters.AddWithValue("@FuelType", txtFuelType.Text);
                            createTractor.Parameters.AddWithValue("@EngineOilLevel", float.Parse(txtEngineOilLevel.Text));
                            createTractor.Parameters.AddWithValue("@Hours", int.Parse(txtHours.Text));
                            createTractor.Parameters.AddWithValue("@HydraulicOilLevel", float.Parse(txtHydraulicOilLevel.Text));
                            createTractor.Parameters.AddWithValue("@LiftingCapacity", float.Parse(txtLiftingCapacity.Text));
                            createTractor.Parameters.AddWithValue("@LoadCapacity", float.Parse(txtLoadCapacity.Text));
                            createTractor.ExecuteNonQuery();
                        }
                    }
                    else if (comboBoxVehicleType.Text == "Truck")
                    {
                        using (OleDbCommand createTruck = new OleDbCommand("INSERT INTO Vehicles ([VehicleType],[Registration],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[Miles],[LoadCapacity]) VALUES (@VehicleType,@Registration,@Make,@Model,@OilType,@CoolantType,@FuelType,@EngineOilLevel,@Miles,@LoadCapacity)", connection))
                        {
                            createTruck.Parameters.AddWithValue("@VehicleType", "Truck");
                            createTruck.Parameters.AddWithValue("@Registration", txtRegistration.Text);
                            createTruck.Parameters.AddWithValue("@Make", txtMake.Text);
                            createTruck.Parameters.AddWithValue("@Model", txtModel.Text);
                            createTruck.Parameters.AddWithValue("@OilType", txtOilType.Text);
                            createTruck.Parameters.AddWithValue("@CoolantType", txtCoolantType.Text);
                            createTruck.Parameters.AddWithValue("@FuelType", txtFuelType.Text);
                            createTruck.Parameters.AddWithValue("@EngineOilLevel", float.Parse(txtEngineOilLevel.Text));
                            createTruck.Parameters.AddWithValue("@Miles", int.Parse(txtMiles.Text));
                            createTruck.Parameters.AddWithValue("@LoadCapacity", float.Parse(txtLoadCapacity.Text));
                            createTruck.ExecuteNonQuery();
                        }
                    }
                    else if (comboBoxVehicleType.Text == "Quadbike")
                    {
                        using (OleDbCommand createQuadbike = new OleDbCommand("INSERT INTO Vehicles ([VehicleType],[Registration],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[Miles]) VALUES (@VehicleType,@Registration,@Make,@Model,@OilType,@CoolantType,@FuelType,@EngineOilLevel,@Miles)", connection))
                        {
                            createQuadbike.Parameters.AddWithValue("@VehicleType", "Quadbike");
                            createQuadbike.Parameters.AddWithValue("@Registration", txtRegistration.Text);
                            createQuadbike.Parameters.AddWithValue("@Make", txtMake.Text);
                            createQuadbike.Parameters.AddWithValue("@Model", txtModel.Text);
                            createQuadbike.Parameters.AddWithValue("@OilType", txtOilType.Text);
                            createQuadbike.Parameters.AddWithValue("@CoolantType", txtCoolantType.Text);
                            createQuadbike.Parameters.AddWithValue("@FuelType", txtFuelType.Text);
                            createQuadbike.Parameters.AddWithValue("@EngineOilLevel", float.Parse(txtEngineOilLevel.Text));
                            createQuadbike.Parameters.AddWithValue("@Miles", int.Parse(txtMiles.Text));
                            createQuadbike.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (OleDbCommand createCar = new OleDbCommand("INSERT INTO Vehicles ([VehicleType],[Registration],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[Miles]) VALUES (@VehicleType,@Registration,@Make,@Model,@OilType,@CoolantType,@FuelType,@EngineOilLevel,@Miles)", connection))
                        {
                            createCar.Parameters.AddWithValue("@VehicleType", "Car");
                            createCar.Parameters.AddWithValue("@Registration", txtRegistration.Text);
                            createCar.Parameters.AddWithValue("@Make", txtMake.Text);
                            createCar.Parameters.AddWithValue("@Model", txtModel.Text);
                            createCar.Parameters.AddWithValue("@OilType", txtOilType.Text);
                            createCar.Parameters.AddWithValue("@CoolantType", txtCoolantType.Text);
                            createCar.Parameters.AddWithValue("@FuelType", txtFuelType.Text);
                            createCar.Parameters.AddWithValue("@EngineOilLevel", float.Parse(txtEngineOilLevel.Text));
                            createCar.Parameters.AddWithValue("@Miles", int.Parse(txtMiles.Text));
                            createCar.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Vehicle Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3.instance?.RefreshVehicleList(sender, e);
                Close();
            }
        }

        private void EditVehicle(object sender, EventArgs e)
        {
            if (CheckSufficientDetailsEntered() == true)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    if (comboBoxVehicleType.Text == "Tractor")
                    {
                        using (OleDbCommand updateTractor = new OleDbCommand("UPDATE Vehicles SET VehicleType=@VehicleType, Registration=@Registration, Make=@Make, Model=@Model, OilType=@OilType, CoolantType=@CoolantType, FuelType=@FuelType, EngineOilLevel=@EngineOilLevel, Hours=@Hours, HydraulicOilLevel=@HydraulicOilLevel, LiftingCapacity=@LiftingCapacity, LoadCapacity=@LoadCapacity, Miles=NULL WHERE VehicleID=@VehicleID", connection))
                        {
                            updateTractor.Parameters.AddWithValue("@VehicleType", "Tractor");
                            updateTractor.Parameters.AddWithValue("@Registration", txtRegistration.Text);
                            updateTractor.Parameters.AddWithValue("@Make", txtMake.Text);
                            updateTractor.Parameters.AddWithValue("@Model", txtModel.Text);
                            updateTractor.Parameters.AddWithValue("@OilType", txtOilType.Text);
                            updateTractor.Parameters.AddWithValue("@CoolantType", txtCoolantType.Text);
                            updateTractor.Parameters.AddWithValue("@FuelType", txtFuelType.Text);
                            updateTractor.Parameters.AddWithValue("@EngineOilLevel", float.Parse(txtEngineOilLevel.Text));
                            updateTractor.Parameters.AddWithValue("@Hours", int.Parse(txtHours.Text));
                            updateTractor.Parameters.AddWithValue("@HydraulicOilLevel", float.Parse(txtHydraulicOilLevel.Text));
                            updateTractor.Parameters.AddWithValue("@LiftingCapacity", float.Parse(txtLiftingCapacity.Text));
                            updateTractor.Parameters.AddWithValue("@LoadCapacity", float.Parse(txtLoadCapacity.Text));
                            updateTractor.Parameters.AddWithValue("@VehicleID", VehicleToEdit?.GetVehicleID());
                            updateTractor.ExecuteNonQuery();
                        }
                    }
                    else if (comboBoxVehicleType.Text == "Truck")
                    {
                        using (OleDbCommand updateTruck = new OleDbCommand("UPDATE Vehicles SET VehicleType=@VehicleType, Registration=@Registration, Make=@Make, Model=@Model, OilType=@OilType, CoolantType=@CoolantType, FuelType=@FuelType, EngineOilLevel=@EngineOilLevel, Miles=@Miles, LoadCapacity=@LoadCapacity, HydraulicOilLevel=NULL, Hours=NULL, LiftingCapacity=NULL WHERE VehicleID=@VehicleID", connection))
                        {
                            updateTruck.Parameters.AddWithValue("@VehicleType", "Truck");
                            updateTruck.Parameters.AddWithValue("@Registration", txtRegistration.Text);
                            updateTruck.Parameters.AddWithValue("@Make", txtMake.Text);
                            updateTruck.Parameters.AddWithValue("@Model", txtModel.Text);
                            updateTruck.Parameters.AddWithValue("@OilType", txtOilType.Text);
                            updateTruck.Parameters.AddWithValue("@CoolantType", txtCoolantType.Text);
                            updateTruck.Parameters.AddWithValue("@FuelType", txtFuelType.Text);
                            updateTruck.Parameters.AddWithValue("@EngineOilLevel", float.Parse(txtEngineOilLevel.Text));
                            updateTruck.Parameters.AddWithValue("@Miles", int.Parse(txtMiles.Text));
                            updateTruck.Parameters.AddWithValue("@LoadCapacity", float.Parse(txtLoadCapacity.Text));
                            updateTruck.Parameters.AddWithValue("@VehicleID", VehicleToEdit?.GetVehicleID());
                            updateTruck.ExecuteNonQuery();
                        }
                    }
                    else if (comboBoxVehicleType.Text == "Quadbike")
                    {
                        using (OleDbCommand updateQuadbike = new OleDbCommand("UPDATE Vehicles SET VehicleType=@VehicleType, Registration=@Registration, Make=@Make, Model=@Model, OilType=@OilType, CoolantType=@CoolantType, FuelType=@FuelType, EngineOilLevel=@EngineOilLevel, Miles=@Miles, HydraulicOilLevel=NULL, Hours=NULL, LiftingCapacity=NULL, LoadCapacity=NULL WHERE VehicleID=@VehicleID", connection))
                        {
                            updateQuadbike.Parameters.AddWithValue("@VehicleType", "Quadbike");
                            updateQuadbike.Parameters.AddWithValue("@Registration", txtRegistration.Text);
                            updateQuadbike.Parameters.AddWithValue("@Make", txtMake.Text);
                            updateQuadbike.Parameters.AddWithValue("@Model", txtModel.Text);
                            updateQuadbike.Parameters.AddWithValue("@OilType", txtOilType.Text);
                            updateQuadbike.Parameters.AddWithValue("@CoolantType", txtCoolantType.Text);
                            updateQuadbike.Parameters.AddWithValue("@FuelType", txtFuelType.Text);
                            updateQuadbike.Parameters.AddWithValue("@EngineOilLevel", float.Parse(txtEngineOilLevel.Text));
                            updateQuadbike.Parameters.AddWithValue("@Miles", int.Parse(txtMiles.Text));
                            updateQuadbike.Parameters.AddWithValue("@VehicleID", VehicleToEdit?.GetVehicleID());
                            updateQuadbike.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (OleDbCommand updateCar = new OleDbCommand("UPDATE Vehicles SET VehicleType=@VehicleType, Registration=@Registration, Make=@Make, Model=@Model, OilType=@OilType, CoolantType=@CoolantType, FuelType=@FuelType, EngineOilLevel=@EngineOilLevel, Miles=@Miles, HydraulicOilLevel=NULL, Hours=NULL, LiftingCapacity=NULL, LoadCapacity=NULL WHERE VehicleID=@VehicleID", connection))
                        {
                            updateCar.Parameters.AddWithValue("@VehicleType", "Car");
                            updateCar.Parameters.AddWithValue("@Registration", txtRegistration.Text);
                            updateCar.Parameters.AddWithValue("@Make", txtMake.Text);
                            updateCar.Parameters.AddWithValue("@Model", txtModel.Text);
                            updateCar.Parameters.AddWithValue("@OilType", txtOilType.Text);
                            updateCar.Parameters.AddWithValue("@CoolantType", txtCoolantType.Text);
                            updateCar.Parameters.AddWithValue("@FuelType", txtFuelType.Text);
                            updateCar.Parameters.AddWithValue("@EngineOilLevel", float.Parse(txtEngineOilLevel.Text));
                            updateCar.Parameters.AddWithValue("@Miles", int.Parse(txtMiles.Text));
                            updateCar.Parameters.AddWithValue("@VehicleID", VehicleToEdit?.GetVehicleID());
                            updateCar.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Vehicle Edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3.instance?.RefreshVehicleList(sender, e);
                Form3.instance?.RefreshInformationPanel(sender, e);
                Close();
            }
        }

        // Edit Vehicle Mode

        private void EnableEditMode(Vehicle? vehicle)
        {
            Text = "Edit Vehicle";
            btnCreateVehicle.Text = "EDIT VEHICLE";

            EnableTextbox(vehicle.GetVehicleType());
            comboBoxVehicleType.SelectedItem = vehicle.GetVehicleType();

            AutoFillVehicleDetails(vehicle);
        }

        private void AutoFillVehicleDetails(Vehicle vehicle)
        {
            LinkedList vehicleDetails = vehicle.GetAllVehicleDetails();

            if (vehicle.GetVehicleType() == "Tractor")
            {
                txtRegistration.Text = vehicleDetails.GetItem(3);
                txtMake.Text = vehicleDetails.GetItem(4);
                txtModel.Text = vehicleDetails.GetItem(5);
                txtOilType.Text = vehicleDetails.GetItem(6);
                txtCoolantType.Text = vehicleDetails.GetItem(7);
                txtFuelType.Text = vehicleDetails.GetItem(8);
                txtEngineOilLevel.Text = vehicleDetails.GetItem(9);
                txtHours.Text = vehicleDetails.GetItem(11);
                txtHydraulicOilLevel.Text = vehicleDetails.GetItem(10);
                txtLiftingCapacity.Text = vehicleDetails.GetItem(12);
                txtLoadCapacity.Text = vehicleDetails.GetItem(13);
            }
            else if (vehicle.GetVehicleType() == "Truck")
            {
                txtRegistration.Text = vehicleDetails.GetItem(3);
                txtMake.Text = vehicleDetails.GetItem(4);
                txtModel.Text = vehicleDetails.GetItem(5);
                txtOilType.Text = vehicleDetails.GetItem(6);
                txtCoolantType.Text = vehicleDetails.GetItem(7);
                txtFuelType.Text = vehicleDetails.GetItem(8);
                txtEngineOilLevel.Text = vehicleDetails.GetItem(9);
                txtMiles.Text = vehicleDetails.GetItem(10);
                txtLoadCapacity.Text = vehicleDetails.GetItem(11);
            }
            else
            {
                txtRegistration.Text = vehicleDetails.GetItem(3);
                txtMake.Text = vehicleDetails.GetItem(4);
                txtModel.Text = vehicleDetails.GetItem(5);
                txtOilType.Text = vehicleDetails.GetItem(6);
                txtCoolantType.Text = vehicleDetails.GetItem(7);
                txtFuelType.Text = vehicleDetails.GetItem(8);
                txtEngineOilLevel.Text = vehicleDetails.GetItem(9);
                txtMiles.Text = vehicleDetails.GetItem(10);
            }
        }

        // Input Restrictions

        private void UpdateTextboxStatus(object sender, EventArgs e)
        {
            DisableAllTextbox();
            EnableTextbox(comboBoxVehicleType.Text);
        }

        private void DisableAllTextbox()
        {
            txtRegistration.Enabled = false;
            txtMake.Enabled = false;
            txtModel.Enabled = false;
            txtOilType.Enabled = false;
            txtCoolantType.Enabled = false;
            txtFuelType.Enabled = false;
            txtEngineOilLevel.Enabled = false;
            txtHours.Enabled = false;
            txtMiles.Enabled = false;
            txtHydraulicOilLevel.Enabled = false;
            txtLiftingCapacity.Enabled = false;
            txtLoadCapacity.Enabled = false;
        }

        private void EnableTextbox(string vehicleType)
        {
            if (vehicleType == "Tractor")
            {
                txtRegistration.Enabled = true;
                txtMake.Enabled = true;
                txtModel.Enabled = true;
                txtOilType.Enabled = true;
                txtCoolantType.Enabled = true;
                txtFuelType.Enabled = true;
                txtEngineOilLevel.Enabled = true;
                txtHours.Enabled = true;
                txtHydraulicOilLevel.Enabled = true;
                txtLiftingCapacity.Enabled = true;
                txtLoadCapacity.Enabled = true;
            }
            else if (vehicleType == "Truck")
            {
                txtRegistration.Enabled = true;
                txtMake.Enabled = true;
                txtModel.Enabled = true;
                txtOilType.Enabled = true;
                txtCoolantType.Enabled = true;
                txtFuelType.Enabled = true;
                txtEngineOilLevel.Enabled = true;
                txtMiles.Enabled = true;
                txtLoadCapacity.Enabled = true;
            }
            else
            {
                txtRegistration.Enabled = true;
                txtMake.Enabled = true;
                txtModel.Enabled = true;
                txtOilType.Enabled = true;
                txtCoolantType.Enabled = true;
                txtFuelType.Enabled = true;
                txtEngineOilLevel.Enabled = true;
                txtMiles.Enabled = true;
            }
        }

        // Validation Checks

        private bool CheckSufficientDetailsEntered()
        {
            if (CheckDropDownSelected() == false)
                return false;
            else
            {
                if (comboBoxVehicleType.Text == "Tractor")
                {
                    if (CheckValidRegistration() == true && CheckMakeAndModel() == true && CheckOilType() == true && CheckCoolantType() == true && CheckFuelType() == true && CheckEngineOilLevel() == true && CheckHours() == true && CheckHydraulicOilLevel() == true && CheckLiftingCapacity() == true && CheckLoadCapacity() == true)
                        return true;
                    else
                        return false;
                }
                else if (comboBoxVehicleType.Text == "Truck")
                {
                    if (CheckValidRegistration() == true && CheckMakeAndModel() == true && CheckOilType() == true && CheckCoolantType() == true && CheckFuelType() == true && CheckEngineOilLevel() == true && CheckMiles() == true && CheckLoadCapacity() == true)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (CheckValidRegistration() == true && CheckMakeAndModel() == true && CheckOilType() == true && CheckCoolantType() == true && CheckFuelType() == true && CheckEngineOilLevel() == true && CheckMiles() == true)
                        return true;
                    else
                        return false;
                }
            }
        }

        private bool CheckDropDownSelected()
        {
            if (comboBoxVehicleType.Text == "")
            {
                MessageBox.Show("Select a Vehicle Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckValidRegistration()
        {
            if (txtRegistration.Text.Length > 7 || txtRegistration.Text.Length < 2)
            {
                MessageBox.Show("Invalid Registration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                int alphabeticalCharacters = 0, numericalCharacters = 0;

                foreach (char character in txtRegistration.Text)
                {
                    if (character >= 'A' && character <= 'Z')
                        alphabeticalCharacters++;
                    else if (character >= '0' && character <= '9')
                        numericalCharacters++;
                }

                if (alphabeticalCharacters >= 1 && numericalCharacters >= 1 && CheckRegistrationDuplicates() == false)
                    return true;
                else
                {
                    MessageBox.Show("Invalid Registration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private bool CheckRegistrationDuplicates()
        {
            int result = 0;
            
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand checkDuplicates = new OleDbCommand("SELECT COUNT ([Registration]) FROM Vehicles WHERE Registration=@Registration", connection))
                {
                    checkDuplicates.Parameters.AddWithValue("@Registration", txtRegistration.Text);
                    result = (int)checkDuplicates.ExecuteScalar();
                }
            }

            if (result == 0)
                return false;
            else if (EditMode == true)
            {
                if (VehicleToEdit.GetRegistration() == txtRegistration.Text)
                    return false;
            }

            return true;
        }

        private bool CheckMiles()
        {
            if (txtMiles.Text == "")
            {
                MessageBox.Show("Vehicle Miles must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    int miles = int.Parse(txtMiles.Text);
                }
                catch
                {
                    MessageBox.Show("Miles must be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool CheckHours()
        {
            if (txtHours.Text == "")
            {
                MessageBox.Show("Vehicle Hours must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    int hours = int.Parse(txtHours.Text);
                }
                catch
                {
                    MessageBox.Show("Hours must be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool CheckMakeAndModel()
        {
            if (txtMake.Text == "")
            {
                MessageBox.Show("Vehicle Make must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtModel.Text == "")
            {
                MessageBox.Show("Vehicle Model must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckEngineOilLevel()
        {
            if (txtEngineOilLevel.Text == "")
            {
                MessageBox.Show("Vehicle Engine Oil Level must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    float engineOilLevel = float.Parse(txtEngineOilLevel.Text);
                }
                catch
                {
                    MessageBox.Show("Engine Oil Level must be numerical", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool CheckOilType()
        {
            if (txtOilType.Text == "")
            {
                MessageBox.Show("Vehicle Oil Type must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckCoolantType()
        {
            if (txtCoolantType.Text == "")
            {
                MessageBox.Show("Vehicle CoolantType Type must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckFuelType()
        {
            if (txtFuelType.Text == "")
            {
                MessageBox.Show("Vehicle Fuel Type must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckHydraulicOilLevel()
        {
            if (txtHydraulicOilLevel.Text == "")
            {
                MessageBox.Show("Vehicle Hydraulic Oil Level must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    float hydraulicOilLevel = float.Parse(txtHydraulicOilLevel.Text);
                }
                catch
                {
                    MessageBox.Show("Hydraulic Oil Level must be numerical", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool CheckLoadCapacity()
        {
            if (txtLoadCapacity.Text == "")
            {
                MessageBox.Show("Vehicle Load Capacity must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    float loadCapacity = float.Parse(txtLoadCapacity.Text);
                }
                catch
                {
                    MessageBox.Show("Load Capacity must be numerical", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool CheckLiftingCapacity()
        {
            if (txtLiftingCapacity.Text == "")
            {
                MessageBox.Show("Vehicle Lifting Capacity must be entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    float liftingCapacity = float.Parse(txtLiftingCapacity.Text);
                }
                catch
                {
                    MessageBox.Show("Lifting Capacity must be numerical", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}
