using Sem12_P4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sem12_P4.ViewModels
{
    internal class SuperHeroViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SuperHero> Heroes { get; set; }
        public SuperHero selectedHero;
        public SuperHero SelectedHero
        {
            get => selectedHero;
            set
            {
                if (selectedHero != value)
                {
                    selectedHero = value;
                    OnPropertyChanged(nameof(SelectedHero));
                }
            }
        }
        public ICommand ShowHeroCommand { get; set; }
        public SuperHeroViewModel()
        {
            Heroes = new ObservableCollection<SuperHero>
            {
                new SuperHero { Name = "Superman", Power = "Volar, SuperFuerza", Image = "superman.png" },
                new SuperHero { Name = "Batman", Power = "Inteligenica, Dinero", Image = "batman.png" },
                new SuperHero { Name = "Spiderman", Power = "Trepar paredes, Sentido arácnido", Image = "spiderman.png" },
                new SuperHero { Name = "Flash", Power = "Velocidad", Image = "flash.png" }
            };

            SelectedHero = Heroes.Count > 0 ? Heroes[0] : null;

            ShowHeroCommand = new Command(async () =>
            {
                if (SelectedHero == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Superhéroe", "Selecciona un héroe", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Héroe Seleccionado", $"Nombre: {SelectedHero.Name}\nPoder: {SelectedHero.Power}", "OK");
                }
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }    
}

