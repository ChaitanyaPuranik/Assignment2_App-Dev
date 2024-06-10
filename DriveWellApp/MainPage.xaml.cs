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
            CarsListView.ItemsSource = null;
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
       
    }

}
