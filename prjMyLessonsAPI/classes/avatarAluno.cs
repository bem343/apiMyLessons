using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class avatarAluno : banco
    {

        #region Propriedades
            public bool selecionado { get; set; }
            public aluno aluno { get; set; }
            public avatar avatar { get; set; }
        #endregion

        #region Construtores
            public avatarAluno(aluno aluno, avatar avatar, bool selecionado) : base()
            {
                this.selecionado = selecionado;
                this.aluno = aluno;
                this.avatar = avatar;
            }
        #endregion

        #region Troca o avatar selecionado
            public bool trocar()
            {
                string nomeSP = "TrocarAvatarAluno";
                string[,] parametros = new string[2,2];
                parametros[0, 0] = "vRm";
                parametros[0, 1] = aluno.rm.ToString();
                parametros[1, 0] = "vAvatar";
                parametros[1, 1] = avatar.codigo.ToString();
                return Executar(nomeSP, parametros);
            }
        #endregion

    }
}