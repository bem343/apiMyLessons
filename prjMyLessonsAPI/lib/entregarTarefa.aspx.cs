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
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            Response.ContentType = "application/json";

            #region Faz as requisições e valida-as
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
                int nivelAtual = 0;
                int nivelObtido = 0;
                aluno aluno = new aluno(int.Parse(rm));
                tarefa tarefa = new tarefa(int.Parse(cdTarefa));
                tarefaAluno tarefaAluno = new tarefaAluno(tarefa, aluno);
                if (aluno.pegaNivel()) { nivelAtual = aluno.nivel; }
                json = "[{'success' : '" + tarefaAluno.entregar(int.Parse(experiencia), int.Parse(esmeralda)).ToString() + "'}, ";

                    #region concatena com as conquista alcançadas
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
                        if (conquistasDesbloqueadas != "") { conquistasDesbloqueadas = conquistasDesbloqueadas.Substring(0, conquistasDesbloqueadas.Length - 1); }
                    #endregion

                    #region concatena com a experiencia
                        string textoNivel = "";
                        if (aluno.pegaNivel()) { nivelObtido = aluno.nivel; }
                        if(nivelAtual != nivelObtido)
                        {
                            int nivel = aluno.nivel;
                            textoNivel = "{'nivel':'" + nivel + "', 'porcentagem':'" + verificar.porcentagem(aluno.qtExperiencia, nivel) + "'}, ";

                            Random n = new Random();
                            switch (n.Next(2))
                            {
                                case 0:
                                    //Avatar
                                    listaAvatar avatares = new listaAvatar();
                                    List<avatar> sorteio = new List<avatar>();
                                    foreach (var item in avatares.todos())
                                    {
                                        int numeroDeVezes = (5 + ((item.raridade.codigo - 1) * -1));
                                        for (int i = 0; i < numeroDeVezes; i++)
                                        {
                                            sorteio.Add(item);
                                        }
                                    }
                                    int numero = n.Next(sorteio.Count);
                                    avatar escolhido = sorteio[numero];
                                    textoNivel += "{'tipo':'avatar', ";
                                    textoNivel += "'codigo':'" + escolhido.codigo + "', ";
                                    textoNivel += "'nome':'" + escolhido.nome + "', ";
                                    textoNivel += "'raridade':'" + escolhido.raridade.codigo + "', ";
                                    textoNivel += "'caminho':'http://localhost:58591/img/avatares/" + escolhido.codigo + ".jpg'}";
                                    break;
                                case 1:
                                    //Tema
                                    listaTema temas = new listaTema();
                                    List<tema> sorteioT = temas.todos();
                                    int Tnumero = n.Next(sorteioT.Count);
                                    tema Tescolhido = sorteioT[Tnumero];
                                    textoNivel += "{'tipo':'tema', ";
                                    textoNivel += "'codigo':'" + Tescolhido.codigo + "', ";
                                    textoNivel += "'nome':'" + Tescolhido.nome + "', ";
                                    textoNivel += "'raridade':'0', ";
                                    textoNivel += "'caminho':'http://localhost:58591/img/temas/" + Tescolhido.codigo + "/'}";
                                    break;
                            }

                        }
                        json += "[" + textoNivel + "], ";
                    #endregion

                json += "[" + conquistasDesbloqueadas + "]";
                json += "]";
                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion

        }

    }
}
