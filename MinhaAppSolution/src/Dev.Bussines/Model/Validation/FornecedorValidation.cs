using FluentValidation;
using MinhaAp.Busines.Models;

namespace Dev.Bussines.Model.Validation
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(x => x.Nome)
                .
        }
    }
}
