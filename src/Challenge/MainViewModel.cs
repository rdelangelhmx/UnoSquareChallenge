using Acr.UserDialogs;
using Challenge.Interfaces;
using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Challenge
{    
    public class MainViewModel : INotifyPropertyChanged
    {
        public IUserDialogs PageDialog = UserDialogs.Instance;

        #region Bindables
        bool isBusy = false;
        public bool IsBusy { get => isBusy; set { isBusy = value; OnPropertyChanged(nameof(IsBusy)); } }

        string bundleName;
        public string BundleName { get => bundleName; set { bundleName = value; OnPropertyChanged(nameof(BundleName)); } }

        string marca;
        public string Marca { get => marca; set { marca = value; OnPropertyChanged(nameof(Marca)); } }

        string modelo;
        public string Modelo { get => modelo; set { modelo = value; OnPropertyChanged(nameof(Modelo)); } }

        string anio;
        public string Anio { get => anio; set { anio = value; OnPropertyChanged(nameof(Anio)); } }

        ObservableCollection<ItemEntry> data;
        public ObservableCollection<ItemEntry> Data { get => data; set { data = value; OnPropertyChanged(nameof(data)); } }
        #endregion

        public MainViewModel()
        {
            BundleName = DependencyService.Get<IAppInfo>().GetPackageName;
            InitList();
        }

        public void InitList()
        {
            Data = new ObservableCollection<ItemEntry>(new List<ItemEntry>
            {
                new ItemEntry() { Marca = "GMC", Modelo = "Cheyenne", Anio = 2010},
                new ItemEntry() { Marca = "Ford", Modelo = "Lobo", Anio = 2011},
            });
        }

        public void AddData()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            var err = 0;
            // validating empty
            #region Manual Validations
            if (string.IsNullOrEmpty(Marca))
                err++;
            if (string.IsNullOrEmpty(Modelo))
                err++;
            if (string.IsNullOrEmpty(Anio))
                err++;
            var year = 0;
            if(!int.TryParse(Anio, out year))
                err++;
            if (err > 0)
            {
                Toast("Existen errores en la captura");
                IsBusy = false;
                return;
            }
            var duplicados = data.Any(w => w.Marca == Marca || w.Modelo == Modelo || w.Anio == year);
            if (duplicados)
            {
                Toast("Existen datos similares en la lista");
                IsBusy = false;
                return;
            }
            #endregion
            data.Add(new ItemEntry() { Marca = Marca, Modelo = Modelo, Anio = year });
            Marca = "";
            Modelo = "";
            Anio = "";
            Toast("Registro agregado");
            IsBusy = false;
            return;
        }

        public void Toast(string message, int seconds = 5)
        {
            PageDialog.Toast(message, new TimeSpan(0, 0, seconds));
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
