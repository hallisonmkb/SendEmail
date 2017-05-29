using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SendEmail;
using SendEmail.Controllers;
using SendEmail.Models;

namespace SendEmail.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Envio_de_Email_Generico_com_Avaliacao_Zerada()
        {
            // Arrange
            HomeController controller = new HomeController();
            bool emailGenerico = true;

            // Act
            ViewResult result = controller.Index() as ViewResult;
            foreach (var item in Enum.GetValues(typeof(ConhecimentoModels.tipoCandidato)))
            {
                ConhecimentoModels.tipoCandidato tipo = (ConhecimentoModels.tipoCandidato)item;

                if (HomeController.avaliacao.listaConhecimento
                    .Where(conhecimento => conhecimento.tipo == tipo && conhecimento.nota < 7)
                    .ToList().Count == 0)
                {
                    if (tipo != ConhecimentoModels.tipoCandidato.Generico)
                    {
                        emailGenerico = false;
                    }
                    else if (emailGenerico && tipo == ConhecimentoModels.tipoCandidato.Generico)
                    {
                        emailGenerico = true;
                    }
                }
            }

            // Assert
            Assert.IsTrue(emailGenerico);
        }
    }
}
