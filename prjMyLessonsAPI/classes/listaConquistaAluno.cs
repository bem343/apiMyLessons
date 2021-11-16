using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class listaConquistaAluno : banco
    {

        private aluno aluno { get; set; }
        private List<conquistaAluno> conquistas = new List<conquistaAluno>();

        #region Construtores
            public listaConquistaAluno(aluno aluno) : base()
            {
                this.aluno = aluno;
            }
        #endregion

        #region Traz as conquistas desbloqueadas do aluno
            public List<conquistaAluno> listarDesbloqueadas()
            {
                MySqlDataReader dados = null;
                string nomeSP = "buscarConquistasAluno";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "vRm";
                parametros[0, 1] = aluno.rm.ToString();
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
                                string sCdTipo = dados["cd_tipo_conquista"].ToString();
                                int cdConquista = int.Parse(sCdConquista);
                                int qtExperiencia = int.Parse(sQtExperiencia);
                                int qtObjetivo = int.Parse(sQtObjetivo);
                                int tipo = int.Parse(sCdTipo);
                                conquista conquista = new conquista(cdConquista, nmConquista, dsConquista, qtExperiencia, qtObjetivo, new tipoConquista(tipo));
                                conquistaAluno conquistaAluno = new conquistaAluno(aluno, conquista);
                                conquistas.Add(conquistaAluno);
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