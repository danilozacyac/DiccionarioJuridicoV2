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
using DiccionarioJuridicoV2.Dto;
using Telerik.Windows.Controls;

namespace DiccionarioJuridicoV2.AddUpdates
{
    /// <summary>
    /// Interaction logic for AddUpdateTesauroScjn.xaml
    /// </summary>
    public partial class AddUpdateTesauroScjn
    {
        private TesauroScjn conceptoScjn;
        private bool isUpdating = false;

        public AddUpdateTesauroScjn()
        {
            InitializeComponent();
            this.conceptoScjn = new TesauroScjn();
            this.Header = "Añadir concepto del tesauro de la SCJN";
        }

        public AddUpdateTesauroScjn(TesauroScjn conceptoScjn)
        {
            InitializeComponent();
            this.conceptoScjn = conceptoScjn;
            this.isUpdating = true;
            this.Header = "Actualizar concepto del tesauro de la SCJN";
        }


        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = conceptoScjn;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
