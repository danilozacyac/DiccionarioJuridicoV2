﻿#pragma checksum "..\..\..\UserControls\RGenSinoni.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D8A7EBBD03C8FB5CA5E82DDD02AF2C49"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34209
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


namespace DiccionarioJuridicoV2.UserControls {
    
    
    /// <summary>
    /// RGenSinoni
    /// </summary>
    public partial class RGenSinoni : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\UserControls\RGenSinoni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadListBox RLstGenericos;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\RGenSinoni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadMenuItem RConCopyInfo;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\UserControls\RGenSinoni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadMenuItem RConPasteInfo;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\UserControls\RGenSinoni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadMenuItem RConCutInfo;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\UserControls\RGenSinoni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView RLstSinonimos;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\UserControls\RGenSinoni.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView RLstDefiniciones;
        
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
            System.Uri resourceLocater = new System.Uri("/DiccionarioJuridicoV2;component/usercontrols/rgensinoni.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\RGenSinoni.xaml"
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
            
            #line 7 "..\..\..\UserControls\RGenSinoni.xaml"
            ((DiccionarioJuridicoV2.UserControls.RGenSinoni)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RLstGenericos = ((Telerik.Windows.Controls.RadListBox)(target));
            
            #line 31 "..\..\..\UserControls\RGenSinoni.xaml"
            this.RLstGenericos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RLstGenericos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RConCopyInfo = ((Telerik.Windows.Controls.RadMenuItem)(target));
            return;
            case 4:
            this.RConPasteInfo = ((Telerik.Windows.Controls.RadMenuItem)(target));
            
            #line 42 "..\..\..\UserControls\RGenSinoni.xaml"
            this.RConPasteInfo.Click += new Telerik.Windows.RadRoutedEventHandler(this.PegarInfo);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RConCutInfo = ((Telerik.Windows.Controls.RadMenuItem)(target));
            
            #line 50 "..\..\..\UserControls\RGenSinoni.xaml"
            this.RConCutInfo.Click += new Telerik.Windows.RadRoutedEventHandler(this.CortarInfo);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RLstSinonimos = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 80 "..\..\..\UserControls\RGenSinoni.xaml"
            this.RLstSinonimos.SelectionChanged += new System.EventHandler<Telerik.Windows.Controls.SelectionChangeEventArgs>(this.RLstSinonimos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RLstDefiniciones = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 107 "..\..\..\UserControls\RGenSinoni.xaml"
            this.RLstDefiniciones.SelectionChanged += new System.EventHandler<Telerik.Windows.Controls.SelectionChangeEventArgs>(this.RLstDefiniciones_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

