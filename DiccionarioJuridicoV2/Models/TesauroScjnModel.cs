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

        /// <summary>
        /// Obtiene los términos relacionados a un concepto genérico en concreto
        /// </summary>
        /// <param name="idConceptoScjn">Identificador del concepto del cual se quieren obtener sus relaciones</param>
        /// <returns></returns>
        public ObservableCollection<TesauroScjn> GetTerminosScjn(Genericos terminoGenerico)
        {
            ObservableCollection<TesauroScjn> conceptos = new ObservableCollection<TesauroScjn>();

            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());
            OleDbCommand cmd;
            OleDbDataReader reader = null;

            try
            {
                connection.Open();

                string sqlCadena = "SELECT T.IdTesauroScjn, T.Concepto, R.IdConcepto, R.IdRelExterna " +
                                   " FROM TesauroScjn T INNER JOIN Relaciones R ON R.IdRelExterna = T.IdTesauroScjn " +
                                   " WHERE IdConcepto = @IdConcepto AND TipoRelacion = 9";

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdConcepto", terminoGenerico.IdGenerico);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TesauroScjn scjn = new TesauroScjn();
                        scjn.Id = reader["IdTesauroScjn"] as int? ?? 0;
                        scjn.ConceptoScjn = reader["Concepto"].ToString();

                        conceptos.Add(scjn);
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Permite añadir un nuevo concepto del Tesauro de la SCJN
        /// </summary>
        /// <param name="terminoScjn"></param>
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

        /// <summary>
        /// Actualiza uno de los terminos existentes del Tesauro de la SCJN
        /// </summary>
        /// <param name="terminoScjn"></param>
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