using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Singletons;
using Telerik.Windows.Controls;
using TesauroUtilities;

namespace DiccionarioJuridicoV2.UserControls
{
    /// <summary>
    /// Lógica de interacción para LTematicos.xaml
    /// </summary>
    public partial class LTematicos : UserControl
    {
        private int uid;
        private Temas selectedTema;
        private int materiaTemaSelect;

        public LTematicos()
        {
            InitializeComponent();
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void RadTabControl_SelectionChanged(object sender, Telerik.Windows.Controls.RadSelectionChangedEventArgs e)
        {
            RadTabItem item = Opciones.SelectedItem as RadTabItem;

            uid = Convert.ToInt16(item.Uid);
            //materiaTemaSelect = Convert.ToInt16(item.Tag);

            this.LaunchBusyIndicator();

        }

        private void TreeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RadTreeView tree = sender as RadTreeView;

            selectedTema = tree.SelectedItem as Temas;

            materiaTemaSelect = Convert.ToInt16(tree.Tag);

            LstSinonimos.DataContext = new TesauroDAC().GetSinonimosForTema(selectedTema.IDTema, "IdTema", materiaTemaSelect);
        }

        #region Background Worker

        private BackgroundWorker worker = new BackgroundWorker();
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            ArbolesSingleton.Temas(uid);
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (uid)
            {
                case 1:
                    TreeConst.DataContext = ArbolesSingleton.Temas(uid);
                    break;
                case 2: TreePenal.DataContext = ArbolesSingleton.Temas(uid);
                    break;
                case 4: TreeCivil.DataContext = ArbolesSingleton.Temas(uid);
                    break;
                case 8: TreeAdmin.DataContext = ArbolesSingleton.Temas(uid);
                    break;
                case 16: TreeLaboral.DataContext = ArbolesSingleton.Temas(uid);
                    break;
                case 32: TreeComun.DataContext = ArbolesSingleton.Temas(uid);
                    break;
            }

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

        
    }
}
