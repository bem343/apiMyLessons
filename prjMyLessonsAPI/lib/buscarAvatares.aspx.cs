using System;
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

            #region Busca o xp e os avatares do aluno
                aluno aluno = new aluno(int.Parse(rm));
                if (aluno.pegaNivel())
                {
                    listaAvatarAluno avatares = new listaAvatarAluno(aluno);
                    json = "[";
                    json += "{'nivel':'" + aluno.nivel + "', ";
                    json += "'porcentagem':'" + verificar.porcentagem(aluno.qtExperiencia, aluno.nivel) + "', ";
                    json += "'qtTotalAvatares':'" + avatares.quantidadeTotal() + "'}, ";
                    json += "[";
                    foreach (var item in avatares.doAluno())
                    {
                        json += "{'codigo':'" + item.avatar.codigo + "', ";
                        json += "'nome':'" + item.avatar.nome + "', ";
                        json += "'raridade':'" + item.avatar.raridade.nome + "',";
                        json += "'caminho':'http://localhost:58591/img/avatares/" + item.avatar.codigo + ".jpg'},";
                    }
                    json = json.Substring(0, json.Length - 1);
                    json += "]";
                    json += "]";
                }
                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion
        }

    }
}