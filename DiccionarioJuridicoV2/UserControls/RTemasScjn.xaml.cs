using System;
using System.Collections.Generic;
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
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Singletons;

namespace DiccionarioJuridicoV2.UserControls
{
    /// <summary>
    /// Lógica de interacción para RTemasScjn.xaml
    /// </summary>
    public partial class RTemasScjn : UserControl
    {
        private Materias selectedMateria;

        public RTemasScjn()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CbxMaterias.DataContext = new Materias().GetMateriasBase();
        }

        private void CbxMaterias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMateria = CbxMaterias.SelectedItem as Materias;

            TreeMaterias.DataContext = ArbolesSingleton.Temas(selectedMateria.Id);
        }

        
    }
}
