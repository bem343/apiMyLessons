using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class listaAvatar : banco
    {

        private aluno aluno { get; set; }
        private List<avatarAluno> avatares = new List<avatarAluno>();

        #region Construtores
            public listaAvatar(aluno aluno) : base()
            {
                this.aluno = aluno;
            }
        #endregion

        #region Traz os avatares do aluno
            public List<avatarAluno> doAluno()
            {
                MySqlDataReader dados = null;
                string nomeSP = "BuscalAvatarAluno";
                string[,] parametros = new string[1, 2];
                parametros[0, 0] = "vRm";
                parametros[0, 1] = aluno.rm.ToString();
                if (Selecionar(nomeSP, parametros, ref dados))
                {
                    if (dados != null)
                    {
                        if (dados.HasRows)
                        {
                            while (dados.Read())
                            {
                                string sCodigoAvatar = dados["cd_avatar"].ToString();
                                string sNomeAvatar = dados["nm_avatar"].ToString();
                                string sRaridadeAvatar = dados["nm_raridade"].ToString();
                                string sSelecionado = dados["ic_selecionado"].ToString();
                                int codigoAvatar = int.Parse(sCodigoAvatar);
                                bool selecionado = bool.Parse(sSelecionado);
                                avatar avatar = new avatar(codigoAvatar, sRaridadeAvatar, sNomeAvatar);
                                avatarAluno avatarAluno = new avatarAluno(aluno, avatar, selecionado);
                                avatares.Add(avatarAluno);
                            }
                        }
                    }
                }
                fechaDados(dados);
                fechaConexao();
                return avatares;
            }
        #endregion

    }
}