using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    class Historique : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Calcul> _histo;

        public Historique()
        {
            _histo = new ObservableCollection<Calcul>();
        }

        public ObservableCollection<Calcul> Histo { get => _histo;
            set
            {
                _histo = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Histo)));
            }
        }
    }
}
