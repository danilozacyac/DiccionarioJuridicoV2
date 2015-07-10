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
    /// Interaction logic for AddGenerico.xaml
    /// </summary>
    public partial class AddGenerico
    {

        private ObservableCollection<Genericos> listaGenericos;
        private Genericos generico;

        public AddGenerico(ObservableCollection<Genericos> listaGenericos)
        {
            InitializeComponent();
            this.listaGenericos = listaGenericos;
            this.generico = new Genericos();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = generico;
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

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            generico.Definiciones = new ObservableCollection<Definiciones>();

            if (!String.IsNullOrEmpty(TxtDefinicion.Text) || !String.IsNullOrWhiteSpace(TxtDefinicion.Text))
            {
                Definiciones newDefinicion = new Definiciones();
                newDefinicion.Definicion = TxtDefinicion.Text;

                if (String.IsNullOrEmpty(TxtFuente.Text) || String.IsNullOrWhiteSpace(TxtFuente.Text))
                {
                    MessageBox.Show("Para poder continuar debes ingresar la fuente de la cual se obtuvo la definición");
                    return;
                }
                else
                {
                    newDefinicion.Fuente = TxtFuente.Text;
                    generico.Definiciones.Add(newDefinicion);
                }

            }

            new GenericosModel().SetNewTerminoGenericos(generico);
            listaGenericos.Add(generico);
            this.Close();
        }
    }
}
