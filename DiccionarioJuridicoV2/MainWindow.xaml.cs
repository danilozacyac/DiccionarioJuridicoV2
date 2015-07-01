using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using DiccionarioJuridicoV2.Singletons;
using Telerik.Windows.Controls;

namespace DiccionarioJuridicoV2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Genericos> listaGenericos;

        public MainWindow()
        {
            InitializeComponent();
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StyleManager.ApplicationTheme = new Windows8Theme();

            this.LaunchBusyIndicator();

            string path = ConfigurationManager.AppSettings["ErrorPath"].ToString();

            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            } 

        }



        #region Background Worker

        private BackgroundWorker worker = new BackgroundWorker();
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            listaGenericos = new GenericosModel().GetGenericos();
            var z = ConceptosSingleton.Conceptos;
            //var y = ArbolesSingleton.Temas(1);
            //y = ArbolesSingleton.Temas(2);
            //y = ArbolesSingleton.Temas(4);
            //y = ArbolesSingleton.Temas(8);
            //y = ArbolesSingleton.Temas(16);
            //y = ArbolesSingleton.Temas(32);
            //if (busyIndicatorAction == 1)
            //{
            //    FuncionariosWord imprime = new FuncionariosWord(FuncionariosSingleton.FuncionariosCollection);
            //    imprime.GeneraDocumentoWord();
            //}
            //else if (busyIndicatorAction == 2)
            //{
            //    OrganismosWord imprime = new OrganismosWord(organismosToPrint);
            //    imprime.GeneraDocumentoWord();
            //}
            //else if (busyIndicatorAction == 3)
            //{
            //    OrganismosModel.SetNewIntegrantesCount();
            //}
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
            this.BusyIndicator.IsBusy = false;
            Diccionario diccionario = new Diccionario(listaGenericos);
            diccionario.Show();
            this.Close();
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
    }
}
