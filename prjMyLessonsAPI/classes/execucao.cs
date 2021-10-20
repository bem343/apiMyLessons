using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMyLessonsAPI.classes
{
    public static class execucao
    {
        private static string LinhaCodigo = "SERVER=localhost;UID=root;PASSWORD=;DATABASE=my_lessons";
        public static string GetConexao()
        {
            return LinhaCodigo;
        }
    }
}