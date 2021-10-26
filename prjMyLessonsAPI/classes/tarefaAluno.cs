using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                string[,] parametros = new string[2, 2];
                parametros[0, 0] = "VRm";
                parametros[0, 1] = aluno.rm.ToString();
                parametros[1, 0] = "vTarefa";
                parametros[1, 1] = tarefa.codigo.ToString();
                bool atualizacao = aluno.atualizarXpEsmeraldas(experiencia, esmeralda);
                bool entrega = Executar(nomeSP, parametros);
                if (atualizacao && entrega)
                {
                    return true;
                }
                return false;
            }
        #endregion

    }
}
