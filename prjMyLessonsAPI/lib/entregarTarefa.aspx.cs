using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class entregarTarefa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = "[]";

            #region Faz as requisições e valida-as
                Response.ContentType = "application/json";
                if (Request["rm"] == null | Request["cdTarefa"] == null | Request["exp"] == null | Request["esm"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "" | Request["cdTarefa"].ToString() == "" | Request["exp"].ToString() == "" | Request["esm"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string cdTarefa = Request["cdTarefa"].ToString();
                string rm = Request["rm"].ToString();
                string experiencia = Request["exp"].ToString();
                string esmeralda = Request["esm"].ToString();
            #endregion

            #region Entrega uma tarefa
                aluno aluno = new aluno(int.Parse(rm));
                tarefa tarefa = new tarefa(int.Parse(cdTarefa));
                tarefaAluno tarefaAluno = new tarefaAluno(tarefa, aluno);
                json = "[{'success' : '" + tarefaAluno.entregar(int.Parse(experiencia), int.Parse(esmeralda)).ToString() + "'}, ";
                json += "[ ";

                    //concatena com as conquista alcançadas
                    string conquistasDesbloqueadas = "";
                    int qtTarefasFeitas = new listaTarefaAluno(aluno).quantidadeTotal();
                    listaConquista conquistas = new listaConquista(new tipoConquista(1, "Tarefa"));
                    foreach (var item in conquistas.listarBloqueadas(rm))
                    {
                        if (qtTarefasFeitas >= item.qtObjetivo)
                        {
                            if (new conquistaAluno(aluno, item).desbloquear())
                            {
                                conquistasDesbloqueadas += "{'codigo':'" + item.codigo + "',";
                                conquistasDesbloqueadas += "'nome':'" + item.nome + "',";
                                conquistasDesbloqueadas += "'qtExperiencia':'" + item.qtExperiencia + "'},";
                            }
                        }
                    }

                if(conquistasDesbloqueadas != "")
                {
                    conquistasDesbloqueadas = conquistasDesbloqueadas.Substring(0, conquistasDesbloqueadas.Length - 1);
                }
                json += conquistasDesbloqueadas;
                json += "]]";
                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion
        }
    }
}
