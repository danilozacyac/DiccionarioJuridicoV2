using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DiccionarioJuridicoV2.Dto;
using ScjnUtilities;

namespace DiccionarioJuridicoV2.Models
{
    public class TemasModel
    {
        //private readonly string textoBuscado;
        //private ObservableCollection<Temas> temasEnLista = new ObservableCollection<Temas>();
        //public TemasModel() { }
        //public TemasModel(string textoBuscado)
        //{
        //    this.textoBuscado = textoBuscado;
        //}
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
                    cmd.Parameters.AddWithValue("@IDPadre", temaPadre.IDPadre);
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Temas tema = new Temas(temaPadre);
                    tema.IDTema = Convert.ToInt32(dataReader["IdTema"].ToString());
                    tema.Nivel = Convert.ToInt32(dataReader["Nivel"].ToString());
                    tema.IDPadre = Convert.ToInt32(dataReader["IDPadre"].ToString());
                    tema.Descripcion = dataReader["Descripcion"].ToString();
                    tema.SubTemas = TemasModel.GetTemasConstitucional(tema);

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
                    cmd.Parameters.AddWithValue("@IDPadre", temaPadre.IDTema);
                    cmd.Parameters.AddWithValue("@Materia", materia);
                }
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Temas tema = new Temas(temaPadre);
                    tema.IDTema = Convert.ToInt32(dataReader["IdTema"].ToString());
                    tema.Nivel = Convert.ToInt32(dataReader["Nivel"].ToString());
                    tema.IDPadre = Convert.ToInt32(dataReader["IDPadre"].ToString());
                    tema.Descripcion = dataReader["Descripcion"].ToString();
                    tema.SubTemas = TemasModel.GetTemasTematico(tema, materia);

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

        /*
         * 
         * 
         * */

        public ObservableCollection<Temas> Temas { get; set; }

        private readonly string textoBuscado;

        private static ObservableCollection<Temas> tematico;

        private ObservableCollection<Temas> temasEnLista = new ObservableCollection<Temas>();

        public static ObservableCollection<Temas> Tematico
        {
            get
            {
                //if (tematico == null)
                //    tematico = new TemasModel().GetTemasRaiz(null);

                return tematico;
            }
        }

        public TemasModel()
        {
            //Temas = this.GetTemasRaiz(null);
        }

        public TemasModel(String textoBuscado, int materia)
        {
            this.textoBuscado = textoBuscado;
            Temas = this.GetTemasBusqueda(null, materia);
        }

        //public ObservableCollection<Temas> GetTemasRaiz(Temas parentModule)
        //{
        //    SqlConnection sqlConne = this.GetConnection();

        //    ObservableCollection<Temas> modulos = new ObservableCollection<Temas>();

        //    foreach (MateriaTO idMateria in UserStatus.MateriasUser)
        //    {
        //        try
        //        {
        //            sqlConne.Open();

        //            string sqlCadena = "SELECT *, (SELECT COUNT(idTEma) FROM TemasTesis T WHERE T.idTema = Temas.Idtema and T.idMateria = Temas.Materia ) Total " +
        //                               "FROM Temas WHERE idtema < -1 AND Materia = @Materia ORDER BY DescripcionStr ";
        //            SqlCommand cmd = new SqlCommand(sqlCadena, sqlConne);
        //            SqlParameter materia = cmd.Parameters.Add("@Materia", SqlDbType.Int, 0);
        //            materia.Value = idMateria.Id;
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    Temas tema;

        //                    if (parentModule != null)
        //                        tema = new Temas(parentModule, true);
        //                    else
        //                        tema = new Temas(null, true);

        //                    tema.Materia = Convert.ToInt32(reader["Materia"]);
        //                    tema.IDTema = Convert.ToInt32(reader["idTema"]);
        //                    tema.IDPadre = Convert.ToInt32(reader["IDPadre"]);
        //                    tema.Nivel = Convert.ToInt32(reader["Nivel"]);
        //                    tema.Descripcion = reader["Descripcion"].ToString();
        //                    tema.IdOrigen = Convert.ToInt32(reader["IdOrigen"]);
        //                    tema.IdTemaOrigen = Convert.ToInt32(reader["IdTemaOrigen"]);
        //                    tema.TesisRelacionadas = Convert.ToInt32(reader["Total"]);

        //                    modulos.Add(tema);
        //                }
        //            }
        //        }
        //        catch (SqlException sql)
        //        {
        //            MessageBox.Show("Error ({0}) : {1}" + sql.Source + sql.Message, "Error Interno");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, "Error Interno");
        //        }
        //        finally
        //        {
        //            sqlConne.Close();
        //        }
        //    }
        //    return modulos;
        //}

        public ObservableCollection<Temas> GetTemasBusqueda(Temas parentModule,int materia)
        {
            SqlConnection sqlConne = this.GetConnection();

            ObservableCollection<Temas> modulos = new ObservableCollection<Temas>();

            try
            {
                sqlConne.Open();

                string sqlCadena = "SELECT *, (SELECT COUNT(idTEma) FROM TemasTesis T WHERE T.idTema = Temas.Idtema and T.idMateria = Temas.Materia ) Total " +
                                   "FROM Temas WHERE (" + this.ArmaCadenaBusqueda(textoBuscado) + ")  AND Materia = @IdMateria  AND idtema >= 0 and idPadre <> -1 ORDER BY DescripcionStr ";
                SqlCommand cmd = new SqlCommand(sqlCadena, sqlConne);
                cmd.Parameters.AddWithValue("@IdMateria", materia);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Temas tema = new Temas(null, true);
                            
                        tema.Materia = Convert.ToInt32(reader["Materia"]);
                        tema.IDTema = Convert.ToInt32(reader["idTema"]);
                        tema.IDPadre = Convert.ToInt32(reader["IDPadre"]);
                        tema.Nivel = Convert.ToInt32(reader["Nivel"]);
                        tema.Descripcion = reader["Descripcion"].ToString();
                        tema.IdOrigen = 99;
                        tema.TesisRelacionadas = Convert.ToInt32(reader["Total"]);
                            
                        List<Temas> buscaExistaTema = (from n in temasEnLista
                                                       where n.IDTema == tema.IDTema && n.Materia == tema.Materia
                                                       select n).ToList() ;
                            
                        //if (temasEnLista.Contains(tema.IDTema))
                        if (buscaExistaTema != null && buscaExistaTema.Count > 0)
                        {
                        }
                        else
                        {
                            if (tema.IDPadre == 0)
                            {
                                modulos.Add(tema);
                                temasEnLista.Add(tema);
                            }
                            else
                            {
                                List<Temas> buscaExistaPadre = (from n in temasEnLista
                                                                where n.IDTema == tema.IDPadre && n.Materia == tema.Materia
                                                                select n).ToList();

                                if (buscaExistaPadre != null && buscaExistaPadre.Count > 0)
                                //if (temasEnLista.Contains(tema.IDPadre) )
                                {
                                    foreach (Temas tematico in modulos)
                                    {
                                        if (tematico.IDTema == tema.IDPadre)
                                        {
                                            if (tematico.SubTemas == null)
                                                tema.SubTemas = new ObservableCollection<Temas>();
                                            tema.Parent = tematico;

                                            tematico.SubTemas.Add(tema);
                                            temasEnLista.Add(tema);
                                        }
                                        else
                                        {
                                            this.SearchExistingParent(tema, tematico);
                                        }
                                    }
                                }
                                else
                                {
                                    this.SearchParent(tema, modulos);
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show("Error ({0}) : {1}" + sql.Source + sql.Message, "Error Interno");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, "Error Interno");
            }
            finally
            {
                sqlConne.Close();
            }

            modulos = this.SetParents(modulos);

            modulos = this.SortSearch(modulos);

            return modulos;
        }

        //private ObservableCollection<Temas> GetTemasBusqueda(Temas parentModule, String sqlCadenaComplement)
        //{
        //    SqlConnection sqlConne = this.GetConnection();
        //    ObservableCollection<Temas> modulos = new ObservableCollection<Temas>();
        //    foreach (MateriaTO idMateria in UserStatus.MateriasUser)
        //    {
        //        try
        //        {
        //            sqlConne.Open();
        //            string sqlCadena = "SELECT *, (SELECT COUNT(idTEma) FROM TemasTesis T WHERE T.idTema = Temas.Idtema and T.idMateria = Temas.Materia ) Total " +
        //                               "FROM Temas WHERE (" + sqlCadenaComplement + ")  and idPadre <> -1 ORDER BY DescripcionStr ";
        //            SqlCommand cmd = new SqlCommand(sqlCadena, sqlConne);
        //            SqlParameter materia = cmd.Parameters.Add("@IdMateria", SqlDbType.Int, 0);
        //            materia.Value = idMateria.Id;
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    Temas tema = new Temas(null, true);
        //                    tema.Materia = Convert.ToInt32(reader["Materia"]);
        //                    tema.IDTema = Convert.ToInt32(reader["idTema"]);
        //                    tema.IDPadre = Convert.ToInt32(reader["IDPadre"]);
        //                    tema.Nivel = Convert.ToInt32(reader["Nivel"]);
        //                    tema.Descripcion = reader["Descripcion"].ToString();
        //                    tema.IdOrigen = 99;
        //                    tema.TesisRelacionadas = Convert.ToInt32(reader["Total"]);

        //                    List<Temas> buscaExistaTema = (from n in temasEnLista
        //                                                   where n.IDTema == tema.IDTema && n.Materia == tema.Materia
        //                                                   select n).ToList();

        //                    //if (temasEnLista.Contains(tema.IDTema))
        //                    if (buscaExistaTema != null && buscaExistaTema.Count > 0)
        //                    {
        //                    }
        //                    else
        //                    {
        //                        if (tema.IDPadre == 0)
        //                        {
        //                            modulos.Add(tema);
        //                            temasEnLista.Add(tema);
        //                        }
        //                        else
        //                        {
        //                            List<Temas> buscaExistaPadre = (from n in temasEnLista
        //                                                            where n.IDTema == tema.IDPadre && n.Materia == tema.Materia
        //                                                            select n).ToList();

        //                            if (buscaExistaPadre != null && buscaExistaPadre.Count > 0)
        //                            //if (temasEnLista.Contains(tema.IDPadre) )
        //                            {
        //                                foreach (Temas tematico in modulos)
        //                                {
        //                                    if (tematico.IDTema == tema.IDPadre)
        //                                    {
        //                                        if (tematico.SubTemas == null)
        //                                            tema.SubTemas = new ObservableCollection<Temas>();
        //                                        tema.Parent = tematico;

        //                                        tematico.SubTemas.Add(tema);
        //                                        temasEnLista.Add(tema);
        //                                    }
        //                                    else
        //                                    {
        //                                        this.SearchExistingParent(tema, tematico);
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                this.SearchParent(tema, modulos);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (SqlException sql)
        //        {
        //            MessageBox.Show("Error ({0}) : {1}" + sql.Source + sql.Message, "Error Interno");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, "Error Interno");
        //        }
        //        finally
        //        {
        //            sqlConne.Close();
        //        }
        //    }
        //    return SortSearch(this.SetParents(modulos));
        //}

        //public ObservableCollection<Temas> GetTemasPorIus(Temas parentModule)
        //{
        //    SqlConnection sqlConne = this.GetConnection();

        //    ObservableCollection<Temas> modulos = new ObservableCollection<Temas>();

        //    String sqlIusMateria = "";

        //    foreach (MateriaTO idMateria in UserStatus.MateriasUser)
        //    {
        //        try
        //        {
        //            sqlConne.Open();

        //            string sqlCadena = "SELECT idMateria,idTema FROM TemasTesis WHERE IUS = @IUS AND " +
        //                               " IdMateria = @IdMateria  ORDER BY IUS Asc";
        //            SqlCommand cmd = new SqlCommand(sqlCadena, sqlConne);
        //            SqlParameter ius = cmd.Parameters.Add("@IUS", SqlDbType.Int, 0);
        //            ius.Value = textoBuscado;
        //            SqlParameter materia = cmd.Parameters.Add("@IdMateria", SqlDbType.Int, 0);
        //            materia.Value = idMateria.Id;
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    sqlIusMateria += " OR (idTema = " + reader["idTema"].ToString() + " AND Materia = " + reader["idMateria"].ToString() + ")";
        //                }
        //            }
        //        }
        //        catch (SqlException sql)
        //        {
        //            MessageBox.Show("Error ({0}) : {1}" + sql.Source + sql.Message, "Error Interno");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, "Error Interno");
        //        }
        //        finally
        //        {
        //            sqlConne.Close();
        //        }
        //    }

        //    if (sqlIusMateria.Length > 2)
        //    {
        //        sqlIusMateria = sqlIusMateria.Substring(4);

        //        modulos = this.GetTemasBusqueda(null, sqlIusMateria);

        //        return SortSearch(this.SetParents(modulos));
        //    }
        //    else
        //    {
        //        MessageBox.Show("No existen temas relacionados al número de tesis ingresada");
        //        return new ObservableCollection<Temas>();
        //    }
        //}

        private ObservableCollection<Temas> SortSearch(ObservableCollection<Temas> moduloToSort)
        {

            ObservableCollection<Temas> moduloOrdenado = new ObservableCollection<Temas>(moduloToSort.OrderBy(i => i.Descripcion));

            foreach (Temas tema in moduloOrdenado)
            {
                this.SortSearch(tema.SubTemas);
            }

            return moduloOrdenado;
        }

        //private ObservableCollection<Temas> SortSearch(ObservableCollection<Temas> moduloToSort)
        //{
            
        //    List<Temas> temp = moduloToSort.ToList();

        //    temp.Sort((x, y) => string.Compare(x.Descripcion, y.Descripcion));

        //    foreach (Temas tema in temp)
        //    {
        //        this.SortSearch(tema.SubTemas);
        //    }

        //    ObservableCollection<Temas> result = new ObservableCollection<Temas>(temp);

        //    return result;
        //}
        


        /// <summary>
        /// Busca el tema padre del nodo actual dentro de la estructura existente
        /// </summary>
        /// <param name="temaHijo">Subtema</param>
        /// <param name="temaPadre">Tema que se esta buscando</param>
        private void SearchExistingParent(Temas temaHijo, Temas temaPadre)
        {
            foreach (Temas tema in temaPadre.SubTemas)
            {
                if (temaHijo.IDPadre == tema.IDTema)
                {
                    if (tema.SubTemas == null)
                        tema.SubTemas = new ObservableCollection<Temas>();
                    temaHijo.Parent = tema;
                    tema.SubTemas.Add(temaHijo);
                    temasEnLista.Add(temaHijo);
                }
                else
                {
                    this.SearchExistingParent(temaHijo, tema);
                }
            }
        }

        /// <summary>
        /// Busca el padre del nodo actual dentro de la base de datos y forma 
        /// la estrucutra que se adicionará a la ya existente
        /// </summary>
        /// <param name="temaHijo">Tema del cual se busca el padre</param>
        /// <param name="modulos">Estructura del arbol existente</param>
        private void SearchParent(Temas temaHijo, ObservableCollection<Temas> modulos)
        {
            Temas temaPadre = this.GetTemaByIdTema(temaHijo.IDPadre, temaHijo.Materia);
            temaPadre.SubTemas = new ObservableCollection<Temas>();
            temaHijo.Parent = temaPadre;
            temaPadre.SubTemas.Add(temaHijo);

            temasEnLista.Add(temaHijo);

            List<Temas> buscaExistaAbuelo = (from n in temasEnLista
                                             where n.IDTema == temaPadre.IDPadre && n.Materia == temaPadre.Materia
                                             select n).ToList();

            //if (temasEnLista.Contains(temaPadre.IDPadre))
            if (buscaExistaAbuelo != null && buscaExistaAbuelo.Count > 0 && temaPadre.IDPadre != 0)
            {
                foreach (Temas tematico in modulos)
                {
                    if (tematico.IDTema == temaPadre.IDPadre)
                    {
                        temaPadre.Parent = tematico;
                        tematico.SubTemas.Add(temaPadre);
                        temasEnLista.Add(temaPadre);

                        break;
                    }
                    //else
                    //{
                    //    this.SearchExistingParent(temaPadre, tematico);
                    //}
                    else
                        GetRecursiveParents(temaPadre, tematico.SubTemas);
                }
            }
            else if (temaPadre.IDPadre == 0)
            {
                modulos.Add(temaPadre);
                temasEnLista.Add(temaPadre);
            }
            else if (temaPadre.IDPadre == -1)
            {
                //Si tiene como padre menos uno no lo agrega porque quiere decir que fue eliminado
            }
            else
                this.SearchParent(temaPadre, modulos);
        }

        /// <summary>
        /// Busqueda top-down del padre del tema, es decir, busca verifica desde el nodo más general hacia el
        /// más particular buscando el nodo padre del tema activo
        /// </summary>
        /// <param name="tema"></param>
        /// <param name="subtemas"></param>
        private void GetRecursiveParents(Temas tema, ObservableCollection<Temas> subtemas)
        {
            foreach (Temas tematico in subtemas)
            {
                if (tematico.IDTema == tema.IDPadre)
                {
                    if (tematico.SubTemas == null)
                        tema.SubTemas = new ObservableCollection<Temas>();
                    tema.Parent = tematico;
                    tematico.SubTemas.Add(tema);
                    temasEnLista.Add(tema);
                    break;
                }
                else 
                    GetRecursiveParents(tema, tematico.SubTemas);
            }
        }

        private ObservableCollection<Temas> SetParents(ObservableCollection<Temas> modulos)
        {
            foreach (Temas tema in modulos)
            {
                foreach (Temas subtema in tema.SubTemas)
                {
                    subtema.Parent = tema;
                    this.SetParents(subtema.SubTemas);
                }
            }
            return modulos;
        }

        private Temas GetTemaByIdTema(int idTema, int mat)
        {
            SqlConnection sqlConne = this.GetConnection();

            Temas tema = new Temas();
            try
            {
                sqlConne.Open();

                string sqlCadena = "SELECT *, (SELECT COUNT(idTEma) FROM TemasTesis T WHERE T.idTema = Temas.Idtema and T.idMateria = Temas.Materia ) Total " +
                                   "FROM Temas WHERE  IdTema = @IdTema AND Materia = @Materia  ORDER BY DescripcionStr ";
                SqlCommand cmd = new SqlCommand(sqlCadena, sqlConne);
                SqlParameter idTemas = cmd.Parameters.Add("@IdTema", SqlDbType.Int, 0);
                idTemas.Value = idTema;
                SqlParameter materia = cmd.Parameters.Add("@Materia", SqlDbType.Int, 0);
                materia.Value = mat;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tema.Materia = Convert.ToInt32(reader["Materia"]);
                        tema.IDTema = Convert.ToInt32(reader["idTema"]);
                        tema.IDPadre = Convert.ToInt32(reader["IDPadre"]);
                        tema.Nivel = Convert.ToInt32(reader["Nivel"]);
                        tema.Descripcion = reader["Descripcion"].ToString();
                        tema.IdTemaOrigen = Convert.ToInt32(reader["IdTemaOrigen"]);
                        tema.TesisRelacionadas = Convert.ToInt32(reader["Total"]);
                    }
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show("Error ({0}) : {1}" + sql.Source + sql.Message, "Error Interno");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, "Error Interno");
            }
            finally
            {
                sqlConne.Close();
            }
            return tema;
        }

        private String ArmaCadenaBusqueda(String textoBuscado)
        {
            String[] listadoPalabras = textoBuscado.Split(' ');

            String resultString1 = "'%";
            foreach (string palabra in listadoPalabras)
            {
                if (!BusquedaUtilities.Stopers.Contains(palabra.Trim().ToLower()))
                    resultString1 += BusquedaUtilities.Normaliza(palabra.Trim()) + "%";
                //resultString += "OR DescripcionStr LIKE '%" + FlowDocumentHighlight.Normaliza( palabra.Trim() ) + "%' ";
            }
            resultString1 += "'";

            String resultString2 = "'%";
            foreach (string palabra in listadoPalabras.Reverse())
            {
                if (!BusquedaUtilities.Stopers.Contains(palabra.Trim().ToLower()))
                    resultString2 += BusquedaUtilities.Normaliza(palabra.Trim()) + "%";
                //resultString += "OR DescripcionStr LIKE '%" + FlowDocumentHighlight.Normaliza( palabra.Trim() ) + "%' ";
            }
            resultString2 += "'";

            return "DescripcionStr LIKE " + resultString1 + " OR DescripcionStr LIKE " + resultString2; 
        }

        private bool findParent = false;

        public void SearchParentAddSon(ObservableCollection<Temas> listaTemas, Temas temaHijo)
        {
            if (!findParent)
                foreach (Temas temaBuscado in listaTemas)
                {
                    if (temaBuscado.IDTema == temaHijo.Parent.IDTema)
                    {
                        temaBuscado.AddSubTema(temaHijo);
                        findParent = true;
                    }
                    else
                    {
                        this.SearchParentAddSon(temaBuscado.SubTemas, temaHijo);
                    }

                    if (findParent)
                        break;
                }
        }

        public void SearchParentDeleteSon(ObservableCollection<Temas> listaTemas, Temas temaHijo)
        {
            if (!findParent)
                foreach (Temas temaBuscado in listaTemas)
                {
                    if (temaBuscado.IDTema == temaHijo.Parent.IDTema)
                    {
                        temaBuscado.RemoveSubTema(temaHijo);
                        findParent = true;
                    }
                    else
                    {
                        this.SearchParentAddSon(temaBuscado.SubTemas, temaHijo);
                    }

                    if (findParent)
                        break;
                }
        }

        private SqlConnection GetConnection()
        {
            String bdStringSql = ConfigurationManager.ConnectionStrings["Tematicos"].ConnectionString;
            SqlConnection realConnection = new SqlConnection(bdStringSql);
            return realConnection;
        }
    }
}