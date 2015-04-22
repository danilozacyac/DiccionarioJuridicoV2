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

        public Diccionario()
        {
            InitializeComponent();
            //worker.DoWork += this.WorkerDoWork;
            //worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //this.LaunchBusyIndicator();
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
            rGrnSin = new RGenSinoni(listaGenericos);
            pane.Content = rGrnSin;
            pane.Header = "Términos genéricos";

            PanelCentral.AddItem(pane, DockPosition.Center);
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

        private void RBtnUpdateGenerico_Click(object sender, RoutedEventArgs e)
        {
            AddUpdateGenericos update = new AddUpdateGenericos(rGrnSin.SelectedGenerico);
            update.ShowDialog();
        }

        RTemasScjn tematScjn;
        private void RBtnTemasScjn_Click(object sender, RoutedEventArgs e)
        {
            RadPane pane = new RadPane();
            tematScjn = new RTemasScjn();
            pane.Content = tematScjn;
            pane.Header = "Temático - SCJN";

            PanelCentral.AddItem(pane, DockPosition.Center);
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



        //#region Background Worker

        //private BackgroundWorker worker = new BackgroundWorker();
        //private void WorkerDoWork(object sender, DoWorkEventArgs e)
        //{
        //    var y = ArbolesSingleton.Temas(1);
        //    //if (busyIndicatorAction == 1)
        //    //{
        //    //    FuncionariosWord imprime = new FuncionariosWord(FuncionariosSingleton.FuncionariosCollection);
        //    //    imprime.GeneraDocumentoWord();
        //    //}
        //    //else if (busyIndicatorAction == 2)
        //    //{
        //    //    OrganismosWord imprime = new OrganismosWord(organismosToPrint);
        //    //    imprime.GeneraDocumentoWord();
        //    //}
        //    //else if (busyIndicatorAction == 3)
        //    //{
        //    //    OrganismosModel.SetNewIntegrantesCount();
        //    //}
        //}

        //void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
        //    this.BusyIndicator.IsBusy = false;
        //}

        //private void LaunchBusyIndicator()
        //{
        //    if (!worker.IsBusy)
        //    {
        //        this.BusyIndicator.IsBusy = true;
        //        worker.RunWorkerAsync();

        //    }
        //}

        //#endregion
    }
}
