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
    public class TemasModel
    {


        public static ObservableCollection<Temas> GetTemasConstitucional(Temas temaPadre)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Constitucional"].ToString());

            ObservableCollection<Temas> listaTemas = new ObservableCollection<Temas>();

            SqlCommand cmd;
            SqlDataReader dataReader;

            cmd = connection.CreateCommand();
            cmd.Connection = connection;

            try
            {
                connection.Open();
                string miQry = "SELECT * FROM The_Temas WHERE IDPadre = @IDPadre ORDER BY DescripcionStr";

                cmd = new SqlCommand(miQry, connection);
                if (temaPadre == null)
                    cmd.Parameters.AddWithValue("@IDPadre", 0);
                else
                    cmd.Parameters.AddWithValue("@IDPadre", temaPadre.Id);
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Temas tema = new Temas(temaPadre);
                    tema.Id = Convert.ToInt32(dataReader["IdTema"].ToString());
                    tema.Nivel = Convert.ToInt32(dataReader["Nivel"].ToString());
                    tema.Padre = Convert.ToInt32(dataReader["IDPadre"].ToString());
                    tema.Descripcion = dataReader["Descripcion"].ToString();
                    tema.TemasHijo = TemasModel.GetTemasConstitucional(tema);


                    listaTemas.Add(tema);
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

            return listaTemas;
        }


        public static ObservableCollection<Temas> GetTemasTematico(Temas temaPadre, int materia)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Tematicos"].ToString());

            ObservableCollection<Temas> listaTemas = new ObservableCollection<Temas>();

            SqlCommand cmd;
            SqlDataReader dataReader;

            cmd = connection.CreateCommand();
            cmd.Connection = connection;

            try
            {
                connection.Open();
                string miQry = "SELECT * FROM Temas WHERE IDPadre = @IDPadre AND Materia = @Materia ORDER BY DescripcionStr";

                cmd = new SqlCommand(miQry, connection);
                if (temaPadre == null)
                {
                    cmd.Parameters.AddWithValue("@IDPadre", -materia);
                    cmd.Parameters.AddWithValue("@Materia", materia);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IDPadre", temaPadre.Id);
                    cmd.Parameters.AddWithValue("@Materia", materia);
                }
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Temas tema = new Temas(temaPadre);
                    tema.Id = Convert.ToInt32(dataReader["IdTema"].ToString());
                    tema.Nivel = Convert.ToInt32(dataReader["Nivel"].ToString());
                    tema.Padre = Convert.ToInt32(dataReader["IDPadre"].ToString());
                    tema.Descripcion = dataReader["Descripcion"].ToString();
                    tema.TemasHijo = TemasModel.GetTemasTematico(tema, materia);


                    listaTemas.Add(tema);
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

            return listaTemas;
        }



    }
}
