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
            public string nome { get; set; }
            public raridade raridade { get; set; }
        #endregion

        #region Construtores
            public avatar(int codigo)
            {
                this.codigo = codigo;
            }
            public avatar(int codigo, string nome, raridade raridade)
            {
                this.codigo = codigo;
                this.nome = nome;
                this.raridade = raridade;
            }
        #endregion

    }
}