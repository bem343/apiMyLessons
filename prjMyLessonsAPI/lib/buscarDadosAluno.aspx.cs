﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarDadosAluno : System.Web.UI.Page
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

            #region Busca os dados do aluno
                aluno aluno = new aluno(int.Parse(rm));
                if (aluno.dados())
                {
                    json = "[";
                    json += "{'nome':'" + aluno.nome + "', ";
                    json += "'qtEsmeraldas':'" + aluno.qtEsmeraldas + "', ";
                    json += "'tema':'" + aluno.temaSelecionado.codigo + "', ";
                    json += "'avatar':'" + aluno.avatarSelecionado.codigo + "'}";
                    json += "]";
                }
                json = json.Replace("'", "\"");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Write(json);
                return;
            #endregion
        }
    }
}