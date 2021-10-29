using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class listaTema : banco
    {

        private aluno aluno { get; set; }
        private List<temaAluno> temas = new List<temaAluno>();

        #region Construtores
            public listaTema(aluno aluno) : base()
            {
                this.aluno = aluno;
            }
        #endregion

        #region Traz o número total de temas
            public int quantidadeTotal()
            {
                int quantidade = 0;
                MySqlDataReader dados = null;
                string nomeSP = "BuscalTotalTema";
                string[,] parametros = new string[0, 0];
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                string sQuantidade = dados["quantidade"].ToString();
                                quantidade = int.Parse(sQuantidade);
                            }
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return quantidade;
            }
        #endregion

        #region Traz os temas do aluno
            public List<temaAluno> doAluno()
            {
                MySqlDataReader dados = null;
                string nomeSP = "BuscalTemaAluno";
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
                                string sCodigoTema = dados["cd_tema"].ToString();
                                string sNomeTema = dados["nm_tema"].ToString();
                                string sSelecionado = dados["ic_selecionado"].ToString();
                                int codigoTema = int.Parse(sCodigoTema);
                                bool selecionado = bool.Parse(sSelecionado);
                                tema tema = new tema(codigoTema, sNomeTema);
                                temaAluno temaAluno = new temaAluno(aluno, tema, selecionado);
                                temas.Add(temaAluno);
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