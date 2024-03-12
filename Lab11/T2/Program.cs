using System;
using VehicleLibrary1;
namespace T2
{ 
    internal class Program
    {
    static void FillCars(Stack<Vehicle> StackVehicle)
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
            StackVehicle.Push(car);
        }
    }
    static void ShowQueue(Stack<Vehicle> StackVehicle)
    {
        foreach (Vehicle item in StackVehicle)
        {
            item.Show();
            Console.WriteLine();
        }
    }
    static Stack<Vehicle> FindMaxCost(Stack<Vehicle> StackVehicle)
    {
        Stack<Vehicle> result = null;
        int maxCost = 0;
        foreach (Vehicle car in StackVehicle)
        {
            if (car is SUV && car.Price > maxCost)
            {
                result.Push(car);
                maxCost += car.Price;
            }
        }
        return result;
    }
    static double AverageSpeed(Stack<Vehicle> StackVehicle)
    {
        int count = 0;
        int sumSpeed = 0;
        foreach (Vehicle car in StackVehicle)
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
    static int SumCost(Stack<Vehicle> queueVehicle)
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
                Stack<Vehicle> stackVehicle = new Stack<Vehicle>(10);
                FillCars(stackVehicle);
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
                            stackVehicle.Push(car);
                            break;
                        }
                    case 2:
                        {
                            Vehicle removedVehicle = stackVehicle.Pop();
                            Console.WriteLine("Removed Vehicle: " + removedVehicle.Brand + removedVehicle.Id);
                            break;
                        }
                    case 3:
                        {
                            double avgSpeed = AverageSpeed(stackVehicle);
                            Console.WriteLine($"Средняя скорость легковых автомобилей: {avgSpeed} км/ч");
                            break;
                        }
                    case 4:
                        {
                            Stack<Vehicle> MaxCost = FindMaxCost(stackVehicle);
                            Console.WriteLine($"{MaxCost}");
                            break;
                        }
                    case 5:
                        {
                            int sumPrice = SumCost(stackVehicle);
                            Console.WriteLine($"Сумма стоимости всех машин: {sumPrice} рублей");
                            break;
                        }
                    case 6:
                        {
                            ShowQueue(stackVehicle);
                            break;
                        }
                    case 7:
                        {
                            Vehicle[] Arr = stackVehicle.ToArray();
                            Array.Sort(Arr, new SortByPrice());
                            Console.WriteLine("Отсортированный массив по стоимости:");
                            for (int i = 0; i < Arr.Length; i++)
                            {
                                Console.WriteLine(Arr[i]);
                            }
                            SUV searchElement = Arr.FirstOrDefault(vehicle => vehicle is SUV) as SUV;
                            if (searchElement != null)
                            {
                                Console.WriteLine("Внедорожник, который был найден: " + searchElement.Brand);
                            }
                            else
                            {
                                Console.WriteLine("Внедорожник не был найден");
                            }
                            break;
                        }
                    case 8:
                        {
                            Stack<Vehicle> clonedQueue = new Stack<Vehicle>(stackVehicle);
                            ShowQueue(stackVehicle);
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
