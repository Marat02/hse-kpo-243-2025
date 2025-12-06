using KPO.Example.Contracts.Views;

namespace KPO.Example.Gateway.Clients;

public class CarDevelopmentClient : ICarDevelopmentClient
{
    private readonly HttpClient _httpClient;

    public CarDevelopmentClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProjectView[]> GetProjects(CancellationToken cancellationToken)
    {
        return await Get<ProjectView[]>("projects", cancellationToken);
    }

    private async Task<TResult> Get<TResult>(string uri, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(uri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadFromJsonAsync<TResult>(cancellationToken);
        return content ?? throw new InvalidOperationException();
    }
}