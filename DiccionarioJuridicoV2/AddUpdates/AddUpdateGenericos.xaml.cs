using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using ScjnUtilities;

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

        /// <summary>
        /// Añade un término genérico al listado previo
        /// </summary>
        /// <param name="listaGenericos">Lista de términos genéricos existentes</param>
        public AddUpdateGenericos(ObservableCollection<Genericos> listaGenericos)
        {
            InitializeComponent();
            this.generico = new Genericos();
            this.listaGenericos = listaGenericos;
            this.Header = "Nuevo término";
        }

        /// <summary>
        /// Permite actualizar la definición o el término seleccionado
        /// </summary>
        /// <param name="generico">Termino que se va a actualizar</param>
        public AddUpdateGenericos(Genericos generico)
        {
            InitializeComponent();
            this.generico = generico;
            this.isUpdating = true;
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
                new GenericosModel().UpdateTerminoGenerico(generico);
                this.Close();
            }
            else
            {
                if (String.IsNullOrEmpty(TxtDefinicion.Text.Trim()))
                    generico.Definicion = "";

                new GenericosModel().SetNewTerminoGenericos(generico);
                listaGenericos.Add(generico);
                this.Close();
            }
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();
            try
            {
                if (!String.IsNullOrEmpty(tempString))
                    RLstDuplicados.DataContext = (from n in listaGenericos
                                                  where n.TerminoStr.Contains(StringUtilities.ConvMayEne(tempString))
                                                  select n).ToList();
                else
                    RLstDuplicados.DataContext = listaGenericos;
            }
            catch (NullReferenceException)
            {
                RLstDuplicados.DataContext = null;
            }
        }
    }
}