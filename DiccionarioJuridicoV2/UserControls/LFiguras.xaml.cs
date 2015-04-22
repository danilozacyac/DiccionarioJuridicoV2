﻿using System;
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
using DiccionarioJuridicoV2.Models;
using DiccionarioJuridicoV2.Singletons;

namespace DiccionarioJuridicoV2.UserControls
{
    /// <summary>
    /// Lógica de interacción para LFiguras.xaml
    /// </summary>
    public partial class LFiguras : UserControl
    {
        public Conceptos ConceptoSelect;

        public LFiguras()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.RLstFiguras.DataContext = ConceptosSingleton.Conceptos;
        }

        private void RLstFiguras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConceptoSelect = RLstFiguras.SelectedItem as Conceptos;

            new ConceptosModel().GetTesisByConcepto(ConceptoSelect);

            ConcepScjn.DataContext = new TesisModel().GetTesisForConcepto(ConceptoSelect.TesisRelacionadas);
        }
    }
}
