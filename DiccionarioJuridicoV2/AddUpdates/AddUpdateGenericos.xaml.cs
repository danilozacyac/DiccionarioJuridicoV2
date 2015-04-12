using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;

namespace DiccionarioJuridicoV2.AddUpdates
{
    /// <summary>
    /// Interaction logic for AddUpdateGenericos.xaml
    /// </summary>
    public partial class AddUpdateGenericos
    {
        private ObservableCollection<Genericos> listaGenericos;
        Genericos generico;
        bool isUpdating;

        public AddUpdateGenericos(ObservableCollection<Genericos> listaGenericos)
        {
            InitializeComponent();
            this.generico = new Genericos();
            this.listaGenericos = listaGenericos;
            this.Header = "Nuevo término";
        }

        public AddUpdateGenericos(Genericos generico)
        {
            InitializeComponent();
            this.generico = generico;
            this.Header = "Actualizar término";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = generico;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (isUpdating)
            {
            }
            else
            {
                new GenericosModel().SetNewTerminoGenericos(generico);
                listaGenericos.Add(generico);
                this.Close();
            }
        }
    }
}
