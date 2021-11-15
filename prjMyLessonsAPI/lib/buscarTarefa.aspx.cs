using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarTarefa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string json = "[]";
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            Response.ContentType = "application/json";

            #region Faz as requisições e valida-as
                if (Request["rm"] == null | Request["cdTarefa"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "" | Request["cdTarefa"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string rm = Request["rm"].ToString();
                string cdTarefa = Request["cdTarefa"].ToString();
            #endregion

            #region Busca os dados de uma tarefa expecífica de um aluno expecífico
                aluno aluno = new aluno(int.Parse(rm));
                tarefa tarefa = new tarefa(int.Parse(cdTarefa));
                tarefaAluno tarefaAluno = new tarefaAluno(tarefa, aluno);
                
                if(tarefaAluno.dados())
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
                Response.Write(json);
                return;
            #endregion

        }

    }
}