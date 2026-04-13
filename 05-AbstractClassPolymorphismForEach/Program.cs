using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportManagementSystem
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; }
        public int MaxSpeed { get; set; }

        public Vehicle(string brand, string model, int year, string plateNumber, int maxSpeed)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.PlateNumber = plateNumber;
            this.MaxSpeed = maxSpeed;
            this.FuelLevel = 100;
        }

        public string GetVehicleInfo()
        {
            return $"{Year} {Brand} {Model} (Nomre: {PlateNumber})";
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine($"Neqliyyat: {GetVehicleInfo()} | Yanacaq: {FuelLevel}% | Max Suret: {MaxSpeed} km/s");
        }
    }

    public class Car : Vehicle
    {
        public int DoorsCount { get; set; }
        public int TrunkCapacity { get; set; }
        public bool IsAutomatic { get; set; }

        public Car(string brand, string model, int year, string plateNumber, int maxSpeed,
                   int doorsCount, int trunkCapacity, bool isAutomatic)
            : base(brand, model, year, plateNumber, maxSpeed)
        {
            this.DoorsCount = doorsCount;
            this.TrunkCapacity = trunkCapacity;
            this.IsAutomatic = isAutomatic;
        }

        public void ShowCarInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Qapi: {DoorsCount} | Baqaj: {TrunkCapacity}L | Suret qutusu: {(IsAutomatic ? "Avtomat" : "Mexanika")}");
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 8 * 1.50;
        }
    }

    public class Motorcycle : Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public string Type { get; set; }

        public Motorcycle(string brand, string model, int year, string plateNumber, int maxSpeed,
                          int engineCapacity, bool hasSidecar, string type)
            : base(brand, model, year, plateNumber, maxSpeed)
        {
            this.EngineCapacity = engineCapacity;
            this.HasSidecar = hasSidecar;
            this.Type = type;
        }

        public void ShowMotorcycleInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Hecm: {EngineCapacity}cc | Nov: {Type} | Yan qosqu: {(HasSidecar ? "Var" : "Yoxdur")}");
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 4 * 1.50;
        }
    }

    public class Truck : Vehicle
    {
        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }

        public Truck(string brand, string model, int year, string plateNumber, int maxSpeed,
                     double cargoCapacity, int axleCount, double currentLoad)
            : base(brand, model, year, plateNumber, maxSpeed)
        {
            this.CargoCapacity = cargoCapacity;
            this.AxleCount = axleCount;
            this.CurrentLoad = currentLoad;
        }

        public void ShowTruckInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Tutum: {CargoCapacity} ton | Ox sayi: {AxleCount} | Cari yuk: {CurrentLoad} ton");
        }

        public void LoadCargo(double weight)
        {
            if (CurrentLoad + weight <= CargoCapacity)
            {
                CurrentLoad += weight;
                Console.WriteLine($"[UgURLU]: {weight} ton yuk elave edildi. Cari yuk: {CurrentLoad} ton.");
            }
            else
            {
                Console.WriteLine($"[XeTA]: Maksimum tutum kecilir! Cemi yuk {CargoCapacity} tonu kece bilmez.");
            }
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * (25 + CurrentLoad * 2) * 1.80;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Car c1 = new Car("Mercedes", "E200", 2023, "10-AA-001", 220, 4, 500, true);
            Car c2 = new Car("BMW", "320i", 2022, "99-BB-999", 235, 4, 480, true);
            Car c3 = new Car("Toyota", "Camry", 2021, "77-CC-777", 210, 4, 524, true);

            Motorcycle m1 = new Motorcycle("Yamaha", "R1", 2023, "10-MM-100", 299, 998, false, "Sport");
            Motorcycle m2 = new Motorcycle("Harley-Davidson", "Fat Boy", 2022, "10-HH-020", 180, 1868, true, "Cruiser");

            Truck t1 = new Truck("MAN", "TGX", 2020, "90-TT-800", 120, 18.0, 3, 12.0);
            Truck t2 = new Truck("Volvo", "FH16", 2021, "50-VV-500", 110, 25.0, 4, 18.0);

            Console.WriteLine("=== AVTOMOBİLLeR (500 km xerci) ===");
            c1.ShowCarInfo(); Console.WriteLine($"Yanacaq xerci: {c1.CalculateFuelCost(500)} AZN\n");
            c2.ShowCarInfo(); Console.WriteLine($"Yanacaq xerci: {c2.CalculateFuelCost(500)} AZN\n");
            c3.ShowCarInfo(); Console.WriteLine($"Yanacaq xerci: {c3.CalculateFuelCost(500)} AZN\n");

            Console.WriteLine("=== MOTOSİKLETLeR (300 km xerci) ===");
            m1.ShowMotorcycleInfo(); Console.WriteLine($"Yanacaq xerci: {m1.CalculateFuelCost(300)} AZN\n");
            m2.ShowMotorcycleInfo(); Console.WriteLine($"Yanacaq xerci: {m2.CalculateFuelCost(300)} AZN\n");

            Console.WriteLine("=== YuK MAsINLARI (800 km xerci) ===");
            t1.ShowTruckInfo(); Console.WriteLine($"Yanacaq xerci: {t1.CalculateFuelCost(800)} AZN\n");
            t2.ShowTruckInfo(); Console.WriteLine($"Yanacaq xerci: {t2.CalculateFuelCost(800)} AZN\n");

            Console.WriteLine("=== YuK eLAVe EDİLMeSİ ===");
            t1.LoadCargo(5);
            Console.WriteLine($"Yeni yanacaq xerci (800 km ucun): {t1.CalculateFuelCost(800)} AZN\n");

            List<Vehicle> allVehicles = new List<Vehicle> { c1, c2, c3, m1, m2, t1, t2 };

            double avgSpeed = allVehicles.Average(v => v.MaxSpeed);

            var mostExpensive = allVehicles.OrderByDescending(v => {
                if (v is Car car) return car.CalculateFuelCost(100);
                if (v is Motorcycle moto) return moto.CalculateFuelCost(100);
                if (v is Truck truck) return truck.CalculateFuelCost(100);
                return 0;
            }).First();

            Console.WriteLine("======= STATİSTİKA =======");
            Console.WriteLine($"umumi neqliyyat sayi: {allVehicles.Count}");
            Console.WriteLine($"Orta maksimum suret: {avgSpeed:F2} km/saat");
            Console.WriteLine($"en yuksek xercli neqliyyat: {mostExpensive.Brand} {mostExpensive.Model}");
            Console.WriteLine("===========================");
        }
    }
}