namespace AnderFlowPrismIsland.Logic;

/// <summary>Histórico de textos copiados, apenas em memória: sem disco, com limite de itens e de tamanho.</summary>
public sealed class HistoricoCopias
{
    public const int LimiteItens = 10;
    public const int LimiteCaracteres = 4000;

    private readonly List<string> itens = new();
    public IReadOnlyList<string> Itens => itens;

    /// <summary>Adiciona no topo. Repetidos sobem para o topo. Retorna false se o texto foi ignorado.</summary>
    public bool Adicionar(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto)) return false;
        if (texto.Length > LimiteCaracteres) texto = texto[..LimiteCaracteres];
        itens.Remove(texto);
        itens.Insert(0, texto);
        if (itens.Count > LimiteItens) itens.RemoveRange(LimiteItens, itens.Count - LimiteItens);
        return true;
    }

    public void Limpar() => itens.Clear();

    /// <summary>Primeira linha não vazia, encurtada para caber na lista.</summary>
    public static string Resumo(string texto, int maximo = 56)
    {
        string linha = texto.Split('\n', '\r').Select(l => l.Trim()).FirstOrDefault(l => l.Length > 0) ?? "";
        return linha.Length <= maximo ? linha : linha[..(maximo - 1)] + "…";
    }
}
