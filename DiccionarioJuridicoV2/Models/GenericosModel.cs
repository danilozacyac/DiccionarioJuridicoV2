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

        /// <summary>
        /// Obtiene los términos que contiene el diccionario hasta el momento
        /// </summary>
        /// <returns></returns>
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
                string miQry = "SELECT G.IdConcepto, G.Concepto, G.ConceptoStr FROM Genericos G ORDER BY G.ConceptoStr";

                cmd = new OleDbCommand(miQry, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Genericos generico = new Genericos();
                    generico.IdGenerico = reader["IdConcepto"] as int? ?? -1;
                    generico.Termino = reader["Concepto"].ToString();
                    generico.TerminoStr = reader["ConceptoStr"].ToString();
                    generico.Definiciones = new DefinicionModel().GetDefinicion(generico.IdGenerico);
                    generico.Sinonimos = new SinonimosModel().GetSinonimos(generico.IdGenerico);
                    generico.ConceptosScjn = new TesauroScjnModel().GetTerminosScjn(generico.IdGenerico);

                    terminosGenericos.Add(generico);
                }


            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GetGenericos", "Diccionario");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GetGenericos", "Diccionario");
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
                dr["Concepto"] = StringUtilities.UppercaseFirst(generico.Termino);
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

                if (generico.Definiciones != null)
                {
                    foreach (Definiciones definicion in generico.Definiciones)
                    {
                        definicion.IdGenerico = generico.IdGenerico;
                        new DefinicionModel().SetDefiniciones(definicion);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,SetNewTerminoGenericos", "Diccionario");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,SetNewTerminoGenericos", "Diccionario");
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateTerminoGenerico(Genericos generico)
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
                dr["Concepto"] = generico.Termino;
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

            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,UpdateTerminoGenerico", "Diccionario");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,UpdateTerminoGenerico", "Diccionario");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Elimina el concepto del diccionario junto con todas sus asociaciones
        /// </summary>
        /// <param name="generico"></param>
        public void DeleteTerminoGenerico(Genericos generico)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());
            OleDbCommand cmd;

            try
            {
                connection.Open();

                string sqlCadena = "Delete FROM Genericos WHERE IdConcepto = @IdConcepto";

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdConcepto", generico.IdGenerico);
                cmd.ExecuteNonQuery();

                new DefinicionModel().DeleteDefinicion(generico.IdGenerico);
                new RelacionesModel().DeleteRelation(generico.IdGenerico, 1);
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DeleteTerminoGenerico", "Diccionario");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DeleteTerminoGenerico", "Diccionario");
            }
            finally
            {
                connection.Close();
            }
        }


        
    }
}
