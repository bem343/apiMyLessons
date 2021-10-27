using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class resgatarPremio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = "[]";

            #region Faz as requisições e valida-as
                Response.ContentType = "application/json";
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

            #region Resgata um premio
                aluno aluno = new aluno(int.Parse(rm));
                premio premio = new premio(int.Parse(cdPremio));
                premioAluno premioAluno = new premioAluno(premio, aluno);
                json = "[{'success' : '" + premioAluno.resgatar().ToString() + "'}]";   
                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion
        }
    }
}