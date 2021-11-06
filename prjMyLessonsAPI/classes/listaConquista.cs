using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class listaConquista : banco
    {

        private tipoConquista tipo { get; set; }
        private List<conquista> conquistas = new List<conquista>();

        #region Construtores
            public listaConquista(tipoConquista tipo) : base()
            {
                this.tipo = tipo;
            }
        #endregion

        #region Traz todas as conquistas
            public List<conquista> listarBloqueadas(string rm)
            {
                MySqlDataReader dados = null;
                string nomeSP = "buscarConquistas";
                string[,] parametros = new string[2, 2];
                parametros [0, 0] = "vRm";
                parametros [0, 1] = rm.ToString();
                parametros [1, 0] = "vTipo";
                parametros [1, 1] = tipo.codigo.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                string sCdConquista = dados["cd_conquista"].ToString();
                                string dsConquista = dados["ds_conquista"].ToString();
                                string nmConquista = dados["nm_conquista"].ToString();
                                string sQtExperiencia = dados["qt_experiencia"].ToString();
                                string sQtObjetivo = dados["qt_objetivo_conquista"].ToString();
                                int cdConquista = int.Parse(sCdConquista);
                                int qtExperiencia = int.Parse(sQtExperiencia);
                                int qtObjetivo = int.Parse(sQtObjetivo);
                                conquista conquista = new conquista(cdConquista, nmConquista, dsConquista, qtExperiencia, qtObjetivo, tipo);
                                conquistas.Add(conquista);
                            }
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return conquistas;
            }
        #endregion

    }
}