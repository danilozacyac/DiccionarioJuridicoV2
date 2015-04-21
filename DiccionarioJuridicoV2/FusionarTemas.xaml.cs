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

namespace DiccionarioJuridicoV2
{
    /// <summary>
    /// Interaction logic for FusionarTemas.xaml
    /// </summary>
    public partial class FusionarTemas
    {
        private readonly Conceptos conceptoPermanece;
        private readonly Conceptos conceptoElimina;

        public FusionarTemas(Conceptos conceptoPermanece, Conceptos conceptoElimina)
        {
            InitializeComponent();
            this.conceptoElimina = conceptoElimina;
            this.conceptoPermanece = conceptoPermanece;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
