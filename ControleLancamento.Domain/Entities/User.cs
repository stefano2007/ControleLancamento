using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;

public sealed class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Occupation { get; private set; }
    public string CellPhone { get; private set; }

    public User(string name, string email, string password, string occupation, string cellPhone)
    {
        ValidateDomain(name, email, password, occupation, cellPhone);
    }

    public User(int id, string name, string email, string password, string occupation, string cellPhone)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name, email, password, occupation, cellPhone);
    }
    public void Update(string name, string email, string password, string occupation, string cellPhone)
    {
        ValidateDomain(name, email, password, occupation, cellPhone);
    }
    public void Delete()
    {
        SetInactive();
    }
    public void ValidateDomain(string name, string email, string password, string occupation, string cellPhone)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name is requerid");

        DomainExceptionValidation.When(name.Length < 3,
           "Invalid name, too short, minimum 3 characters");

        DomainExceptionValidation.When(name.Length > 100,
           "Invalid name, too large, maximum 100 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "Invalid email is requerid");

        DomainExceptionValidation.When(email.Length < 3,
           "Invalid email, too short, minimum 3 characters");

        DomainExceptionValidation.When(email.Length > 120,
           "Invalid email, too large, maximum 120 characters");

        DomainExceptionValidation.When(!string.IsNullOrEmpty(Occupation) && Occupation.Length > 60,
            "Invalid image name, too large, maximum 60 characters");

        DomainExceptionValidation.When(!string.IsNullOrEmpty(CellPhone) && CellPhone.Length > 11,
            "Invalid image name, too large, maximum 11 characters");

        Name = name;
        Email = email;
        Password = password;
        Occupation = occupation;
        CellPhone = cellPhone;
    }
}