using DriveWellApp.BusinessLogic;

namespace DriveWellApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            CarTypePicker.ItemsSource = Enum.GetValues<CarType>();
            YearPicker.ItemsSource = GetYear();
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
