using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DiccionarioJuridicoV2.AddUpdates;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using DiccionarioJuridicoV2.UserControls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace DiccionarioJuridicoV2
{
    /// <summary>
    /// Interaction logic for Diccionario.xaml
    /// </summary>
    public partial class Diccionario
    {

        private ObservableCollection<Genericos> listaGenericos;

        public Diccionario()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void RBtnAgregarGenerico_Click(object sender, RoutedEventArgs e)
        {
            AddUpdateGenericos addUpdate = new AddUpdateGenericos(listaGenericos);
            addUpdate.ShowDialog();
        }

        private void RBtnTermGen_Click(object sender, RoutedEventArgs e)
        {
            listaGenericos = new GenericosModel().GetGenericos();

            RadPane pane = new RadPane();
            pane.Content = new RGenSinoni(listaGenericos);
            pane.Header = "Términos genéricos";

            PanelCentral.AddItem(pane, DockPosition.Center);
        }
    }
}
