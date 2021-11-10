using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class tarefa
    {

        #region Propriedades
            public int codigo { get; set; }
            public string titulo { get; set; }
            public string descricao { get; set; }
            public bool atribuida { get; set; }
            
            public professor professor { get; set; }
            public disciplina disciplina { get; set; }
        #endregion

        #region Construtores
            public tarefa(int codigo, string titulo, string descricao, disciplina disciplina)
            {
                this.codigo = codigo;
                this.titulo = titulo;
                this.descricao = descricao;
                this.disciplina = disciplina;
            }
            public tarefa(int codigo)
            {
                this.codigo = codigo;
            }
        #endregion

    }
}