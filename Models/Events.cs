using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labb2Trådar.Models
{
    internal class Events
    {
        public static Mutex mutex = new Mutex();
        private static readonly object carDistance = new object;
        private static bool eventOccurred = false;
        private static bool raceIsOn = false;
        private static readonly List<string> possibleEvents = new List<string>
        {
            "Gas refill",
            "Flat tire",
            "Bird on windshield",
            "Engine trouble"
        };


        public static List<Car> GetCars()
        {
            return new List<Car>
            {
                new Car { CarID = 101, CarName = "BilEtt", SpeedPerHour = 12000},
                new Car { CarID = 102, CarName = "BilTvå", SpeedPerHour = 12000}
            };
        }


        public static void Competition()
        {

            List<Car> cars = GetCars();

            //Start the race for each car
            List<Thread> carThreads = new List<Thread>();
            foreach (var car in cars)
            {
                Thread carThread = new Thread(() => CompStart(car));
                carThread.Name = car.CarName;
                carThreads.Add(carThread);
                carThread.Start();
            }


            // Thread for generating random events

            //Thread randomEventThread = new Thread(() =>
            //{
            //    Thread.Sleep(3000);
            //    while (true)
            //    {
            //        // Generate random events for each car
            //        foreach (var car in cars)
            //        {
            //            mutex.WaitOne();
            //            car.IsInEvent = true;
            //            Car.Randomiser(car);
            //            car.IsInEvent = false;
            //            mutex.ReleaseMutex();
            //        }
            //        Thread.Sleep(30000); // Wait for 30 seconds between events
            //    }
            //});

            //randomEventThread.Start();

            foreach (var carThread in carThreads)
            {
                carThread.Join();
            }


        }





        public static void CompStart(Car car)
        {
            List<Car> cars = GetCars();
            int totalDistance = 100000; // 10 km in meters
            //double currentDistance = 0;
            DateTime lastProgressTime = DateTime.Now;


            Console.WriteLine($"Car {car.CarName} started racing!");

            while (car.CurrentDistance < totalDistance)
            {
                car.IsRacing = true;
                lock (carDistance)
                {
                    if (car.IsInEvent)
                    {
                        if (car.CarID == car.CarID)
                        {
                            lock (car)
                            {

                            }
                            continue;
                        }

                    }
                    else
                    {

                        mutex.WaitOne();
                        // Simulate driving
                        car.CurrentDistance += car.SpeedPerHour / 360; // Convert speed to m/s
                        Thread.Sleep(100); // Sleep for 100 milliseconds
                        mutex.ReleaseMutex();

                    }
                }
                
                if ((DateTime.Now - lastProgressTime).TotalSeconds >= 5)
                {
                    Console.WriteLine($"Car {car.CarName} has driven {car.CurrentDistance / 1000} km. Speed: {car.SpeedPerHour}");
                    lastProgressTime = DateTime.Now;
                }
            }

            Console.WriteLine($"Car {car.CarName} reached the finish line!");
            car.IsRacing = false;



        }
    }
}


                //public static void Randomiser(Car car)
                //{

//    Console.WriteLine($"Randomiser called for car {car.CarName}");
//    lock (lockObject)
//    {

//        int random150 = random.Next(1, 51);

//        if (random150 == 19)
//        {
//            mutex.WaitOne();
//            Console.WriteLine($"Gas refill event occurred!\n{car.CarName} stops for 30 sek.");
//            Thread.Sleep(3000);
//            mutex.ReleaseMutex();
//            car.IsInEvent = false;


//        }
//        else if (random150 == 17 || random150 == 18)
//        {
//            mutex.WaitOne();
//            Console.WriteLine($"Popped tired event occured!\n{car.CarName} stops for 20 sek.");
//            Thread.Sleep(2000);
//            mutex.ReleaseMutex();
//            car.IsInEvent = false;


//        }
//        else if (random150 >= 11 && random150 <= 16)
//        {
//            mutex.WaitOne();
//            Console.WriteLine($"Birds on the windshield event occured!\n{car.CarName} stops for 10 sek.");
//            Thread.Sleep(1000);
//            mutex.ReleaseMutex();
//            car.IsInEvent = false;


//        }
//        else if (random150 >= 1 && random150 <= 10)
//        {
//            mutex.WaitOne();
//            Console.WriteLine($"Engine trouble event occured!\n{car.CarName} Speed per hour decreses from {car.SpeedPerHour} to {(car.SpeedPerHour - 1)} ");
//            car.SpeedPerHour = car.SpeedPerHour - 1;
//            mutex.ReleaseMutex();
//            car.IsInEvent = false;


//        }
//        else
//        {
//            Console.WriteLine($"{car.CarName} kept driving without any problems.");

//        }
//        // Set car in an event
//    }


//}

//        public static void Gas(Car car)
//        {
//            mutex.WaitOne();
//            Console.WriteLine($"Gas refill event occurred!\n{car.CarName} stops for 30 sek.");
//            Thread.Sleep(3000);
//            mutex.ReleaseMutex();
//            car.IsInEvent = false;

//        }
//        public static void FlatTire(Car car)
//        {
//            mutex.WaitOne();
//            Console.WriteLine($"Popped tired event occured!\n{car.CarName} stops for 20 sek.");
//            Thread.Sleep(2000);
//            mutex.ReleaseMutex();
//            car.IsInEvent = false;

//        }
//        public static void BirdWindshield(Car car)
//        {
//            mutex.WaitOne();
//            Console.WriteLine($"Birds on the windshield event occured!\n{car.CarName} stops for 10 sek.");
//            Thread.Sleep(1000);
//            mutex.ReleaseMutex();
//            car.IsInEvent = false;

//        }
//        public static void EngineTrouble(Car car)
//        {
//            mutex.WaitOne();
//            Console.WriteLine($"Engine trouble event occured!\n{car.CarName} Speed per hour decreses from {car.SpeedPerHour} to {(car.SpeedPerHour - 1)} ");
//            car.SpeedPerHour = car.SpeedPerHour - 1;
//            mutex.ReleaseMutex();
//            car.IsInEvent = false;


//        }
//    }
//}
