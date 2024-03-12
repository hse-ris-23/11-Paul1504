using System;
using System.Collections.Generic;
using VehicleLibrary1;
namespace Lab11

{
    internal class Program
    {
        static void FillCars(Queue<Vehicle> queueVehicle)
        {
            for (int i = 0; i < 10; i++)
            {
                Vehicle car;
                if (i % 4 == 0)
                    car = new Car();
                else if (i % 4 == 1)
                    car = new SUV();
                else
                    car = new Truck();
                car.RandomInit();
                queueVehicle.Enqueue(car);
            }
        }
        static void ShowQueue(Queue<Vehicle> queueVehicle)
        {
            foreach (Vehicle item in queueVehicle)
            {
                item.Show();
                Console.WriteLine();
            }
        }
        static Queue<Vehicle> FindMaxCost(Queue<Vehicle> queueVehicle)
        {
            Queue<Vehicle> result = null;
            int maxCost = 0;
            foreach (Vehicle car in queueVehicle)
            {
                if (car is SUV && car.Price > maxCost)
                {
                    result.Enqueue(car);
                    maxCost += car.Price;
                }
            }
            return result;
        }
        static double AverageSpeed(Queue<Vehicle> queueVehicle)
        {
            int count = 0;
            int sumSpeed = 0;
            foreach (Vehicle car in queueVehicle)
            {
                if (car is Car)
                {
                    Car Car = car as Car;
                    sumSpeed += Car.MaxSpeed;
                    count++;
                }
            }
            if (count > 0)
            {
                double avg = (double)sumSpeed / count;
                return avg;
            }
            return 0;
        }
        static int SumCost(Queue<Vehicle> queueVehicle)
        {
            int sumCost = 0;
            foreach (Vehicle car in queueVehicle)
            {
                sumCost += car.Price;
            }
            return sumCost;
        }
        static void Main(string[] args)
        {
            bool isSucceed;
            int choice;
            do
            {
                Console.WriteLine('\n' + "1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Вывести среднюю скорость легковых автомобилей");
                Console.WriteLine("4. Вывести максимальную скорость среди всех автомобилей");
                Console.WriteLine("5. Вывести сумму цен всех автомобилей из списка");
                Console.WriteLine("6. Вывести очередь");
                Console.WriteLine("7. Отсортировать и найти грузовик по Id");
                Console.WriteLine("8. Clone и ShallowCopy");
                Console.WriteLine("9. Выход ");
                do
                {
                    string tmp = Console.ReadLine();
                    isSucceed = int.TryParse(tmp, out choice);
                    if (!isSucceed)
                    {
                        Console.WriteLine("Неверный ввод.Попробуйте еще раз.");
                    }
                } while (!isSucceed);
                Queue<Vehicle> vehicleQueue = new Queue<Vehicle>(10);
                FillCars(vehicleQueue);
                switch (choice)
                { 
                    case 1:
                        {
                            Console.WriteLine("Какую машину вы хотите добавить: 1)Легковую 2)Грузовую 3)Внедорожник");
                            int answ = int.Parse(Console.ReadLine());
                            Vehicle car = new Vehicle();
                            if (answ == 1)
                                car = new Car();
                            else if (answ == 2)
                               car = new Truck();
                            else if (answ == 3)
                                car = new SUV();
                            else
                                Console.WriteLine("Введите число от 1 до 3");
                            car.Init();
                            vehicleQueue.Enqueue(car);
                            break;
                        }
                        case 2:
                        {
                            Vehicle removedVehicle = vehicleQueue.Dequeue();
                            Console.WriteLine("Удаенная машина: " + removedVehicle.Brand + removedVehicle.Id);
                            break;
                        }
                    case 3:
                        {
                            double avgSpeed = AverageSpeed(vehicleQueue);
                            Console.WriteLine($"Средняя скорость легковых автомобилей: {avgSpeed} км/ч");
                            break;
                        }
                    case 4:
                        {
                            Queue<Vehicle> MaxCost = FindMaxCost(vehicleQueue);
                            Console.WriteLine($"{MaxCost}");
                            break;
                        }
                    case 5:
                        {
                            int sumPrice = SumCost(vehicleQueue);
                            Console.WriteLine($"Сумма стоимости всех машин: {sumPrice} рублей");
                            break;
                        }
                    case 6:
                        {
                            ShowQueue(vehicleQueue);
                            break;
                        }
                    case 7:
                        {
                            Vehicle[] Arr = vehicleQueue.ToArray();
                            Array.Sort(Arr, new SortByPrice());
                            Console.WriteLine("Отсортированный массив по стоимости:");
                            for(int i = 0; i < Arr.Length; i++)
                            {
                                Console.WriteLine(Arr[i]);
                            }
                            SUV searchElement = Arr.FirstOrDefault(vehicle => vehicle is SUV) as SUV;
                            if (searchElement != null)
                            {
                                Console.WriteLine("Внедорожник, который был найден: " + searchElement.Brand + searchElement.Id);
                            }
                            else
                            {
                                Console.WriteLine("Внедорожник не был найден");
                            }
                            break;
                        }
                    case 8:
                        {
                            Queue<Vehicle> clonedQueue = new Queue<Vehicle>(vehicleQueue);
                            ShowQueue(clonedQueue);
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Завершение работы программы.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню.");
                            break;
                        }
                }
            } while (choice != 9);
        }
    }
}
