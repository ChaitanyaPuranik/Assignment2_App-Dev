using System;
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

        /// <summary>
        /// Initializes Field Variables
        /// </summary>
        /// <param name="vin">Type:string Initializes VIN</param>
        /// <param name="carMake">Type:string Initializes carMake</param>
        /// <param name="carType">Type:<Enum>CarType Initializes carType</param>
        /// <param name="price">Type:float Initializes price</param>
        /// <param name="modelYear">Type:int Initializes modelYear</param>
        public Car(string vin, string carMake, CarType carType, float price, int modelYear)
        {
            VIN = vin;
            CarMake = carMake;
            CarType = carType;
            Price = price;
            ModelYear = modelYear;
        }

        /// <summary>
        /// Returns _price with 13% Tax
        /// </summary>
        public float NetPrice
        {
            get { return _price + (0.13F * _price); }
        }

        /// <summary>
        /// Overides ToString() method 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            for(int i = 1;; i++) 
            {
                return $"Car: VIN: {VIN}, Car Make: {CarMake}, Type: {CarType}, Year: {ModelYear}, NetPrice: {NetPrice}";
            }
        }

        #region Properties

        /// <summary>
        /// Returns _vin and Initializes _vin after validations.
        /// </summary>
        public string VIN 
        {
            get { return _vin; }
            private set 
            { 
                if( value.Trim().Length <= 0 || value.Trim().Length != 17)
                {
                    throw new Exception("VIN number must be of 17 alphanumeric characters");
                }            
                _vin = value;
            }
        }

        /// <summary>
        /// Returns _carMake and Initializes _carMake after validations.
        /// </summary>
        public string CarMake
        {
            get { return _carMake; }
            internal set 
            {
                if(value.Trim().Length == 0)
                {
                    throw new Exception("Car Make cannot be empty");
                }            
                _carMake = value;
            }
        }

        /// <summary>
        /// Returns _carType and Initializes _carType after validations.
        /// </summary>
        public CarType CarType
        {
            get { return _carType; }
            internal set 
        {       if(value == CarType.None)
                {
                    throw new Exception("Car type cannot be None");
                }
                _carType = value; }
        }


        /// <summary>
        /// Returns _price and Initializes _price after validations.
        /// </summary>
        public float Price
        {
            get { return _price; }
            internal set 
            {
                if(value <= 0)
                {
                    throw new Exception("Invalid Price.");
                }
                _price = value;
            }
        }

        /// <summary>
        /// Returns _modelYear and Initializes _modelYear after validations.
        /// </summary>
        public int ModelYear
        {
            get { return _modelYear; }
            internal set { _modelYear = value; }
        }
        #endregion
    }
}
