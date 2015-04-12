using System;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Controls;

namespace DiccionarioJuridicoV2.Dto
{
    public class Temas : ViewModelBase
    {
        private bool? isSelected = false;
        private int id;
        private int nivel;
        private int padre;
        private string clave;
        private string descripcion;
        private ObservableCollection<Temas> temasHijo;
        private Temas temaPadre;
        //private ObservableCollection<RPSinonimos> sinonimos;
        //private ObservableCollection<RPSinonimos> relacionesProx;

        public Temas(Temas padre)
        {
            this.temaPadre = padre;
        }


        private bool reentrancyCheck = false;
        public bool? IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                if (this.isSelected != value)
                {
                    if (reentrancyCheck)
                        return;
                    this.reentrancyCheck = true;
                    this.isSelected = value;
                    this.UpdateCheckState();
                    OnPropertyChanged("IsSelected");
                    this.reentrancyCheck = false;
                }
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Nivel
        {
            get
            {
                return this.nivel;
            }
            set
            {
                this.nivel = value;
            }
        }

        public int Padre
        {
            get
            {
                return this.padre;
            }
            set
            {
                this.padre = value;
            }
        }

        public string Clave
        {
            get
            {
                return this.clave;
            }
            set
            {
                this.clave = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public ObservableCollection<Temas> TemasHijo
        {
            get
            {
                return this.temasHijo;
            }
            set
            {
                this.temasHijo = value;
            }
        }

        public Temas TemaPadre
        {
            get
            {
                return this.temaPadre;
            }
            set
            {
                this.temaPadre = value;
            }
        }

        /// <summary>
        /// we need to implement the logic that determines the checked state of each item. For that purpose we have to traverse 
        /// the children colleciton of a checked item as well as to find the checked state in which its parent item should be set.
        /// </summary>
        private void UpdateChildrenCheckState()
        {
            foreach (var item in this.TemasHijo)
            {
                if (this.IsSelected != null)
                {
                    item.IsSelected = this.IsSelected;
                }
            }
        }

        /// <summary>
        /// We can also create a method that updates the checked state of the parent item. In order to simplify the code, 
        /// we can use a lambda function to count the number of the checked children of the parent item. If this number 
        /// indicates that all its children are checked, we can set the parent item checked state to checked, if the count 
        /// of its checked children is 0, then we need to uncheck it. In all other cases, its state should stay indeterminate
        /// </summary>
        /// <returns></returns>
        private bool? DetermineCheckState()
        {
            bool allChildrenChecked = this.TemasHijo.Count(x => x.IsSelected == true) == this.TemasHijo.Count;
            if (allChildrenChecked)
            {
                return true;
            }

            bool allChildrenUnchecked = this.TemasHijo.Count(x => x.IsSelected == false) == this.TemasHijo.Count;
            if (allChildrenUnchecked)
            {
                return false;
            }

            return null;
        }


        private void UpdateCheckState()
        {
            // update all children:
            if (this.TemasHijo.Count != 0)
            {
                this.UpdateChildrenCheckState();
            }
            //update parent item
            if (this.TemaPadre != null)
            {
                bool? parentIsChecked = this.TemaPadre.DetermineCheckState();
                this.TemaPadre.IsSelected = parentIsChecked;
            }
        }

    }
}
