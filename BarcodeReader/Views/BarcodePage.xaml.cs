using System;
using System.Collections.Generic;
using BarcodeReader.ViewModels;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace BarcodeReader.Views
{
    public partial class BarcodePage : ContentPage
    {
        public BarcodePage()
        {
            BindingContext = App.ServiceProvider.GetService<BarcodeViewModel>();
            InitializeComponent();
        }
    }
}
