using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarPremios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string json = "[]";
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            Response.ContentType = "application/json";

            #region Faz as requisições e valida-as
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
                int mesAtual = DateTime.Now.Month;
                listaPremio premios = new listaPremio(mesAtual);
                json = "[ ";

                foreach (var item in premios.listar(rm))
                {
                    json += "{'codigo':'" + item.codigo + "', ";
                    json += "'nome':'" + item.nome + "', ";
                    json += "'descricao':'" + item.descricao + "', ";
                    json += "'qtEsmeralda':'" + item.qtEsmeralda + "', ";
                    json += "'qtPremio':'" + item.qtPremio + "', ";
                    json += "'dtFinal':'" + item.dtFinal.ToShortDateString() + "'},";
                }
                json = json.Substring(0, json.Length - 1);
                json = json.Replace("'", "\"");
                json += "]";
                Response.Write(json);
                return;
            #endregion

        }
    }
}