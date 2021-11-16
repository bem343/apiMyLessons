using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarConquistas : System.Web.UI.Page
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

            #region Busca todas as conqusitas bloqueadas do aluno
                listaConquista conquistas = new listaConquista();
                json = "[ ";
                foreach (var item in conquistas.listarTodasBloqueadas(rm))
                {
                    json += "{'codigo':'" + item.codigo + "', ";
                    json += "'nome':'" + item.nome + "', ";
                    json += "'descricao':'" + item.descricao + "', ";
                    json += "'qtExperiencia':'" + item.qtExperiencia + "', ";
                    json += "'qtObjetivo':'" + item.qtObjetivo + "', ";
                    json += "'tipo':'" + item.tipoConquista.codigo + "'},";
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