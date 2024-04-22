using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Trådar.Models
{
    internal class Events
    {
        static ThreadLocal<int> _current = new ThreadLocal<int>();


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
            Thread car1 = new Thread(() => CompStart("Bil Ett", 120))
            {
                Name = "Bil Ett"

            };
            Thread car2 = new Thread(() => CompStart("Bil Två", 120))
            {
                Name = "Bil Två"
            };
            while (true)
            {

                car1.Start();
                car2.Start();


            }

        }
        public static void Randomiser()
        {
            Random rand = new Random();
            int random150 = rand.Next(1, 51); // Ger ett nummer mellan 1-50 (1/50 risk)
            if (random150 == 19)
            {
                Gas();
            }
            else if (random150 == 17 || random150 == 18) // (6/50 risk)
            {
                PoppedTire();
            } 
            else if (random150 >= 11 || random150 <= 16) //(5/50 risk) 
            {
                BirdWindshield();
            }
            else if (random150 >= 1 || random150 <= 10) // (10/50 risk)
            {
                MotorProblem();
            }
            else
            {
                Console.WriteLine("");
            }
        }
        public static void CompStart(string carName, int carSpeed)
        {
            int totalLength = 10000;
            Console.WriteLine($"Car with name {Thread.CurrentThread.Name} started racing!");
            for (int i = 0; i < totalLength;)
                {
                    i++;
                    for (i = )

                }
            
        }
        public static void Gas()
        {

            Console.WriteLine($"Gas refill event occurred for {Thread.CurrentThread.Name}!\n{Thread.CurrentThread.Name} stops for 30 sek.");
            Thread.Sleep(3000);

        }
        public static void PoppedTire() 
        {
            Console.WriteLine($"Popped tired event occured!\n{Thread.CurrentThread.Name} stops for 20 sek.");
            Thread.Sleep(2000);
        }
        public static void BirdWindshield()
        {
            Console.WriteLine($"Birds on the windshield event occured!\n{Thread.CurrentThread.Name} stops for 10 sek.");
            Thread.Sleep(1000);

        }
        public static void MotorProblem()
        {
            Console.WriteLine("Motor problem event occured!\n{car} Speed per hour decreses from {car.speed} to ");
            
        }
    }
}
