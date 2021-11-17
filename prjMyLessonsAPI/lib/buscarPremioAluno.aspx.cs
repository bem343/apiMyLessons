using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarPremio : System.Web.UI.Page
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
                string rm = Request["rm"].ToString();
            #endregion

            #region Busca os dados de um premio expecífico
                aluno aluno = new aluno(int.Parse(rm));
                premio premio = new premio(int.Parse(cdPremio));
                premioAluno premioAluno = new premioAluno(premio, aluno);

                if (premioAluno.dados())
                {
                    json = "[";
                    json += "{'nome':'" + premioAluno.premio.nome + "', ";
                    json += "'descricao':'" + premioAluno.premio.descricao + "', ";
                    json += "'qtEsmeralda':'" + premioAluno.premio.qtEsmeralda + "', ";
                    json += "'qtPremio':'" + premioAluno.premio.qtPremio + "', ";
                    json += "'dtFinal':'" + premioAluno.premio.dtFinal.ToShortDateString() + "', ";
                    json += "'retirado':'" + premioAluno.retirado + "', ";
                    json += "'dtRetirado':'" + verificar.data(premioAluno.dtRetirado) + "', ";
                    json += "'hrRetirado':'" + verificar.hora(premioAluno.hrRetirado) + "'}";
                    json += "]";
                }

                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion

        }

    }
}