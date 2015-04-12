using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using ScjnUtilities;

namespace DiccionarioJuridicoV2.AddUpdates
{
    /// <summary>
    /// Interaction logic for AddUpdateSinonimos.xaml
    /// </summary>
    public partial class AddUpdateSinonimos
    {
        private Sinonimos sinonimo;
        private readonly bool isUpdating;
        private ObservableCollection<Sinonimos> sinonimosRelacionados;

        public AddUpdateSinonimos(ObservableCollection<Sinonimos> sinonimosRelacionados)
        {
            InitializeComponent();
            this.sinonimo = new Sinonimos();
            this.Header = "Agregar sinónimo";
            this.sinonimosRelacionados = sinonimosRelacionados;
        }

        public AddUpdateSinonimos(Sinonimos concepto)
        {
            InitializeComponent();
            this.sinonimo = concepto;
            this.isUpdating = true;
            this.Header = "Actualizar sinónimo";
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = sinonimo;
        }

        private void RBtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            SinonimosModel model = new SinonimosModel();
            sinonimo.SinonimoStr = StringUtilities.PrepareToAlphabeticalOrder(sinonimo.Sinonimo);
            sinonimo.FuenteStr = StringUtilities.PrepareToAlphabeticalOrder(sinonimo.Fuente);

            if (isUpdating)
            {
                model.UpdateSinonimo(sinonimo);
            }
            else
            {
                model.SetNewSinonimo(sinonimo);
                sinonimosRelacionados.Add(sinonimo);
            }

            this.Close();
        }

        private void RBtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
