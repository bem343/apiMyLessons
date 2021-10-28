using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarTarefasConcluidas : System.Web.UI.Page
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

            #region Busca as tarefas concluídas de um aluno apartir de seu rm
                aluno aluno = new aluno(int.Parse(rm));
                listaTarefaAluno tarefas = new listaTarefaAluno(aluno);
                json = "[ ";
                foreach (var item in tarefas.listarConcluidas())
                {
                    json += "{'codigo':'" + item.tarefa.codigo + "', ";
                    json += "'titulo':'" + item.tarefa.titulo + "', ";
                    json += "'descricao':'" + item.tarefa.descricao + "', ";
                    json += "'dtEntrega':'" + item.dtEntrega.ToShortDateString() + "', ";
                    json += "'hrEntrega':'" + formatacao.hrDuasCasas(item.hrEntrega) + "'},";
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