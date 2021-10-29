using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarTemas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = "[]";

            #region Faz as requisições e valida-as
                Response.ContentType = "application/json";
                if (Request["rm"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string rm = Request["rm"].ToString();
            #endregion

            #region Busca o xp e os avatares do aluno
                aluno aluno = new aluno(int.Parse(rm));
                if (aluno.pegaNivel())
                {
                    listaTema temas = new listaTema(aluno);
                    json = "[";
                    json += "{'nivel':'" + aluno.nivel + "', ";
                    json += "'porcentagem':'" + fazPorcentagem(aluno.qtExperiencia, aluno.nivel) + "', ";
                    json += "'qtTotalTemas':'" + temas.quantidadeTotal() + "'}, ";
                    json += "[";
                    foreach (var item in temas.doAluno())
                    {
                        json += "{'codigo':'" + item.tema.codigo + "', ";
                        json += "'nome':'" + item.tema.nome + "'},";
                    }
                    json = json.Substring(0, json.Length - 1);
                    json += "]";
                    json += "]";
                }
                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion
        }

        #region Verifica se a conta deu vai ficar fazia, para então substituir por zero
            private string fazPorcentagem(double quebrado, int inteiro)
            {
                string porcentagem = ((quebrado - inteiro) * 100).ToString("##");
                if (porcentagem == "")
                {
                    return "0";
                }
                return porcentagem;
            }
        #endregion
    }
}