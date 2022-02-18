using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fdlmobile
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //private async void Button_ClickedToNextPage(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Catalog());
        //}

        private async void Button_Clicked_vhod(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TabbedPage1());
        }
    }
}
