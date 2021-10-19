using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace prjMyLessonsAPI.classes
{
    //email.mandarCodigo(aluno.email, aluno.nome, codigo.ToString())
    public static class email
    {

        public static string remetente = "mylessonstcc@gmail.com";
        public static string senha = "h&*6@G7gy7d8he92o2fj";

        public static bool mandarCodigo( string destinatario, string nome, string codigo )
        {
            MailMessage mensagem = new MailMessage(
                new MailAddress(remetente, "MyLessons", Encoding.GetEncoding("UTF-8")),
                new MailAddress(destinatario)
            );
            mensagem.Subject = "Mylessons - redefinição de senha";
            mensagem.IsBodyHtml = true;
            mensagem.Body = "<p>Olá " + nome + ", seu código é: <b>" + codigo + "</b></p>";
            mensagem.SubjectEncoding = Encoding.GetEncoding("UTF-8");
            mensagem.BodyEncoding = Encoding.GetEncoding("UTF-8");

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;

            //COLOCAR A SENHA QUANDO FOR TESTAR
            smtpClient.Credentials = new NetworkCredential(remetente, senha);
            smtpClient.EnableSsl = true;
            try { smtpClient.Send(mensagem); } catch { return false; } 
            return true;
            
        }
    }
}