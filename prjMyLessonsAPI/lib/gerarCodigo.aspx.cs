using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class gerarCodigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string json = "[]";

            #region Faz as requisições e valida-as
                if (Request["R"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["R"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string rm = Request["R"].ToString();
            #endregion

            #region Pega o email e manda o código pra ele
                aluno aluno = new aluno(int.Parse(rm));
                if (aluno.pegaEmail())
                {
                    int codigo = new Random().Next(100000, 999999);
                    if(email.mandarCodigo(aluno.email, aluno.nome, codigo.ToString()))
                    {
                        json = "[{'codigo' : '" + codigo + "'}]";
                    }
                }
                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion
        }
    }
}