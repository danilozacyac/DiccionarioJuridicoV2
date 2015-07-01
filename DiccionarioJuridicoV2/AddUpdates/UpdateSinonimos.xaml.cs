using System;
using System.Linq;
using System.Windows;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;

namespace DiccionarioJuridicoV2.AddUpdates
{
    /// <summary>
    /// Interaction logic for UpdateSinonimos.xaml
    /// </summary>
    public partial class UpdateSinonimos
    {
        private Sinonimos sinonimo;

        public UpdateSinonimos(Sinonimos sinonimo)
        {
            InitializeComponent();
            this.sinonimo = sinonimo;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = sinonimo;
        }

        private void RBtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            new SinonimosModel().UpdateSinonimo(sinonimo);
            this.Close();
        }

        private void RBtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
