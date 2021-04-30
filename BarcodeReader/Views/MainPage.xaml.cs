using BarcodeReader.ViewModels;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace BarcodeReader.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = App.ServiceProvider.GetService<MainViewModel>();
            InitializeComponent();
        }
    }
}
