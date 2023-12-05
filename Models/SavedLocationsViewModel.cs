using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TakPhone.Models;

namespace TakPhone.Models
{
    internal class SavedLocationsViewModel : INotifyPropertyChanged
    {
        public class GridLocation
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Name { get; set; }
        }

        public ICommand SaveCurrentLocationCommand { get; private set; }


        private ObservableCollection<GridLocation> savedLocations = new ObservableCollection<GridLocation>();

        public ObservableCollection<GridLocation> SavedLocations
        {
            get { return savedLocations; }
            set
            {
                if (savedLocations != value)
                {
                    savedLocations = value;
                    OnPropertyChanged();
                }
            }
        }

        public void AddLocation(GridLocation location)
        {
            savedLocations.Add(location);
            OnPropertyChanged(nameof(SavedLocations));
        }

        public void RemoveLocation(GridLocation location)
        {
            savedLocations.Remove(location);
            OnPropertyChanged(nameof(SavedLocations));

        }

        public void SaveCurrentLocation(double latitude, double longitude, string name)
        {
            AddLocation(new GridLocation { Latitude = latitude, Longitude = longitude, Name = name });
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}