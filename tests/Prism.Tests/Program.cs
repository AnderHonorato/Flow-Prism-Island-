using AnderFlowPrismIsland.Logic;
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
Console.WriteLine($"VALIDADOS: {verificados} testes de lógica.");