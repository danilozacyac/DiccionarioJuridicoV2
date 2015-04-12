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
    public class TesauroScjnModel
    {


        public ObservableCollection<TesauroScjn> GetTerminosScjn()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            ObservableCollection<TesauroScjn> terminosScjn = new ObservableCollection<TesauroScjn>();

            OleDbCommand cmd;
            OleDbDataReader reader;

            cmd = connection.CreateCommand();
            cmd.Connection = connection;

            try
            {
                connection.Open();
                string miQry = "SELECT * FROM TesauroScjn";

                cmd = new OleDbCommand(miQry, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TesauroScjn tesauro = new TesauroScjn();
                    tesauro.Id = reader["IdTesauroScjn"] as int? ?? -1;
                    tesauro.ConceptoScjn = reader["Concepto"].ToString();

                    terminosScjn.Add(tesauro);
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
                connection.Close();
            }

            return terminosScjn;
        }

        public void SetNewTerminoScjn(TesauroScjn terminoScjn)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                string sqlCadena = "SELECT * FROM TesauroScjn WHERE IdTesauroScjn = 0";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);

                dataAdapter.Fill(dataSet, "TesauroScjn");

                dr = dataSet.Tables["TesauroScjn"].NewRow();
                dr["IdTesauroScjn"] = terminoScjn.Id;
                dr["Concepto"] = StringUtilities.ToTitleCase(terminoScjn.ConceptoScjn);

                dataSet.Tables["TesauroScjn"].Rows.Add(dr);

                dataAdapter.InsertCommand = connection.CreateCommand();

                dataAdapter.InsertCommand.CommandText = "INSERT INTO TesauroScjn VALUES (@IdTesauroScjn,@Concepto)";
                dataAdapter.InsertCommand.Parameters.Add("@IdTesauroScjn", OleDbType.Numeric, 0, "IdTesauroScjn");
                dataAdapter.InsertCommand.Parameters.Add("@Concepto", OleDbType.VarChar, 0, "Concepto");

                dataAdapter.Update(dataSet, "TesauroScjn");
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

        public void UpdateTerminoScjn(TesauroScjn terminoScjn)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                string sqlCadena = "SELECT * FROM TesauroScjn WHERE IdTesauroScjn = " + terminoScjn.Id;

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);
                dataAdapter.Fill(dataSet, "TesauroScjn");

                dr = dataSet.Tables["TesauroScjn"].Rows[0];
                dr.BeginEdit();
                dr["Concepto"] = StringUtilities.UppercaseFirst(terminoScjn.ConceptoScjn);
                dr.EndEdit();

                dataAdapter.UpdateCommand = connection.CreateCommand();

                dataAdapter.UpdateCommand.CommandText = "UPDATE TesauroScjn SET Concepto = @Concepto WHERE IdTesauroScjn = @IdTesauroScjn";

                dataAdapter.UpdateCommand.Parameters.Add("@Concepto", OleDbType.VarChar, 0, "Concepto");
                dataAdapter.UpdateCommand.Parameters.Add("@IdTesauroScjn", OleDbType.Numeric, 0, "IdTesauroScjn");

                dataAdapter.Update(dataSet, "TesauroScjn");
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

    }
}
