using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DiccionarioJuridicoV2.Dto;
using ScjnUtilities;

namespace DiccionarioJuridicoV2.Models
{
    public class MateriasModel
    {

        /// <summary>
        /// Devuelve el listado de las materias contenidas en el IUS
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Materias> GetMateriasIus()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Constitucional"].ToString());

            ObservableCollection<Materias> materias = new ObservableCollection<Materias>();

            SqlCommand cmd;
            SqlDataReader dataReader;

            cmd = connection.CreateCommand();
            cmd.Connection = connection;

            try
            {
                connection.Open();
                string miQry = "SELECT * FROM Raiz";

                cmd = new SqlCommand(miQry, connection);
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Materias materia = new Materias();
                    materia.Id = Convert.ToInt32(dataReader["Id"].ToString());
                    materia.Descripcion = dataReader["Descripcion"].ToString();
                    materia.Tabla = (materia.Descripcion.Equals("Constitucional")) ? "The_Temas" : dataReader["Tabla"].ToString();

                    materias.Add(materia);
                }


            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

                MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, methodName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorUtilities.SetNewErrorMessage(ex, methodName, 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

                MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, methodName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorUtilities.SetNewErrorMessage(ex, methodName, 0);
            }
            finally
            {
                connection.Close();
            }



            return materias;
        }
    }
}
