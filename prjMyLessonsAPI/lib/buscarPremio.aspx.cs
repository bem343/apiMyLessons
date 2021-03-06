using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarPremio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string json = "[]";
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            Response.ContentType = "application/json";

            #region Faz as requisições e valida-as
                if (Request["rm"] == null | Request["cdPremio"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "" | Request["cdPremio"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string cdPremio = Request["cdPremio"].ToString();
            #endregion

            #region Busca os dados de um premio expecífico
                premio premio = new premio(int.Parse(cdPremio));

                if (premio.dados())
                {
                    json = "[";
                    json += "{'nome':'" + premio.nome + "', ";
                    json += "'descricao':'" + premio.descricao + "', ";
                    json += "'qtEsmeralda':'" + premio.qtEsmeralda + "', ";
                    json += "'qtPremio':'" + premio.qtPremio + "', ";
                    json += "'dtFinal':'" + premio.dtFinal.ToShortDateString() + "'}";
                    json += "]";
                }

                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion

        }
    }
}