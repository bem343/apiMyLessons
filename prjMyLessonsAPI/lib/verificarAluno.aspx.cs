using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class verificarAluno : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            string json = "[]";
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            Response.ContentType = "application/json";

            #region Faz as requisições e valida-as
                if (Request["rm"] == null | Request["senha"] == null)
                {
                    Response.Write(json);
                    return;
                }

                if (Request["rm"].ToString() == "" | Request["senha"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }

                string rm = Request["rm"].ToString();
                string senha = Request["senha"].ToString();
            #endregion

            #region Verifica se o aluno existe apartir do rm e senha
                aluno aluno = new aluno(int.Parse(rm), senha);

                if (aluno.verificarAluno())
                {
                    if (aluno.dados())
                    {
                        json = "[";
                        json += "{'nome':'" + aluno.nome + "', ";
                        json += "'qtEsmeraldas':'" + aluno.qtEsmeraldas + "', ";

                        switch (aluno.temaSelecionado.tipo.codigo)
                        {
                            case 1:
                                json += "'tipoTema':'.jpg', ";
                                break;
                            case 2:
                                json += "'tipoTema':'.gif', ";
                                break;
                        }

                        json += "'tema':'http://localhost:58591/img/temas/" + aluno.temaSelecionado.codigo + "/', ";
                        json += "'avatar':'http://localhost:58591/img/avatares/" + aluno.avatarSelecionado.codigo + ".jpg'}";
                        json += "]";
                    }
                }

                json = json.Replace("'", "\"");
                Response.Write(json);
                return;
            #endregion

        }
    }
}