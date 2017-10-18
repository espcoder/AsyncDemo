using Prism.Commands;
using Prism.Mvvm;
using SimpleAsync.Library;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleAsync.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Hello, Hands of Hope NW";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        private ObservableCollection<FunFact> _funFactCollection;

        public ObservableCollection<FunFact> FunFactCollection
        {
            get { return _funFactCollection; }
            set { SetProperty(ref _funFactCollection, value); }
        }

        public DelegateCommand GetFunFactsCommand { get; set; }
        public DelegateCommand GetFunFactsAsyncCommand { get; set; }
        public DelegateCommand ClearFactsCommand { get; set; }

        public MainWindowViewModel()
        {
            FunFactCollection = new ObservableCollection<FunFact>();

            FunFactCollection.Add(new FunFact { Fact = "Test Fact", Impacts =new List<string>() { "Fun" } });


            GetFunFactsCommand = new DelegateCommand(GetFunFacts);
            GetFunFactsAsyncCommand = new DelegateCommand(GetFunFactsAsync);
            ClearFactsCommand = new DelegateCommand(ClearFacts);

        }

        private void ClearFacts()
        {
            FunFactCollection.Clear();
        }

        private void GetFunFactsAsync()
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);

                Task<HttpResponseMessage> getTask = client.GetAsync("http://localhost:51055/api/FunFacts");

                Task<List<FunFact>> contentTask = getTask.Result.Content.ReadAsAsync<List<FunFact>>();

                FunFactCollection = new ObservableCollection<FunFact>(contentTask.Result);

            }
        }

        private void GetFunFacts()
        {
            MessageBox.Show("Working");
        }



        private static void InitializeClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:51055/api/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
