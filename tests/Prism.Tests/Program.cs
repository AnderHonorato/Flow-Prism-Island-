using AnderFlowPrismIsland.Logic;
using System.IO;
int verificados = 0;
void Testar(string nome, Action teste) {
    teste(); verificados++; Console.WriteLine("PASSOU: " + nome);
}
void Exigir(bool condicao, string mensagem) {
    if (!condicao) throw new Exception(mensagem);
}
Testar("Temporizador com duração inicial real", () => {
    var t = new Temporizador(TimeSpan.FromMinutes(25));
    Exigir(t.Restante == TimeSpan.FromMinutes(25) && !t.Rodando, "Estado inicial incorreto");
});
Testar("Temporizador só avança ao iniciar", () => {
    var t = new Temporizador(TimeSpan.FromMinutes(1));
    t.Avancar(TimeSpan.FromSeconds(15));
    Exigir(t.Restante == TimeSpan.FromMinutes(1), "Não deveria avançar");
    t.Iniciar(); t.Avancar(TimeSpan.FromSeconds(15));
    Exigir(t.Restante == TimeSpan.FromSeconds(45), "Deveria subtrair 15 segundos");
});
Testar("Pausa, reinício e término não geram tempo negativo", () => {
    var t = new Temporizador(TimeSpan.FromSeconds(5));
    t.Iniciar(); t.Avancar(TimeSpan.FromSeconds(2)); t.Pausar(); t.Avancar(TimeSpan.FromSeconds(2));
    Exigir(t.Restante == TimeSpan.FromSeconds(3), "Pausa ignorada");
    t.Iniciar(); t.Avancar(TimeSpan.FromSeconds(10));
    Exigir(t.Restante == TimeSpan.Zero && !t.Rodando, "Ultrapassou zero");
    t.Reiniciar();
    Exigir(t.Restante == TimeSpan.FromSeconds(5) && !t.Rodando, "Falhou reiniciar");
});
Testar("Ilha alterna e fixa sem fechar acidentalmente", () => {
    var m = new MaquinaIlha();
    Exigir(m.Estado == EstadoIlha.Recolhida, "Inicial");
    m.Expandir(); m.Fixar();
    Exigir(m.Estado == EstadoIlha.Fixada, "Deveria estar fixada");
    m.RecolherSeNaoFixada();
    Exigir(m.Estado == EstadoIlha.Fixada, "Não deveria recolher");
    m.Desfixar(); m.RecolherSeNaoFixada();
    Exigir(m.Estado == EstadoIlha.Recolhida, "Não recolheu");
});
Testar("Mídia sem sessão não inventa título nem habilita controles", () => {
    var m = MidiaVisivel.Vazia();
    Exigir(!m.TemSessao && m.Titulo == "Nenhuma mídia em reprodução", "Estado sem música incorreto");
    Exigir(!m.PodePausar && !m.PodeAvancar, "Controles sem sessão deveriam estar desativados");
});
Testar("Mídia respeita player e recursos realmente expostos", () => {
    var m = MidiaVisivel.DaSessao("Canção", "Artista", "Spotify", true, true, false);
    Exigir(m.TemSessao && m.Titulo == "Canção" && m.Tocando, "Metadados incorretos");
    Exigir(m.PodePausar && !m.PodeAvancar, "Capabilities ignoradas");
});
Testar("Volume sempre limitado de 0 a 100", () => {
    Exigir(VolumeSistema.LimitarPorcentagem(-4) == 0, "Negativo");
    Exigir(VolumeSistema.LimitarPorcentagem(400) == 100, "Acima de 100");
    Exigir(VolumeSistema.LimitarPorcentagem(50) == 50, "Meio");
});
Testar("A reação a áudio não inventa som quando a entrada está vazia", () => {
    Exigir(IntensidadeAudio.Calcular(Array.Empty<float>()) == 0, "Entrada vazia");
    Exigir(IntensidadeAudio.Calcular(new float[] { 0, 0, 0 }) == 0, "Silêncio");
});
Testar("A reação a áudio retorna intensidade normalizada", () => {
    var intensidade = IntensidadeAudio.Calcular(new float[] { 0.5f, -0.5f });
    Exigir(intensidade > 0.99 && intensidade <= 1, "Saturação limitada");
    Exigir(IntensidadeAudio.Calcular(new float[] { 0.01f, 0.01f }) > 0, "Áudio baixo");
});
Testar("Histórico de cópias ignora vazio, deduplica e respeita limites", () => {
    var h = new HistoricoCopias();
    Exigir(!h.Adicionar("   ") && !h.Adicionar(null), "Vazio deveria ser ignorado");
    h.Adicionar("a"); h.Adicionar("b"); h.Adicionar("a");
    Exigir(h.Itens.Count == 2 && h.Itens[0] == "a", "Repetido deveria subir ao topo");
    for (int i = 0; i < 20; i++) h.Adicionar("item" + i);
    Exigir(h.Itens.Count == HistoricoCopias.LimiteItens && h.Itens[0] == "item19", "Limite de itens");
    h.Adicionar(new string('x', 10000));
    Exigir(h.Itens[0].Length == HistoricoCopias.LimiteCaracteres, "Limite de tamanho");
    h.Limpar();
    Exigir(h.Itens.Count == 0, "Limpar");
    Exigir(HistoricoCopias.Resumo("\n  primeira linha  \nsegunda") == "primeira linha", "Resumo usa a primeira linha");
});
Testar("Ocultação automática usa intervalos permitidos e fallback", () => {
    Exigir(TempoOcultacao.Normalizar(0) == 2500, "Valor inválido deveria usar padrão");
    Exigir(TempoOcultacao.Normalizar(1500) == 1500, "1500 ms deve ser aceito");
    Exigir(TempoOcultacao.Normalizar(5000) == 5000, "5000 ms deve ser aceito");
    Exigir(TempoOcultacao.Proximo(1500) == 2500, "1500 deve avançar para 2500");
    Exigir(TempoOcultacao.Proximo(2500) == 5000, "2500 deve avançar para 5000");
    Exigir(TempoOcultacao.Proximo(5000) == 1500, "5000 deve voltar para 1500");
});
Testar("Mod Windows define alvos reais de tema e barra", () => {
    var escuro = PlanoModWindows.Criar(ModWindowsOpcao.TemaEscuroPrism);
    Exigir(escuro.Count == 3, "Tema deve alterar personalização real do usuário");
    Exigir(escuro.Any(a => a.Nome == "AppsUseLightTheme" && a.Valor == 0), "Apps escuros");
    Exigir(escuro.Any(a => a.Nome == "SystemUsesLightTheme" && a.Valor == 0), "Windows escuro");
    Exigir(escuro.Any(a => a.Nome == "ColorPrevalence" && a.Valor == 1), "Bordas de destaque");
    var esquerda = PlanoModWindows.Criar(ModWindowsOpcao.AlinharEsquerda);
    Exigir(esquerda.Count == 1 && esquerda[0].Nome == "TaskbarAl" && esquerda[0].Valor == 0, "Ícones na esquerda");
    var centro = PlanoModWindows.Criar(ModWindowsOpcao.AlinharCentro);
    Exigir(centro.Count == 1 && centro[0].Valor == 1, "Ícones centralizados");
});
Testar("Mod Prism gera regras reais do Explorer para Windhawk", () => {
    string texto = PlanoModWindows.GerarConfigWindhawk();
    Exigir(texto.Contains("controlStyles:"), "Arquivo sem estilos");
    Exigir(texto.Contains("Taskbar.TaskListButton"), "Estilo não afeta Explorer");
    Exigir(texto.Contains("#FFE8622A"), "Cor Ander Flow ausente");
    Exigir(!texto.Contains("powershell"), "Não executar comandos na importação de tema");
});
Testar("Backup de mod salva e relê sem alterar opções do Windows", () => {
    if (!ServicoModWindows.Compativel) return;
    string pasta = Path.Combine(Path.GetTempPath(), "prism-mod-test-" + Guid.NewGuid().ToString("N"));
    try
    {
        var servico = new ServicoModWindows(pasta);
        Exigir(!servico.PossuiBackup, "Teste não deveria ter backup inicial");
        servico.PrepararBackup();
        Exigir(servico.PossuiBackup, "Backup não foi salvo");
        string arquivo = Path.Combine(pasta, "visual-windows-original.json");
        string original = File.ReadAllText(arquivo);
        Exigir(original.Contains("TaskbarAl") && original.Contains("Environment") == false,
            "Faltam os valores gerenciados no backup");
        servico.PrepararBackup();
        Exigir(File.ReadAllText(arquivo) == original, "Backup foi sobrescrito");
    }
    finally { if (Directory.Exists(pasta)) Directory.Delete(pasta, true); }
});
Console.WriteLine($"VALIDADOS: {verificados} testes de lógica.");