using System;
using System.Linq;

namespace DiccionarioJuridicoV2.Dto
{
    public class TesauroScjn
    {
        private int id;
        private string conceptoScjn;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string ConceptoScjn
        {
            get
            {
                return this.conceptoScjn;
            }
            set
            {
                this.conceptoScjn = value;
            }
        }
    }
}
