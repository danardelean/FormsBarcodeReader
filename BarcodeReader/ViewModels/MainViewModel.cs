using System;
using BarcodeReader.Resx;
using Xamarin.Forms;

namespace BarcodeReader.ViewModels
{
    [QueryProperty(nameof(BarcodeValue), "barcode")]
    [QueryProperty(nameof(BarcodeType), "type")]
    public class MainViewModel:BaseViewModel
    {
        public MainViewModel()
        {
            Title = AppResources.MainPage_Title;
            CommandReadBarcode = new Command(async () =>
              {
                  BarcodeType = null;
                  BarcodeValue = null;
                  await Shell.Current.GoToAsync(nameof(BarcodeViewModel));
              });
        }

        string _barcodeValue;
        public string BarcodeValue { get => _barcodeValue; set => SetProperty(ref _barcodeValue, value); }


        string _barcodeType;
        public string BarcodeType { get => _barcodeType; set => SetProperty(ref _barcodeType, value); }


        public Command CommandReadBarcode { get;private set; }

       
    }
}
