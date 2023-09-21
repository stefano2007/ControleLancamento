namespace ControleLancamento.Domain.Entities;

public abstract class EntidadeBase
{
    public int Id { get; protected set; }
    public DateTime DataCriacao { get; private set; }
    public bool Ativo { get; private set; }
    public void TornaInativo()
    {
        Ativo = false;
    }
}