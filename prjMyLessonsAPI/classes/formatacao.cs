using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public static class formatacao
    {

        #region Formatação da hora
            public static string hrDuasCasas(DateTime hora)
            {
                string h = hora.Hour.ToString();
                if (h.Length == 1) { h = "0" + h; }
                string m = hora.Minute.ToString();
                if (m.Length == 1) { m = "0" + m; }
                string s = hora.Second.ToString();
                if (s.Length == 1) { s = "0" + s; }
                return h + ":" + m + ":" + s;
            }
        #endregion

    }
}