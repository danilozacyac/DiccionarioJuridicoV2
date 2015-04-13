using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using DiccionarioJuridicoV2.Dto;

namespace DiccionarioJuridicoV2.UserControls
{
    /// <summary>
    /// Lógica de interacción para RGenFigScjn.xaml
    /// </summary>
    public partial class RGenFigScjn : UserControl
    {
        private ObservableCollection<Genericos> listaGenericos;

        public RGenFigScjn(ObservableCollection<Genericos> listaGenericos)
        {
            InitializeComponent();
            this.listaGenericos = listaGenericos;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            RLstGenericos.DataContext = listaGenericos;
        }
    }
}
