using NotDefteri.Modeller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotDefteri
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Notlar notlar;        
        public MainPage()
        {
            InitializeComponent();
            notlar = new Notlar();           
            BindingContext = notlar;
        }

        void NotKaydet(object sender, EventArgs e)
        {
            var gelenNot = (Notlar)BindingContext;

            if (gelenNot == null)
            {
                // Yeni Kaydet
                Notlar.NotuKaydet(notlar, notGirisi.Text);
            }
            else
            {
                //Güncelle
                Notlar.NotuKaydet(gelenNot, notGirisi.Text);
            }
        }
        
        void NotSil(object sender, EventArgs e)
        {
            var silinecekNot = (Notlar)BindingContext;
            Notlar.NotuSil(silinecekNot);
        }

        


    }
}
