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
        private readonly bool isUpdating;
        private ObservableCollection<Sinonimos> sinonimosRelacionados;
        private ObservableCollection<Sinonimos> sinonimosPorGuardar;
        private int idConceptoPrincipal;

        public AddUpdateSinonimos(ObservableCollection<Sinonimos> sinonimosRelacionados, int idConceptoPrincipal)
        {
            InitializeComponent();
            this.Header = "Agregar sinónimo";
            this.sinonimosRelacionados = sinonimosRelacionados;
            this.idConceptoPrincipal = idConceptoPrincipal;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            sinonimosPorGuardar = new ObservableCollection<Sinonimos>();
            RLstSinonimos.DataContext = sinonimosPorGuardar;
        }

        private void RBtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            SinonimosModel model = new SinonimosModel();

            foreach (Sinonimos sinonimo in sinonimosPorGuardar)
            {
                model.SetNewSinonimo(sinonimo, idConceptoPrincipal);
                sinonimosRelacionados.Add(sinonimo);
            }
            
            this.Close();
        }

        private void RBtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtConcepto.Text) || String.IsNullOrWhiteSpace(TxtConcepto.Text))
            {
                MessageBox.Show("Ingrese el concepto antes de Agregar");
                return;
            }
            else
            {
                Sinonimos newSinonimo = new Sinonimos();
                newSinonimo.Sinonimo = TxtConcepto.Text;
                newSinonimo.SinonimoStr = StringUtilities.PrepareToAlphabeticalOrder(newSinonimo.Sinonimo);
                newSinonimo.Fuente = TxtFuente.Text;

                if(!String.IsNullOrEmpty(newSinonimo.Fuente) || !String.IsNullOrWhiteSpace(newSinonimo.Fuente))
                    newSinonimo.FuenteStr = StringUtilities.PrepareToAlphabeticalOrder(newSinonimo.Fuente);

                sinonimosPorGuardar.Add(newSinonimo);

                TxtConcepto.Text = String.Empty;
                RBtnAceptar.IsEnabled = true;
            }
        }
    }
}