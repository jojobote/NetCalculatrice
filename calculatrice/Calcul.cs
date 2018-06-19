using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Calculatrice
{
    public class Calcul
    {
        private string _chaineCalc;
        private double _result;
        private DataTable dt;

        public Calcul()
        {
            dt = new DataTable();
            _chaineCalc = "0";
            _result = 0;
        }

        public string ChaineCalc
        {
            get => _chaineCalc;
            set
            {
                _chaineCalc = value;
                if (char.IsDigit(_chaineCalc[ChaineCalc.Length - 1]))
                {
                    processCalc();
                }
            } 
        }
        public double Result { get => _result; set => _result = value; }

        //public void removeLast() { ChaineCalc = _chaineCalc.Remove(_chaineCalc.Length - 1); }

        public void processCalc()
        {
            try
            {
                _result = Convert.ToDouble(dt.Compute(_chaineCalc, "").ToString());
            }
            catch (Exception)
            {
                this.Result = Double.NaN;
                //((Double)e).
            }
        }
    }
}
