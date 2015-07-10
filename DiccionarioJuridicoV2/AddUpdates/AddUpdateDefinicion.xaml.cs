using System;
using System.Linq;
using System.Windows;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;

namespace DiccionarioJuridicoV2.AddUpdates
{
    /// <summary>
    /// Interaction logic for AddUpdateDefinicion.xaml
    /// </summary>
    public partial class AddUpdateDefinicion
    {
        private Genericos terminoGenerico;
        private Definiciones definicion;
        private bool isupdating = false;
        
        public AddUpdateDefinicion(Genericos terminoGenerico)
        {
            InitializeComponent();
            this.terminoGenerico = terminoGenerico;
            this.definicion = new Definiciones();
        }

        public AddUpdateDefinicion(Definiciones definicion)
        {
            InitializeComponent();
            this.definicion = definicion;
            this.isupdating = true;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = definicion;

            if (isupdating)
                this.Header = "Actualizar definición";
            else
                this.Header = "Agregar nueva definición";

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtDefinicion.Text) || String.IsNullOrWhiteSpace(TxtDefinicion.Text) || String.IsNullOrEmpty(TxtFuente.Text) || String.IsNullOrWhiteSpace(TxtFuente.Text))
            {
                    MessageBox.Show("Para poder continuar debes ingresar tanto la definición como la fuente de la misma");
                    return;
            }

            if (isupdating)
            {
                new DefinicionModel().UpdateDefinicion(definicion);
            }
            else
            {
                definicion.IdGenerico = terminoGenerico.IdGenerico;
                new DefinicionModel().SetDefiniciones(definicion);
                terminoGenerico.Definiciones.Add(definicion);
            }
            this.Close();
        }
    }
}
