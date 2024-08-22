using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class VeiculoServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoApagarVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        veiculo.Nome = "Fit";
        veiculo.Marca = "Honda";
        veiculo.Ano = 2015;

        var veiculoServico = new VeiculoServico(context);
        veiculoServico.Incluir(veiculo);

        // Act
        veiculoServico.Apagar(veiculo);

        // Assert
        Assert.AreEqual(0, veiculoServico.Todos(1).Count());

    }

    [TestMethod]
    public void TestandoAtualizarVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo
        {
            Id = 1,
            Nome = "Fit",
            Marca = "Honda",
            Ano = 2015
        };

        var veiculoServico = new VeiculoServico(context);
        veiculoServico.Incluir(veiculo);
        
        veiculo.Nome = "Marea";
        veiculo.Marca = "Fiat";
        veiculo.Ano = 2008;

        // Act
        veiculoServico.Atualizar(veiculo);

        // Assert
        Assert.AreEqual(1, veiculoServico.BuscaPorId(veiculo.Id)?.Id);
        Assert.AreEqual("Marea", veiculoServico.BuscaPorId(veiculo.Id)?.Nome);
        Assert.AreEqual("Fiat", veiculoServico.BuscaPorId(veiculo.Id)?.Marca);
        Assert.AreEqual(2008, veiculoServico.BuscaPorId(veiculo.Id)?.Ano);
    }

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        veiculo.Nome = "Fit";
        veiculo.Marca = "Honda";
        veiculo.Ano = 2015;

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);
        var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);

        // Assert
        Assert.AreEqual(1, veiculoDoBanco?.Id);
    }

    [TestMethod]
    public void TestandoIncluirVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        veiculo.Nome = "Fit";
        veiculo.Marca = "Honda";
        veiculo.Ano = 2015;

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);

        // Assert
        Assert.AreEqual(1, veiculoServico.Todos().Count);
    }

}