﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarAvatares : System.Web.UI.Page
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

            #region Busca o xp e os avatares do aluno
                aluno aluno = new aluno(int.Parse(rm));
                if (aluno.pegaNivel())
                {
                    listaAvatar avatares = new listaAvatar(aluno);
                    json = "[";
                    json += "{'nivel':'" + aluno.nivel + "', ";
                    json += "'porcentagem':'" + fazPorcentagem(aluno.qtExperiencia, aluno.nivel) + "', ";
                    json += "'qtTotalAvatares':'" + avatares.quantidadeTotal() + "'}, ";
                    json += "[";
                    foreach (var item in avatares.doAluno())
                    {
                        json += "{'codigo':'" + item.avatar.codigo + "', ";
                        json += "'nome':'" + item.avatar.nome + "', ";
                        json += "'raridade':'" + item.avatar.raridade + "'},";
                    }
                    json = json.Substring(0, json.Length - 1);
                    json += "]";
                    json += "]";
                }
                json = json.Replace("'", "\"");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Write(json);
                return;
            #endregion
        }

        #region Verifica se a conta deu vai ficar fazia, para então substituir por zero
            private string fazPorcentagem(double quebrado, int inteiro)
            {
                string porcentagem = ((quebrado - inteiro) * 100).ToString("##");
                if(porcentagem == "")
                {
                    return "0";
                }
                return porcentagem;
            }
        #endregion
    }
}