using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SendEmail.Models
{
    public class AvaliacaoViewModels
    {
        [Required]
        public int id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string nome { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string email { get; set; }

        public List<ConhecimentoModels> listaConhecimento = new List<ConhecimentoModels>();

        public AvaliacaoViewModels()
        {
            nome = string.Empty;
            email = string.Empty;

            listaConhecimento.Add(new ConhecimentoModels
            {
                nome = "HTML",
                descricao = "HTML",
                nota = 0,
                tipo = ConhecimentoModels.tipoCandidato.Front_End
            });
            listaConhecimento.Add(new ConhecimentoModels
            {
                nome = "CSS",
                descricao = "CSS",
                nota = 0,
                tipo = ConhecimentoModels.tipoCandidato.Front_End
            });
            listaConhecimento.Add(new ConhecimentoModels
            {
                nome = "Javascript",
                descricao = "Javascript",
                nota = 0,
                tipo = ConhecimentoModels.tipoCandidato.Front_End
            });
            listaConhecimento.Add(new ConhecimentoModels
            {
                nome = "Python",
                descricao = "Python",
                nota = 0,
                tipo = ConhecimentoModels.tipoCandidato.Back_End
            });
            listaConhecimento.Add(new ConhecimentoModels
            {
                nome = "Django",
                descricao = "Django",
                nota = 0,
                tipo = ConhecimentoModels.tipoCandidato.Back_End
            });
            listaConhecimento.Add(new ConhecimentoModels
            {
                nome = "IOS",
                descricao = "Desenvolvimento iOS",
                nota = 0,
                tipo = ConhecimentoModels.tipoCandidato.Mobile
            });
            listaConhecimento.Add(new ConhecimentoModels
            {
                nome = "Android",
                descricao = "Desenvolvimento Android",
                nota = 0,
                tipo = ConhecimentoModels.tipoCandidato.Mobile
            });
        }
    }
}