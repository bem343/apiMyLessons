using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarPremiosResgatados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = "[]";

            #region Faz as requisições e valida-as
                Response.ContentType = "application/json";
                if (Request["rm"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string rm = Request["rm"].ToString();
            #endregion

            #region Busca os prêmios deste mês
                aluno aluno = new aluno(int.Parse(rm));
                listaPremio premios = new listaPremio(aluno);
                json = "[ ";
                foreach (var item in premios.listarResgatados())
                {
                    json += "{'codigo':'" + item.premio.codigo + "', ";
                    json += "'nome':'" + item.premio.nome + "', ";
                    json += "'descricao':'" + item.premio.descricao + "', ";
                    json += "'retirado':'" + item.retirado + "', ";
                    json += "'dtRetirado':'" + verificaData(item.dtRetirado) + "', ";
                    json += "'hrRetirado':'" + verificaHora(item.hrRetirado) + "'},";
                }
                json = json.Substring(0, json.Length - 1);
                json = json.Replace("'", "\"");
                json += "]";
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Write(json);
                return;
            #endregion
        }

        #region Verifica se a data ou hora ficaram zeradas e transforma em 'nada' caso ocorra
            private string verificaData(DateTime DateTime)
            {
                if (DateTime.ToString() != "01/01/0001 00:00:00")
                    return DateTime.ToShortDateString();
                else
                    return "";
            }
            private string verificaHora(DateTime DateTime)
            {
                if (DateTime.ToString() != "01/01/0001 00:00:00")
                    return formatacao.hrDuasCasas(DateTime);
                else
                    return "";
            }
        #endregion
    }
}