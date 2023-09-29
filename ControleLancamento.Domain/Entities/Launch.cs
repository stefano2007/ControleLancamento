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
    public string Description { get; private set; }
    public DateOnly DateLaunch { get; private set; }
    public decimal Price { get; private set; }
    public string Observation { get; private set; }
    public string Tag { get; private set; }
    public Launch(LaunchType launchType, int categoryId, int accountId, string description, DateOnly dateLaunch, decimal price, string observation, string tag)
    {
        ValidateDomain(launchType, categoryId, accountId, description, dateLaunch, price, observation, tag);
    }
    public Launch(int id, LaunchType launchType, int categoryId, int accountId, string description, DateOnly dateLaunch, decimal price, string observation, string tag)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(launchType, categoryId, accountId, description, dateLaunch, price, observation, tag);
    }
    public void Update(LaunchType launchType, int categoryId, int accountId, string description, DateOnly dateLaunch, decimal price, string observation, string tag)
    {
        ValidateDomain(launchType, categoryId, accountId, description, dateLaunch, price, observation, tag);
    }
    public void Delete()
    {
        SetInactive();
    }
    public void ValidateDomain(LaunchType launchType, int categoryId, int accountId, string description, DateOnly dateLaunch, decimal price, string observation, string tag)
    {
        DomainExceptionValidation.When(categoryId <= 0, "Category Id invalid");

        DomainExceptionValidation.When(accountId <= 0, "Account Id invalid");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description),
        "Invalid description is required");

        DomainExceptionValidation.When(description.Length < 3,
           "Invalid description, too short, minimum 3 characters");

        DomainExceptionValidation.When(description.Length > 100,
           "Invalid name, too large, maximum 100 characters");

        DomainExceptionValidation.When(price < 0, "Price invalid");

        DomainExceptionValidation.When(dateLaunch == DateOnly.MinValue, "Date Launch invalid");

        DomainExceptionValidation.When(!string.IsNullOrEmpty(observation) && observation.Length > 250,
            "Invalid observation, too large, maximum 250 characters");

        DomainExceptionValidation.When(!string.IsNullOrEmpty(tag) && tag.Length > 20,
            "Invalid tag, too large, maximum 20 characters");

        LaunchType = launchType;
        CategoryId = categoryId;
        AccountId = accountId;
        Description = description;
        DateLaunch = dateLaunch;
        Price = price;
        Observation = observation;
        Tag = tag;
    }
}


