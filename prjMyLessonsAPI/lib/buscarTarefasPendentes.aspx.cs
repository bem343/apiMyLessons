using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarTarefasPendentes : System.Web.UI.Page
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
                listaTarefaAluno tarefas = new listaTarefaAluno(rm);
                json = "[ ";
                foreach (var item in tarefas.listar())
                {
                    json += "{'codigo':'" + item.tarefa.codigo + "', ";
                    json += "'titulo':'" + item.tarefa.titulo + "', ";
                    json += "'descricao':'" + item.tarefa.descricao + "', ";
                    json += "'dtInicio':'" + item.dtInicio.ToShortDateString() + "', ";
                    json += "'hrInicio':'" + formataHora(item.hrInicio) +"', ";
                    json += "'dtFim':'" + item.dtFim.ToShortDateString() + "', ";
                    json += "'hrFim':'" + formataHora(item.hrFim) + "'},";
                }
                json = json.Substring(0,json.Length-1);
                json = json.Replace("'", "\"");
                json += "]";
                Response.Write(json);
                return;
            #endregion
        }

        #region Formatação da hora
            private string formataHora(DateTime hora)
            {
                string h = hora.Hour.ToString();
                if (h.Length == 1) { h = "0" + h; }
                string m = hora.Minute.ToString();
                if (m.Length == 1) { m = "0" + m; }
                string s = hora.Second.ToString();
                if (s.Length == 1) { s = "0" + s; }
                return h + ":" + m + ":" + s;
            }
        #endregion

    }
}