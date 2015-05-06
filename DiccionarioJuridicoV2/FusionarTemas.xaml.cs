using System;
using System.Linq;
using System.Windows;
using DiccionarioJuridicoV2.Dto;

namespace DiccionarioJuridicoV2
{
    /// <summary>
    /// Interaction logic for FusionarTemas.xaml
    /// </summary>
    public partial class FusionarTemas
    {
        private Conceptos conceptoPermanece;
        private Conceptos conceptoElimina;
        private Conceptos conceptoTemporal;

        public FusionarTemas(Conceptos conceptoPermanece, Conceptos conceptoElimina)
        {
            InitializeComponent();
            this.conceptoElimina = conceptoElimina;
            this.conceptoPermanece = conceptoPermanece;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TxtConserva.Text = conceptoPermanece.Concepto;
            TxtEliminar.Text = conceptoElimina.Concepto;
        }

        private void RBtnCambiar_Click(object sender, RoutedEventArgs e)
        {
            conceptoTemporal = conceptoPermanece;

            conceptoPermanece = conceptoElimina;

            conceptoElimina = conceptoTemporal;

            TxtConserva.Text = conceptoPermanece.Concepto;
            TxtEliminar.Text = conceptoElimina.Concepto;

        }

        
    }
}
