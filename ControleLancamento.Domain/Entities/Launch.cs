using ControleLancamento.Domain.Entities.Enum;
using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;

public sealed class Launch : Entity
{
    public LaunchType LaunchType { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public string Observation { get; set; }
    public string Tag { get; set; }
    public Launch(LaunchType launchType, int categoryId, decimal price, string observation, string tag)
    {
        ValidateDomain(launchType, categoryId, price, observation, tag);
    }

    public Launch(int id, LaunchType launchType, int categoryId, decimal price, string observation, string tag)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(launchType, categoryId, price, observation, tag);
    }

    public void ValidateDomain(LaunchType launchType, int categoryId, decimal price, string observation, string tag)
    {
        DomainExceptionValidation.When(price < 0, "Price inválido");

        DomainExceptionValidation.When(string.IsNullOrEmpty(observation) && observation.Length > 250,
            "Invalid image name, too large, maximum 250 characters");

        LaunchType = launchType;
        CategoryId = categoryId;
        Price = price;
        Observation = observation;
        Tag = tag;
    }
}


