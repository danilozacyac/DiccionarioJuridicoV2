using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using DiccionarioJuridicoV2.Dto;
using ScjnUtilities;

namespace DiccionarioJuridicoV2.Models
{
    public class DefinicionModel
    {
        
        
        /// <summary>
        /// Obtiene las dedfiniciones relacionadas a un concepto
        /// </summary>
        /// <param name="idConcepto">Identificador del Concepto</param>
        /// <returns></returns>
        public ObservableCollection<Definiciones> GetDefinicion(Genericos terminoGenerico)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            ObservableCollection<Definiciones> listaDefiniciones = new ObservableCollection<Definiciones>();

            OleDbCommand cmd;
            OleDbDataReader reader;

            cmd = connection.CreateCommand();
            cmd.Connection = connection;

            try
            {
                connection.Open();
                string miQry = "SELECT * FROM Definiciones WHERE IdConcepto = @IdConcepto";

                cmd = new OleDbCommand(miQry, connection);
                cmd.Parameters.AddWithValue("@IdConcepto", terminoGenerico.IdGenerico);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Definiciones definicion = new Definiciones();
                    definicion.IdDefinicion = Convert.ToInt32(reader["Id"]);
                    definicion.IdGenerico = Convert.ToInt32(reader["IdConcepto"]);
                    definicion.Definicion = reader["Definicion"].ToString();
                    definicion.DefinicionStr = reader["DefinicionStr"].ToString();
                    definicion.Fuente = reader["Fuente"].ToString();
                    definicion.FuenteStr = reader["FuenteStr"].ToString();

                    listaDefiniciones.Add(definicion);
                }


            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GetDefinicion", "Diccionario");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GetDefinicion", "Diccionario");
            }
            finally
            {
                connection.Close();
            }

            return listaDefiniciones;
        }

        /// <summary>
        /// Agrega una propuesta de definición para un término 
        /// </summary>
        /// <param name="generico"></param>
        public void SetDefiniciones(Definiciones definicion)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {

                string sqlCadena = "SELECT * FROM Definiciones WHERE Id = 0";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);

                dataAdapter.Fill(dataSet, "Definiciones");

                dr = dataSet.Tables["Definiciones"].NewRow();
                dr["IdConcepto"] = definicion.IdGenerico;
                dr["Definicion"] = definicion.Definicion;

                if (!String.IsNullOrWhiteSpace(definicion.Definicion))
                    dr["DefinicionStr"] = ScjnUtilities.StringUtilities.PrepareToAlphabeticalOrder(definicion.Definicion);
                else
                    dr["DefinicionStr"] = String.Empty;
                dr["FechaAlta"] = DateTime.Now;
                dr["FechaAltaInt"] = DateTimeUtilities.DateToInt(DateTime.Now);

                dr["Fuente"] = definicion.Fuente;

                if (!String.IsNullOrWhiteSpace(definicion.Fuente))
                    dr["FuenteStr"] = ScjnUtilities.StringUtilities.PrepareToAlphabeticalOrder(definicion.Fuente);
                else
                    dr["FuenteStr"] = String.Empty;


                dataSet.Tables["Definiciones"].Rows.Add(dr);

                dataAdapter.InsertCommand = connection.CreateCommand();

                dataAdapter.InsertCommand.CommandText = "INSERT INTO Definiciones (IdConcepto,Definicion,DefinicionStr,FechaAlta,FechaAltaInt,Fuente,FuenteStr) VALUES (@IdConcepto,@Definicion,@DefinicionStr,@FechaAlta,@FechaAltaInt,@Fuente,@FuenteSrt)";
                dataAdapter.InsertCommand.Parameters.Add("@IdConcepto", OleDbType.Numeric, 0, "IdConcepto");
                dataAdapter.InsertCommand.Parameters.Add("@Definicion", OleDbType.VarChar, 0, "Definicion");
                dataAdapter.InsertCommand.Parameters.Add("@DefinicionStr", OleDbType.VarChar, 0, "DefinicionStr");
                dataAdapter.InsertCommand.Parameters.Add("@FechaAlta", OleDbType.Date, 0, "FechaAlta");
                dataAdapter.InsertCommand.Parameters.Add("@FechaAltaInt", OleDbType.Numeric, 0, "FechaAltaInt");
                dataAdapter.InsertCommand.Parameters.Add("@Fuente", OleDbType.VarChar, 0, "Fuente");
                dataAdapter.InsertCommand.Parameters.Add("@FuenteStr", OleDbType.VarChar, 0, "FuenteStr");

                dataAdapter.Update(dataSet, "Definiciones");
                dataSet.Dispose();
                dataAdapter.Dispose();

            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,SetDefiniciones", "Diccionario");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,SetDefiniciones", "Diccionario");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Actualiza la definición propuesta 
        /// </summary>
        /// <param name="definicion"></param>
        public void UpdateDefinicion(Definiciones definicion)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                string sqlCadena = "SELECT * FROM Definiciones WHERE Id = " + definicion.IdDefinicion;

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);
                dataAdapter.Fill(dataSet, "Definiciones");

                dr = dataSet.Tables["Definiciones"].Rows[0];
                dr.BeginEdit();
                dr["Definicion"] = definicion.Definicion;
                dr["DefinicionStr"] = definicion.DefinicionStr;
                dr["Fuente"] = definicion.Fuente;
                dr["FuenteStr"] = definicion.FuenteStr;
                dr.EndEdit();

                dataAdapter.UpdateCommand = connection.CreateCommand();

                dataAdapter.UpdateCommand.CommandText = "UPDATE Definiciones SET Definicion = @Definicion, DefinicionStr = @DefinicionStr, Fuente = @Fuente, FuenteStr = @FuenteStr WHERE Id = @Id";

                dataAdapter.UpdateCommand.Parameters.Add("@Definicion", OleDbType.VarChar, 0, "Definicion");
                dataAdapter.UpdateCommand.Parameters.Add("@DefinicionStr", OleDbType.VarChar, 0, "DefinicionStr");
                dataAdapter.UpdateCommand.Parameters.Add("@Fuente", OleDbType.VarChar, 0, "Fuente");
                dataAdapter.UpdateCommand.Parameters.Add("@FuenteStr", OleDbType.VarChar, 0, "FuenteStr");
                dataAdapter.UpdateCommand.Parameters.Add("@Id", OleDbType.Numeric, 0, "Id");

                dataAdapter.Update(dataSet, "Definiciones");
                dataSet.Dispose();
                dataAdapter.Dispose();



            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,UpdateDefinicion", "Diccionario");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,UpdateDefinicion", "Diccionario");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Elimina la definición propuesta 
        /// </summary>
        /// <param name="definicion">Definición que se quiere eliminar</param>
        public void DeleteDefinicion(Definiciones definicion)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());
            OleDbCommand cmd;

            try
            {
                connection.Open();

                string sqlCadena = "Delete FROM Definiciones WHERE Id = @Id";

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Id", definicion.IdDefinicion);
                cmd.ExecuteNonQuery();

            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DeleteDefinicion", "Diccionario");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DeleteDefinicion", "Diccionario");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Elimina todas las definiciones relacionadas a un término, el cual esta por ser eliminado
        /// </summary>
        /// <param name="idGenerico">Identificador del término que se esta eliminando</param>
        public void DeleteDefinicion(int idGenerico)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());
            OleDbCommand cmd;

            try
            {
                connection.Open();

                string sqlCadena = "Delete FROM Definiciones WHERE IdConcepto = @IdConcepto";

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdConcepto", idGenerico);
                cmd.ExecuteNonQuery();

            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DeleteDefinicion", "Diccionario");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DeleteDefinicion", "Diccionario");
            }
            finally
            {
                connection.Close();
            }
        }




    }
}
