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
            //InventoryPricelabel.Text = $"Total inventory net price: {}";
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

        private void OnAddCar(object sender, EventArgs e)
        {
            try
            {
                string vin = vinEntry.Text;
                string carmake = makeEntry.Text;
                CarType cartype = (CarType)CarTypePicker.SelectedItem;
                float price = float.Parse(priceEntry.Text);
                int year = (int)YearPicker.SelectedItem;

                Car carobj = new Car(vin, carmake, cartype, price, year);
                inventory.AddCar(carobj);
                DisplayAlert("Car", $"Car added to inventory", "Ok");
                CarsListView.ItemsSource = null;
                CarsListView.ItemsSource = inventory.Cars;
                CarCountLabel.Text = $"Car count {inventory.Cars.Count()}";
            }
            catch (Exception ex)
            {
                DisplayAlert("Error404",$"{ex}","Ok"); 
            }
        }
    }

}
