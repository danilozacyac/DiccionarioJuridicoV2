using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using DiccionarioJuridicoV2.Singletons;
using ScjnUtilities;

namespace DiccionarioJuridicoV2.UserControls
{
    /// <summary>
    /// Lógica de interacción para RGenFigScjn.xaml
    /// </summary>
    public partial class RGenFigScjn : UserControl
    {
        private ObservableCollection<Genericos> listaGenericos;
        private Genericos genericoSelected;

        public RGenFigScjn(ObservableCollection<Genericos> listaGenericos)
        {
            InitializeComponent();
            this.listaGenericos = listaGenericos;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            RLstGenericos.DataContext = listaGenericos;
            RLstFiguras.DataContext = ConceptosSingleton.Conceptos;
            RLstScjn.DataContext = TesauroScjnSingleton.ConceptosScjn;
        }

        private void RLstGenericos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            genericoSelected = RLstGenericos.SelectedItem as Genericos;

            foreach (Conceptos concept in this.ConceptosState(true))
            {
                concept.IsSelected = false;
            }

            if (genericoSelected.ConceptosAsociados == null)
                genericoSelected.ConceptosAsociados = new RelacionesModel().GetRelations(genericoSelected.IdGenerico, 1);

            foreach (int concepto in genericoSelected.ConceptosAsociados)
            {
                Conceptos con = (from n in ConceptosSingleton.Conceptos
                                 where n.IdConcepto == concepto
                                 select n).ToList()[0];
                if (con != null)
                    con.IsSelected = true;
            }
        }

        private void RbtnGuardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RelacionesModel model = new RelacionesModel();

            foreach (int id in genericoSelected.ConceptosAsociados)
            {
                model.DeleteRelation(genericoSelected.IdGenerico, id, 1);
            }

            foreach (Conceptos conceptSelect in this.ConceptosState(true))
            {
                new RelacionesModel().SetNewRelation(genericoSelected.IdGenerico, conceptSelect.IdConcepto, 1);
            }
        }

        private List<Conceptos> ConceptosState(bool isSelectedState)
        {
            List<Conceptos> seleccionadas = (from n in ConceptosSingleton.Conceptos
                                             where n.IsSelected == isSelectedState
                                             select n).ToList();
            return seleccionadas;
        }

        private void SearchConceptos_Search(object sender, System.Windows.RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
            {
                this.RLstFiguras.DataContext = (from n in ConceptosSingleton.Conceptos
                                                     where n.Concepto.ToUpper().Contains(StringUtilities.ConvMayEne(tempString)) 
                                                     select n).ToList();
            }
            else
                this.RLstFiguras.DataContext = ConceptosSingleton.Conceptos;
        }

        private void SearchScjn_Search(object sender, System.Windows.RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
            {
                this.RLstScjn.DataContext = (from n in TesauroScjnSingleton.ConceptosScjn
                                                where n.ConceptoScjn.ToUpper().Contains(StringUtilities.ConvMayEne(tempString))
                                                select n).ToList();
            }
            else
                this.RLstScjn.DataContext = TesauroScjnSingleton.ConceptosScjn;
        }
        
    }
}
