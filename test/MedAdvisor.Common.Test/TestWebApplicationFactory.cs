using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
namespace MedAdvisor.Common.Test;

public class TestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
{

    public TestWebApplicationFactory()
    {
        BuildConfiguration();

    }
    public WebApplicationFactory<TStartup> WithEnvironment(Dictionary<string, string> variables)
    {
        foreach (var variable in variables)
        {
            Environment.SetEnvironmentVariable(variable.Key, variable.Value);
        }

        return this;
    }
    private static void BuildConfiguration()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
            {

            });

    }

}
