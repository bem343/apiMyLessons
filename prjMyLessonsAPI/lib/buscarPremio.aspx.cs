using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarPremio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string json = "[]";

            #region Faz as requisições e valida-as
                if (Request["rm"] == null | Request["cdPremio"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "" | Request["cdPremio"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string cdPremio = Request["cdPremio"].ToString();
                string rm = Request["rm"].ToString();
            #endregion

            #region Busca os dados de um premio expecífico
                aluno aluno = new aluno(int.Parse(rm));
                tarefa tarefa = new tarefa(int.Parse(cdPremio));
                tarefaAluno tarefaAluno = new tarefaAluno(tarefa, aluno);

                if (tarefaAluno.dados())
                {
                    json = "[";
                    json += "{'disciplina':'" + tarefaAluno.tarefa.disciplina.nome + "', ";
                    json += "'titulo':'" + tarefaAluno.tarefa.titulo + "', ";
                    json += "'descricao':'" + tarefaAluno.tarefa.descricao + "', ";
                    json += "'dtInicio':'" + tarefaAluno.dtInicio.ToShortDateString() + "', ";
                    json += "'hrInicio':'" + tarefaAluno.hrInicio.ToLongTimeString() + "', ";
                    json += "'dtFim':'" + tarefaAluno.dtFim.ToShortDateString() + "', ";
                    json += "'hrFim':'" + tarefaAluno.hrFim.ToLongTimeString() + "', ";
                    json += "'entregue':'" + tarefaAluno.entregue + "', ";
                    json += "'dtEntrega':'" + verificar.data(tarefaAluno.dtEntrega) + "', ";
                    json += "'hrEntrega':'" + verificar.hora(tarefaAluno.hrEntrega) + "', ";
                    json += "'mencao':'" + tarefaAluno.mencao + "', ";
                    json += "'devolucao':'" + tarefaAluno.devolucaoProfessor + "'}";
                    json += "]";
                }

                json = json.Replace("'", "\"");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.ContentType = "application/json";
                Response.Write(json);
                return;
            #endregion

        }

    }
}