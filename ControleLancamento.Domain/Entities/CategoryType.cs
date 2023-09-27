using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;
public sealed class CategoryType : Entity
{
    public string Name { get; private set; }
    
    public CategoryType(string name)
    {
        ValidateDomain(name);
    }

    public CategoryType(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name);
    }
    public void Update(string name)
    {
        ValidateDomain(name);
    }
    public void Delete()
    {
        SetInactive();
    }
    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Campo name é requerido");

        DomainExceptionValidation.When(name.Length < 3,
           "name inválido mínimo de 3 caracteres");

        DomainExceptionValidation.When(name.Length > 100,
           "Invalid name, too large, maximum 100 characters");

        Name = name;
    }
}

