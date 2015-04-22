using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using ScjnUtilities;

namespace DiccionarioJuridicoV2.Models
{
    /// <summary>
    /// Establece los diferentes tipos de relaciones que se pueden presentar entre las diferentes fuentes de información,
    /// los tipos de relaciones serán los siguientes:
    /// 1. Genérico-Concepto Jurídico
    /// 2. Genérico-Sinónimo
    /// 3. Genérico-Tesauro Constitucional
    /// 4. Genérico-Tesauro Penal
    /// 5. Genérico-Tesauro Laboral
    /// 6. Genérico-Tesauro Civil
    /// 7. Genérico-Tesauro Administrativa
    /// 8. Genérico-Tesauro Común
    /// 9. Genérico- Tesauro SCJN
    /// 10. Concepto Jurídico-Tesauro Constitucional
    /// 11. Concepto Jurídico-Tesauro Penal
    /// 12. Concepto Jurídico-Tesauro Laboral
    /// 13. Concepto Jurídico-Tesauro Civil
    /// 14. Concepto Jurídico-Tesauro Administrativa
    /// 15. Concepto Jurídico-Tesauro Común
    /// 16. Concepto Jurídico-Tesauro SCJN
    /// 
    /// Cuando la relación sea entre un Tema del Temático de la CCST y uno del tesauro de la
    /// Suprema Corte, aquellos del Temático se almacenarán como IdConcepto y los de la SCJN
    /// como IdRelExterna
    /// 
    /// 101. Tesauro Constitucional - Tesauro SCJN
    /// 102. Tesauro Penal - Tesauro SCJN-
    /// 104. Tesauro Civil - Tesauro SCJN-
    /// 108. Tesauro Administrativa - Tesauro SCJN-
    /// 116. Tesauro Laboral - Tesauro SCJN-
    /// 132. Tesauro Común - Tesauro SCJN-
    /// </summary>
    public class RelacionesModel
    {


        /// <summary>
        /// Estable un relación de conceptos entre aquellos contenidos en el diciconario, sus sinónimos, el tesauro constitucional
        /// y el tesauro de la Suprema Corte
        /// </summary>
        /// <param name="idConcepto">Identificador del condepto del diccionario</param>
        /// <param name="idRelExterna">Identificador del concepto con el cual se relacionará el del diccionario</param>
        /// <param name="tipoRelacion"></param>
        public void SetNewRelation(int idConcepto, int idRelExterna, int tipoRelacion)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());

            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                string sqlCadena = "SELECT * FROM Relaciones WHERE IdRelacion = 0";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);

                dataAdapter.Fill(dataSet, "Relaciones");

                dr = dataSet.Tables["Relaciones"].NewRow();
                dr["IdConcepto"] = idConcepto;
                dr["IdRelExterna"] = idRelExterna;
                dr["TipoRelacion"] = tipoRelacion;


                dataSet.Tables["Relaciones"].Rows.Add(dr);

                dataAdapter.InsertCommand = connection.CreateCommand();

                dataAdapter.InsertCommand.CommandText = "INSERT INTO Relaciones (IdConcepto,IdRelExterna,TipoRelacion) VALUES (@IdConcepto,@IdRelExterna,@TipoRelacion)";
                dataAdapter.InsertCommand.Parameters.Add("@IdConcepto", OleDbType.Numeric, 0, "IdConcepto");
                dataAdapter.InsertCommand.Parameters.Add("@IdRelExterna", OleDbType.Numeric, 0, "IdRelExterna");
                dataAdapter.InsertCommand.Parameters.Add("@TipoRelacion", OleDbType.Numeric, 0, "TipoRelacion");

                dataAdapter.Update(dataSet, "Relaciones");
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
        /// Elimina la relación seleccionada
        /// </summary>
        /// <param name="idConcepto">Identificador del concepto base</param>
        /// <param name="idRelExterna">Identificador del concepto relacionado</param>
        /// <param name="tipoRelacion">Tipo de relacion establecida</param>
        public void DeleteRelation(int idConcepto, int idRelExterna, int tipoRelacion)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());
            OleDbCommand cmd;

            try
            {
                connection.Open();

                string sqlCadena = "Delete FROM Relaciones WHERE IdConcepto = @IdConcepto AND IdRelExterna = @IdRelExterna AND TipoRelacion = @TipoRelacion";

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdConcepto", idConcepto);
                cmd.Parameters.AddWithValue("@IdRelExterna", idRelExterna);
                cmd.Parameters.AddWithValue("@TipoRelacion", tipoRelacion);
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

        /// <summary>
        /// Elimina todas las asociaciones de un concepto
        /// </summary>
        /// <param name="idConcepto">Concepto que se elimina</param>
        /// <param name="idReferenciaBorrado">Tipo de borrado que se realizará</param>
        public void DeleteRelation(int idConcepto, int idReferenciaBorrado)
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Diccionario"].ToString());
            OleDbCommand cmd;

            try
            {
                connection.Open();

                string sqlCadena = "Delete FROM Relaciones WHERE IdConcepto = @IdConcepto ";

                if (idReferenciaBorrado == 1)
                    sqlCadena += " AND TipoRelacion BETWEEN 1 AND 9";

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdConcepto", idConcepto);
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
