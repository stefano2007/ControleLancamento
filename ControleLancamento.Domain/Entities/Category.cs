using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;

public sealed class Category : Entity
{    
    public string Name { get; private set; }
    public string Color { get; private set; }
    public string Icon { get; private set; }
    public DateTime DateCreate { get; private set; }

    public Category(string name, string color, string icon, DateTime dateCreate)
    {
        ValidateDomain(name, color, icon, dateCreate);
    }
    public Category(int id, string name, string color, string icon, DateTime dateCreate)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;

        ValidateDomain(name, color, icon, dateCreate);
    }
    public void Update(string name, string color, string icon, DateTime dateCreate)
    {
        ValidateDomain(name, color, icon, dateCreate);
    }
    public void Delete()
    {
        SetInactive();
    }
    private void ValidateDomain(string name, string color, string icon, DateTime dateCreate)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name.Name is required");

        DomainExceptionValidation.When(name.Length < 3,
           "Invalid name, too short, minimum 3 characters");

        Name = name;
        Color = color;
        Icon = icon;
        DateCreate = dateCreate;
    }
}
