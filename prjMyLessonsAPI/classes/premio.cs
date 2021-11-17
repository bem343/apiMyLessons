using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class premio : banco
    {

        #region Propriedades
            public int codigo { get; set; }
            public string nome { get; set; }
            public int qtEsmeralda { get; set; }
            public int qtPremio { get; set; }
            public string descricao { get; set; }
            public DateTime dtFinal { get; set; }
        #endregion

        #region Construtores
            public premio(int codigo)
            {
                this.codigo = codigo;
            }
            public premio(int codigo, string nome, string descricao)
            {
                this.codigo = codigo;
                this.nome = nome;
                this.descricao = descricao;
            }
            public premio(int codigo, string nome, int qtEsmeralda, int qtPremio, string descricao, DateTime dtFinal)
            {
                this.codigo = codigo;
                this.nome = nome;
                this.qtEsmeralda = qtEsmeralda;
                this.qtPremio = qtPremio;
                this.descricao = descricao;
                this.dtFinal = dtFinal;
            }
        #endregion

        #region Busca os dados de um prêmio expecífico de um aluno
            public bool dados()
            {
                MySqlDataReader dados = null;
                string nomeSP = "buscarPremioEspecifico";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "vCd";
                parametros[0, 1] = codigo.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {

                                nome = dados["nm_premio_escolar"].ToString();
                                descricao = dados["ds_premio_escolar"].ToString();
                                string sQtEsmeralda = dados["qt_esmeralda"].ToString();
                                string sQtPremio = dados["qt_premio_escolar"].ToString();
                                string sData = dados["data"].ToString();
                                qtEsmeralda = int.Parse(sQtEsmeralda);
                                qtPremio = int.Parse(sQtPremio);
                                dtFinal = DateTime.Parse(sData);

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
