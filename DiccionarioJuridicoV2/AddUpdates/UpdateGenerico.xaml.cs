﻿using System;
using System.Linq;
using System.Windows;
using DiccionarioJuridicoV2.Dto;
using DiccionarioJuridicoV2.Models;
using ScjnUtilities;

namespace DiccionarioJuridicoV2.AddUpdates
{
    /// <summary>
    /// Interaction logic for UpdateGenerico.xaml
    /// </summary>
    public partial class UpdateGenerico
    {
        private Genericos generico;

        public UpdateGenerico(Genericos generico)
        {
            InitializeComponent();
            this.generico = generico;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TxtTermino.Text = generico.Termino;
            TxtDefinicion.Text = generico.Definicion;
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            generico.Termino = TxtTermino.Text;
            generico.Definicion = TxtDefinicion.Text;
            generico.TerminoStr = StringUtilities.PrepareToAlphabeticalOrder(generico.Termino);

            if (!String.IsNullOrEmpty(generico.Definicion) || !String.IsNullOrWhiteSpace(generico.Definicion))
                generico.DefinicionStr = StringUtilities.PrepareToAlphabeticalOrder(generico.Definicion);

            new GenericosModel().UpdateTerminoGenerico(generico);

            this.Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}