using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fdlmobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class forView
    {
        public string codeProduct { get; set; }
        public string price { get; set; }
        public string title { get; set; }
        public Image image { get; set; }
        public string matter { get; set; }
        public string colour { get; set; }
        public string view { get; set; }
    }

    public partial class TabbedPage1 : ContentPage
    {
        List<forView> listForView = new List<forView>();
        public static string productURL = "http://www.fdl.somee.com/product";
        List<ProductModel> res = new List<ProductModel>();


        public TabbedPage1()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await products();
            CollectionViewMain.ItemsSource = listForView;
            CollectionViewMain.BindingContext = listForView;
        }
        private async Task products()
        {
            
            HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync(productURL);
                if (response.IsSuccessStatusCode)
                {
                    var js = response.Content.ReadAsStringAsync().Result;
                    res = JsonConvert.DeserializeObject<List<ProductModel>>(js);

                    foreach (var i in res)
                    {
                        forView newEl = new forView();
                        Image img = new Image();
                        var stream1 = new MemoryStream(i.image);
                        img.Source = ImageSource.FromStream(() => stream1);
                        newEl.image = img;
                        newEl.title = i.title;
                        newEl.price = i.price;
                        newEl.codeProduct = i.codeProduct;
                        newEl.colour = i.colour;
                        newEl.matter = i.colour;
                        newEl.view = i.view;
                        listForView.Add(newEl);
                    }
                }
            }
            catch (Exception e)
            {

            }


        }

        

        private async void CollectionViewMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null)
                return;
            forView selectedItem = e.CurrentSelection.Last() as forView;
            var forSend = res.Where(i => i.codeProduct == selectedItem.codeProduct).FirstOrDefault();
            await Navigation.PushAsync(new Info_protuct(forSend));
        }

        private void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
            {
                var listSearch = listForView.Where(item=>item.title.Contains(e.NewTextValue)|| item.matter.Contains(e.NewTextValue)|| item.colour.Contains(e.NewTextValue)).ToList();
                CollectionViewMain.ItemsSource = listSearch;
                CollectionViewMain.BindingContext = listSearch;
            }
            else
            {
                CollectionViewMain.ItemsSource = listForView;
                CollectionViewMain.BindingContext = listForView;
            }
        }
    }
}