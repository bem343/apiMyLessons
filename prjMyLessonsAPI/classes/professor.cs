using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class professor
    {

        #region Propriedades
            private string senha { get; set; }
            public string email { get; private set; }
            public int codigo { get; set; }
            public string nome { get; set; }
        #endregion

        #region Construtores
            public professor(int codigo)
            {
                this.codigo = codigo;
            }
        #endregion

    }
}