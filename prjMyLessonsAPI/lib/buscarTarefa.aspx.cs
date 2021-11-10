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
                    json += "'hrInicio':'" + formatacao.hrDuasCasas(tarefaAluno.hrInicio) + "', ";
                    json += "'dtFim':'" + tarefaAluno.dtFim.ToShortDateString() + "', ";
                    json += "'hrFim':'" + formatacao.hrDuasCasas(tarefaAluno.hrFim) + "', ";
                    json += "'entregue':'" + tarefaAluno.entregue + "', ";
                    json += "'dtEntrega':'" + verificaData(tarefaAluno.dtEntrega) + "', ";
                    json += "'hrEntrega':'" + verificaHora(tarefaAluno.hrEntrega) + "', ";
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

        #region Verifica se a data ou hora ficaram zeradas e transforma em 'nada' caso ocorra
            private string verificaData(DateTime DateTime)
            {
                if (DateTime.ToString() != "01/01/0001 00:00:00")
                    return DateTime.ToShortDateString();
                else
                    return "";
            }
            private string verificaHora(DateTime DateTime)
            {
                if (DateTime.ToString() != "01/01/0001 00:00:00")
                    return formatacao.hrDuasCasas(DateTime);
                else
                    return "";
            }
        #endregion

    }
}