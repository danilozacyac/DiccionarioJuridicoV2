using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiccionarioJuridicoV2.Singletons;
using Telerik.Windows.Controls;

namespace DiccionarioJuridicoV2.UserControls
{
    /// <summary>
    /// Lógica de interacción para LTematicos.xaml
    /// </summary>
    public partial class LTematicos : UserControl
    {
        private int uid;

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

            this.LaunchBusyIndicator();

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
