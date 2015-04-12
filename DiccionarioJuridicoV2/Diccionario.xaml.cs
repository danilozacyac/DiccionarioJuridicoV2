using System;
using System.Collections.Generic;
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
using DiccionarioJuridicoV2.UserControls;
using Telerik.Windows.Controls;

namespace DiccionarioJuridicoV2
{
    /// <summary>
    /// Interaction logic for Diccionario.xaml
    /// </summary>
    public partial class Diccionario
    {
        public Diccionario()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void RBtnAgregarGenerico_Click(object sender, RoutedEventArgs e)
        {
            RadPane pane = new RadPane();
            pane.Content = new RGenSinoni();
            pane.Header = "Términos genéricos";

            PanelCentral.Items.Add(pane);
        }
    }
}
