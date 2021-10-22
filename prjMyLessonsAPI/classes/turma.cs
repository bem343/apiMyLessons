using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class turma
    {

        #region Propriedades
            public string sigla { get; set; }
            public int ano { get; set; }
        #endregion

        #region Construtores
            public turma(string sigla, int ano)
            {
                this.sigla = sigla;
                this.ano = ano;
            }
        #endregion

    }
}