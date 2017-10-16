using Prism.Commands;
using Prism.Mvvm;
using SimpleAsync.Library;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using System.Collections.Generic;

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
            MessageBox.Show("Working");
        }

        private void GetFunFacts()
        {
            MessageBox.Show("Working");
        }
    }
}
