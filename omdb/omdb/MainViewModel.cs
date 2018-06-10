using Acr.UserDialogs;
using omdb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace omdb
{
    public class MainViewModel:BindableObject
    {
        private string _search;
        private List<Content> _result = new List<Content>();
        public readonly ContentsService _service;

        public MainViewModel()
        {
            _service = new ContentsService();
        }

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged();
            }
        }

        public List<Content> Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public bool AnyItem => Result.Any();

        public ICommand SearchCommand => new Command(async () =>
        {
            UserDialogs.Instance.ShowLoading("Searching...");
            var result = await _service.SearchContentsAsync(Search);
            if(result == null)
            {
                UserDialogs.Instance.HideLoading();
                await UserDialogs.Instance.AlertAsync("There is no data available!", "Alert", "OK");
                this.Result = new List<Content>();
                OnPropertyChanged("AnyItem");
            }
            else
            {
                this.Result = result;
                OnPropertyChanged("AnyItem");
                UserDialogs.Instance.HideLoading();
            }
        });
       
        public ICommand ShareCommand => new Command<Content>((Content) =>
        {
            Device.OpenUri(new Uri(Content.Poster));
        });

    }
}
