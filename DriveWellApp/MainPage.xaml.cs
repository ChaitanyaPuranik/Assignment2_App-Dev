using DriveWellApp.BusinessLogic;

namespace DriveWellApp
{
    public partial class MainPage : ContentPage
    {

        CarInventory inventory = new CarInventory();

        /// <summary>
        /// Initializes MainPage.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            CarTypePicker.ItemsSource = Enum.GetValues<CarType>();
            YearPicker.ItemsSource = GetYear();
            CarsListView.ItemsSource = inventory.Cars;
            CarCountLabel.Text = $"Car count {inventory.Cars.Count()}";
            InventoryPricelabel.Text = $"Total inventory net price: {inventory.TotalInventoryNetPrice()}";
   
         }
        /// <summary>
        /// Creates list of years 
        /// </summary>
        /// <returns>List<years></returns>
        public List<int> GetYear()
        {
            List<int> years = new List<int>();
            for(int year = 2013;  year <= 2024;  year++)
            {
                years.Add(year);
            }
            return years;
        }
        /// <summary>
        /// Creates car object. 
        /// Adds the car to CarInventory List<Cars>
        /// Populates ItemSource with list of cars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAddCar(object sender, EventArgs e)
        {
            try
            {
                string vin = vinEntry.Text;
                string carmake = makeEntry.Text;
                CarType cartype = (CarType)CarTypePicker.SelectedItem;
                float price = float.Parse(priceEntry.Text);
                int year = int.Parse(YearPicker.SelectedItem.ToString());

                Car carobj = new Car(vin, carmake, cartype, price, year);
                inventory.AddCar(carobj);
                DisplayAlert("Car", $"Car added to inventory", "Ok");
                CarsListView.ItemsSource = null;
                CarsListView.ItemsSource = inventory.Cars;
                CarCountLabel.Text = $"Car count {inventory.Cars.Count()}";
                InventoryPricelabel.Text = $"Total inventory net price: {inventory.TotalInventoryNetPrice()}";
            }
            catch (Exception ex)
            {
                DisplayAlert("Error404",$"{ex}","Ok"); 
            }
        }
        /// <summary>
        /// Updates the attributes of Car except VIN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUpdateCar(object sender, EventArgs e)
        {
            try
            {
                vinLabel.Text = "Enter Car VIN to update: ";
                string vin = vinEntry.Text;

                if (inventory.GetByVIN(vin) is null)
                {
                    DisplayAlert("Error", $"Car with {vin} does not exists", "Ok");
                }
                else
                {
                    string carmake = makeEntry.Text;
                    CarType cartype = (CarType)CarTypePicker.SelectedItem;
                    float price = float.Parse(priceEntry.Text);
                    int year = int.Parse(YearPicker.SelectedItem.ToString());
                    inventory.UpdateCar(vin, carmake, cartype, price, year);
                    DisplayAlert("Car", $"Car updated successfully", "Ok");
                    CarsListView.ItemsSource = null;
                    CarsListView.ItemsSource = inventory.Cars;
                    CarCountLabel.Text = $"Car count {inventory.Cars.Count()}";
                    InventoryPricelabel.Text = $"Total inventory net price: {inventory.TotalInventoryNetPrice()}";
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Error404", $"{ex}", "Ok");
            }
        }

        /// <summary>
        /// Erases the input entered by user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClearCar(object sender, EventArgs e)
        {

            vinEntry.Text = null;
            makeEntry.Text = null;
            CarTypePicker.SelectedIndex = 0;
            CarImage.Source = "dotnet_bot.png";
            priceEntry.Text = null;
            YearPicker.SelectedItem = null;
        }

        /// <summary>
        /// Generates corresponding image on selection from picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectFromPicker(object sender, EventArgs e)
        {
            
            CarType cartype = (CarType)CarTypePicker.SelectedItem;
            switch (cartype)
            {
               
                case CarType.Coupe:
                    CarImage.Source = "coupe.png";
                    break;

                case CarType.Sedan:
                    CarImage.Source = "sedan.png";
                    break;

                case CarType.SUV:
                    CarImage.Source = "suv.png";
                    break;

                case CarType.Hatchback:
                    CarImage.Source = "hatchback.png";
                    break;

                case CarType.None:
                    CarImage.Source = "dotnet_bot,png";
                    break;

                default:
                    CarTypePicker.SelectedItem = null;
                    break;
            }
        }

        private void OnListviewSelect(object sender, SelectedItemChangedEventArgs e)
        {
            Car carobj = (Car)CarsListView.SelectedItem;
            vinEntry.Text = carobj.VIN;
            makeEntry.Text = carobj.CarMake;
            CarTypePicker.SelectedItem = carobj.CarType;
            priceEntry.Text = carobj.Price.ToString();
            YearPicker.SelectedItem = carobj.ModelYear;
        }
    }

}
