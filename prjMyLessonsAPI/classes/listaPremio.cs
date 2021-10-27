using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    class listaPremio : banco
    {

        private string rm = "";
        private int mesAtual = 0;
        private List<premio> premios = new List<premio>();
        private List<premioAluno> premiosResgatados = new List<premioAluno>();

        #region Construtores
            public listaPremio(int mesAtual) : base()
            {
                this.mesAtual = mesAtual;
            }
            public listaPremio(string rm) : base()
            {
                this.rm = rm;
            }
        #endregion

        #region Traz os premios do mês atual
            public List<premio> listar()
            {
                MySqlDataReader dados = null;
                string nomeSP = "buscarPremios";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "vMes";
                parametros[0, 1] = mesAtual.ToString();
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
                                string qtEsmeralda = dados["qt_esmeralda"].ToString();
                                string qtPremio = dados["qt_premio_escolar"].ToString();
                                string descricaoPremio = dados["ds_premio_escolar"].ToString();
                                string data = dados["data"].ToString();
                                //Convertendo para os devidos tipos
                                DateTime dData = DateTime.Parse(data);
                                int iCodigoPremio = int.Parse(codigoPremio);
                                int iQtEsmeralda = int.Parse(qtEsmeralda);
                                int iQtPremio = int.Parse(qtPremio);
                                premio premio = new premio(iCodigoPremio, nomePremio, iQtEsmeralda, iQtPremio , descricaoPremio, dData);
                                premios.Add(premio);
                            }
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return premios;
            }
        #endregion

        #region Traz os premios resgatos pelo aluno
            public List<premioAluno> listarResgatados()
            {
                MySqlDataReader dados = null;
                string nomeSP = "buscarPremiosAluno";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = rm;
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
