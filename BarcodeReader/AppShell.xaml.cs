using BarcodeReader.ViewModels;
using BarcodeReader.Views;
using Xamarin.Forms;

namespace BarcodeReader
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BarcodeViewModel), typeof(BarcodePage));
        }

    }
}
