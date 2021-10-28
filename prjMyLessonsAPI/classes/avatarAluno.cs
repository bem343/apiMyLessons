using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class avatarAluno
    {

        #region Propriedades
            public bool selecionado { get; set; }
            public aluno aluno { get; set; }
            public avatar avatar { get; set; }
        #endregion

        #region Construtores
            public avatarAluno(aluno aluno, avatar avatar, bool selecionado)
            {
                this.selecionado = selecionado;
                this.aluno = aluno;
                this.avatar = avatar;
            }
        #endregion

    }
}