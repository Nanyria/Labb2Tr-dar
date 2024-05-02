using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labb2Trådar.Models
{
    internal class Car
    {

        private static readonly Random random = new Random();

        public int CarID { get; set; }
        public string CarName { get; set; }
        public double SpeedPerHour { get; set; }

        public double CurrentDistance { get; set; }

        public bool IsInEvent { get; set; }

        public bool IsRacing { get; set; }

        public Car(int carID, string carName, double speedPerHour, double currentDistance, bool isInEvent, bool isRacing)
        {
            CarID = carID;
            CarName = carName;
            SpeedPerHour = speedPerHour;
            CurrentDistance = currentDistance;
            IsInEvent = isInEvent;
            IsRacing = isRacing;
        }


        public static void Randomiser(Car car)
        {

            Console.WriteLine($"Randomiser called for car {car.CarName}");


                int random150 = random.Next(1, 51);

                if (random150 == 19)
                {
                    mutex.WaitOne();
                    Console.WriteLine($"Gas refill event occurred!\n{car.CarName} stops for 30 sek.");
                    Thread.Sleep(3000);
                    mutex.ReleaseMutex();
                    car.IsInEvent = false;


                }
                else if (random150 == 17 || random150 == 18)
                {
                    mutex.WaitOne();
                    Console.WriteLine($"Popped tired event occured!\n{car.CarName} stops for 20 sek.");
                    Thread.Sleep(2000);
                    mutex.ReleaseMutex();
                    car.IsInEvent = false;


                }
                else if (random150 >= 11 && random150 <= 16)
                {
                    mutex.WaitOne();
                    Console.WriteLine($"Birds on the windshield event occured!\n{car.CarName} stops for 10 sek.");
                    Thread.Sleep(1000);
                    mutex.ReleaseMutex();
                    car.IsInEvent = false;


                }
                else if (random150 >= 1 && random150 <= 10)
                {
                    mutex.WaitOne();
                    Console.WriteLine($"Engine trouble event occured!\n{car.CarName} Speed per hour decreses from {car.SpeedPerHour} to {(car.SpeedPerHour - 1)} ");
                    car.SpeedPerHour = car.SpeedPerHour - 1;
                    mutex.ReleaseMutex();
                    car.IsInEvent = false;


                }
                else
                {
                    Console.WriteLine($"{car.CarName} kept driving without any problems.");

                }
                // Set car in an event
            


        }
    }
}
