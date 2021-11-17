using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class tipoTema
    {

        #region Propriedades
            public int codigo { get; set; }
            public string nome { get; set; }
        #endregion

        #region Construtores
            public tipoTema(int codigo)
            {
                this.codigo = codigo;
            }
            public tipoTema(int codigo, string nome)
            {
                this.codigo = codigo;
                this.nome = nome;
            }
        #endregion

    }
}