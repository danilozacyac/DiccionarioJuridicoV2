using System;
using System.Collections.ObjectModel;
using System.Linq;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;

namespace DiccionarioJuridicoV2.Singletons
{
    public class TesauroScjnSingleton
    {

        private static ObservableCollection<TesauroScjn> conceptosScjn;

        private TesauroScjnSingleton()
        {
        }

        public static ObservableCollection<TesauroScjn> ConceptosScjn
        {

            get
            {
                if (conceptosScjn == null)
                    conceptosScjn = new TesauroScjnModel().GetTerminosScjn();

                return conceptosScjn;
            }


        }
    }
}
