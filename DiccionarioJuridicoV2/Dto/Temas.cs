using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using DiccionarioJuridicoV2.Models;

namespace DiccionarioJuridicoV2.Dto
{
    //public class Temas : ViewModelBase
    //{
    //    private bool? isSelected = false;
    //    private int id;
    //    private int nivel;
    //    private int padre;
    //    private string clave;
    //    private string descripcion;
    //    private ObservableCollection<Temas> temasHijo;
    //    private Temas temaPadre;
    //    private int tesisRelacionadas;
    //    private int idColorLetra;
    //    private int materia;
        
    //    //private ObservableCollection<RPSinonimos> sinonimos;
    //    //private ObservableCollection<RPSinonimos> relacionesProx;

    //    public Temas() { }

    //    public Temas(Temas padre)
    //    {
    //        this.temaPadre = padre;
    //    }


    //    private bool reentrancyCheck = false;
        
    //   public bool? IsSelected
    //    {
    //        get
    //        {
    //            return this.isSelected;
    //        }
    //        set
    //        {
    //            if (this.isSelected != value)
    //            {
    //                if (reentrancyCheck)
    //                    return;
    //                this.reentrancyCheck = true;
    //                this.isSelected = value;
    //                this.UpdateCheckState();
    //                OnPropertyChanged("IsSelected");
    //                this.reentrancyCheck = false;
    //            }
    //        }
    //    }

    //    public int Id
    //    {
    //        get
    //        {
    //            return this.id;
    //        }
    //        set
    //        {
    //            this.id = value;
    //        }
    //    }

    //    public int Nivel
    //    {
    //        get
    //        {
    //            return this.nivel;
    //        }
    //        set
    //        {
    //            this.nivel = value;
    //        }
    //    }

    //    public int Padre
    //    {
    //        get
    //        {
    //            return this.padre;
    //        }
    //        set
    //        {
    //            this.padre = value;
    //        }
    //    }

    //    public string Clave
    //    {
    //        get
    //        {
    //            return this.clave;
    //        }
    //        set
    //        {
    //            this.clave = value;
    //        }
    //    }

    //    public string Descripcion
    //    {
    //        get
    //        {
    //            return this.descripcion;
    //        }
    //        set
    //        {
    //            this.descripcion = value;
    //        }
    //    }

    //    public ObservableCollection<Temas> TemasHijo
    //    {
    //        get
    //        {
    //            return this.temasHijo;
    //        }
    //        set
    //        {
    //            this.temasHijo = value;
    //        }
    //    }

    //    public Temas TemaPadre
    //    {
    //        get
    //        {
    //            return this.temaPadre;
    //        }
    //        set
    //        {
    //            this.temaPadre = value;
    //        }
    //    }

    //    public int TesisRelacionadas
    //    {
    //        get
    //        {
    //            return this.tesisRelacionadas;
    //        }
    //        set
    //        {
    //            this.tesisRelacionadas = value;
    //        }
    //    }


    //    public int IdColorLetra
    //    {
    //        get
    //        {
    //            return this.idColorLetra;
    //        }
    //        set
    //        {
    //            this.idColorLetra = value;
    //        }
    //    }

    //    public int Materia
    //    {
    //        get
    //        {
    //            return this.materia;
    //        }
    //        set
    //        {
    //            this.materia = value;
    //        }
    //    }

        

    //    /// <summary>
    //    /// we need to implement the logic that determines the checked state of each item. For that purpose we have to traverse 
    //    /// the children colleciton of a checked item as well as to find the checked state in which its parent item should be set.
    //    /// </summary>
    //    private void UpdateChildrenCheckState()
    //    {
    //        foreach (var item in this.TemasHijo)
    //        {
    //            if (this.IsSelected != null)
    //            {
    //                item.IsSelected = this.IsSelected;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// We can also create a method that updates the checked state of the parent item. In order to simplify the code, 
    //    /// we can use a lambda function to count the number of the checked children of the parent item. If this number 
    //    /// indicates that all its children are checked, we can set the parent item checked state to checked, if the count 
    //    /// of its checked children is 0, then we need to uncheck it. In all other cases, its state should stay indeterminate
    //    /// </summary>
    //    /// <returns></returns>
    //    private bool? DetermineCheckState()
    //    {
    //        bool allChildrenChecked = this.TemasHijo.Count(x => x.IsSelected == true) == this.TemasHijo.Count;
    //        if (allChildrenChecked)
    //        {
    //            return true;
    //        }

    //        bool allChildrenUnchecked = this.TemasHijo.Count(x => x.IsSelected == false) == this.TemasHijo.Count;
    //        if (allChildrenUnchecked)
    //        {
    //            return false;
    //        }

    //        return null;
    //    }


    //    private void UpdateCheckState()
    //    {
    //        // update all children:
    //        if (this.TemasHijo.Count != 0)
    //        {
    //            this.UpdateChildrenCheckState();
    //        }
    //        //update parent item
    //        if (this.TemaPadre != null)
    //        {
    //            bool? parentIsChecked = this.TemaPadre.DetermineCheckState();
    //            this.TemaPadre.IsSelected = parentIsChecked;
    //        }
    //    }

    //}

    public class Temas : INotifyPropertyChanged
    {
        static readonly Temas dummyChild = new Temas();

        Temas parent;// {get;set;};

        bool isExpanded;
        bool isSelected;

        private Temas parentItem;

        private int idTema;

        public int IDTema
        {
            get
            {
                return idTema;
            }
            set
            {
                idTema = value;
            }
        }

        private string descripcion;

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
                this.OnPropertyChanged("Descripcion");
            }


        }

        private string descripcionStr = "";

        public string DescripcionStr
        {
            get
            {
                return descripcionStr;
            }
            set
            {
                descripcionStr = value;
            }
        }

        private int nivel;

        public int Nivel
        {
            get
            {
                return nivel;
            }
            set
            {
                nivel = value;
            }
        }

        private int idPadre;

        public int IDPadre
        {
            get
            {
                return idPadre;
            }
            set
            {
                idPadre = value;
            }
        }

        private int idUser;

        public int IDUser
        {
            get
            {
                return idUser;
            }
            set
            {
                idUser = value;
            }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }

        private DateTime hora;

        public DateTime Hora
        {
            get
            {
                return hora;
            }
            set
            {
                hora = value;
            }
        }

        private String nota = "";

        public String Nota
        {
            get
            {
                return nota;
            }
            set
            {
                nota = value;
            }
        }

        private String observaciones = "";

        public String Observaciones
        {
            get
            {
                return observaciones;
            }
            set
            {
                observaciones = value;
            }
        }

        private int materia;

        public int Materia
        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;
            }
        }

        private int status;

        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        private int idOrigen;

        public int IdOrigen
        {
            get
            {
                return idOrigen;
            }
            set
            {
                idOrigen = value;
            }
        }

        private int idTemaOrigen = 0;

        public int IdTemaOrigen
        {
            get
            {
                return idTemaOrigen;
            }
            set
            {
                idTemaOrigen = value;
            }
        }

        private int tesisRelacionadas;

        public int TesisRelacionadas
        {
            get
            {
                return tesisRelacionadas;
            }
            set
            {
                if (value != null)
                {
                    tesisRelacionadas = value;
                    this.OnPropertyChanged("TesisRelacionadas");
                }
                else
                {
                    tesisRelacionadas = 0;
                }
            }
        }

        private ObservableCollection<Temas> subtemas;

        public ObservableCollection<Temas> SubTemas
        {
            get
            {
                if (this.subtemas == null)
                {
                    this.subtemas = new ObservableCollection<Temas>();
                }
                return this.subtemas;
            }
            set
            {
                this.subtemas = value;
            }
        }

        public void AddSubTema(Temas tema)
        {
            subtemas.Add(tema);
        }

        private String abogadoCrea = "";

        public String AbogadoCrea
        {
            get
            {
                return abogadoCrea;
            }
            set
            {
                abogadoCrea = value;
            }
        }

        private string regIusString;

        public string RegIusString
        {
            get
            {
                return regIusString;
            }
            set
            {
                regIusString = value;
            }


        }

        

        #region Constructores

        public Temas()
        {
        }

        public Temas(Temas parent)
        {
            this.parentItem = parent;
        }

        public Temas(Temas parent, bool lazyLoadChildren)
        {
            this.parent = parent;

            subtemas = new ObservableCollection<Temas>();

            if (lazyLoadChildren)
                subtemas.Add(dummyChild);
        }

        #endregion

        #region HasLoadedChildren

        /// <summary>
        /// Returns true if this object's Children have not yet been populated.
        /// </summary>
        public bool HasDummyChild
        {
            get
            {
                return this.SubTemas.Count == 1 && this.SubTemas[0] == dummyChild;
            }
        }

        #endregion // HasLoadedChildren

        #region Parent

        public Temas Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        #endregion

        #region IsExpanded

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }
            set
            {
                if (value != isExpanded)
                {
                    isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }
                // Expand all the way up to the root.
                if (isExpanded && parent != null)
                    parent.IsExpanded = true;
                // Lazy load the child items, if necessary.
                if (this.HasDummyChild)
                {
                    this.SubTemas.Remove(dummyChild);
                    this.LoadChildren();
                }
            }
        }

        #endregion // IsExpanded

        #region LoadChildren

        /// <summary>
        /// Invoked when the child items need to be loaded on demand.
        /// Subclasses can override this to populate the Children collection.
        /// </summary>
        protected virtual void LoadChildren()
        {
            foreach (var item in new TemasModel().GetTemasByDemand(this, this.Materia))
                SubTemas.Add(item);
        }

        #endregion // LoadChildren

        #region AddRemove Children



        protected virtual void AddSubtema(Temas child)
        {
            child.Parent = this;
            SubTemas.Add(child);
        }

        #endregion

        public virtual void RemoveSubTema(Temas child)
        {
            SubTemas.Remove(child);
        }

        #region IsSelected

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        #endregion // IsSelected


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members


    }
}
