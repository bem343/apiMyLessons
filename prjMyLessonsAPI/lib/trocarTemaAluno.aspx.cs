using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class trocarTemaAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string json = "[]";
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            Response.ContentType = "application/json";

            #region Faz as requisições e valida-as
                if (Request["rm"] == null | Request["cdTema"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "" | Request["cdTema"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string rm = Request["rm"].ToString();
                string cdTema = Request["cdTema"].ToString();
            #endregion

            #region Troca o avatar do aluno para o que foi selecionado
                aluno aluno = new aluno(int.Parse(rm));
                tema tema = new tema(int.Parse(cdTema));
                temaAluno temaAluno = new temaAluno(aluno, tema, true);
                json = "[{'success':'" + temaAluno.trocar() + "'}]";
                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion

        }
    }
}