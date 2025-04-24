using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample2
{
    internal class Constants // Changed from private to internal to fix CS1527  
    {
        public const double AirDensity = 1.225; // kg/m^3 at sea level  
        public const double Gravity = 9.81; // m/s^2  
    }

    class Aircraft // constant values for Cessna 172
    {
        private int _passengerCount;
        private double Thrust { get; set; } = 0; // in Newtons
        private double Drag { get; set; } = 0;// in Newtons
        private double EnginePower { get; set; } = 160; // in Watts
        public double Weight { get; set; } = 11282.5;
        private double WingArea { get; set; } = 16.2; // in m^2
        private double LiftCoefficient { get; set; } = 1.5; // Assumed constant for simplicity  
        private double SFC { get; set; } = 0.228; // Specific Fuel Consumption in g/N/s
        private double TakeOffSpeed { get; set; } // in m/s
        private int PassengerCapacity { get; set; }
        public string Name { get; set; } = "Default";
        public string Model { get; set; } = "Default Model";
        public double Altitude { get; set; }
        public double Speed { get; set; }
        public double Fuel { get; set; }

        public int PassengerCount
        {
            get { return _passengerCount; }
            set
            {
                if (value > PassengerCapacity)
                {
                    Console.WriteLine("Passenger count exceeds capacity.");
                    _passengerCount = PassengerCapacity;
                }
                else
                {
                    _passengerCount = value;
                }
            }
        }

        Aircraft()
        {
            TakeOffSpeed = Math.Sqrt((2 * Weight) / (Constants.AirDensity * WingArea * LiftCoefficient)); // in m/s
        }
        private double ROC() { return (Thrust - Drag) / (Speed * Weight); } // Rate of Climb in m/s
        private void Climbing()
        {
            if (Altitude < 1000)
            {
                Console.WriteLine($"{Name} is climbing to {Altitude} meters.");
                while (Altitude < 1000)
                {
                    FuelConsumption();
                    ChangeAltitude(ROC());
                }
            }
            else
            {
                Console.WriteLine($"{Name} is already at cruising altitude.");
            }
        }
        
        public void ChangeSpeed(double speed)
        {
            this.Speed += speed;
            Drag = 0.5 * Constants.AirDensity * Math.Pow(Speed, 2) * WingArea * LiftCoefficient; // in Newtons
            Thrust = EnginePower / Speed; // in Newtons
        }
        public void ChangeAltitude(double altitude) { this.Altitude += altitude; }
        public void FuelConsumption()
        {
            Fuel -= (SFC * Thrust) / 1000; // in kg/s
        }
        
        public void TakeOff()
        {
            if (Fuel > 0 && Speed >= TakeOffSpeed)
            {
                Console.WriteLine($"{Name} is taking off.");
                Climbing();
            }
            else if (Fuel > 0)
            {
                while (Speed < TakeOffSpeed)
                {
                    ChangeSpeed(10);
                    Console.WriteLine($"{Name} is accelerating to take off speed.");
                }
                Console.WriteLine($"{Name} is now at take off speed.");
                Climbing();
            }
        }
        public void Land()
        {
            if (Altitude > 0)
                Console.WriteLine($"{Name} is landing.");
            else
                Console.WriteLine($"{Name} cannot land as it is already on the ground.");
        }
    }
}
