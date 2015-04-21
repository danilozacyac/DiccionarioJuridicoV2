using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DiccionarioJuridicoV2.Dto
{
    public class Genericos
    {
        private int idGenerico;
        private string termino;
        private string terminoStr;
        private string definicion;
        private string definicionStr;
        private ObservableCollection<Conceptos> conceptosAsociados;
        private ObservableCollection<Sinonimos> sinonimos;

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

        public string Definicion
        {
            get
            {
                return this.definicion;
            }
            set
            {
                this.definicion = value;
            }
        }

        public string DefinicionStr
        {
            get
            {
                return this.definicionStr;
            }
            set
            {
                this.definicionStr = value;
            }
        }

        public ObservableCollection<Conceptos> ConceptosAsociados
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

        
    }
}
