using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class premioAluno : banco
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
            public premioAluno(premio premio, aluno aluno)
            {
                this.premio = premio;
                this.aluno = aluno;
            }
        #endregion

        #region Resgata o premio para um determinado aluno
            public bool resgatar()
            {
                string nomeSP = "inserirPremioAluno";
                string[,] parametros = new string[2, 2];
                parametros[0, 0] = "vRm";
                parametros[0, 1] = aluno.rm.ToString();
                parametros[1, 0] = "vPremio";
                parametros[1, 1] = premio.codigo.ToString();
                return Executar(nomeSP, parametros);
            }
        #endregion

    }
}