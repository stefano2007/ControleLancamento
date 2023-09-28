using ControleLancamento.Domain.Entities.Enum;
using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;

public sealed class Launch : Entity
{
    public LaunchType LaunchType { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }
    public int AccountId { get; private set; }
    public Account Account { get; private set; }
    public decimal Price { get; private set; }
    public string Observation { get; private set; }
    public string Tag { get; private set; }
    public Launch(LaunchType launchType, int categoryId, int accountId, decimal price, string observation, string tag)
    {
        ValidateDomain(launchType, categoryId, accountId, price, observation, tag);
    }

    public Launch(int id, LaunchType launchType, int categoryId, int accountId, decimal price, string observation, string tag)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(launchType, categoryId, accountId, price, observation, tag);
    }

    public void ValidateDomain(LaunchType launchType, int categoryId, int accountId, decimal price, string observation, string tag)
    {
        DomainExceptionValidation.When(price < 0, "Price inválido");

        DomainExceptionValidation.When(!string.IsNullOrEmpty(observation) && observation.Length > 250,
            "Invalid image name, too large, maximum 250 characters");

        LaunchType = launchType;
        CategoryId = categoryId;
        AccountId = AccountId;
        Price = price;
        Observation = observation;
        Tag = tag;
    }
}


