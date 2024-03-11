using System.Net;
using System.Net.Mail;
using App.v1.Models;

namespace App.v1.Services;

public class MailService
{
    public void Send(Mail mail)
    {
        var messager = new MailMessage();

        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("jorgedorio@alunos.utfpr.edu.br", "kjqrls34")
        };

        messager.From = new MailAddress("jorgedorio@alunos.utfpr.edu.br", mail.Subject);
        messager.Body = mail.Body;
        messager.Subject = mail.Subject;
        messager.IsBodyHtml = true;
        messager.Priority = MailPriority.Normal;
        messager.To.Add(mail.To);

        client.Send(messager);
    }
}