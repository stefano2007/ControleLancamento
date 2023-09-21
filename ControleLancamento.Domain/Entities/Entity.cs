namespace ControleLancamento.Domain.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
    public DateTime DateCreate { get; protected set; }
    public bool Active { get; private set; }
    public void SetInactive()
    {
        Active = false;
    }
}