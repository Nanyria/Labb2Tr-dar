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
        public int probability = 50;


        public Thread car1 = new Thread(CompStart);
        public Thread car2 = new Thread(CompStart);
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

        }
        public static void CompStart()
        {
            int SpeedPerHour = 120;
            int totalLength = 10000;

                for (int i = 0; i < totalLength; i++)
                {

                }
            
        }
        public static void Gas()
        {
            GetCars();
            //1/50 prob.
            Console.WriteLine($"{car1}");

        }
        public static void PoppedTire() 
        {
            //2/50
        }
        public static void BirdWindshield()
        {
            //5/50
        }
        public static void MotorProblem()
        {
            //10/50
            //var Car = new Car();
            //Car.SpeedPerHour = Car.SpeedPerHour - 1;
            
        }
    }
}
