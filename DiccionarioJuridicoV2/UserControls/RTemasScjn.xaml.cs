using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using DiccionarioJuridicoV2.Singletons;

namespace DiccionarioJuridicoV2.UserControls
{
    /// <summary>
    /// Lógica de interacción para RTemasScjn.xaml
    /// </summary>
    public partial class RTemasScjn : UserControl
    {
        private Materias selectedMateria;
        private Temas selectedTema;
        private ObservableCollection<TesauroScjn> conceptosScjn;

        public RTemasScjn()
        {
            InitializeComponent();
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CbxMaterias.DataContext = new Materias().GetMateriasBase();
        }

        private void CbxMaterias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMateria = CbxMaterias.SelectedItem as Materias;

            this.LaunchBusyIndicator();
        }

        private void TreeMaterias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTema = TreeMaterias.SelectedItem as Temas;

            conceptosScjn = new RelacionesModel().GetRelations(selectedTema, selectedMateria.Id + 100);

            ConcepScjn.DataContext = conceptosScjn;
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TxtIdTemaScjn.Text = String.Empty;
            TxtConceptoScjn.Text = String.Empty;
        }

        private void BtnAddRelaciona_Click(object sender, RoutedEventArgs e)
        {
            TesauroScjn tesauro = new TesauroScjn()
            {
                Id = Convert.ToInt32(TxtIdTemaScjn.Text),
                ConceptoScjn = TxtConceptoScjn.Text,
                IsSelected = false
            };

            new TesauroScjnModel().SetNewTerminoScjn(tesauro);
            new RelacionesModel().SetNewRelation(selectedTema.Id, tesauro.Id, selectedMateria.Id + 100);
            TesauroScjnSingleton.ConceptosScjn.Add(tesauro);
            conceptosScjn.Add(tesauro);

            this.BtnLimpiar_Click(null, null);
        }

        #region Background Worker

        private BackgroundWorker worker = new BackgroundWorker();
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            ArbolesSingleton.Temas(selectedMateria.Id);
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
            this.BusyIndicator.IsBusy = false;
            TreeMaterias.DataContext = ArbolesSingleton.Temas(selectedMateria.Id);
        }

        private void LaunchBusyIndicator()
        {
            try
            {
                if (!worker.IsBusy)
                {
                    this.BusyIndicator.IsBusy = true;
                    worker.RunWorkerAsync();

                }
            }
            catch (Exception) { }
        }

        #endregion

        

        

        
    }
}
