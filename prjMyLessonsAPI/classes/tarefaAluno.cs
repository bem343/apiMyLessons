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
            public tarefaAluno(tarefa tarefa, DateTime dtInicio, DateTime hrInicio, DateTime dtFim, DateTime hrFim)
            {
                this.tarefa = tarefa;
                this.dtInicio = dtInicio;
                this.hrInicio = hrInicio;
                this.dtFim = dtFim;
                this.hrFim = hrFim;
            }
        #endregion

    }
}