using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class temaAluno : banco
    {

        #region Propriedades
            public bool selecionado { get; set; }
            public aluno aluno { get; set; }
            public tema tema { get; set; }
        #endregion

        #region Construtores
            public temaAluno(aluno aluno, tema tema, bool selecionado) : base()
            {
                this.selecionado = selecionado;
                this.aluno = aluno;
                this.tema = tema;
            }
        #endregion

        #region Troca o avatar selecionado
            public bool trocar()
            {
                string nomeSP = "TrocarTemaAluno";
                string[,] parametros = new string[2, 2];
                parametros[0, 0] = "vRm";
                parametros[0, 1] = aluno.rm.ToString();
                parametros[1, 0] = "vTema";
                parametros[1, 1] = tema.codigo.ToString();
                return Executar(nomeSP, parametros);
            }
        #endregion

    }
}