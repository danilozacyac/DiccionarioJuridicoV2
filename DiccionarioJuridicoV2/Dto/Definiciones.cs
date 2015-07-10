using System;
using System.Linq;

namespace DiccionarioJuridicoV2.Dto
{
    public class Definiciones
    {
        private int idDefinicion;
        private int idGenerico;
        private string definicion;
        private string definicionStr;
        private string fuente;
        private string fuenteStr;

        public int IdDefinicion
        {
            get
            {
                return this.idDefinicion;
            }
            set
            {
                this.idDefinicion = value;
            }
        }

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

        public string Fuente
        {
            get
            {
                return this.fuente;
            }
            set
            {
                this.fuente = value;
            }
        }

        public string FuenteStr
        {
            get
            {
                return this.fuenteStr;
            }
            set
            {
                this.fuenteStr = value;
            }
        }
    }
}
