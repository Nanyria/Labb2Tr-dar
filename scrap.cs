using Labb2Trådar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Trådar
{
    internal class scrap
    {

        //    public static Mutex mutex = new Mutex();

        //    private static readonly Random random = new Random();
        //    private static readonly object lockObject = new object();
        //    private static readonly List<string> possibleEvents = new List<string>
        //{
        //    "Gas refill",
        //    "Flat tire",
        //    "Bird on windshield",
        //    "Engine trouble"
        //};


        // Thread for generating random events

        //Thread randomEventThread = new Thread(() =>
        //{
        //    Thread.Sleep(3000);
        //    while (true)
        //    {
        //        // Generate random events for each car
        //        foreach (var car in cars)
        //        {

        //             Randomiser(car);


        //        }
        //        Thread.Sleep(30000); // Wait for 30 seconds between events
        //    }
        //});
        //randomEventThread.Start();

        //    public static List<Car> GetCars()
        //    {
        //        return new List<Car>
        //    {
        //        new Car { CarID = 101, CarName = "BilEtt", SpeedPerHour = 12000},
        //        new Car { CarID = 102, CarName = "BilTvå", SpeedPerHour = 12000}
        //    };
        //    }


        //    public static void Competition()
        //    {
        //        //List<Car> cars = GetCars();
        //        ////Tråd som kallar på det första objektet i car-listan
        //        //Thread car1 = new Thread(() => CompStart(cars[0]))
        //        //{
        //        //    Name = "Bil Ett"

        //        //};
        //        //Thread car2 = new Thread(() => CompStart(cars[1]))
        //        //{
        //        //    Name = "Bil Två"
        //        //};


        //        //    car1.Start();
        //        //    car2.Start();
        //        //Task car1Task = new Task(() => CompStart(cars[0]));

        //        List<Car> cars = GetCars();
        //        List<Thread> threads = new List<Thread>();

        //        foreach (var car in cars)
        //        {
        //            Thread carThread = new Thread(() => CompStart(car))
        //            {
        //                Name = car.CarName
        //            };
        //            threads.Add(carThread);
        //            carThread.Start();
        //        }

        //        foreach (var thread in threads)
        //        {
        //            thread.Join();
        //        }

        //    }


        //    public static void Randomiser(Car car)
        //    {
        //        //List<Car> cars = GetCars();
        //        //Random rand = new Random();
        //        //Car currentCar = cars[rand.Next(cars.Count)];

        //        //int random150 = rand.Next(1, 51); // Ger ett nummer mellan 1-50 (1/50 risk)
        //        //if (random150 == 19)
        //        //{
        //        //    Gas(currentCar);
        //        //    return false;
        //        //}
        //        //else if (random150 == 17 || random150 == 18) // (6/50 risk)
        //        //{
        //        //    PoppedTire(currentCar);
        //        //    return false;
        //        //} 
        //        //else if (random150 >= 11 && random150 <= 16) //(5/50 risk) 
        //        //{
        //        //    BirdWindshield(currentCar);
        //        //    return false;
        //        //}
        //        //else if (random150 >= 1 && random150 <= 10) // (10/50 risk)
        //        //{

        //        //    MotorProblem(currentCar);
        //        //    return false;

        //        //}
        //        //else
        //        //{
        //        //    Console.WriteLine($"{currentCar.CarName} drove on without encountering any problems.");
        //        //    return false;
        //        //}

        //        lock (lockObject)
        //        {
        //            int random150 = random.Next(1, 51);

        //            if (random150 == 19)
        //            {
        //                Gas(car);

        //            }
        //            else if (random150 == 17 || random150 == 18)
        //            {
        //                FlatTire(car);

        //            }
        //            else if (random150 >= 11 && random150 <= 16)
        //            {
        //                BirdWindshield(car);

        //            }
        //            else if (random150 >= 1 && random150 <= 10)
        //            {
        //                EngineTrouble(car);

        //            }
        //            car.IsInEvent = true; // Set car in an event

        //        }



        //    }
        //    public static void CompStart(Car car)
        //    {
        //        //int totalLength = 10000;
        //        //double currentM = 0;
        //        //bool raceFinished = false;
        //        //bool eventOccured = false;
        //        //object lockObject = new object();

        //        //Console.WriteLine($"Car with name {car.CarName} started racing!");


        //        //Timer Tracker = new Timer(state =>
        //        //{
        //        //    Console.WriteLine($"{car.CarName} has driven {(currentM / 1000)} km.");
        //        //}, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        //        //Timer Events = new Timer(state =>
        //        //{
        //        //    mutex.WaitOne();
        //        //    Randomiser(car);
        //        //    lock (lockObject)
        //        //    {
        //        //        eventOccured = true;
        //        //    }
        //        //    mutex.ReleaseMutex();
        //        //}, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

        //        //while (currentM != totalLength && !raceFinished)
        //        //{


        //        //    for (int i = 0; i < totalLength; i++)
        //        //    {
        //        //        currentM = currentM + (car.SpeedPerHour / 3600);
        //        //        Thread.Sleep(100);

        //        //        lock (lockObject)
        //        //        {
        //        //            if (eventOccured)
        //        //            {
        //        //                eventOccured = false;
        //        //                break;
        //        //            }

        //        //        }
        //        //        if (currentM >= totalLength)
        //        //        {
        //        //            Console.WriteLine($"{car.CarName} has reached the finish line!");
        //        //            raceFinished = true;
        //        //            break;
        //        //        }

        //        //    }
        //        //    Events.Dispose();

        //        //}

        //        int totalDistance = 10000; // 10 km in meters
        //        double currentDistance = 0;
        //        int eventInterval = 30 * 1000; // 30 seconds in milliseconds
        //        int distanceInterval = 10 * 1000; //10 sek
        //        DateTime lastProgressTime = DateTime.Now;

        //        Console.WriteLine($"Car {car.CarName} started racing!");

        //        Timer eventsTimer = new Timer(state =>
        //        {
        //            if (!car.IsInEvent)
        //            {
        //                Randomiser(car);
        //            }
        //        }, null, 0, eventInterval);

        //        //Timer distanceTracker = new Timer(state =>
        //        //{
        //        //    // Display progress
        //        //    Console.WriteLine($"Car {car.CarName} has driven {currentDistance / 1000} km.");
        //        //}, null, 0, distanceInterval);

        //        while (currentDistance < totalDistance)
        //        {
        //            // Simulate driving
        //            currentDistance += car.SpeedPerHour / 3600; // Convert speed to m/s
        //            Thread.Sleep(100); // Sleep for 10 milliseconds

        //            if ((DateTime.Now - lastProgressTime).TotalMilliseconds >= distanceInterval)
        //            {
        //                Console.WriteLine($"Car {car.CarName} has driven {currentDistance / 1000} km.");
        //                lastProgressTime = DateTime.Now;
        //            }

        //        }

        //        eventsTimer.Dispose();
        //        Console.WriteLine($"Car {car.CarName} reached the finish line!");

        //    }



        //    public static void Gas(Car car)
        //    {

        //        Console.WriteLine($"Gas refill event occurred!\n{car.CarName} stops for 30 sek.");
        //        Thread.Sleep(3000);
        //        car.IsInEvent = false; // Event ended
        //    }
        //    public static void FlatTire(Car car)
        //    {
        //        Console.WriteLine($"Popped tired event occured!\n{car.CarName} stops for 20 sek.");
        //        Thread.Sleep(2000);
        //        car.IsInEvent = false; // Event ended
        //    }
        //    public static void BirdWindshield(Car car)
        //    {
        //        Console.WriteLine($"Birds on the windshield event occured!\n{car.CarName} stops for 10 sek.");
        //        Thread.Sleep(1000);
        //        car.IsInEvent = false; // Event ended

        //    }
        //    public static void EngineTrouble(Car car)
        //    {

        //        Console.WriteLine($"Engine trouble event occured!\n{car.CarName} Speed per hour decreses from {car.SpeedPerHour} to {(car.SpeedPerHour - 1)} ");
        //        car.SpeedPerHour = car.SpeedPerHour - 1;
        //        car.IsInEvent = false; // Event ended

        //    }
    }
}
