using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class redefinirSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = "[]";

            #region Faz as requisições e valida-as
                Response.ContentType = "application/json";
                if (Request["rm"] == null | Request["senha"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "" | Request["senha"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string rm = Request["rm"].ToString();
                string senha = Request["senha"].ToString();
            #endregion

            #region Redefine a senha do aluno
                aluno aluno = new aluno(int.Parse(rm), senha);
                if (aluno.redefinirSenha())
                {
                    json = "[{'bool' : '1'}]";
                }
                else
                {
                    json = "[{'bool' : '0'}]";
                }
                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion
        }
    }
}