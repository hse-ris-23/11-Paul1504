using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleLibrary1;

namespace Т3
{
    internal class Collections
    {
        public Queue<Car> queueCar1 = new Queue<Car>();
        public Queue<string> queueCar2 = new Queue<string>();
        public Dictionary<Vehicle, Car> dictCar1 = new Dictionary<Vehicle, Car>();
        public Dictionary<string, Car> dictCar2 = new Dictionary<string, Car>();

        public Collections()
        {
            for (int i = 0; i < 1000; i++)
            {
                Car car = new Car();
                car.RandomInit();

                queueCar1.Enqueue(car);
                queueCar2.Enqueue(car.ToString());

                dictCar1.Add(car.BaseCar,car);
                dictCar2.Add(car.ToString(), car);
            }
        }
    }
}
