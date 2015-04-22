using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DiccionarioJuridicoV2.Dto
{
    public class Conceptos : INotifyPropertyChanged
    {
        private bool isSelected;
        private int idConcepto;
        private string concepto;
        private string conceptoStr;
        private DateTime fechaAlta;
        //private ObservableCollection<Sinonimos> sinonimos;
        private ObservableCollection<int> tesisRelacionadas;
        private int numTesis;

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
            }
        }

        public int IdConcepto
        {
            get
            {
                return this.idConcepto;
            }
            set
            {
                this.idConcepto = value;
            }
        }

        public string Concepto
        {
            get
            {
                return this.concepto;
            }
            set
            {
                this.concepto = value;
                this.OnPropertyChanged("Concepto");
            }
        }

        public string ConceptoStr
        {
            get
            {
                return this.conceptoStr;
            }
            set
            {
                this.conceptoStr = value;
            }
        }

        public DateTime FechaAlta
        {
            get
            {
                return this.fechaAlta;
            }
            set
            {
                this.fechaAlta = value;
            }
        }

        public int NumTesis
        {
            get
            {
                return this.numTesis;
            }
            set
            {
                this.numTesis = value;
            }
        }

        //public ObservableCollection<Sinonimos> Sinonimos
        //{
        //    get
        //    {
        //        return this.sinonimos;
        //    }
        //    set
        //    {
        //        this.sinonimos = value;
        //    }
        //}

        public ObservableCollection<int> TesisRelacionadas
        {
            get
            {
                return this.tesisRelacionadas;
            }
            set
            {
                this.tesisRelacionadas = value;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion // INotifyPropertyChanged Members
    }
}
