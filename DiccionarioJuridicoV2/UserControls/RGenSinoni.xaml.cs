using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using Telerik.Windows.Controls;

namespace DiccionarioJuridicoV2.UserControls
{
    /// <summary>
    /// Lógica de interacción para RGenSinoni.xaml
    /// </summary>
    public partial class RGenSinoni : UserControl
    {
        private ObservableCollection<Genericos> listaGenericos;
        public Genericos SelectedGenerico;
        private RadRibbonButton pegarButton;

        public Sinonimos SelectedSinonimo;

        public Genericos GenericoPorEliminar;

        public Definiciones SelectedDefinition;

        public RGenSinoni() { }

        public RGenSinoni(ObservableCollection<Genericos> listaGenericos, RadRibbonButton pegarButton)
        {
            InitializeComponent();
            this.listaGenericos = listaGenericos;
            this.pegarButton = pegarButton;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(listaGenericos == null)
                listaGenericos = new GenericosModel().GetGenericos();

            RLstGenericos.DataContext = listaGenericos;
            
        }

        private void RLstGenericos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedGenerico = RLstGenericos.SelectedItem as Genericos;

            RLstDefiniciones.DataContext = SelectedGenerico.Definiciones;

            RLstSinonimos.DataContext = SelectedGenerico.Sinonimos;
        }

        private void PegarInfo(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (GenericoPorEliminar.IdGenerico == SelectedGenerico.IdGenerico)
            {
                MessageBox.Show("El origen y destino de la información es el mismo");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Estas a punto de eliminar el tema \"" + GenericoPorEliminar.Termino + 
                "\" y agregar su información al tema \"" + SelectedGenerico.Termino + "\" ¿Deseas continuar?",
                "ATENCIÓN:", MessageBoxButton.YesNo, MessageBoxImage.Question);

            //ARREGLAR

            //if (result == MessageBoxResult.Yes)
            //{
            //    SelectedGenerico.Definicion += "\n\r\n\r" + GenericoPorEliminar.Definicion;

            //    new GenericosModel().UpdateTerminoGenerico(SelectedGenerico);

            //    RelacionesModel model = new RelacionesModel();
            //    foreach (Sinonimos sinonimo in GenericoPorEliminar.Sinonimos)
            //    {
            //        SelectedGenerico.Sinonimos.Add(sinonimo);
            //        model.UpdateRelation(2, SelectedGenerico.IdGenerico, GenericoPorEliminar.IdGenerico, sinonimo.IdSinonimo);
                    
            //    }

            //    foreach (TesauroScjn conceptoScjn in GenericoPorEliminar.ConceptosScjn)
            //    {
            //        SelectedGenerico.ConceptosScjn.Add(conceptoScjn);
            //        model.UpdateRelation(9, SelectedGenerico.IdGenerico, GenericoPorEliminar.IdGenerico, conceptoScjn.Id);
            //    }

            //    listaGenericos.Remove(GenericoPorEliminar);
            //    new GenericosModel().DeleteTerminoGenerico(GenericoPorEliminar);
            //}
        }

        private void CortarInfo(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            GenericoPorEliminar = RLstGenericos.SelectedItem as Genericos;


            RConPasteInfo.IsEnabled = true;
            pegarButton.IsEnabled = true;
        }

        private void RLstSinonimos_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            
            SelectedSinonimo = RLstSinonimos.SelectedItem as Sinonimos;
        }

        private void RLstDefiniciones_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            SelectedDefinition = RLstDefiniciones.SelectedItem as Definiciones;
        }
    }
}
