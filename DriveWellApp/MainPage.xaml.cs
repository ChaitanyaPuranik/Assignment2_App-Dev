using DriveWellApp.BusinessLogic;

namespace DriveWellApp
{
    public partial class MainPage : ContentPage
    {

        CarInventory inventory = new CarInventory();


        public MainPage()
        {
            InitializeComponent();
            CarTypePicker.ItemsSource = Enum.GetValues<CarType>();
            YearPicker.ItemsSource = GetYear();
            CarsListView.ItemsSource = inventory.Cars;
            CarCountLabel.Text = $"Car count {inventory.Cars.Count()}";
            InventoryPricelabel.Text = $"Total inventory net price: {inventory.TotalInventoryNetPrice()}";
            
            //GenerateCorrespondingCar();
        }

        public List<int> GetYear()
        {
            List<int> years = new List<int>();
            for(int year = 2013;  year <= 2024;  year++)
            {
                years.Add(year);
            }
            return years;
        }

        public void GenerateCorrespondingCar()
        {
            if ((CarType)CarTypePicker.SelectedItem == null)
            {
                CarImage.Source = "dotnet_bot.png";
            }

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

                default:
                    CarImage.Source = "dotnet_bot,png";
                    break;
            }
        }

        private void OnAddCar(object sender, EventArgs e)
        {
            try
            {
                string vin = vinEntry.Text;
                string carmake = makeEntry.Text;
                CarType cartype = (CarType)CarTypePicker.SelectedItem;
                GenerateCorrespondingCar();
                float price = float.Parse(priceEntry.Text);
                int year = (int)YearPicker.SelectedItem;

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
    }

}
