using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class tema
    {

        #region Propriedades
            public int codigo { get; set; }
            public string nome { get; set; }
            public tipoTema tipo { get; set; }
        #endregion

        #region Construtores
            public tema(int codigo)
            {
                this.codigo = codigo;
            }
            public tema(int codigo, tipoTema tipo)
            {
                this.codigo = codigo;
                this.tipo = tipo;
            }
            public tema(int codigo, string nome)
            {
                this.codigo = codigo;
                this.nome = nome;
            }
        #endregion

    }
}