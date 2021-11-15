using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class premioAluno : banco
    {

        #region Propriedades
            public bool retirado { get; set; }
            public DateTime dtRetirado { get; set; }
            public DateTime hrRetirado { get; set; }

            public aluno aluno { get; set; }
            public premio premio { get; set; }
        #endregion

        #region Construtores
            public premioAluno(premio premio, bool retirado, DateTime dtRetirado, DateTime hrRetirado)
            {
                this.premio = premio;
                this.retirado = retirado;
                this.dtRetirado = dtRetirado;
                this.hrRetirado = hrRetirado;
            }
            public premioAluno(premio premio, aluno aluno)
            {
                this.premio = premio;
                this.aluno = aluno;
            }
        #endregion

        #region Resgata o premio para um determinado aluno
            public bool resgatar()
            {
                string nomeSP = "inserirPremioAluno";
                string[,] parametros = new string[2, 2];
                parametros[0, 0] = "vRm";
                parametros[0, 1] = aluno.rm.ToString();
                parametros[1, 0] = "vPremio";
                parametros[1, 1] = premio.codigo.ToString();
                return Executar(nomeSP, parametros);
            }
        #endregion

        #region Busca os dados de um prêmio expecífico de um aluno
            public bool dados()
            {
                MySqlDataReader dados = null;
                string nomeSP = "buscarPremio";
                string[,] parametros = new string[2, 2];
                parametros[0, 0] = "vRm";
                parametros[0, 1] = aluno.rm.ToString();
                parametros[1, 0] = "vCd";
                parametros[1, 1] = premio.codigo.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {

                                premio.nome = dados["nm_premio_escolar"].ToString();
                                premio.descricao = dados["ds_premio_escolar"].ToString();
                                string sQtEsmeralda = dados["qt_esmeralda"].ToString();
                                string sQtPremio = dados["qt_premio_escolar"].ToString();
                                string sData = dados["data"].ToString();

                                string sRetirado = dados["ic_retirado"].ToString();
                                retirado = bool.Parse(sRetirado);

                                string sDtRetirada = dados["dt_retirada"].ToString();
                                string sHrRetirada = dados["hr_retirada"].ToString();
                                if (sDtRetirada != "") { dtRetirado = DateTime.Parse(sDtRetirada); }
                                if (sHrRetirada != "") { hrRetirado = DateTime.Parse(sHrRetirada); }

                                premio.qtEsmeralda = int.Parse(sQtEsmeralda);
                                premio.qtPremio = int.Parse(sQtPremio);
                                premio.dtFinal = DateTime.Parse(sData);

                            }
                            fechaDados(dados);
                            fechaConexao();
                            return true;
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return false;
            }
        #endregion

    }
}