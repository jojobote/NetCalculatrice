using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private Calcul c = new Calcul();
        private ObservableCollection<Calcul> _myList = new ObservableCollection<Calcul>();

        public MainWindow()
        {
            InitializeComponent();           

        }


        public String CurrentChaineCalc
        {
            get { return c.ChaineCalc; }
            set
            {
                if (c.ChaineCalc != value)
                {
                    c.ChaineCalc = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentChaineCalc)));
                }
                c.ChaineCalc = value;
            }
        }
        public String CurrentResult
        {
            get { return c.Result.ToString(); }
            set
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentResult)));
            }
        }

        public ObservableCollection<Calcul> MyList
        {
            get { return _myList; }
            set
            {
                if (_myList != value)
                {
                    _myList = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(MyList)));
                }
                _myList = value;
            }
        }
        private void triggerCalc()
        {
            if(c.ChaineCalc != "0")
            {
                c.processCalc();
                MyList.Add(c);
                c = new Calcul();
            }
        }

        private void addCalc(string valeur)
        {
            CurrentChaineCalc = (c.ChaineCalc == "0") ? valeur : String.Concat(c.ChaineCalc, valeur);
            CurrentResult = c.Result.ToString();
        }

        public void removeLast()
        {
            if(CurrentChaineCalc.Length > 0)
                CurrentChaineCalc = CurrentChaineCalc.Remove(CurrentChaineCalc.Length - 1);
        }

        private void button_0(object Sender, RoutedEventArgs e)
        {
            Button btn = Sender as Button;
            addCalc(btn.Content.ToString());
            resetFocus(btn);
        }
        

        private void handleKeys(object Sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.None:
                    break;
                case Key.Cancel:
                    break;
                case Key.Back:
                    removeLast();
                    CurrentResult = c.Result.ToString();
                    break;
                case Key.Tab:
                    break;
                case Key.LineFeed:
                    break;
                case Key.Clear:
                    break;
                case Key.Enter:
                    triggerCalc();
                    break;
                case Key.Pause:
                    break;
                case Key.Escape:
                    break;
                case Key.Space:
                    break;
                case Key.PageUp:
                    break;
                case Key.PageDown:
                    break;
                case Key.End:
                    break;
                case Key.Home:
                    break;
                case Key.Left:
                    break;
                case Key.Up:
                    break;
                case Key.Right:
                    break;
                case Key.Down:
                    break;
                case Key.Select:
                    break;
                case Key.Insert:
                    break;
                case Key.Delete:
                    break;
                case Key.Z:
                    break;
                case Key.LWin:
                    break;
                case Key.RWin:
                    break;
                case Key.Apps:
                    break;
                case Key.Sleep:
                    break;
                case Key.NumPad0:
                    addCalc("0");
                    break;
                case Key.NumPad1:
                    addCalc("1");
                    break;
                case Key.NumPad2:
                    addCalc("2");
                    break;
                case Key.NumPad3:
                    addCalc("3");
                    break;
                case Key.NumPad4:
                    addCalc("4");
                    break;
                case Key.NumPad5:
                    addCalc("5");
                    break;
                case Key.NumPad6:
                    addCalc("6");
                    break;
                case Key.NumPad7:
                    addCalc("7");
                    break;
                case Key.NumPad8:
                    addCalc("8");
                    break;
                case Key.NumPad9:
                    addCalc("9");
                    break;
                case Key.Multiply:
                    addCalc("*");
                    break;
                case Key.Add:
                    addCalc("+");
                    break;
                case Key.Separator:
                    break;
                case Key.Subtract:
                    addCalc("-");
                    break;
                case Key.Decimal:
                    addCalc(".");
                    break;
                case Key.Divide:
                    addCalc("/");
                    break;
                case Key.Scroll:
                    break;
                default:
                    break;
            }
        }

        private void Button_equal(object sender, RoutedEventArgs e)
        {
            triggerCalc();
        }

        private void Click_close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Click_reset_histo(object sender, RoutedEventArgs e)
        {
            MyList.Clear();
        }

        private void resetFocus(Button leBtn)
        {
            if (leBtn == null) return;

            var scope = FocusManager.GetFocusScope(leBtn);
            FocusManager.SetFocusedElement(scope, null);
            Keyboard.ClearFocus();
            Keyboard.Focus(this);
        }
    }

   
}
