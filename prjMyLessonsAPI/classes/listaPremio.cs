using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    class listaPremio : banco
    {

        private int mesAtual { get; set; }
        private List<premio> premios = new List<premio>();

        #region Construtores
            public listaPremio(int mesAtual) : base()
            {
                this.mesAtual = mesAtual;
            }
        #endregion

        #region Traz os premios do mês atual
            public List<premio> listar(string rm)
            {
                MySqlDataReader dados = null;
                string nomeSP = "buscarPremios";
                string[,] parametros = new string[2, 2];
                parametros[0, 0] = "vMes";
                parametros[0, 1] = mesAtual.ToString();
                parametros[1, 0] = "vRm";
                parametros[1, 1] = rm;
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

    }
}
