using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fdlmobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class Info_protuct : ContentPage
    {
    
        forView listForView = new forView();
        public static string productURL = "http://www.fdl.somee.com/product";
        public Info_protuct(ProductModel forview)
        {
            InitializeComponent();
            //ImgG.Source = forview.image.Source;
            byte[] imageArray = forview.image; // is your data
            var stream1 = new MemoryStream(imageArray);
            try
            {
                ImgG.Source = ImageSource.FromStream(() => stream1);
            }
            catch
            {
                stream1.Dispose();
                throw;
            }
            titleLab.Text = forview.title;
            viewLab.Text = $"Вид растения: {forview.view}";
            priceLab.Text = $"{forview.price} ₽";
            matterLab.Text = forview.matter;
            colourLab.Text = forview.colour;
            //codeProductLab.Text = forview.codeProduct;
        }

       

        }
    }