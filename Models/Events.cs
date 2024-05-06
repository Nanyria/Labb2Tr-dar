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
        private static Car firstFinisher;
        private static bool raceCompleted;

        public static List<Car> GetCars()
        {
            return new List<Car>
            {

                new Car(101, "BilEtt", 12000, 0, false, false),
                new Car(102, "BilTvå", 12000, 0, false, false)
            };
        }

        private static void ListenForUserInput(List<Car> cars)
        {
            try
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "status")
                    {
                        Console.WriteLine("Current race status:");
                        foreach (var car in cars)
                        {
                            Console.WriteLine($"Car {car.CarName}: Distance: {car.CurrentDistance / 1000} km, Speed: {car.SpeedPerHour} km/h");
                        }
                    }
                }
            }
            catch (ThreadInterruptedException)
            {
                // Do nothing, the thread was interrupted intentionally
            }
        }

        public static void Competition()
        {

            List<Car> cars = GetCars();

            // Shared variable to track last event time
            DateTime lastEventTime = DateTime.MinValue;


            // Dictionary to store locks for each car
            Dictionary<Car, object> carLocks = new Dictionary<Car, object>();

            // Create locks for each car
            foreach (var car in cars)
            {
                carLocks.Add(car, new object());
            }
            //Start the race for each car
            List<Thread> carThreads = new List<Thread>();
            foreach (var car in cars)
            {
                Thread carThread = new Thread(() => CompStart(car, ref lastEventTime, carLocks[car]));
                carThread.Name = car.CarName;
                carThreads.Add(carThread);
                carThread.Start();
            }

            // Listen for user input in a separate thread
            Thread userInputThread = new Thread(() => ListenForUserInput(cars));
            userInputThread.Start();

            // Stop listening for user input
            userInputThread.Interrupt();
            foreach (var carThread in carThreads)
            {
                carThread.Join();
            }
            if (raceCompleted)
            {
                Console.WriteLine($"The race was completed by car: {firstFinisher.CarName}");
            }


        }





        public static void CompStart(Car car, ref DateTime lastEventTime, object carLock)
        {
            List<Car> cars = GetCars();
            int totalDistance = 100000; // 10 km in meters
            //double currentDistance = 0;
            DateTime lastProgressTime = DateTime.Now;


            Console.WriteLine($"Car {car.CarName} started racing!");

            while (car.CurrentDistance < totalDistance)
            {
                car.IsRacing = true;
                if (!car.IsInEvent && (DateTime.Now - lastEventTime).TotalSeconds >= 30)
                {
                    // Trigger an event
                    lock (carLock)
                    {
                        car.IsInEvent = true;
                        Car.Randomiser(car);
                        car.IsInEvent = false;
                        // Update last event time
                        lastEventTime = DateTime.Now;
                    }

                }
                if(!car.IsInEvent)
                {

                    // Simulate driving
                    car.CurrentDistance += car.SpeedPerHour / 360; // Convert speed to m/s
                    Thread.Sleep(10); // Sleep for 100 milliseconds
                }

                if ((DateTime.Now - lastProgressTime).TotalSeconds >= 5)
                {
                    Console.WriteLine($"Car {car.CarName} has driven {car.CurrentDistance / 1000} km. Speed: {car.SpeedPerHour}");
                    lastProgressTime = DateTime.Now;
                }


            }
            lock (carLock)
            {
                if (!raceCompleted)
                {
                    firstFinisher = car;
                    raceCompleted = true;
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
