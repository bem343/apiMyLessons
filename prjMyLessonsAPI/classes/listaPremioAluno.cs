using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class listaPremioAluno : banco
    {

        private aluno aluno { get; set; }
        private List<premioAluno> premiosResgatados = new List<premioAluno>();

        #region Construtores
            public listaPremioAluno(aluno aluno) : base()
            {
                this.aluno = aluno;
            }
        #endregion

        #region Traz os premios resgatos pelo aluno
            public List<premioAluno> listarResgatados()
            {
                MySqlDataReader dados = null;
                string nomeSP = "buscarPremiosAluno";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = aluno.rm.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                string codigoPremio = dados["cd_premio_escolar"].ToString();
                                string nomePremio = dados["nm_premio_escolar"].ToString();
                                string descricaoPremio = dados["ds_premio_escolar"].ToString();
                                string retirado = dados["ic_retirado"].ToString();
                                string dtRetirada = dados["dt_retirada"].ToString();
                                string hrRetirada = dados["hr_retirada"].ToString();
                                //Convertendo para os devidos tipos
                                DateTime dDtRetirado = new DateTime();
                                DateTime dHrRetirado = new DateTime();
                                bool bRetirado = bool.Parse(retirado);
                                if (bRetirado)
                                {
                                    dDtRetirado = DateTime.Parse(dtRetirada);
                                    dHrRetirado = DateTime.Parse(hrRetirada);
                                }
                                int iCodigoPremio = int.Parse(codigoPremio);
                                premio premio = new premio(iCodigoPremio, nomePremio, descricaoPremio);
                                premioAluno premioAluno = new premioAluno(premio, bRetirado, dDtRetirado, dHrRetirado);
                                premiosResgatados.Add(premioAluno);
                            }
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return premiosResgatados;
            }
        #endregion

    }
}