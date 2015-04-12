using System;
using System.Linq;

namespace DiccionarioJuridicoV2.Dto
{
    public class Sinonimos
    {
        private bool isSelected;
        private int idSinonimo;
        private string sinonimo;
        private string sinonimoStr;
        private string fuente;
        private string fuenteStr;
        private DateTime fechaAlta;
        private int fechaAltaInt;

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

        public int IdSinonimo
        {
            get
            {
                return this.idSinonimo;
            }
            set
            {
                this.idSinonimo = value;
            }
        }

        public string Sinonimo
        {
            get
            {
                return this.sinonimo;
            }
            set
            {
                this.sinonimo = value;
            }
        }

        public string SinonimoStr
        {
            get
            {
                return this.sinonimoStr;
            }
            set
            {
                this.sinonimoStr = value;
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

        public int FechaAltaInt
        {
            get
            {
                return this.fechaAltaInt;
            }
            set
            {
                this.fechaAltaInt = value;
            }
        }
    }
}
