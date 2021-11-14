using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class trocarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string json = "[]";

            #region Faz as requisições e valida-as
                if (Request["rm"] == null | Request["senhaAtual"] == null | Request["novaSenha"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "" | Request["senhaAtual"].ToString() == "" | Request["novaSenha"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string rm = Request["rm"].ToString();
                string senhaAtual = Request["senhaAtual"].ToString();
                string novaSenha = Request["novaSenha"].ToString();
            #endregion

            #region Redefine a senha do aluno
                aluno aluno = new aluno(int.Parse(rm), senhaAtual);
                if (aluno.verificarAluno()) { json = "[{'success' : '" + aluno.redefinirSenha(novaSenha) + "'}]"; }
                else { json = "[{'success' : 'false'}]"; }
                json = json.Replace("'", "\"");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.ContentType = "application/json";
                Response.Write(json);
                return;
            #endregion

        }
    }
}