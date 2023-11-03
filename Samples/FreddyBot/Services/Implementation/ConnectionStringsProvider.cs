using Microsoft.Extensions.Configuration;

namespace FreddyBot.Services.Implementation;

public class ConnectionStringsProvider : IConnectionStringsProvider
{
    private readonly IConfiguration configuration;
    public ConnectionStringsProvider(IConfiguration configuration) => this.configuration = configuration;

    public string? Get(string name) => configuration.GetConnectionString(name);
}
