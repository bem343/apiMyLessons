using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class conquista
    {

        #region Propriedades
            public int codigo { get; set; }
            public string nome { get; set; }
            public string descricao { get; set; }
            public int qtExperiencia { get; set; }
            public int qtObjetivo { get; set; }

            public tipoConquista tipoConquista { get; set; }
        #endregion

        #region Construtores
            public conquista(int codigo)
            {
                this.codigo = codigo;
            }
            public conquista(int codigo, int qtExperiencia, int qtObjetivo, tipoConquista tipoConquista)
            {
                this.codigo = codigo;
                this.qtExperiencia = qtExperiencia;
                this.qtObjetivo = qtObjetivo;
                this.tipoConquista = tipoConquista;
            }
        #endregion

    }
}