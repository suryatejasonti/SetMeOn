using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : CarouselPage
    {
        MainViewModel viewmodel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new MainViewModel();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var currentPage = (YBItem)CurrentPage.BindingContext;
            var page = new TYBBrowser(currentPage.LinkURL);
            Navigation.PushModalAsync(page);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewmodel.GetDataAsync(1);
        }
        protected async override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            if( Children.IndexOf(CurrentPage)+6 == Children.Count)
            {
                await viewmodel.GetDataAsync((this.Children.Count/int.Parse(Constants.PostCount))+1);
            }
        }
    }
}
