using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Dominio.DTOs;

namespace Test.Mocks;

public class VeiculoServicoMock : IVeiculoServico
{
    private static List<Veiculo> veiculos = new List<Veiculo>(){
        new Veiculo{
            Id = 1,
            Nome = "Fit",
            Marca = "Honda",
            Ano = 2015
        }
    };

    public Veiculo? BuscaPorId(int id)
    {
        return veiculos.Find(a => a.Id == id);
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculo.Id = veiculos.Count() + 1;
        veiculos.Add(veiculo);
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        return veiculos;
    }

    public void Apagar(Veiculo veiculo)
    {
        veiculos.Remove(veiculo);
    }

    public void Atualizar(Veiculo veiculo)
    {
        var index = veiculos.IndexOf(veiculo);
        if(index > -1)
        {
            veiculos[index].Nome = veiculo.Nome;
            veiculos[index].Marca = veiculo.Marca;
            veiculos[index].Ano = veiculo.Ano;
        }
    }
}