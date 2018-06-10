using omdb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace omdb
{
	public partial class MainPage : ContentPage
	{
        MainViewModel mainViewModel;
		public MainPage()
		{
			InitializeComponent();
            mainViewModel = new MainViewModel();
        }
        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e == null || e.Item == null)
            {
                await DisplayAlert("Error", "List item is null!", "OK");
                return;
            }
            var content = e.Item as Content;            
            var contentPage = new ContentViewPage(mainViewModel, content);
            await Application.Current.MainPage.Navigation.PushAsync(contentPage);           
        }
    }
}
