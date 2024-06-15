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

        /// <summary>
        /// Initializes 3 Car object instances with hardcoded values and Adds Car to List
        /// </summary>
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

        /// <summary>
        /// Adds carobject to List<cars>
        /// </summary>
        /// <param name="carobject">Type:Car. Accepts carobject as an arguement.</param>
        /// <exception cref="Exception"></exception>
        public void AddCar(Car carobject)
        {
            if(GetByVIN(carobject.VIN) is not null)
            {
                throw new Exception("Car already exists");
            }
            cars.Add(carobject);
                
        }

        /// <summary>
        /// Returns car object with matching VIN
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns List of cars.
        /// </summary>
        public List<Car> Cars
        {
            get { return cars; }
        }

        /// <summary>
        /// Computes total inventory net price.
        /// </summary>
        /// <returns></returns>
        public float TotalInventoryNetPrice()
        {
            float totalInventoryNetPrice = 0;
            foreach(Car carprice in cars) 
            {
                totalInventoryNetPrice += carprice.NetPrice;
            }
            return totalInventoryNetPrice;
        }

        /// <summary>
        /// Updates Atributes of car with corresponding VIN
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="carmake"></param>
        /// <param name="cartype"></param>
        /// <param name="price"></param>
        /// <param name="year"></param>
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
