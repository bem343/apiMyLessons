using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class tarefaAluno : banco
    {

        #region Propriedades
            public int codigo { get; set; }
            public bool entregue { get; set; }
            public string mencao { get; set; }
            public DateTime dtEntrega { get; set; }
            public DateTime hrEntrega { get; set; }
            public DateTime dtInicio { get; set; }
            public DateTime hrInicio { get; set; }
            public DateTime dtFim { get; set; }
            public DateTime hrFim { get; set; }
            public string devolucaoProfessor { get; set; }

            public tarefa tarefa { get; set; }
            public aluno aluno { get; set; }
        #endregion

        #region Construtores
            public tarefaAluno(tarefa tarefa, DateTime dtInicio, DateTime hrInicio, DateTime dtFim, DateTime hrFim) : base()
            {
                this.tarefa = tarefa;
                this.dtInicio = dtInicio;
                this.hrInicio = hrInicio;
                this.dtFim = dtFim;
                this.hrFim = hrFim;
            }
            public tarefaAluno(tarefa tarefa, DateTime dtEntrega, DateTime hrEntrega) : base()
            {
                this.tarefa = tarefa;
                this.dtEntrega = dtEntrega;
                this.hrEntrega = hrEntrega;
            }
            public tarefaAluno(tarefa tarefa, aluno aluno) : base()
            {
                this.tarefa = tarefa;
                this.aluno = aluno;
            }
        #endregion

        #region Entregar Tarefa A partir do rm do aluno e código da tarefa
            public bool entregar(int experiencia, int esmeralda)
            {
                string nomeSP = "EntregaTarefaAluno";
                string[,] parametros = new string[4, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = aluno.rm.ToString();
                parametros[1, 0] = "vTarefa";
                parametros[1, 1] = tarefa.codigo.ToString();
                parametros[2, 0] = "vXp";
                parametros[2, 1] = experiencia.ToString();
                parametros[3, 0] = "vEsmeralda";
                parametros[3, 1] = esmeralda.ToString();
                return Executar(nomeSP, parametros);
            }
        #endregion

        #region Busca os dados de uma tarefa de um aluno
            public bool dados()
            {
                MySqlDataReader dados = null;
                string nomeSP = "tarefaEspecificaAluno";
                string[,] parametros = new string[2, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = aluno.rm.ToString();
                parametros[1, 0] = "vTarefa";
                parametros[1, 1] = tarefa.codigo.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                tarefa.titulo = dados["nm_titulo_tarefa"].ToString();
                                tarefa.descricao = dados["ds_tarefa"].ToString();
                                tarefa.disciplina = new disciplina(dados["nm_disciplina"].ToString());

                                string dtInicio = dados["dt_inicio_tarefa"].ToString();
                                string hrInicio = dados["hr_inicio_tarefa"].ToString();
                                this.dtInicio = DateTime.Parse(dtInicio);
                                this.hrInicio = DateTime.Parse(hrInicio);

                                string dtFim = dados["dt_fim_tarefa"].ToString();
                                string hrFim = dados["hr_fim_tarefa"].ToString();
                                this.dtFim = DateTime.Parse(dtFim);
                                this.hrFim = DateTime.Parse(hrFim);

                                string dtEntrega = dados["dt_entrega"].ToString();
                                string hrEntrega = dados["hr_entrega"].ToString();
                                if (dtEntrega != "") { this.dtEntrega = DateTime.Parse(dtEntrega); }
                                if (hrEntrega != "") { this.hrEntrega = DateTime.Parse(hrEntrega); }

                                this.entregue = bool.Parse(dados["ic_entregue"].ToString());
                                this.mencao = dados["nm_mencao"].ToString();
                                this.devolucaoProfessor = dados["ds_devolutiva_tarefa"].ToString();
                            }
                            fechaDados(dados);
                            fechaConexao();
                            return true;
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return false;
            }
        #endregion

    }
}
