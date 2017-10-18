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
using System.Net;
using System.Threading;
using System.IO;

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

            GetFunFactsCommand = new DelegateCommand(GetFunFacts);
            GetFunFactsAsyncCommand = new DelegateCommand(GetFunFactsAsync);
            ClearFactsCommand = new DelegateCommand(ClearFacts);

        }

        private void ClearFacts()
        {
            FunFactCollection.Clear();
        }

        private async void GetFunFactsAsync()
        {
            using (var client = new HttpClient())
            {
                InitializeClient(client);

                HttpResponseMessage getTask = await client.GetAsync("http://localhost:51055/api/FunFacts");

                List<FunFact> contentTask = await getTask.Content.ReadAsAsync<List<FunFact>>();

                FunFactCollection = new ObservableCollection<FunFact>(contentTask);

            }
        }

        private void GetFunFacts()
        {
            WebRequest request = WebRequest.Create("http://localhost:51055/api/FunFacts");
            WebResponse responseTask = request.GetResponse();
            WebResponse response = responseTask;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string content = reader.ReadToEnd();
                List<FunFact> facts = JsonConvert.DeserializeObject<List<FunFact>>(content);
                FunFactCollection = new ObservableCollection<FunFact>(facts);
            }

        }



        private static void InitializeClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:51055/api/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
