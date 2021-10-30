using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class conquistaAluno : banco
    {

        #region Propriedades
            public aluno aluno { get; set; }
            public conquista conquista { get; set; }
        #endregion

        #region Construtores
            public conquistaAluno(aluno aluno, conquista conquista) : base()
            {
                this.aluno = aluno;
                this.conquista = conquista;
            }
        #endregion

        #region Insere uma conquista ao aluno
            public bool desbloquear()
            {
                string nomeSP = "InserirConquistasAluno";
                string[,] parametros = new string[2, 2];
                parametros[0, 0] = "vRm";
                parametros[0, 1] = aluno.rm.ToString();
                parametros[1, 0] = "vConquista";
                parametros[1, 1] = conquista.codigo.ToString();
                return Executar(nomeSP, parametros);
            }
        #endregion

    }
}