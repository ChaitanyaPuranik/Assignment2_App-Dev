//using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveWellApp.BusinessLogic
{
    internal class CarInventory
    {
        List<Car> cars = new List<Car>();

        public CarInventory()
        {
            //Hardcoded Car instances
            Car car1 = new Car("1HGCM82633A123456", "BMW", CarType.Sedan, 80000.50F, 2021);
            Car car2 = new Car("JH4KA8260MC123456", "Mercedes", CarType.Sedan, 75000.50F, 2019);
            Car car3 = new Car("1J4GZ58S7VC123456", "Audi", CarType.Coupe, 90000.00F, 2022);
            AddCar(car1);
            AddCar(car2);
            AddCar(car3);

        }

        public void AddCar(Car carobject)
        {

            if(GetByVIN(carobject.VIN) is not null)
            {
                throw new Exception("Car already exists");
            }
            cars.Add(carobject);
                
        }

        public Car GetByVIN(string vin)
        {
            foreach(Car c in cars)
            {
                if (c.VIN == vin)
                {
                    return c;
                }
            }   
            return null;
        }

        public List<Car> Cars
        {
            get { return cars; }
        }

        public float TotalInventoryNetPrice()
        {
            float totalInventoryNetPrice = 0;
            foreach(Car carprice in cars) 
            {
                totalInventoryNetPrice += carprice.NetPrice;
            }
            return totalInventoryNetPrice;
            
        }

        public void UpdateCar(string vin, string carmake, CarType cartype, float price, int year)
        {
            foreach(Car car in cars)
            {
                if (car.VIN == vin)
                {
                    car.CarMake = carmake;
                    car.CarType = cartype;
                    car.Price = price;
                    car.ModelYear = year;

                }
            }
           
        }
    }

    
}
