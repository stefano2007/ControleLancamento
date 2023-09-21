using ControleLancamento.Domain.Validation;

namespace ControleLancamento.Domain.Entities;

public sealed class Lancamento : EntidadeBase
{
    public TipoLancamento TipoLancamento { get; set; }
    public int CategoriaId { get; set; }
    public decimal Valor { get; set; }
    public string Observacao { get; set; }
    public string Tag { get; set; }
    public Lancamento(TipoLancamento tipoLancamento, int categoriaId, decimal valor, string observacao, string tag)
    {
        ValidarDominio(tipoLancamento, categoriaId, valor, observacao, tag);
    }

    public Lancamento(int id, TipoLancamento tipoLancamento, int categoriaId, decimal valor, string observacao, string tag)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido");
        Id = id;
        ValidarDominio(tipoLancamento, categoriaId, valor, observacao, tag);
    }

    public void ValidarDominio(TipoLancamento tipoLancamento, int categoriaId, decimal valor, string observacao, string tag)
    {
        DomainExceptionValidation.When(valor < 0, "Valor inválido");

        DomainExceptionValidation.When(string.IsNullOrEmpty(observacao) && observacao.Length > 250,
            "Invalid image name, too long, maximum 250 characters");

        TipoLancamento = tipoLancamento;
        CategoriaId = categoriaId;
        Valor = valor;
        Observacao = observacao;
        Tag = tag;
    }
}


