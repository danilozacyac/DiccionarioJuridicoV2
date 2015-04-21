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

namespace DiccionarioJuridicoV2.UserControls
{
    /// <summary>
    /// Lógica de interacción para RGenSinoni.xaml
    /// </summary>
    public partial class RGenSinoni : UserControl
    {
        private ObservableCollection<Genericos> listaGenericos;
        public Genericos SelectedGenerico;

        public RGenSinoni(ObservableCollection<Genericos> listaGenericos)
        {
            InitializeComponent();
            this.listaGenericos = listaGenericos;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //listaGenericos = new GenericosModel().GetGenericos();

            RLstGenericos.DataContext = listaGenericos;
            
        }

        private void RLstGenericos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedGenerico = RLstGenericos.SelectedItem as Genericos;

            TxtDefinicion.Text = SelectedGenerico.Definicion;

            RLstSinonimos.DataContext = SelectedGenerico.Sinonimos;
        }
    }
}
