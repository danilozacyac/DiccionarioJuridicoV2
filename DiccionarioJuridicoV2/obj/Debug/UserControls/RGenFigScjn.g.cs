﻿#pragma checksum "..\..\..\UserControls\RGenFigScjn.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "21B775226013956383541DF2076A53FA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18034
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Carousel;
using Telerik.Windows.Controls.Data.PropertyGrid;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.RibbonView;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Data;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Shapes;
using UIControls;


namespace DiccionarioJuridicoV2.UserControls {
    
    
    /// <summary>
    /// RGenFigScjn
    /// </summary>
    public partial class RGenFigScjn : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\UserControls\RGenFigScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadListBox RLstGenericos;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\UserControls\RGenFigScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadListBox RLstFiguras;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\UserControls\RGenFigScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UIControls.SearchTextBox SearchConceptos;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\UserControls\RGenFigScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UIControls.SearchTextBox SearchScjn;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\UserControls\RGenFigScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadListBox RLstScjn;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\UserControls\RGenFigScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadButton RbtnGuardar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DiccionarioJuridicoV2;component/usercontrols/rgenfigscjn.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\RGenFigScjn.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\UserControls\RGenFigScjn.xaml"
            ((DiccionarioJuridicoV2.UserControls.RGenFigScjn)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RLstGenericos = ((Telerik.Windows.Controls.RadListBox)(target));
            
            #line 26 "..\..\..\UserControls\RGenFigScjn.xaml"
            this.RLstGenericos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RLstGenericos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RLstFiguras = ((Telerik.Windows.Controls.RadListBox)(target));
            return;
            case 4:
            this.SearchConceptos = ((UIControls.SearchTextBox)(target));
            
            #line 81 "..\..\..\UserControls\RGenFigScjn.xaml"
            this.SearchConceptos.Search += new System.Windows.RoutedEventHandler(this.SearchConceptos_Search);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SearchScjn = ((UIControls.SearchTextBox)(target));
            
            #line 107 "..\..\..\UserControls\RGenFigScjn.xaml"
            this.SearchScjn.Search += new System.Windows.RoutedEventHandler(this.SearchScjn_Search);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RLstScjn = ((Telerik.Windows.Controls.RadListBox)(target));
            return;
            case 7:
            this.RbtnGuardar = ((Telerik.Windows.Controls.RadButton)(target));
            
            #line 136 "..\..\..\UserControls\RGenFigScjn.xaml"
            this.RbtnGuardar.Click += new System.Windows.RoutedEventHandler(this.RbtnGuardar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

