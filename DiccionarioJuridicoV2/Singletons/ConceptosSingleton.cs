using System;
using System.Collections.ObjectModel;
using System.Linq;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;

namespace DiccionarioJuridicoV2.Singletons
{
    public class ConceptosSingleton
    {

        private static ObservableCollection<Conceptos> conceptos;

        private ConceptosSingleton()
        {
        }

        public static ObservableCollection<Conceptos> Conceptos
        {

            get
            {
                if (conceptos == null)
                    conceptos = new ConceptosModel().GetConceptos();

                return conceptos;
            }


        }
    }
}
