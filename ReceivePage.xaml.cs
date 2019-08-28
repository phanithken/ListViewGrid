﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ListViewGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReceivePage : Page
    {
        public ReceivePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameters = (ItemModel)e.Parameter;
            this.Image.Source = new BitmapImage(new Uri($"ms-appx:///{parameters.Image}"));
            this.Title.Text = parameters.Title;
            this.Price.Text = parameters.Price;
            this.ID.Text = parameters.ID;

            base.OnNavigatedTo(e);
        }

        private void Goback(object sender, RoutedEventArgs args)
        {
            Frame.GoBack();
        }
    }
}
