﻿#pragma checksum "..\..\..\UserControls\RTemasScjn.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6C80F9AB1ECA41CF15BEF77EFD36126F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34209
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using DiccionarioJuridicoV2.Converters;
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
    /// RTemasScjn
    /// </summary>
    public partial class RTemasScjn : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\UserControls\RTemasScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadBusyIndicator BusyIndicator;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\RTemasScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadComboBox CbxMaterias;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\UserControls\RTemasScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadTreeView TreeMaterias;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\UserControls\RTemasScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView ConcepScjn;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\UserControls\RTemasScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtIdTemaScjn;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\UserControls\RTemasScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtConceptoScjn;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\UserControls\RTemasScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadButton BtnLimpiar;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\UserControls\RTemasScjn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadButton BtnAddRelaciona;
        
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
            System.Uri resourceLocater = new System.Uri("/DiccionarioJuridicoV2;component/usercontrols/rtemasscjn.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\RTemasScjn.xaml"
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
            
            #line 9 "..\..\..\UserControls\RTemasScjn.xaml"
            ((DiccionarioJuridicoV2.UserControls.RTemasScjn)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BusyIndicator = ((Telerik.Windows.Controls.RadBusyIndicator)(target));
            return;
            case 3:
            this.CbxMaterias = ((Telerik.Windows.Controls.RadComboBox)(target));
            
            #line 44 "..\..\..\UserControls\RTemasScjn.xaml"
            this.CbxMaterias.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbxMaterias_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TreeMaterias = ((Telerik.Windows.Controls.RadTreeView)(target));
            
            #line 51 "..\..\..\UserControls\RTemasScjn.xaml"
            this.TreeMaterias.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TreeMaterias_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 88 "..\..\..\UserControls\RTemasScjn.xaml"
            ((UIControls.SearchTextBox)(target)).Search += new System.Windows.RoutedEventHandler(this.SearchTextBox_Search);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ConcepScjn = ((Telerik.Windows.Controls.RadGridView)(target));
            return;
            case 7:
            this.TxtIdTemaScjn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TxtConceptoScjn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.BtnLimpiar = ((Telerik.Windows.Controls.RadButton)(target));
            
            #line 161 "..\..\..\UserControls\RTemasScjn.xaml"
            this.BtnLimpiar.Click += new System.Windows.RoutedEventHandler(this.BtnLimpiar_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnAddRelaciona = ((Telerik.Windows.Controls.RadButton)(target));
            
            #line 169 "..\..\..\UserControls\RTemasScjn.xaml"
            this.BtnAddRelaciona.Click += new System.Windows.RoutedEventHandler(this.BtnAddRelaciona_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

