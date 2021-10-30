using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class tipoConquista
    {

        #region Propriedades
            public int codigo { get; set; }
            public string nome { get; set; }
        #endregion

        #region Construtores
            public tipoConquista(int codigo)
            {
                this.codigo = codigo;
            }
            public tipoConquista(int codigo, string nome)
            {
                this.codigo = codigo;
                this.nome = nome;
            }
        #endregion

    }
}