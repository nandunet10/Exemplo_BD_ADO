using APIBancoDeDados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace APIBancoDeDados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        [HttpPost()]
        public void Post([FromQuery] string emailDestino, string assunto, string conteudo)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("turma@devpratica.com.br");

            mail.To.Add(emailDestino);

            mail.Subject = assunto;
            mail.Body = conteudo;

            SmtpClient client = new SmtpClient("smtp.kinghost.net");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("turma1@devpratica.com.br", "Turma1@1");

            client.Send(mail);
        }

        [HttpPost("SegundoDisparo")]
        public void Post([FromBody] EmailModel emailModel)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("turma@devpratica.com.br");
            foreach (var item in emailModel.EmailDestino)
            {
                mail.To.Add(item);
            }
            mail.Subject = emailModel.Assunto;
            mail.Body = emailModel.Conteudo;

            SmtpClient client = new SmtpClient("smtp.kinghost.net");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("turma1@devpratica.com.br", "Turma1@1");

            client.Send(mail);
        }
    }
}
