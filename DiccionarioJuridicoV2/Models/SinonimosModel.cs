using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using DiccionarioJuridicoV2.Dto;
using ScjnUtilities;

namespace DiccionarioJuridicoV2.Models
{
    public class SinonimosModel
    {

        public void SetNewSinonimo(Sinonimos sinonimo)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                sinonimo.IdSinonimo = DataBaseUtilities.GetNextIdForUse("Sinonimos", "IdSinonimo", connection);

                string sqlCadena = "SELECT * FROM Sinonimos WHERE IdSinonimo = 0";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);

                dataAdapter.Fill(dataSet, "Sinonimos");

                dr = dataSet.Tables["Sinonimos"].NewRow();
                dr["IdSinonimo"] = sinonimo.IdSinonimo;
                dr["Sinonimo"] = sinonimo.Sinonimo;
                dr["SinonimoStr"] = sinonimo.SinonimoStr;
                dr["Fuente"] = sinonimo.Fuente;
                dr["FuenteStr"] = sinonimo.FuenteStr;
                dr["FechaAlta"] = DateTime.Now;
                dr["FechaAltaInt"] = DateTimeUtilities.DateToInt(DateTime.Now);

                dataSet.Tables["Sinonimos"].Rows.Add(dr);

                dataAdapter.InsertCommand = connection.CreateCommand();

                dataAdapter.InsertCommand.CommandText = "INSERT INTO Sinonimos VALUES (@IdSinonimo,@Sinonimo,@SinonimoStr,@Fuente,@FuenteStr,@FechaAlta,@FechaAltaInt)";
                dataAdapter.InsertCommand.Parameters.Add("@IdSinonimo", OleDbType.Numeric, 0, "IdSinonimo");
                dataAdapter.InsertCommand.Parameters.Add("@Sinonimo", OleDbType.VarChar, 0, "Sinonimo");
                dataAdapter.InsertCommand.Parameters.Add("@SinonimoStr", OleDbType.VarChar, 0, "SinonimoStr");
                dataAdapter.InsertCommand.Parameters.Add("@Fuente", OleDbType.VarChar, 0, "Fuente");
                dataAdapter.InsertCommand.Parameters.Add("@FuenteStr", OleDbType.VarChar, 0, "FuenteStr");
                dataAdapter.InsertCommand.Parameters.Add("@FechaAlta", OleDbType.Date, 0, "FechaAlta");
                dataAdapter.InsertCommand.Parameters.Add("@FechaAltaInt", OleDbType.Numeric, 0, "FechaAltaInt");

                dataAdapter.Update(dataSet, "Sinonimos");
                dataSet.Dispose();
                dataAdapter.Dispose();

            }
            catch (OleDbException ex)
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
        }

        public void UpdateSinonimo(Sinonimos sinonimo)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {

                string sqlCadena = "SELECT * FROM Sinonimos WHERE IdSinonimo = @IdSinonimo";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@IdSinonimo", sinonimo.IdSinonimo);
                dataAdapter.Fill(dataSet, "Sinonimos");

                dr = dataSet.Tables["Sinonimos"].Rows[0];
                dr.BeginEdit();
                dr["Sinonimo"] = sinonimo.Sinonimo;
                dr["SinonimoStr"] = sinonimo.SinonimoStr;
                dr["Fuente"] = sinonimo.Fuente;
                dr["FuenteStr"] = sinonimo.FuenteStr;
                dr.EndEdit();



                dataAdapter.UpdateCommand = connection.CreateCommand();

                dataAdapter.UpdateCommand.CommandText = "UPDATE Sinonimos SET Sinonimo = @Sinonimo, SinonimoStr = @SinonimoStr, " +
                                                        " Fuente = @Fuente, FuenteStr = @FuenteStr WHERE IdSinonimo = @IdSinonimo";
                dataAdapter.UpdateCommand.Parameters.Add("@Sinonimo", OleDbType.VarChar, 0, "Sinonimo");
                dataAdapter.UpdateCommand.Parameters.Add("@SinonimoStr", OleDbType.VarChar, 0, "SinonimoStr");
                dataAdapter.InsertCommand.Parameters.Add("@Fuente", OleDbType.VarChar, 0, "Fuente");
                dataAdapter.InsertCommand.Parameters.Add("@FuenteStr", OleDbType.VarChar, 0, "FuenteStr");
                dataAdapter.UpdateCommand.Parameters.Add("@IdSinonimo", OleDbType.Numeric, 0, "IdSinonimo");

                dataAdapter.Update(dataSet, "Sinonimos");
                dataSet.Dispose();
                dataAdapter.Dispose();

            }
            catch (OleDbException ex)
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
        }

        public ObservableCollection<Sinonimos> GetSinonimos()
        {
            ObservableCollection<Sinonimos> conceptos = new ObservableCollection<Sinonimos>();

            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());
            OleDbCommand cmd;
            OleDbDataReader reader = null;

            try
            {
                connection.Open();

                string sqlCadena = "SELECT * FROM Sinonimos";

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sinonimos sinonimo = new Sinonimos();

                        sinonimo.IdSinonimo = reader["IdSinonimo"] as int? ?? 0;
                        sinonimo.Sinonimo = reader["Sinonimo"].ToString();
                        sinonimo.SinonimoStr = reader["SinonimoStr"].ToString();

                        conceptos.Add(sinonimo);
                    }
                }
            }
            catch (OleDbException ex)
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
                reader.Close();
                connection.Close();
            }

            return conceptos;
        }

        public void DeleteConcepto(Sinonimos sinonimo)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());
            OleDbCommand cmd;

            try
            {
                connection.Open();

                string sqlCadena = "Delete FROM Sinonimos WHERE IdSinonimo = @IdSinonimo";

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdSinonimo", sinonimo.IdSinonimo);
                cmd.ExecuteNonQuery();

            }
            catch (OleDbException ex)
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
        }
    }
}
