using Xamarin.Forms;

namespace Challenge
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm = new MainViewModel();
        }

        private void addData_Clicked(object sender, System.EventArgs e)
        {
            vm.AddData();
        }

        private void txtMarca_Completed(object sender, System.EventArgs e)
        {
            txtModelo.Focus();
        }

        private void txtModelo_Completed(object sender, System.EventArgs e)
        {
            txtAnio.Focus();
        }

        private void txtAnio_Completed(object sender, System.EventArgs e)
        {
            vm.AddData();
        }
    }
}
