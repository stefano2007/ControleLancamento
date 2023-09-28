using ControleLancamento.Domain.Entities;
using MediatR;

namespace ControleLancamento.Application.UseCases.Launchs.Queries
{
    public class GetLaunchByIdQuery : IRequest<Launch>
    {
        public int Id { get; set; }
        public GetLaunchByIdQuery(int id)
        {
            Id = id;
        }
    }
}
