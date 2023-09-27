using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.AccountTypes.Queries
{
    public class GetAccountTypeByIdQuery : IRequest<AccountType>
    {
        public int Id { get; set; }
        public GetAccountTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
