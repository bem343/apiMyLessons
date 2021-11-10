using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class raridade
    {

        #region Propriedades
            public int codigo { get; set; }
            public string nome { get; set; }
        #endregion

        #region Construtores
            public raridade(int codigo): base()
            {
                this.codigo = codigo;
            }
            public raridade(string nome): base()
            {
                this.nome = nome;
            }
            public raridade(int codigo, string nome) : base()
            {
                this.codigo = codigo;
                this.nome = nome;
            }
        #endregion
    }
}