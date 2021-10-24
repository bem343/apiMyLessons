using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class disciplina
    {

        #region Propriedades
            public int codigo { get; set; }
            public string nome { get; set; }
        #endregion

        #region Construtores
            public disciplina(int codigo)
            {
                this.codigo = codigo;
            }
        #endregion
    }
}