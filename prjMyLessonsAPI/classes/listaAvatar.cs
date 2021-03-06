using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjMyLessonsAPI.classes
{
    public class listaAvatar : banco
    {

        #region Propriedades
            private List<avatar> avatares = new List<avatar>();
        #endregion

        #region Construtores
        public listaAvatar() : base()
            {

            }
        #endregion

        #region Traz os avatares do banco
            public List<avatar> todos()
            {
                MySqlDataReader dados = null;
                string nomeSP = "BuscarAvatares";
                string[,] parametros = new string[0, 0];
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
                                string sCodigoRaridade = dados["cd_raridade"].ToString();
                                int codigoAvatar = int.Parse(sCodigoAvatar);
                                int codigoRaridade = int.Parse(sCodigoRaridade);
                                raridade raridade = new raridade(codigoRaridade);
                                avatar avatar = new avatar(codigoAvatar, sNomeAvatar, raridade);
                                avatares.Add(avatar);
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