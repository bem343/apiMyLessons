using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class verificarAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = "[]";

            #region Faz as requisições e valida-as
                if (Request["R"] == null | Request["S"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["R"].ToString() == "" | Request["S"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string rm = Request["R"].ToString();
                string senha = Request["S"].ToString();
            #endregion

            #region Verifica se o aluno existe apartir do rm e senha
                aluno aluno = new aluno(int.Parse(rm), senha);
                if (aluno.verificarAluno())
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