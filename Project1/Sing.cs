using System;

public class Program
{
    public static void Main()
    {
        Configuracoes configuracoes = Configuracoes.GetInstancia();

        configuracoes.SetConfiguracao("idioma", "portugues");

        Console.WriteLine("Idioma: " + configuracoes.GetConfiguracao("idioma"));

        Configuracoes outraConfiguracoes = Configuracoes.GetInstancia();
        if (configuracoes == outraConfiguracoes)
        {
            Console.WriteLine("As duas variáveis apontam para a mesma instância da classe Configuracoes.");
        }
        else
        {
            Console.WriteLine("As duas variáveis apontam para instâncias diferentes da classe Configuracoes.");
        }
    }
}

public class Configuracoes
{
    private static Configuracoes instancia = null;
    private readonly string[] configuracoes = new string[10];

    private Configuracoes()
    {

    }

    public static Configuracoes GetInstancia()
    {
        if (instancia == null)
        {
            instancia = new Configuracoes();
        }
        return instancia;
    }
    public void SetConfiguracao(string nome, string valor)
    {
        configuracoes[nome.GetHashCode() % 10] = valor;
    }
    public string GetConfiguracao(string nome)
    {
        return configuracoes[nome.GetHashCode() % 10];
    }
}


