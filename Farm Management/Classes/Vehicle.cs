namespace Classes.Vehicle
{
    using Classes.LinkedList;

    public class Vehicle
    {
        private int VehicleID;
        private string VehicleType;
        private string Registration;
        private string Make;
        private string Model;
        private string OilType;
        private string CoolantType;
        private string FuelType;
        private double EngineOilLevel;

        public Vehicle(int VehicleID, string VehicleType, string Registration, string Make, string Model, string OilType, string CoolantType, string FuelType, double EngineOilLevel)
        {
            this.VehicleID = VehicleID;
            this.VehicleType = VehicleType;
            this.Registration = Registration;
            this.Make = Make;
            this.Model = Model;
            this.OilType = OilType;
            this.CoolantType = CoolantType;
            this.FuelType = FuelType;
            this.EngineOilLevel = EngineOilLevel;
        }

        public virtual LinkedList GetAllVehicleDetails()
        {
            LinkedList vehicleDetails = new LinkedList();
            vehicleDetails.Append(Convert.ToString(VehicleID));
            vehicleDetails.Append(VehicleType);
            vehicleDetails.Append(Registration);
            vehicleDetails.Append(Make);
            vehicleDetails.Append(Model);
            vehicleDetails.Append(OilType);
            vehicleDetails.Append(CoolantType);
            vehicleDetails.Append(FuelType);
            vehicleDetails.Append(Convert.ToString(EngineOilLevel));

            return vehicleDetails;
        }

        public int GetVehicleID()
        {
            return VehicleID;
        }

        public string GetVehicleType()
        {
            return VehicleType;
        }

        public string GetRegistration()
        {
            return Registration;
        }

        public string GetMake()
        {
            return Make;
        }

        public string GetModel()
        {
            return Model;
        }

        public string GetOilType()
        {
            return OilType;
        }

        public string GetCoolantType()
        {
            return CoolantType;
        }

        public string GetFuelType()
        {
            return FuelType;
        }

        public double GetEngineOilLevel()
        {
            return EngineOilLevel;
        }
    }

    public class Tractor : Vehicle
    {
        private double LiftingCapacity;
        private double LoadCapacity;
        private double HydraulicOilLevel;
        private int Hours;

        public Tractor(int VehicleID, string VehicleType, string Registration, string Make, string Model, string OilType, string CoolantType, string FuelType, double EngineOilLevel, double HydraulicOilLevel, int Hours, double LiftingCapacity, double LoadCapacity) : base(VehicleID, VehicleType, Registration, Make, Model, OilType, CoolantType, FuelType, EngineOilLevel)
        {
            this.LiftingCapacity = LiftingCapacity;
            this.LoadCapacity = LoadCapacity;
            this.HydraulicOilLevel = HydraulicOilLevel;
            this.Hours = Hours;
        }

        public override LinkedList GetAllVehicleDetails()
        {
            LinkedList vehicleDetails = new LinkedList();
            vehicleDetails = base.GetAllVehicleDetails();
            vehicleDetails.Append(Convert.ToString(HydraulicOilLevel));
            vehicleDetails.Append(Convert.ToString(Hours));
            vehicleDetails.Append(Convert.ToString(LiftingCapacity));
            vehicleDetails.Append(Convert.ToString(LoadCapacity));

            return vehicleDetails;
        }

        public double GetLiftingCapacity()
        {
            return LiftingCapacity;
        }

        public double GetLoadCapacity()
        {
            return LoadCapacity;
        }

        public double GetHydraulicOilLevel()
        {
            return HydraulicOilLevel;
        }

        public int GetHours()
        {
            return Hours;
        }
    }

    public class Car : Vehicle
    {
        private int Miles;

        public Car(int VehicleID, string VehicleType, string Registration, string Make, string Model, string OilType, string CoolantType, string FuelType, double EngineOilLevel, int Miles) : base(VehicleID, VehicleType, Registration, Make, Model, OilType, CoolantType, FuelType, EngineOilLevel)
        {
            this.Miles = Miles;
        }

        public override LinkedList GetAllVehicleDetails()
        {
            LinkedList vehicleDetails = new LinkedList();
            vehicleDetails = base.GetAllVehicleDetails();
            vehicleDetails.Append(Convert.ToString(Miles));

            return vehicleDetails;
        }

        public int GetMiles()
        {
            return Miles;
        }
    }

    public class Quadbike : Vehicle
    {
        private int Miles;

        public Quadbike(int VehicleID, string VehicleType, string Registration, string Make, string Model, string OilType, string CoolantType, string FuelType, double EngineOilLevel, int Miles) : base(VehicleID, VehicleType, Registration, Make, Model, OilType, CoolantType, FuelType, EngineOilLevel)
        {
            this.Miles = Miles;
        }

        public override LinkedList GetAllVehicleDetails()
        {
            LinkedList vehicleDetails = new LinkedList();
            vehicleDetails = base.GetAllVehicleDetails();
            vehicleDetails.Append(Convert.ToString(Miles));

            return vehicleDetails;
        }

        public int GetMiles()
        {
            return Miles;
        }
    }

    public class Truck : Vehicle
    {
        private int Miles;
        private double LoadCapacity;

        public Truck(int VehicleID, string VehicleType, string Registration, string Make, string Model, string OilType, string CoolantType, string FuelType, double EngineOilLevel, int Miles, double LoadCapacity) : base(VehicleID, VehicleType, Registration, Make, Model, OilType, CoolantType, FuelType, EngineOilLevel)
        {
            this.Miles = Miles;
            this.LoadCapacity = LoadCapacity;
        }

        public override LinkedList GetAllVehicleDetails()
        {
            LinkedList vehicleDetails = new LinkedList();
            vehicleDetails = base.GetAllVehicleDetails();
            vehicleDetails.Append(Convert.ToString(Miles));
            vehicleDetails.Append(Convert.ToString(LoadCapacity));

            return vehicleDetails;
        }

        public int GetMiles()
        {
            return Miles;
        }

        public double GetLoadCapacity()
        {
            return LoadCapacity;
        }
    }
}
