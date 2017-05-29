using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SendEmail.Models;
using System.Web.UI;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace SendEmail.Controllers
{
    public class HomeController : Controller
    {
        public static AvaliacaoViewModels avaliacao = new AvaliacaoViewModels();

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Index()
        {
            return View(avaliacao.listaConhecimento);
        }

        [HttpGet]
        public async Task<ActionResult> Submit()
        {
            if (Request.QueryString["inputEmail"] != null)
                avaliacao.email = Request.QueryString["inputEmail"];

            if (Request.QueryString["inputNome"] != null)
                avaliacao.nome = Request.QueryString["inputNome"];

            int nota;
            foreach (var item in avaliacao.listaConhecimento)
            {
                nota = 0;
                int.TryParse(Request.QueryString["hidden" + item.nome], out nota);
                item.nota = nota;
            }

            var body = "Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador {0}{1}entraremos em contato.";
            var message = new MailMessage();
            message.To.Add(new MailAddress(avaliacao.email));
            message.To.Add(new MailAddress("hallisonmkb@gmail.com"));
            message.From = new MailAddress("hallisonmkb@gmail.com");
            message.Subject = "Obrigado por se candidatar";
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "hallisonmkb@gmail.com",  
                    Password = "senha" //Configurar com a senha válida
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                bool emailGenerico = true;
                foreach (var item in Enum.GetValues(typeof(ConhecimentoModels.tipoCandidato)))
                {
                    ConhecimentoModels.tipoCandidato tipo = (ConhecimentoModels.tipoCandidato)item;

                    if (avaliacao.listaConhecimento
                        .Where(conhecimento => conhecimento.tipo == tipo && conhecimento.nota < 7)
                        .ToList().Count == 0)
                    {
                        if (tipo != ConhecimentoModels.tipoCandidato.Generico)
                        {
                            emailGenerico = false;
                            message.Body = string.Format(body, tipo.ToString().Replace("_", "-"), " ");
                            await smtp.SendMailAsync(message);
                        }
                        else if (emailGenerico && tipo == ConhecimentoModels.tipoCandidato.Generico)
                        {
                            message.Body = string.Format(body, "", "");
                            await smtp.SendMailAsync(message);
                        }
                    }
                }
            }

            return RedirectToAction("Sent");
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}