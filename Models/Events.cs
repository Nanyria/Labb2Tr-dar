using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Trådar.Models
{
    internal class Events
    {

        public static List<Car> GetCars()
        {
            return new List<Car>
        {
            new Car { CarID = 101, CarName = "BilEtt", SpeedPerHour = 120},
            new Car { CarID = 102, CarName = "BilTvå", SpeedPerHour = 120}
        }; ;
        }

        public static void Competition()
        {
            List<Car> cars = GetCars();
            //Tråd som kallar på det första objektet i car-listan
            Thread car1 = new Thread(() => CompStart(cars[0]))
            {
                Name = "Bil Ett"

            };
            Thread car2 = new Thread(() => CompStart(cars[1]))
            {
                Name = "Bil Två"
            };


                car1.Start();
                car2.Start();

        }
        public static void Randomiser()
        {
            List<Car> cars = GetCars();
            Random rand = new Random();
            Car currentCar = cars[rand.Next(cars.Count)];

            int random150 = rand.Next(1, 51); // Ger ett nummer mellan 1-50 (1/50 risk)
            if (random150 == 19)
            {
                Gas(currentCar);
            }
            else if (random150 == 17 || random150 == 18) // (6/50 risk)
            {
                PoppedTire(currentCar);
            } 
            else if (random150 >= 11 && random150 <= 16) //(5/50 risk) 
            {
                BirdWindshield(currentCar);
            }
            else if (random150 >= 1 && random150 <= 10) // (10/50 risk)
            {
                
                MotorProblem(currentCar);
            }
            else
            {
                Console.WriteLine($"{currentCar.CarName} drove on without encountering any problems.");
            }
        }
        public static void CompStart(Car car)
        {
            int totalLength = 10000;
            int currentKm = 0;
            Console.WriteLine($"Car with name {car.CarName} started racing!");

            Timer Events = new Timer(state =>
            {
                Randomiser();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            Timer Tracker = new Timer(state =>
            {
                Console.WriteLine($"{car.CarName} has driven {currentKm} km.");
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            for (int i = 0; i < totalLength; i++)
            {
                currentKm++;
                Thread.Sleep(10);

            }
            Console.WriteLine($"{car.CarName} has reached the finish line!");

            //
            Events.Dispose();

            
        }
        public static void Gas(Car car)
        {

            Console.WriteLine($"Gas refill event occurred!\n{car.CarName} stops for 30 sek.");
            Thread.Sleep(3000);

        }
        public static void PoppedTire(Car car) 
        {
            Console.WriteLine($"Popped tired event occured!\n{car.CarName} stops for 20 sek.");
            Thread.Sleep(2000);
        }
        public static void BirdWindshield(Car car)
        {
            Console.WriteLine($"Birds on the windshield event occured!\n{car.CarName} stops for 10 sek.");
            Thread.Sleep(1000);

        }
        public static void MotorProblem(Car car)
        {

            Console.WriteLine($"Motor problem event occured!\n{car.CarName} Speed per hour decreses from {car.SpeedPerHour} to {(car.SpeedPerHour - 1)} ");
            car.SpeedPerHour--;
            
        }
    }
}
