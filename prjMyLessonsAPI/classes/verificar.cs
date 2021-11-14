using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public static class verificar
    {

        private static string vazio = "01/01/0001 00:00:00";

        #region Verifica se uma data ficou vazia
            public static string data(DateTime DateTime)
            {
                if (DateTime.ToString() != vazio)
                    return DateTime.ToShortDateString();
                else
                    return "";
            }
        #endregion

        #region Verifica se uma hora ficou vazia
            public static string hora(DateTime DateTime)
            {
                if (DateTime.ToString() != vazio)
                    return DateTime.ToLongTimeString();
                else
                    return "";
            }
        #endregion

        #region Verifica se a conta vai ficar fazia, para então substituir por zero
            public static string porcentagem(double quebrado, int inteiro)
            {
                string porcentagem = ((quebrado - inteiro) * 100).ToString("##");
                if (porcentagem == "") { return "0"; }
                return porcentagem;
            }
        #endregion

    }
}