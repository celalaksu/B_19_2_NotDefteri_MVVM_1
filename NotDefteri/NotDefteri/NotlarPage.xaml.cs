using NotDefteri.Modeller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotDefteri
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotlarPage : ContentPage
    {
        

        public NotlarPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notlar = new List<Notlar>();

            //var dosyalar = Directory.EnumerateFiles(App.DosyaYolu, "*.notlar.txt");
            //foreach (var dosyaadi in dosyalar)
            //{
            //    notlar.Add(new Notlar
            //    {
            //        DosyaAdi = dosyaadi,
            //        NotMetni = File.ReadAllText(dosyaadi),
            //        NotTarih = File.GetCreationTime(dosyaadi)
            //    });
            //}

            notlar = Notlar.NotlariListele();

            notlarListView.ItemsSource = notlar
                .OrderBy(d => d.NotTarih)
                .ToList();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage
            {
                BindingContext = new Notlar()
            });
        }

        private async void notlarListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MainPage
                {
                    BindingContext = e.SelectedItem as Notlar
                });
            }
        }
    }
}