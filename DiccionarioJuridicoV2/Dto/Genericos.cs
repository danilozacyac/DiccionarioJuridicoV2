using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DiccionarioJuridicoV2.Dto
{
    public class Genericos : INotifyPropertyChanged
    {
        private int idGenerico;
        private string termino;
        private string terminoStr;
        private int idDefinicion;
        //private string definicion;
        //private string definicionStr;
        private ObservableCollection<int> conceptosAsociados;
        ObservableCollection<Definiciones> definiciones;
        private ObservableCollection<Sinonimos> sinonimos;
        private ObservableCollection<TesauroScjn> conceptosScjn;
        


        public int IdGenerico
        {
            get
            {
                return this.idGenerico;
            }
            set
            {
                this.idGenerico = value;
            }
        }

        public string Termino
        {
            get
            {
                return this.termino;
            }
            set
            {
                this.termino = value;
            }
        }

        public string TerminoStr
        {
            get
            {
                return this.terminoStr;
            }
            set
            {
                this.terminoStr = value;
            }
        }

        //public int IdDefinicion
        //{
        //    get
        //    {
        //        return this.idDefinicion;
        //    }
        //    set
        //    {
        //        this.idDefinicion = value;
        //    }
        //}

        //public string Definicion
        //{
        //    get
        //    {
        //        return this.definicion;
        //    }
        //    set
        //    {
        //        this.definicion = value;
        //        this.OnPropertyChanged("Definicion");
        //    }
        //}

        //public string DefinicionStr
        //{
        //    get
        //    {
        //        return this.definicionStr;
        //    }
        //    set
        //    {
        //        this.definicionStr = value;
        //    }
        //}

        public ObservableCollection<int> ConceptosAsociados
        {
            get
            {
                return this.conceptosAsociados;
            }
            set
            {
                this.conceptosAsociados = value;
            }
        }


        public ObservableCollection<Definiciones> Definiciones
        {
            get
            {
                return this.definiciones;
            }
            set
            {
                this.definiciones = value;
            }
        }


        public ObservableCollection<Sinonimos> Sinonimos
        {
            get
            {
                return this.sinonimos;
            }
            set
            {
                this.sinonimos = value;
            }
        }

        public ObservableCollection<TesauroScjn> ConceptosScjn
        {
            get
            {
                return this.conceptosScjn;
            }
            set
            {
                this.conceptosScjn = value;
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
