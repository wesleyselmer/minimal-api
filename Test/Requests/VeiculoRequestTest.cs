using System.Net;
using System.Text;
using System.Text.Json;
using minimal_api.Dominio.ModelViews;
using minimal_api.Dominio.DTOs;
using minimal_api;
using Test.Helpers;

namespace Test.Requests;

[TestClass]
public class VeiculoRequestTest
{
    [ClassInitialize]
    public static void ClassInit(TestContext testContext)
    {
        Setup.ClassInit(testContext);
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        Setup.ClassCleanup();
    }
    
    // [TestMethod]
    // public async Task TestarGetSetPropriedades()
    // {
       
    // }
}