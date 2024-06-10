﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveWellApp.BusinessLogic
{
    class Car
    {
        string _vin;
        string _carMake;
        CarType _carType;
        float _price;
        int _modelYear;

        public Car(string vin, string carMake, CarType carType, float price, int modelYear)
        {
            VIN = vin;
            CarMake = carMake;
            CarType = carType;
            Price = price;
            ModelYear = modelYear;
        }

        public float NetPrice
        {
            get { return _price + (0.13F * _price); }
        }

        public override string ToString()
        {
            for(int i = 1; ; i++) 
            {
                return $"Car{i}: VIN: {VIN}, Car Make: {CarMake}, Type: {CarType}, Year: {ModelYear}, NetPrice: {NetPrice}";
            }
        }
        #region Properties
        public string VIN 
        {
            get { return _vin; }
            private set 
            { 
                if( value.Trim().Length <= 0 || value.Trim().Length > 17)
                {
                    throw new Exception("VIN number must be of 17 alphanumeric characters");
                }            
                _vin = value;
            }
        }

        public string CarMake
        {
            get { return _carMake; }
            private set 
            {
                if(value.Trim().Length == 0)
                {
                    throw new Exception("Car Make cannot be empty");
                }            
                _carMake = value;
            }
        }

        public CarType CarType
        {
            get { return _carType; }
            private set { _carType = value; }
        }

        public float Price
        {
            get { return _price; }
            private set 
            {
                if(value <= 0)
                {
                    throw new Exception("Invalid Price.");
                }
                _price = value;
            }
        }

        public int ModelYear
        {
            get { return _modelYear; }
            private set { value = _modelYear; }
        }
        #endregion
    }
}
