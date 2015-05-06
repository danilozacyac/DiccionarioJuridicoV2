using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using DiccionarioJuridicoV2.Singletons;
using Telerik.Windows.Controls;

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
        ObservableCollection<Temas> temasBusqueda;
        private int uid = 0;
        RadRibbonButton botonPdf;

        public RTemasScjn(RadRibbonButton botonPdf)
        {
            InitializeComponent();
            this.botonPdf = botonPdf;

            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CbxMaterias.DataContext = new Materias().GetMateriasBase();
        }

        private void CbxMaterias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uid = 0;
            selectedMateria = CbxMaterias.SelectedItem as Materias;

            this.LaunchBusyIndicator();

            SearchBox.IsEnabled = (selectedMateria.Id == 1) ? false : true;

            botonPdf.Tag = selectedMateria;
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
            new RelacionesModel().SetNewRelation(selectedTema.IDTema, tesauro.Id, selectedMateria.Id + 100);
            TesauroScjnSingleton.ConceptosScjn.Add(tesauro);
            conceptosScjn.Add(tesauro);

            this.BtnLimpiar_Click(null, null);
        }

        String searchText;
        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            searchText = ((TextBox)sender).Text.ToUpper();

            uid = 100;
            this.LaunchBusyIndicator();
        }

        #region Background Worker

        private BackgroundWorker worker = new BackgroundWorker();
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (uid == 0)
            {
                ArbolesSingleton.Temas(selectedMateria.Id);
            }
            else if (uid == 100)
            {

                if (!String.IsNullOrEmpty(searchText))
                    temasBusqueda = new TemasModel(searchText, selectedMateria.Id).Temas;
                else
                {
                    temasBusqueda = ArbolesSingleton.Temas(selectedMateria.Id);
                    uid = 0;
                }
            }
        }

        private void ExpandAll(Temas items)
        {
            foreach (Temas obj in items.SubTemas)
            {

                if (obj.Descripcion != null)
                {
                    ExpandAll(obj);
                    obj.IsExpanded = true;
                }
            }
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
            this.BusyIndicator.IsBusy = false;

            if (uid == 0)
            {
                TreeMaterias.DataContext = ArbolesSingleton.Temas(selectedMateria.Id);
                botonPdf.IsEnabled = true;
            }
            else
            {
                TreeMaterias.DataContext = temasBusqueda;

                foreach (object item in TreeMaterias.Items)
                {
                    Temas treeItem = item as Temas;
                    if (treeItem != null)
                    {
                        ExpandAll(treeItem);
                    }
                    treeItem.IsExpanded = true;
                }
            }

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
