using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class avatar
    {

        #region Propriedades
            public int codigo { get; set; }
            public int raridade { get; set; }
            public string nome { get; set; }
        #endregion

        #region Construtores
            public avatar(int codigo)
            {
                this.codigo = codigo;
            }
        #endregion

    }
}