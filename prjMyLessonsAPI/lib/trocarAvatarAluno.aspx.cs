using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class trocarAvatarAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = "[]";

            #region Faz as requisições e valida-as
                Response.ContentType = "application/json";
                if (Request["rm"] == null | Request["cdAvatar"] == null)
                {
                    Response.Write(json);
                    return;
                }
                if (Request["rm"].ToString() == "" | Request["cdAvatar"].ToString() == "")
                {
                    Response.Write(json);
                    return;
                }
                string rm = Request["rm"].ToString();
                string cdAvatar = Request["cdAvatar"].ToString();
            #endregion

            #region Troca o avatar do aluno para o que foi selecionado
                aluno aluno = new aluno(int.Parse(rm));
                avatar avatar = new avatar(int.Parse(cdAvatar));
                avatarAluno avatarAluno = new avatarAluno(aluno, avatar, true);
                json = "[{'success':'" + avatarAluno.trocar() + "'}]";
                json = json.Replace("'", "\"");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Write(json);
                return;
            #endregion
        }
    }
}