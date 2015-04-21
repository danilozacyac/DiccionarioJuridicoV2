using System;
using System.Linq;

namespace DiccionarioJuridicoV2.Dto
{
    public class Tesis
    {
        private int ius;
        private string rubro;
        private string texto;
        private string precedentes;

        public int Ius
        {
            get
            {
                return this.ius;
            }
            set
            {
                this.ius = value;
            }
        }

        public string Rubro
        {
            get
            {
                return this.rubro;
            }
            set
            {
                this.rubro = value;
            }
        }

        public string Texto
        {
            get
            {
                return this.texto;
            }
            set
            {
                this.texto = value;
            }
        }

        public string Precedentes
        {
            get
            {
                return this.precedentes;
            }
            set
            {
                this.precedentes = value;
            }
        }
    }
}
