using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjMyLessonsAPI.classes;

namespace prjMyLessonsAPI.lib
{
    public partial class buscarPremiosResgatados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = "[]";

            #region Faz as requisições e valida-as
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

            #region Busca os prêmios deste mês
                aluno aluno = new aluno(int.Parse(rm));
                listaPremioAluno premios = new listaPremioAluno(aluno);
                json = "[ ";
                foreach (var item in premios.listarResgatados())
                {
                    json += "{'codigo':'" + item.premio.codigo + "', ";
                    json += "'nome':'" + item.premio.nome + "', ";
                    json += "'descricao':'" + item.premio.descricao + "', ";
                    json += "'retirado':'" + item.retirado + "', ";
                    json += "'dtRetirado':'" + verificar.data(item.dtRetirado) + "', ";
                    json += "'hrRetirado':'" + verificar.hora(item.hrRetirado) + "'},";
                }
                json = json.Substring(0, json.Length - 1);
                json = json.Replace("'", "\"");
                json += "]";
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.ContentType = "application/json";
                Response.Write(json);
                return;
            #endregion
        }
    }
}