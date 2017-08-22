using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TYBBrowser : ContentPage
    {
        public TYBBrowser(string URL)
        {
            InitializeComponent();
            Browser.Source = URL;
        }
    }
}