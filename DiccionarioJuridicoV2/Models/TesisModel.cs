using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DiccionarioJuridicoV2.Dto;
using ScjnUtilities;

namespace DiccionarioJuridicoV2.Models
{
    public class TesisModel
    {
        public ObservableCollection<Tesis> GetTesisForConcepto(ObservableCollection<int> numerosIus)
        {
            ObservableCollection<Tesis> listaTesis = new ObservableCollection<Tesis>();

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MantesisSql"].ToString());

            SqlCommand cmd;
            SqlDataReader reader;

            string sqlQry = "SELECT IUS,Rubro, Texto, Precedentes FROM Tesis WHERE " + this.ArmaCadena(numerosIus);

            try
            {
                connection.Open();

                cmd = new SqlCommand(sqlQry, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Tesis tesis = new Tesis();
                    tesis.Ius = reader["IUS"] as int? ?? 0;
                    tesis.Rubro = reader["Rubro"].ToString();
                    tesis.Texto = reader["Texto"].ToString();
                    tesis.Precedentes = reader["Precedentes"].ToString();
                    listaTesis.Add(tesis);
                    
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

            return listaTesis;
        }

        private string ArmaCadena(ObservableCollection<int> numerosIus)
        {
            List<string> conditions = new List<string>();

            foreach (int ius in numerosIus)
                conditions.Add("IUS = " + ius);

            string finalCondition = String.Join(" OR ", conditions.ToArray());

            return finalCondition;
        }
    }
}