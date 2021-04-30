using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmHelpers.Commands;
using Xamarin.Essentials;

namespace BarcodeReader.ViewModels
{
    public class BarcodeViewModel:BaseViewModel
    {
        public BarcodeViewModel()
        {
            CommandScannedBarcode = new AsyncCommand<ZXing.Result>(async (barcode)=>await OnBarcodeScannedAsync(barcode));
        }

        public AsyncCommand<ZXing.Result> CommandScannedBarcode { get; private set; }

        bool _isScanning = true;
        public bool IsScanning { get => _isScanning; set => SetProperty(ref _isScanning, value); }

        SemaphoreSlim _barcodeLock=new SemaphoreSlim(1); 
        async Task OnBarcodeScannedAsync(ZXing.Result barcode)
        {
            if (barcode == null)
                return;
            IsScanning = false;
            if (_barcodeLock.CurrentCount == 0)
                return;
            await _barcodeLock.WaitAsync();
           
            Vibrate();
            if (!Xamarin.Essentials.MainThread.IsMainThread)
            {
                await Xamarin.Essentials.MainThread.InvokeOnMainThreadAsync(async () => await GoBack(barcode));
                return;
            }
            await GoBack(barcode);
            _barcodeLock.Release();
        }

        async Task GoBack(ZXing.Result barcode)
        {
            await AppShell.Current.GoToAsync($"..?barcode={barcode.Text}&type={barcode.BarcodeFormat}");
        }

        void Vibrate()
        {
            try
            {
                Vibration.Vibrate(TimeSpan.FromMilliseconds(300));
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch(Exception ex)
            {

            }
        }

    }
}
