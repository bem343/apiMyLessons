using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class listaTarefaAluno : banco
    {

        private aluno aluno { get; set; }
        private List<tarefaAluno> tarefas = new List<tarefaAluno>();

        #region Construtores
            public listaTarefaAluno(aluno aluno) : base()
            {
                this.aluno = aluno;
            }
        #endregion

        #region Traz as tarefas Pendentes do aluno
            public List<tarefaAluno> listarPendentes()
            {
                MySqlDataReader dados = null;
                string nomeSP = "tarefasPendentesAluno";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = aluno.rm.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                string codigoTarefa = dados["cd_tarefa"].ToString();
                                string titulo = dados["nm_titulo_tarefa"].ToString();
                                string descricao = dados["ds_tarefa"].ToString();
                                string nmDisciplina = dados["nm_disciplina"].ToString();
                                disciplina disciplina = new disciplina(nmDisciplina);
                                tarefa tarefa = new tarefa(int.Parse(codigoTarefa), titulo, descricao, disciplina);

                                string dtInicio = dados["dt_inicio_tarefa"].ToString();
                                string hrInicio = dados["hr_inicio_tarefa"].ToString();
                                string dtFim = dados["dt_fim_tarefa"].ToString();
                                string hrFim = dados["hr_fim_tarefa"].ToString();
                                DateTime dtI = DateTime.Parse(dtInicio);
                                DateTime hrI = DateTime.Parse(hrInicio);
                                DateTime dtF = DateTime.Parse(dtFim);
                                DateTime hrF = DateTime.Parse(hrFim);

                                TimeSpan d = dtF - DateTime.Today;
                                TimeSpan t = hrF - DateTime.Now;
                                if (!atrazou(d, t))
                                {
                                    tarefaAluno tarefaAluno = new tarefaAluno(tarefa, dtI, hrI, dtF, hrF);
                                    tarefas.Add(tarefaAluno);
                                }
                            }
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return tarefas;
            }
        #endregion

        #region Traz as tarefas Concluídas do aluno
            public List<tarefaAluno> listarConcluidas()
            {
                MySqlDataReader dados = null;
                string nomeSP = "tarefasConcluidasAluno";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = aluno.rm.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                string codigoTarefa = dados["cd_tarefa"].ToString();
                                string titulo = dados["nm_titulo_tarefa"].ToString();
                                string descricao = dados["ds_tarefa"].ToString();
                                string nmDisciplina = dados["nm_disciplina"].ToString();
                                disciplina disciplina = new disciplina(nmDisciplina);
                                tarefa tarefa = new tarefa(int.Parse(codigoTarefa), titulo, descricao, disciplina);

                                string dtEntrega = dados["dt_entrega"].ToString();
                                string hrEntrega = dados["hr_entrega"].ToString();
                                DateTime dtE = DateTime.Parse(dtEntrega);
                                DateTime hrE = DateTime.Parse(hrEntrega);
                                tarefaAluno tarefaAluno = new tarefaAluno(tarefa, dtE, hrE);
                                tarefas.Add(tarefaAluno);
                            }
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return tarefas;
            }
        #endregion

        #region Traz o número de tarefas feitas pelo aluno
            public int quantidadeTotal()
            {
                int quantidade = 0;
                MySqlDataReader dados = null;
                string nomeSP = "QuantidadeTarefasFeitas";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "vRm";
                parametros[0, 1] = aluno.rm.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                string sQuantidade = dados["quantidade"].ToString();
                                quantidade = int.Parse(sQuantidade);
                            }
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return quantidade;
            }
        #endregion

        #region Verifica se houve atrazo naquela tarefa
            private bool atrazou(TimeSpan d, TimeSpan t)
            {
                if (d.Days > 0) { return false; }
                if (d.Days < 0) { return true; }
                return desempate(t);
            }
        #endregion

        #region Desempata nas horas, minutos e segundos
            private bool desempate(TimeSpan t)
            {
                if (t.Hours > 0) { return false; }
                if (t.Hours < 0) { return true; }
                if (t.Minutes > 0) { return false; }
                if (t.Minutes < 0) { return true; }
                if (t.Seconds > 0) { return false; }
                else { return true; }
            }
        #endregion

    }
}