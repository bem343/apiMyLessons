using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class temaAluno
    {

        #region Propriedades
            public bool selecionado { get; set; }
            public aluno aluno { get; set; }
            public tema tema { get; set; }
        #endregion

        #region Construtores
            public temaAluno(aluno aluno, tema tema, bool selecionado)
            {
                this.selecionado = selecionado;
                this.aluno = aluno;
                this.tema = tema;
            }
        #endregion

    }
}