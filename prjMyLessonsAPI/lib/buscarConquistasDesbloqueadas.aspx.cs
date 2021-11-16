using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarConquistasDesbloqueadas : System.Web.UI.Page
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

            #region Busca todas as conqusitas desbloqueadas do aluno
                aluno aluno = new aluno(int.Parse(rm));
                listaConquistaAluno conquistas = new listaConquistaAluno(aluno);
                json = "[ ";
                foreach (var item in conquistas.listarDesbloqueadas())
                {
                    json += "{'codigo':'" + item.conquista.codigo + "', ";
                    json += "'nome':'" + item.conquista.nome + "', ";
                    json += "'descricao':'" + item.conquista.descricao + "', ";
                    json += "'qtExperiencia':'" + item.conquista.qtExperiencia + "', ";
                    json += "'qtObjetivo':'" + item.conquista.qtObjetivo + "', ";
                    json += "'tipo':'" + item.conquista.tipoConquista.codigo + "'},";
                }
                json = json.Substring(0, json.Length - 1);
                json = json.Replace("'", "\"");
                json += "]";
                Response.Write(json);
                return;
            #endregion

        }
    }
}