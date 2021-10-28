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
            public string raridade { get; set; }
            public string nome { get; set; }
        #endregion

        #region Construtores
            public avatar(int codigo)
            {
                this.codigo = codigo;
            }
            public avatar(int codigo, string raridade, string nome)
            {
                this.codigo = codigo;
                this.raridade = raridade;
                this.nome = nome;
            }
        #endregion

    }
}