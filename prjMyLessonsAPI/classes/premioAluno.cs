using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public class premioAluno
    {

        #region Propriedades
            public bool retirado { get; set; }
            public DateTime dtRetirado { get; set; }
            public DateTime hrRetirado { get; set; }

            public aluno aluno { get; set; }
            public premio premio { get; set; }
        #endregion

        #region Construtores
            public premioAluno(premio premio, bool retirado, DateTime dtRetirado, DateTime hrRetirado)
            {
                this.premio = premio;
                this.retirado = retirado;
                this.dtRetirado = dtRetirado;
                this.hrRetirado = hrRetirado;
            }    
        #endregion

    }
}