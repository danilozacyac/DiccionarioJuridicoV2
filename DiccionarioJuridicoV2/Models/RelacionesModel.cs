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
    /// 4. Genérico- Tesauro SCJN
    /// 5. Concepto Jurídico-Tesauro Constitucional
    /// 6. Concepto Jurídico-Tesauro Penal
    /// 7. Concepto Jurídico-Tesauro Laboral
    /// 8. Concepto Jurídico-Tesauro Civil
    /// 9. Concepto Jurídico-Tesauro Administrativa
    /// 10. Concepto Jurídico-Tesauro Común
    /// 11. Concepto Jurídico-Tesauro SCJN
    /// 12. Tesauro SCJN-Tesauro Constitucional
    /// 13. Tesauro SCJN-Tesauro Penal
    /// 14. Tesauro SCJN-Tesauro Laboral
    /// 15. Tesauro SCJN-Tesauro Civil
    /// 16. Tesauro SCJN-Tesauro Administrativa
    /// 17. Tesauro SCJN-Tesauro Común
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

                dataAdapter.InsertCommand.CommandText = "INSERT INTO Relaciones VALUES (@IdConcepto,@IdRelExterna,@TipoRelacion)";
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


    }
}
