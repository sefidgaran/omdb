using Acr.UserDialogs;
using omdb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace omdb
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContentViewPage : ContentPage
    {
		public ContentViewPage (MainViewModel mainViewModel,Content detail)
		{
			InitializeComponent ();
            UserDialogs.Instance.ShowLoading("Loading...");
            ContentModel contentModel = null;
            Task.Run(async () => {
                var result = await mainViewModel._service.GetContentAsync(detail.imdbID);
                contentModel = result;
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (contentModel != null)
                        this.BindingContext = contentModel;
                    UserDialogs.Instance.HideLoading();
                });
            });           

        }

    }
}
