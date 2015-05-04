using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

        public Genericos GenericoPorEliminar;

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

            TxtDefinicion.Text = SelectedGenerico.Definicion;

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
        }

        private void CortarInfo(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            GenericoPorEliminar = RLstGenericos.SelectedItem as Genericos;


            RConPasteInfo.IsEnabled = true;
            pegarButton.IsEnabled = true;
        }
    }
}
