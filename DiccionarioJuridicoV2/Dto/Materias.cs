using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DiccionarioJuridicoV2.Dto
{
    public class Materias
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string tabla;

        public string Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int servidor;

        public int Servidor
        {
            get { return servidor; }
            set { servidor = value; }
        }


        public ObservableCollection<Materias> GetMateriasBase()
        {
            ObservableCollection<Materias> materias = new ObservableCollection<Materias>();

            materias.Add(new Materias { Id = 1, Descripcion = "Constitucional", Tabla = "The_Temas", Servidor = 1 });
            materias.Add(new Materias { Id = 2, Descripcion = "Penal", Tabla = "Temas", Servidor = 2 });
            materias.Add(new Materias { Id = 4, Descripcion = "Civil", Tabla = "Temas", Servidor = 2 });
            materias.Add(new Materias { Id = 8, Descripcion = "Administrativa", Tabla = "Temas", Servidor = 2 });
            materias.Add(new Materias { Id = 16, Descripcion = "Laboral", Tabla = "Temas", Servidor = 2 });
            materias.Add(new Materias { Id = 32, Descripcion = "Común", Tabla = "Temas", Servidor = 2 });
            materias.Add(new Materias { Id = 64, Descripcion = "Derechos Humanos", Tabla = "Temas", Servidor = 2 });

            return materias;
        }

    }
}
