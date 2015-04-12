using System;
using System.Collections.ObjectModel;
using System.Linq;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;

namespace DiccionarioJuridicoV2.Singletons
{
    public class ArbolesSingleton
    {

        private static ObservableCollection<Temas> constitucional;
        private static ObservableCollection<Temas> penal;
        private static ObservableCollection<Temas> civil;
        private static ObservableCollection<Temas> administrativa;
        private static ObservableCollection<Temas> laboral;
        private static ObservableCollection<Temas> comun;
        private static ObservableCollection<Temas> derechos;

        private ArbolesSingleton()
        {
        }

        public static ObservableCollection<Temas> Temas(int idMateria)
        {
            switch (idMateria)
            {
                case 1:
                    if (constitucional == null)
                        constitucional = TemasModel.GetTemasConstitucional(null);

                    return constitucional;

                case 2:
                    if (penal == null)
                        penal = TemasModel.GetTemasTematico(null, idMateria);

                    return penal;

                case 4:
                    if (civil == null)
                        civil = TemasModel.GetTemasTematico(null, idMateria);

                    return civil;

                case 8:
                    if (administrativa == null)
                        administrativa = TemasModel.GetTemasTematico(null, idMateria);

                    return administrativa;

                case 16:
                    if (laboral == null)
                        laboral = TemasModel.GetTemasTematico(null, idMateria);

                    return laboral;

                case 32:
                    if (comun == null)
                        comun = TemasModel.GetTemasTematico(null, idMateria);

                    return comun;

                case 64:
                    if (derechos == null)
                        derechos = TemasModel.GetTemasTematico(null, idMateria);

                    return derechos;

                default: return null;
            }


        }


    }
}
