using VehicleLibrary1;
using System;
using System.Diagnostics;

namespace Т3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Collections Collections = new Collections();
            Stopwatch stopwatch = new Stopwatch();
            Car CarFirst = Collections.queueCar1.Peek();
            Car CarMiddle = Collections.queueCar1.ToArray()[Collections.queueCar1.Count / 2];
            Car CarLast = Collections.queueCar1.ToArray()[Collections.queueCar2.Count - 1];

            Car first = new Car(CarFirst.Brand, CarFirst.Year, CarFirst.Color,CarFirst.Price, CarFirst.GroundClearance, new IdNumber(CarMiddle.Id.Number), CarFirst.SeatCount, CarFirst.MaxSpeed);
            Car mid = new Car( CarMiddle.Brand, CarMiddle.Year, CarMiddle.Color,CarMiddle.Price, CarMiddle.GroundClearance, new IdNumber(CarMiddle.Id.Number), CarMiddle.SeatCount, CarMiddle.MaxSpeed);
            Car last = new Car(CarLast.Brand, CarLast.Year, CarLast.Color, CarLast.Price, CarLast.GroundClearance, new IdNumber(CarMiddle.Id.Number), CarLast.SeatCount, CarLast.MaxSpeed);
            Car other = new Car("UAZ", 2023, "green", 100000, 10, new IdNumber(int.MaxValue), 4, 300);

            Console.WriteLine('\n' + "Queue Car");
            long time1 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.queueCar1.Contains(first);
                stopwatch.Stop();
                time1 += stopwatch.ElapsedMilliseconds;
            }
            time1 = time1 / 5;

            Console.WriteLine($"First = {time1}");

            long time2 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.queueCar1.Contains(mid);
                stopwatch.Stop();
                time2 += stopwatch.ElapsedMilliseconds;
            }
            time2 = time2 / 5;

            Console.WriteLine($"Mid = {time2}");

            long time3 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.queueCar1.Contains(last);
                stopwatch.Stop();
                time3 += stopwatch.ElapsedMilliseconds;
            }
            time3 = time3 / 5;

            Console.WriteLine($"Last = {time3}");

            long time4 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.queueCar1.Contains(other);
                stopwatch.Stop();
                time4 += stopwatch.ElapsedMilliseconds;
            }
            time4 = time4 / 5;

            Console.WriteLine($"Unknown = {time4}");


            Console.WriteLine('\n' + "Queue string");
            time1 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.queueCar2.Contains(first.ToString());
                stopwatch.Stop();
                time1 += stopwatch.ElapsedMilliseconds;
            }
            time1 = time1 / 5;

            Console.WriteLine($"First = {time1}");

            time2 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.queueCar2.Contains(mid.ToString());
                stopwatch.Stop();
                time2 += stopwatch.ElapsedMilliseconds;
            }
            time2 = time2 / 5;

            Console.WriteLine($"Mid = {time2}");

            time3 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.queueCar2.Contains(last.ToString());
                stopwatch.Stop();
                time3 += stopwatch.ElapsedMilliseconds;
            }
            time3 = time3 / 5;

            Console.WriteLine($"Last = {time3}");

            time4 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.queueCar2.Contains(other.ToString());
                stopwatch.Stop();
                time4 += stopwatch.ElapsedMilliseconds;
            }
            time4 = time4 / 5;

            Console.WriteLine($"Unknown = {time4}");

            Console.WriteLine('\n' + "Dictionary");
            long time5 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.dictCar1.ContainsValue(first);
                stopwatch.Stop();
                time5 += stopwatch.ElapsedMilliseconds;
            }
            time5 = time5 / 5;

            Console.WriteLine($"First = {time5}");

            long time6 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.dictCar1.ContainsValue(mid);
                stopwatch.Stop();
                time6 += stopwatch.ElapsedMilliseconds;
            }
            time6 = time6 / 5;

            Console.WriteLine($"Mid = {time6}");

            long time7 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.dictCar1.ContainsValue(last);
                stopwatch.Stop();
                time7 += stopwatch.ElapsedMilliseconds;
            }
            time7 = time7 / 5;

            Console.WriteLine($"Last = {time7}");

            long time8 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.dictCar1.ContainsValue(other);
                stopwatch.Stop();
                time8 += stopwatch.ElapsedMilliseconds;
            }
            time8 = time8 / 5;

            Console.WriteLine($"Unknown = {time8}");

            Console.WriteLine('\n' + "Dictionary string");
            time5 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.dictCar2.ContainsKey(first.ToString());
                stopwatch.Stop();
                time5 += stopwatch.ElapsedMilliseconds;
            }
            time5 = time5 / 5;

            Console.WriteLine($"First = {time5}");

            time6 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.dictCar2.ContainsKey(mid.ToString());
                stopwatch.Stop();
                time6 += stopwatch.ElapsedMilliseconds;
            }
            time6 = time6 / 5;

            Console.WriteLine($"Mid = {time6}");

            time7 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.dictCar2.ContainsKey(last.ToString());
                stopwatch.Stop();
                time7 += stopwatch.ElapsedMilliseconds;
            }
            time7 = time7 / 5;

            Console.WriteLine($"Last = {time7}");

            time8 = 0;
            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                bool check = Collections.dictCar2.ContainsKey(other.ToString());
                stopwatch.Stop();
                time8 += stopwatch.ElapsedMilliseconds;
            }
            time8 = time8 / 5;

            Console.WriteLine($"Unknown = {time8}");
        }
    }
}