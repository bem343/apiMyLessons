using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class listaTema : banco
    {

        #region Propriedades
            private List<tema> temas = new List<tema>();
        #endregion

        #region Construtores
        public listaTema() : base()
            {

            }
        #endregion

        #region Traz os temas do banco
            public List<tema> todos()
            {
                MySqlDataReader dados = null;
                string nomeSP = "BuscarTemas";
                string[,] parametros = new string[0, 0];
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                string sCodigoTema = dados["cd_tema"].ToString();
                                string sNomeTema = dados["nm_tema"].ToString();
                                int codigoTema = int.Parse(sCodigoTema);
                                tema tema = new tema(codigoTema, sNomeTema);
                                temas.Add(tema);
                            }
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return temas;
            }
            #endregion

    }
}