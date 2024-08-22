using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Nome = "Fit";
        veiculo.Marca = "Honda";
        veiculo.Ano = 2015;

        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Fit", veiculo.Nome);
        Assert.AreEqual("Honda", veiculo.Marca);
        Assert.AreEqual(2015, veiculo.Ano);
    }
}