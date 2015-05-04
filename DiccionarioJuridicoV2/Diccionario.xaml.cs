using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using DiccionarioJuridicoV2.Reportes;
using DiccionarioJuridicoV2.Singletons;
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
        private RGenSinoni rGrnSin;

        private ObservableCollection<Genericos> listaGenericos;
        private int uid;

        public Diccionario(ObservableCollection<Genericos> listaGenericos)
        {
            InitializeComponent();
            this.listaGenericos = listaGenericos;
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }
        
        private void RBtnTermGen_Click(object sender, RoutedEventArgs e)
        {
            RadPane pane = new RadPane();
            rGrnSin = new RGenSinoni(listaGenericos, RBtnPegarInfo);
            pane.Content = rGrnSin;
            pane.Header = "Términos genéricos";

            PanelCentral.AddItem(pane, DockPosition.Center);

            Ribbon.SelectedIndex = 1;
        }

        private void RBtnAddSin_Click(object sender, RoutedEventArgs e)
        {
            if (rGrnSin == null || rGrnSin.SelectedGenerico == null)
            {
                MessageBox.Show("Seleccione el término al cual desea agregar el sinónimo");
                return;
            }

            if (rGrnSin.SelectedGenerico.Sinonimos == null)
                rGrnSin.SelectedGenerico.Sinonimos = new ObservableCollection<Sinonimos>();

            AddUpdateSinonimos sinonimo = new AddUpdateSinonimos(rGrnSin.SelectedGenerico.Sinonimos,rGrnSin.SelectedGenerico.IdGenerico);
            sinonimo.Show();
        }

        LFiguras figuras;
        private void RBtnListaFiguras_Click(object sender, RoutedEventArgs e)
        {
            RadPane pane = new RadPane();
            figuras = new LFiguras();
            pane.Content = figuras;
            pane.Header = "Figuras Jurídicas";

            PanelCentral.AddItem(pane, DockPosition.Center);
        }

        RGenFigScjn relacionesGenericos;
        private void RBtnGenericRelaciones_Click(object sender, RoutedEventArgs e)
        {
            RadPane pane = new RadPane();
            relacionesGenericos = new RGenFigScjn(listaGenericos);
            pane.Content = relacionesGenericos;
            pane.Header = "Establecer relaciones";

            PanelCentral.AddItem(pane, DockPosition.Center);
        }

        private void RBtnLoadTrees_Click(object sender, RoutedEventArgs e)
        {
            RadRibbonButton button = sender as RadRibbonButton;

            uid = Convert.ToInt32(button.Uid);

            this.LaunchBusyIndicator();
        }

        RTemasScjn tematScjn;
        private void RBtnRelTesaScjn_Click(object sender, RoutedEventArgs e)
        {
            RadPane pane = new RadPane();
            tematScjn = new RTemasScjn(RBtnArbolPdf);
            pane.Content = tematScjn;
            pane.Header = "Temático - SCJN";

            PanelCentral.AddItem(pane, DockPosition.Center);
        }

        LTematicos tematicos;
        private void RBtnTematico_Click(object sender, RoutedEventArgs e)
        {
            RadPane pane = new RadPane();
            tematicos = new LTematicos();
            pane.Content = tematicos;
            pane.Header = " Temáticos ";

            PanelCentral.AddItem(pane, DockPosition.Center);
        }

        #region Terminos Genericos

        private void RBtnAgregarGenerico_Click(object sender, RoutedEventArgs e)
        {
            AddUpdateGenericos addUpdate = new AddUpdateGenericos(listaGenericos);
            addUpdate.ShowDialog();
        }

        private void RBtnUpdateGenerico_Click(object sender, RoutedEventArgs e)
        {
            UpdateGenerico update = new UpdateGenerico(rGrnSin.SelectedGenerico);
            update.ShowDialog();
        }

        private void RBtnDelGenerico_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estas seguro de que deseas eliminar el concepto: \"" + rGrnSin.SelectedGenerico.Termino + "\"", "ATENCIÓN:",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                new GenericosModel().DeleteTerminoGenerico(rGrnSin.SelectedGenerico);
            }
        }

        private void CortarInfo(object sender, RoutedEventArgs e)
        {

        }

        private void PegarInfo(object sender, RoutedEventArgs e)
        {

        }


        #endregion

        

        #region Figuras Jurídicas

        private void RBtnDeleteConcept_Click(object sender, RoutedEventArgs e)
        {
            if (figuras != null && figuras.ConceptoSelect != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Estas seguro de que deseas eliminar el concepto: \"" + figuras.ConceptoSelect.Concepto + "\"", "ATENCIÓN:",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    new ConceptosModel().DeleteConcepto(figuras.ConceptoSelect);
                }
            }
        }

        private void RBtnFusionar_Click(object sender, RoutedEventArgs e)
        {
            IList concepFusionar = figuras.RLstFiguras.SelectedItems;

            if (concepFusionar.Count != 2)
            {
                MessageBox.Show("Para utilizar esta función debe seleccionar EXACTAMENTE dos conceptos del listado");
                return;
            }
            else
            {
                FusionarTemas fusion = new FusionarTemas(concepFusionar[0] as Conceptos, concepFusionar[1] as Conceptos);
                fusion.ShowDialog();
            }
        }

        #endregion






        #region Background Worker

        private BackgroundWorker worker = new BackgroundWorker();
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            switch (uid)
            {
                case 100: var x = ArbolesSingleton.Temas(1);
                    x = ArbolesSingleton.Temas(2);
                    x = ArbolesSingleton.Temas(4);
                    x = ArbolesSingleton.Temas(8);
                    x = ArbolesSingleton.Temas(16);
                    x = ArbolesSingleton.Temas(32);
                    x = null;
                    break;
            }
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
            this.BusyIndicator.IsBusy = false;
        }

        private void LaunchBusyIndicator()
        {
            if (!worker.IsBusy)
            {
                this.BusyIndicator.IsBusy = true;
                worker.RunWorkerAsync();

            }
        }

        #endregion

        private void RBtnArbolPdf_Click(object sender, RoutedEventArgs e)
        {
            Materias materia = RBtnArbolPdf.Tag as Materias;

            ArbolesEnPdf pdf = new ArbolesEnPdf(ArbolesSingleton.Temas( materia.Id));
            pdf.GeneraPdf();
        }

        

        
    }
}
