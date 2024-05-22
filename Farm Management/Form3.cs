using System.Data.OleDb;
using Classes.Vehicle;
using Classes.LinkedList;
using Classes.User;

namespace Farm_Management
{
    public partial class Form3 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\FarmDatabase.accdb;Persist Security Info=False;";

        public static Form3 ?instance;

        public User? CurrentUser;
        public Vehicle? SelectedVehicle;

        public Form3(User CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            pictureBoxLogo.Load(@"Resources\Logo.png");
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
            instance = this;
        }

        // Form Events

        private void OnLoad(object sender, EventArgs e)
        {
            PopulatePanel();
        }

        // Buttons

        private void CreateVehicle(object sender, EventArgs e)
        {
            using (Form4 form4 = new Form4())
                form4.ShowDialog();
        }

        private void EditVehicle(object sender, EventArgs e)
        {
            using (Form4 form4 = new Form4(SelectedVehicle))
                form4.ShowDialog();
        }

        private void DeleteVehicle(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this vehicle?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand deleteVehicle = new OleDbCommand("DELETE FROM Vehicles WHERE VehicleID=@VehicleID", connection))
                    {
                        deleteVehicle.Parameters.AddWithValue("@VehicleID", SelectedVehicle?.GetVehicleID());
                        deleteVehicle.ExecuteNonQuery();
                    }
                }

                RefreshInformationPanel(sender, e);
                RefreshVehicleList(sender, e);
            }
        }
        
        private void ViewJobs(object sender, EventArgs e)
        {
            using (Form5 form5 = new Form5(SelectedVehicle))
                form5.ShowDialog();
        }

        private void GenerateVehicleButton(string iconType, string registration)
        {
            Panel vehicleInformation = new Panel();
            vehicleInformation.Dock = DockStyle.Fill;

            vehicleInformation.Controls.Add(GenerateIcon(iconType, registration));
            vehicleInformation.Controls.Add(GenerateLabel(registration));

            layoutPanelVehicles.Controls.Add(vehicleInformation);
        }

        private void ViewStatistics(object sender, EventArgs e)
        {
            if (CheckNumberOfVehiclesExist() == 0)
                MessageBox.Show("There are no vehicles to display statistics", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                using (Form10 form10 = new Form10())
                    form10.ShowDialog();
            }
        }

        // Vehicle Grid

        private void PopulatePanel()
        {
            LinkedList vehicles = PopulateLinkedList();
            int LinkedListPosition = 1;

            if (CheckNumberOfVehiclesExist() == 0)
                GenerateVehicleButton("Add", "");
            else if (CheckNumberOfVehiclesExist() <= 24)
            {
                for (int i = 1; i <= CheckNumberOfVehiclesExist(); i++)
                {
                    GenerateVehicleButton($"{vehicles.GetItem(LinkedListPosition)}", $"{vehicles.GetItem(LinkedListPosition + 1)}");
                    LinkedListPosition = LinkedListPosition + 2;
                }

                GenerateVehicleButton("Add", "");
            }
            else
            {
                for (int i = 1; i <= CheckNumberOfVehiclesExist(); i++)
                {
                    GenerateVehicleButton($"{vehicles.GetItem(LinkedListPosition)}", $"{vehicles.GetItem(LinkedListPosition + 1)}");
                    LinkedListPosition = LinkedListPosition + 2;
                }
            }
        }

        private LinkedList PopulateLinkedList()
        {
            LinkedList vehicles = new LinkedList();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getVehicleData = new OleDbCommand("SELECT TOP 25 [VehicleType],[Registration] FROM Vehicles", connection))
                {
                    using (OleDbDataReader reader = getVehicleData.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vehicles.Append(reader.GetString(0));
                            vehicles.Append(reader.GetString(1).ToUpper());
                        }
                    }
                }
            }

            return vehicles;
        }

        public void RefreshVehicleList(object sender, EventArgs e)
        {
            layoutPanelVehicles.Controls.Clear();
            PopulatePanel();
        }

        private int CheckNumberOfVehiclesExist()
        {
            int result = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getNumberOfVehicles = new OleDbCommand("SELECT COUNT ([Registration]) FROM Vehicles", connection))
                    result = (int)getNumberOfVehicles.ExecuteScalar();
            }

            return result;
        }

        private PictureBox GenerateIcon(string iconType, string registration)
        {
            PictureBox icon = new PictureBox();
            icon.Width = 104;
            icon.Height = 104;
            icon.Dock = DockStyle.Fill;
            icon.SizeMode = PictureBoxSizeMode.CenterImage;
            icon.Cursor = Cursors.Hand;

            string[] TagInformation = { $"{iconType}", $"{registration}" };

            if (iconType == "Add")
            {
                icon.Load(@"Resources\Add.png");
                icon.Click += CreateVehicle;
            }
            if (iconType == "Tractor")
            {
                icon.Load(@"Resources\Tractor.png");
                icon.Tag = TagInformation;
                icon.Click += DisplayVehicleInformation;
            }
            if (iconType == "Car")
            {
                icon.Load(@"Resources\Car.png");
                icon.Tag = TagInformation;
                icon.Click += DisplayVehicleInformation;
            }
            if (iconType == "Quadbike")
            {
                icon.Load(@"Resources\Quadbike.png");
                icon.Tag = TagInformation;
                icon.Click += DisplayVehicleInformation;
            }
            if (iconType == "Truck")
            {
                icon.Load(@"Resources\Truck.png");
                icon.Tag = TagInformation;
                icon.Click += DisplayVehicleInformation;
            }

            return icon;
        }

        private Label GenerateLabel(string registration)
        {
            Label registrationLabel = new Label();
            registrationLabel.Text = registration;
            registrationLabel.Font = new Font("Arial Rounded MT Bold", 10);
            registrationLabel.TextAlign = ContentAlignment.TopCenter;
            registrationLabel.Dock = DockStyle.Bottom;

            return registrationLabel;
        }

        // Vehicle Information Panel

        public void RefreshInformationPanel(object sender, EventArgs e)
        {
            panelVehicleInformation.Controls.Clear();
        }

        private Panel CreateRegistrationPanel(string Registration)
        {
            Font LabelFont = new Font("Arial Rounded MT Bold", 18);

            Panel panelRegistration = new Panel();
            panelRegistration.Location = new Point(229, 143);
            panelRegistration.Height = 35;
            panelRegistration.Width = 146;

            Label RegistrationLabel = new Label();
            panelRegistration.Controls.Add(RegistrationLabel);
            RegistrationLabel.Font = LabelFont;
            RegistrationLabel.ForeColor = Color.Black;
            RegistrationLabel.BackColor = Color.Gold;
            RegistrationLabel.TextAlign = ContentAlignment.MiddleCenter;
            RegistrationLabel.Dock = DockStyle.Fill;
            RegistrationLabel.BorderStyle = BorderStyle.FixedSingle;
            RegistrationLabel.Text = Registration;
            RegistrationLabel.AutoSize = false;

            return panelRegistration;
        }

        private Panel CreateMakeAndModelPanel(Vehicle vehicle)
        {
            Font LabelFont = new Font("Arial Rounded MT Bold", 18);

            Panel panelMakeAndModel = new Panel();
            panelMakeAndModel.Location = new Point(3, 68);
            panelMakeAndModel.Height = 69;
            panelMakeAndModel.Width = 598;

            Label MakeAndModel = new Label();
            panelMakeAndModel.Controls.Add(MakeAndModel);
            MakeAndModel.Font = LabelFont;
            MakeAndModel.ForeColor = Color.DarkCyan;
            MakeAndModel.TextAlign = ContentAlignment.MiddleCenter;
            MakeAndModel.Dock = DockStyle.Fill;
            MakeAndModel.Text = vehicle.GetMake().ToUpper() + " " + vehicle.GetModel().ToUpper();
            MakeAndModel.AutoSize = false;

            return panelMakeAndModel;
        }

        private void DisplayVehicleInformation(object sender, EventArgs e)
        {
            panelVehicleInformation.Controls.Clear();
            
            PictureBox icon = (PictureBox)sender;
            string[] TagInformation = (string[])icon.Tag;

            Vehicle vehicle = GetVehicleDetails(TagInformation[0], TagInformation[1]);
            SelectedVehicle = vehicle;

            panelVehicleInformation.Controls.Add(CreateMakeAndModelPanel(vehicle));
            panelVehicleInformation.Controls.Add(CreateRegistrationPanel(TagInformation[1]));

            if (TagInformation[0] == "Tractor")
            {
                GenerateLabelHeadings(TagInformation[0]);
                GenerateLabelValues(vehicle);
            }
            else if (TagInformation[0] == "Truck")
            {
                GenerateLabelHeadings(TagInformation[0]);
                GenerateLabelValues(vehicle);
            }
            else
            {
                GenerateLabelHeadings(TagInformation[0]);
                GenerateLabelValues(vehicle);
            }

            GenerateOptionButtons();
        }

        private void GenerateLabelHeadings(string VehicleType)
        {
            Font LabelFont = new Font("Arial Rounded MT Bold", 11);

            if (VehicleType == "Tractor")
            {
                for (int i = 0; i < 8; i++)
                {
                    Label Heading = new Label();
                    panelVehicleInformation.Controls.Add(Heading);
                    Heading.Font = LabelFont;
                    Heading.ForeColor = Color.LightSlateGray;
                    Heading.TextAlign = ContentAlignment.MiddleCenter;
                    Heading.AutoSize = true;

                    if (i == 0)
                    {
                        Heading.Text = "Oil Type:";
                        Heading.Location = new Point(125, 240);
                    }
                    else if (i == 1)
                    {
                        Heading.Text = "Coolant Type:";
                        Heading.Location = new Point(250, 240);
                    }
                    else if (i == 2)
                    {
                        Heading.Text = "Fuel Type:";
                        Heading.Location = new Point(407, 240);
                    }
                    else if (i == 3)
                    {
                        Heading.Text = "Engine Oil Level:";
                        Heading.Location = new Point(67, 329);
                    }
                    else if (i == 4)
                    {
                        Heading.Text = "Hyrdaulic Oil Level:";
                        Heading.Location = new Point(407, 329);
                    }
                    else if (i == 5)
                    {
                        Heading.Text = "Hours:";
                        Heading.Location = new Point(275, 329);
                    }
                    else if (i == 6)
                    {
                        Heading.Text = "Lifting Capacity:";
                        Heading.Location = new Point(132, 418);
                    }
                    else
                    {
                        Heading.Text = "Load Capacity:";
                        Heading.Location = new Point(343, 418);
                    }
                }
            }
            else if (VehicleType == "Truck")
            {
                for (int i = 0; i < 6; i++)
                {
                    Label Heading = new Label();
                    panelVehicleInformation.Controls.Add(Heading);
                    Heading.Font = LabelFont;
                    Heading.ForeColor = Color.LightSlateGray;
                    Heading.TextAlign = ContentAlignment.MiddleCenter;
                    Heading.AutoSize = true;

                    if (i == 0)
                    {
                        Heading.Text = "Oil Type:";
                        Heading.Location = new Point(125, 240);
                    }
                    else if (i == 1)
                    {
                        Heading.Text = "Coolant Type:";
                        Heading.Location = new Point(250, 240);
                    }
                    else if (i == 2)
                    {
                        Heading.Text = "Fuel Type:";
                        Heading.Location = new Point(407, 240);
                    }
                    else if (i == 3)
                    {
                        Heading.Text = "Engine Oil Level:";
                        Heading.Location = new Point(67, 329);
                    }
                    else if (i == 4)
                    {
                        Heading.Text = "Miles:";
                        Heading.Location = new Point(280, 329);
                    }
                    else
                    {
                        Heading.Text = "Load Capacity:";
                        Heading.Location = new Point(418, 329);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Label Heading = new Label();
                    panelVehicleInformation.Controls.Add(Heading);
                    Heading.Font = LabelFont;
                    Heading.ForeColor = Color.LightSlateGray;
                    Heading.TextAlign = ContentAlignment.MiddleCenter;
                    Heading.AutoSize = true;

                    if (i == 0)
                    {
                        Heading.Text = "Oil Type:";
                        Heading.Location = new Point(125, 240);
                    }
                    else if (i == 1)
                    {
                        Heading.Text = "Coolant Type:";
                        Heading.Location = new Point(250, 240);
                    }
                    else if (i == 2)
                    {
                        Heading.Text = "Fuel Type:";
                        Heading.Location = new Point(407, 240);
                    }
                    else if (i == 3)
                    {
                        Heading.Text = "Engine Oil Level:";
                        Heading.Location = new Point(159, 329);
                    }
                    else
                    {
                        Heading.Text = "Miles:";
                        Heading.Location = new Point(384, 329);
                    }
                }
            }
        }

        private void GenerateLabelValues(Vehicle vehicle)
        {
            Font LabelFont = new Font("Arial Rounded MT Bold", 11);

            if (vehicle.GetVehicleType() == "Tractor")
            {
                Tractor tractor = (Tractor) vehicle;

                for (int i = 0; i < 8; i++)
                {
                    Panel valuePanel = new Panel();
                    valuePanel.Width = 115;
                    valuePanel.Height = 25;
                    valuePanel.BorderStyle = BorderStyle.None;
                    valuePanel.BackColor = Color.Transparent;

                    Label valueLabel = new Label();
                    valueLabel.Font = LabelFont;
                    valueLabel.ForeColor = Color.DodgerBlue;
                    valueLabel.TextAlign = ContentAlignment.MiddleCenter;
                    valueLabel.AutoSize = false;
                    valueLabel.Dock = DockStyle.Fill;

                    valuePanel.Controls.Add(valueLabel);
                    panelVehicleInformation.Controls.Add(valuePanel);

                    if (i == 0)
                    {
                        valuePanel.Location = new Point(103, 260);
                        valueLabel.Text = tractor.GetOilType();
                    }
                    else if (i == 1)
                    {
                        valuePanel.Location = new Point(246, 260);
                        valueLabel.Text = tractor.GetCoolantType();
                    }
                    else if (i == 2)
                    {
                        valuePanel.Location = new Point(390, 260);
                        valueLabel.Text = tractor.GetFuelType();
                    }
                    else if (i == 3)
                    {
                        valuePanel.Location = new Point(74, 349);
                        valueLabel.Text = Convert.ToString(tractor.GetEngineOilLevel());
                    }
                    else if (i == 4)
                    {
                        valuePanel.Location = new Point(245, 349);
                        valueLabel.Text = Convert.ToString(tractor.GetHours());
                    }
                    else if (i == 5)
                    {
                        valuePanel.Location = new Point(424, 349);
                        valueLabel.Text = Convert.ToString(tractor.GetHydraulicOilLevel());
                    }
                    else if (i == 6)
                    {
                        valuePanel.Location = new Point(137, 438);
                        valueLabel.Text = Convert.ToString(tractor.GetLiftingCapacity());
                    }
                    else
                    {
                        valuePanel.Location = new Point(343, 438);
                        valueLabel.Text = Convert.ToString(tractor.GetLoadCapacity());
                    }
                }
            }
            else if (vehicle.GetVehicleType() == "Truck")
            {
                Truck truck = (Truck) vehicle;
                
                for (int i = 0; i < 6; i++)
                {
                    Panel valuePanel = new Panel();
                    valuePanel.Width = 115;
                    valuePanel.Height = 25;
                    valuePanel.BorderStyle = BorderStyle.None;
                    valuePanel.BackColor = Color.Transparent;

                    Label valueLabel = new Label();
                    valueLabel.Font = LabelFont;
                    valueLabel.ForeColor = Color.DodgerBlue;
                    valueLabel.TextAlign = ContentAlignment.MiddleCenter;
                    valueLabel.AutoSize = false;
                    valueLabel.Dock = DockStyle.Fill;

                    valuePanel.Controls.Add(valueLabel);
                    panelVehicleInformation.Controls.Add(valuePanel);

                    if (i == 0)
                    {
                        valuePanel.Location = new Point(103, 260);
                        valueLabel.Text = truck.GetOilType();
                    }
                    else if (i == 1)
                    {
                        valuePanel.Location = new Point(246, 260);
                        valueLabel.Text = truck.GetCoolantType();
                    }
                    else if (i == 2)
                    {
                        valuePanel.Location = new Point(390, 260);
                        valueLabel.Text = truck.GetFuelType();
                    }
                    else if (i == 3)
                    {
                        valuePanel.Location = new Point(74, 349);
                        valueLabel.Text = Convert.ToString(truck.GetEngineOilLevel());
                    }
                    else if (i == 4)
                    {
                        valuePanel.Location = new Point(247, 349);
                        valueLabel.Text = Convert.ToString(truck.GetMiles());
                    }
                    else
                    {
                        valuePanel.Location = new Point(416, 349);
                        valueLabel.Text = Convert.ToString(truck.GetLoadCapacity());
                    }
                }
            }
            else if (vehicle.GetVehicleType() == "Car")
            {
                Car car = (Car) vehicle;
                
                for (int i = 0; i < 5; i++)
                {
                    Panel valuePanel = new Panel();
                    valuePanel.Width = 115;
                    valuePanel.Height = 25;
                    valuePanel.BorderStyle = BorderStyle.None;
                    valuePanel.BackColor = Color.Transparent;

                    Label valueLabel = new Label();
                    valueLabel.Font = LabelFont;
                    valueLabel.ForeColor = Color.DodgerBlue;
                    valueLabel.TextAlign = ContentAlignment.MiddleCenter;
                    valueLabel.AutoSize = false;
                    valueLabel.Dock = DockStyle.Fill;

                    valuePanel.Controls.Add(valueLabel);
                    panelVehicleInformation.Controls.Add(valuePanel);

                    if (i == 0)
                    {
                        valuePanel.Location = new Point(103, 260);
                        valueLabel.Text = car.GetOilType();
                    }
                    else if (i == 1)
                    {
                        valuePanel.Location = new Point(246, 260);
                        valueLabel.Text = car.GetCoolantType();
                    }
                    else if (i == 2)
                    {
                        valuePanel.Location = new Point(390, 260);
                        valueLabel.Text = car.GetFuelType();
                    }
                    else if (i == 3)
                    {
                        valuePanel.Location = new Point(163, 349);
                        valueLabel.Text = Convert.ToString(car.GetEngineOilLevel());
                    }
                    else
                    {
                        valuePanel.Location = new Point(351, 349);
                        valueLabel.Text = Convert.ToString(car.GetMiles());
                    }
                }
            }
            else
            {
                Quadbike quadbike = (Quadbike) vehicle;

                for (int i = 0; i < 5; i++)
                {
                    Panel valuePanel = new Panel();
                    valuePanel.Width = 115;
                    valuePanel.Height = 25;
                    valuePanel.BorderStyle = BorderStyle.None;
                    valuePanel.BackColor = Color.Transparent;

                    Label valueLabel = new Label();
                    valueLabel.Font = LabelFont;
                    valueLabel.ForeColor = Color.DodgerBlue;
                    valueLabel.TextAlign = ContentAlignment.MiddleCenter;
                    valueLabel.AutoSize = false;
                    valueLabel.Dock = DockStyle.Fill;

                    valuePanel.Controls.Add(valueLabel);
                    panelVehicleInformation.Controls.Add(valuePanel);

                    if (i == 0)
                    {
                        valuePanel.Location = new Point(103, 260);
                        valueLabel.Text = quadbike.GetOilType();
                    }
                    else if (i == 1)
                    {
                        valuePanel.Location = new Point(246, 260);
                        valueLabel.Text = quadbike.GetCoolantType();
                    }
                    else if (i == 2)
                    {
                        valuePanel.Location = new Point(390, 260);
                        valueLabel.Text = quadbike.GetFuelType();
                    }
                    else if (i == 3)
                    {
                        valuePanel.Location = new Point(163, 349);
                        valueLabel.Text = Convert.ToString(quadbike.GetEngineOilLevel());
                    }
                    else
                    {
                        valuePanel.Location = new Point(351, 349);
                        valueLabel.Text = Convert.ToString(quadbike.GetMiles());
                    }
                }
            }
        }

        public Vehicle GetVehicleDetails(string VehicleType, string Registration)
        {
            if (VehicleType == "Tractor")
            {
                LinkedList tractorDetails = new LinkedList();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand getVehicleDetails = new OleDbCommand("SELECT [VehicleID],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[HydraulicOilLevel],[Hours],[LiftingCapacity],[LoadCapacity] FROM Vehicles WHERE Registration=@Registration", connection))
                    {
                        getVehicleDetails.Parameters.AddWithValue("@Registration", Registration);
                        using (OleDbDataReader reader = getVehicleDetails.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tractorDetails.Append(Convert.ToString(reader.GetInt32(0)));
                                tractorDetails.Append(VehicleType);
                                tractorDetails.Append(Registration);
                                tractorDetails.Append(reader.GetString(1));
                                tractorDetails.Append(reader.GetString(2));
                                tractorDetails.Append(reader.GetString(3));
                                tractorDetails.Append(reader.GetString(4));
                                tractorDetails.Append(reader.GetString(5));
                                tractorDetails.Append(Convert.ToString(reader.GetDouble(6)));
                                tractorDetails.Append(Convert.ToString(reader.GetDouble(7)));
                                tractorDetails.Append(Convert.ToString(reader.GetInt32(8)));
                                tractorDetails.Append(Convert.ToString(reader.GetDouble(9)));
                                tractorDetails.Append(Convert.ToString(reader.GetDouble(10)));
                            }
                        }
                    }
                }

                return ConvertListToVehicle(VehicleType, tractorDetails);
            }
            else if (VehicleType == "Truck")
            {
                LinkedList truckDetails = new LinkedList();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand getVehicleDetails = new OleDbCommand("SELECT [VehicleID],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[Miles],[LoadCapacity] FROM Vehicles WHERE Registration=@Registration", connection))
                    {
                        getVehicleDetails.Parameters.AddWithValue("@Registration", Registration);
                        using (OleDbDataReader reader = getVehicleDetails.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                truckDetails.Append(Convert.ToString(reader.GetInt32(0)));
                                truckDetails.Append(VehicleType);
                                truckDetails.Append(Registration);
                                truckDetails.Append(reader.GetString(1));
                                truckDetails.Append(reader.GetString(2));
                                truckDetails.Append(reader.GetString(3));
                                truckDetails.Append(reader.GetString(4));
                                truckDetails.Append(reader.GetString(5));
                                truckDetails.Append(Convert.ToString(reader.GetDouble(6)));
                                truckDetails.Append(Convert.ToString(reader.GetInt32(7)));
                                truckDetails.Append(Convert.ToString(reader.GetDouble(8)));
                            }
                        }
                    }
                }

                return ConvertListToVehicle(VehicleType, truckDetails);
            }
            else
            {
                LinkedList carOrQuadbikeDetails = new LinkedList();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand getVehicleDetails = new OleDbCommand("SELECT [VehicleID],[Make],[Model],[OilType],[CoolantType],[FuelType],[EngineOilLevel],[Miles] FROM Vehicles WHERE Registration=@Registration", connection))
                    {
                        getVehicleDetails.Parameters.AddWithValue("@Registration", Registration);
                        using (OleDbDataReader reader = getVehicleDetails.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                carOrQuadbikeDetails.Append(Convert.ToString(reader.GetInt32(0)));
                                carOrQuadbikeDetails.Append(VehicleType);
                                carOrQuadbikeDetails.Append(Registration);
                                carOrQuadbikeDetails.Append(reader.GetString(1));
                                carOrQuadbikeDetails.Append(reader.GetString(2));
                                carOrQuadbikeDetails.Append(reader.GetString(3));
                                carOrQuadbikeDetails.Append(reader.GetString(4));
                                carOrQuadbikeDetails.Append(reader.GetString(5));
                                carOrQuadbikeDetails.Append(Convert.ToString(reader.GetDouble(6)));
                                carOrQuadbikeDetails.Append(Convert.ToString(reader.GetInt32(7)));
                            }
                        }
                    }
                }

                return ConvertListToVehicle(VehicleType, carOrQuadbikeDetails);
            }
        }

        private Vehicle ConvertListToVehicle(string VehicleType, LinkedList list)
        {
            if (VehicleType == "Tractor")
            {
                Tractor tractor = new Tractor(int.Parse(list.GetItem(1)), list.GetItem(2), list.GetItem(3), list.GetItem(4), list.GetItem(5), list.GetItem(6), list.GetItem(7), list.GetItem(8), double.Parse(list.GetItem(9)), double.Parse(list.GetItem(10)), int.Parse(list.GetItem(11)), double.Parse(list.GetItem(12)), double.Parse(list.GetItem(13)));
                return tractor;
            }
            else if (VehicleType == "Truck")
            {
                Truck truck = new Truck(int.Parse(list.GetItem(1)), list.GetItem(2), list.GetItem(3), list.GetItem(4), list.GetItem(5), list.GetItem(6), list.GetItem(7), list.GetItem(8), double.Parse(list.GetItem(9)), int.Parse(list.GetItem(10)), double.Parse(list.GetItem(11)));
                return truck;
            }
            else if (VehicleType == "Car")
            {
                Car car = new Car(int.Parse(list.GetItem(1)), list.GetItem(2), list.GetItem(3), list.GetItem(4), list.GetItem(5), list.GetItem(6), list.GetItem(7), list.GetItem(8), double.Parse(list.GetItem(9)), int.Parse(list.GetItem(10)));
                return car;
            }
            else
            {
                Quadbike quadbike = new Quadbike(int.Parse(list.GetItem(1)), list.GetItem(2), list.GetItem(3), list.GetItem(4), list.GetItem(5), list.GetItem(6), list.GetItem(7), list.GetItem(8), double.Parse(list.GetItem(9)), int.Parse(list.GetItem(10)));
                return quadbike;
            }
        }

        private void GenerateOptionButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                Button button = new Button();
                Font ButtonFont = new Font("Arial Rounded MT Bold", 9);
                button.Font = ButtonFont;

                if (i == 0 || i == 2)
                {
                    button.Width = 100;
                    button.Height = 40;

                    if (i == 0)
                    {
                        button.Location = new Point(115, 510);
                        button.Text = "EDIT VEHICLE";
                        button.ForeColor = Color.MediumSeaGreen;
                        button.Click += EditVehicle;
                    }
                    else
                    {
                        button.Location = new Point(395, 510);
                        button.Text = "DELETE VEHICLE";
                        button.ForeColor = Color.Tomato;
                        button.Click += DeleteVehicle;
                    }
                }
                else
                {
                    button.Width = 100;
                    button.Height = 50;
                    button.Location = new Point(255, 500);
                    button.Text = "VIEW JOBS";
                    button.ForeColor = Color.RoyalBlue;
                    button.Click += ViewJobs;
                }

                panelVehicleInformation.Controls.Add(button);
            }
        }
    }
}
