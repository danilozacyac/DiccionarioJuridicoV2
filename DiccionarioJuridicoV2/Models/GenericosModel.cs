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
    public class GenericosModel
    {


        public ObservableCollection<Genericos> GetGenericos()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            ObservableCollection<Genericos> terminosGenericos = new ObservableCollection<Genericos>();

            OleDbCommand cmd;
            OleDbDataReader reader;

            cmd = connection.CreateCommand();
            cmd.Connection = connection;

            try
            {
                connection.Open();
                string miQry = "SELECT G.IdConcepto, G.Concepto, G.ConceptoStr, D.Definicion " +
                               " FROM Definiciones D INNER JOIN Genericos G ON D.IdConcepto = G.IdConcepto ORDER BY G.ConceptoStr";

                cmd = new OleDbCommand(miQry, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Genericos generico = new Genericos();
                    generico.IdGenerico = reader["IdConcepto"] as int? ?? -1;
                    generico.Termino = reader["Concepto"].ToString();
                    generico.TerminoStr = reader["ConceptoStr"].ToString();
                    generico.Definicion = reader["Definicion"].ToString();

                    terminosGenericos.Add(generico);
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

            return terminosGenericos;
        }


        public void SetNewTerminoGenericos(Genericos generico)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                generico.IdGenerico = DataBaseUtilities.GetNextIdForUse("Genericos", "IdConcepto", connection);


                string sqlCadena = "SELECT * FROM Genericos WHERE IdConcepto = 0";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);

                dataAdapter.Fill(dataSet, "Genericos");

                dr = dataSet.Tables["Genericos"].NewRow();
                dr["IdConcepto"] = generico.IdGenerico;
                dr["Concepto"] = StringUtilities.ToTitleCase(generico.Termino);
                dr["ConceptoStr"] = ScjnUtilities.StringUtilities.PrepareToAlphabeticalOrder(generico.Termino);
                dr["FechaAlta"] = DateTime.Now;
                dr["FechaAltaInt"] = DateTimeUtilities.DateToInt(DateTime.Now);


                dataSet.Tables["Genericos"].Rows.Add(dr);

                dataAdapter.InsertCommand = connection.CreateCommand();

                dataAdapter.InsertCommand.CommandText = "INSERT INTO Genericos VALUES (@IdConcepto,@Concepto,@ConceptoStr,@FechaAlta,@FechaAltaInt)";
                dataAdapter.InsertCommand.Parameters.Add("@IdConcepto", OleDbType.Numeric, 0, "IdConcepto");
                dataAdapter.InsertCommand.Parameters.Add("@Concepto", OleDbType.VarChar, 0, "Concepto");
                dataAdapter.InsertCommand.Parameters.Add("@ConceptoStr", OleDbType.VarChar, 0, "ConceptoStr");
                dataAdapter.InsertCommand.Parameters.Add("@FechaAlta", OleDbType.Date, 0, "FechaAlta");
                dataAdapter.InsertCommand.Parameters.Add("@FechaAltaInt", OleDbType.Numeric, 0, "FechaAltaInt");

                dataAdapter.Update(dataSet, "Genericos");
                dataSet.Dispose();
                dataAdapter.Dispose();

                this.SetDefiniciones(generico);

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

        public void UpdateTerminoJuridico(Genericos generico)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                string sqlCadena = "SELECT * FROM Genericos WHERE IdConcepto = " + generico.IdGenerico;

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);
                dataAdapter.Fill(dataSet, "Genericos");

                dr = dataSet.Tables["Genericos"].Rows[0];
                dr.BeginEdit();
                dr["Concepto"] = StringUtilities.UppercaseFirst(generico.Termino);
                dr["ConceptoStr"] = ScjnUtilities.StringUtilities.PrepareToAlphabeticalOrder(generico.Termino);
                dr.EndEdit();

                dataAdapter.UpdateCommand = connection.CreateCommand();

                dataAdapter.UpdateCommand.CommandText = "UPDATE Genericos SET Concepto = @Concepto, ConceptoStr = @ConceptoStr WHERE IdConcepto = @IdConcepto";

                dataAdapter.UpdateCommand.Parameters.Add("@Concepto", OleDbType.VarChar, 0, "Concepto");
                dataAdapter.UpdateCommand.Parameters.Add("@ConceptoStr", OleDbType.VarChar, 0, "ConceptoStr");
                dataAdapter.UpdateCommand.Parameters.Add("@IdConcepto", OleDbType.Numeric, 0, "IdConcepto");

                dataAdapter.Update(dataSet, "Genericos");
                dataSet.Dispose();
                dataAdapter.Dispose();

                this.SetDefiniciones(generico);

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


        private void SetDefiniciones(Genericos generico)
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
                dr["IdConcepto"] = generico.IdGenerico;
                dr["Definicion"] = generico.Definicion;
                dr["DefinicionStr"] = ScjnUtilities.StringUtilities.PrepareToAlphabeticalOrder(generico.Definicion);
                dr["FechaAlta"] = DateTime.Now;
                dr["FechaAltaInt"] = DateTimeUtilities.DateToInt(DateTime.Now);


                dataSet.Tables["Definiciones"].Rows.Add(dr);

                dataAdapter.InsertCommand = connection.CreateCommand();

                dataAdapter.InsertCommand.CommandText = "INSERT INTO Definiciones (IdConcepto,Definicion,DefinicionStr,FechaAlta,FechaAltaInt) VALUES (@IdConcepto,@Definicion,@DefinicionStr,@FechaAlta,@FechaAltaInt)";
                dataAdapter.InsertCommand.Parameters.Add("@IdConcepto", OleDbType.Numeric, 0, "IdConcepto");
                dataAdapter.InsertCommand.Parameters.Add("@Definicion", OleDbType.VarChar, 0, "Definicion");
                dataAdapter.InsertCommand.Parameters.Add("@DefinicionStr", OleDbType.VarChar, 0, "DefinicionStr");
                dataAdapter.InsertCommand.Parameters.Add("@FechaAlta", OleDbType.Date, 0, "FechaAlta");
                dataAdapter.InsertCommand.Parameters.Add("@FechaAltaInt", OleDbType.Numeric, 0, "FechaAltaInt");

                dataAdapter.Update(dataSet, "Definiciones");
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
