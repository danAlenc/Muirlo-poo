//RA : N7470h0 
//Nome: Daniel Alencar Silva

using System;
using System.Collections.Generic;

public class Usuario
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Matricula { get; set; }
    public string Senha { get; set; }
}

public class Administrador : Usuario
{
}

public class Recurso
{
    public string Nome { get; set; }
    public DateTime DataLivre { get; set; }
    public List<Reserva> Reservas { get; set; }
}

public class Reserva
{
    public Usuario Usuario { get; set; }
    public Recurso Recurso { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public bool Aprovada { get; set; }
}

public class Faculdade
{
    public List<Administrador> Administradores { get; set; }
    public List<Recurso> Recursos { get; set; }
    public List<Reserva> Reservas { get; set; }

    public bool EfetuarLogin(string cpf, string senha)
    {
        foreach (var admin in Administradores)
        {
            if (admin.Cpf == cpf && admin.Senha == senha)
            {
                return true;
            }
        }
        return false;
    }

    public void CadastrarUsuario(string nome, string cpf, string matricula, string senha)
    {
        var usuario = new Usuario
        {
            Nome = nome,
            Cpf = cpf,
            Matricula = matricula,
            Senha = senha
        };
        Administradores.Add(usuario);
    }

    public void EnviarMensagemAprovadaOuNegadaAReserva(Reserva reserva)
    {
        string assunto = reserva.Aprovada ? "Reserva aprovada" : "Reserva rejeitada";
        Console.WriteLine($"Assunto: {assunto}");
    }

    public void MostrarMensagemAnaliseReserva()
    {
        Console.WriteLine("Sua reserva está sendo analisada.");
    }
}