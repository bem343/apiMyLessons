using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjMyLessonsAPI.classes
{
    public class premio
    {

        #region Propriedades
            public int codigo { get; set; }
            public string nome { get; set; }
            public int qtEsmeralda { get; set; }
            public int qtPremio { get; set; }
            public string descricao { get; set; }
            public DateTime dtFinal { get; set; }
        #endregion

        #region Construtores
            public premio(int codigo)
            {
                this.codigo = codigo;
            }
            public premio(int codigo, string nome, string descricao)
            {
                this.codigo = codigo;
                this.nome = nome;
                this.descricao = descricao;
            }
            public premio(int codigo, string nome, int qtEsmeralda, int qtPremio, string descricao, DateTime dtFinal)
            {
                this.codigo = codigo;
                this.nome = nome;
                this.qtEsmeralda = qtEsmeralda;
                this.qtPremio = qtPremio;
                this.descricao = descricao;
                this.dtFinal = dtFinal;
            }
        #endregion

    }
}
