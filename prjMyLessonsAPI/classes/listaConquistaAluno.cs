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
                                int cdConquista = int.Parse(sCdConquista);
                                conquista conquista = new conquista(cdConquista);
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