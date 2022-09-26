using BattleshipsCore.Entities;
using RestSharp;

namespace BattleshipsBlazor.ApiClient;

public class ApiClient
{
    private readonly RestClient _restClient;

    public ApiClient(RestClient restClient)
    {
        _restClient = restClient;
    }

    public async Task<GameStatus> GetGameStatus()
        => (await _restClient.GetJsonAsync<GameStatus>("status/"))!;

    public async Task<Dictionary<int, int>> GetPossibleShips()
        => (await _restClient.GetJsonAsync<Dictionary<int, int>>("ship/available/"))!;

    public async Task<bool> CreateShip(int playerNumber, List<Tile> tiles)
    {
        var request = new RestRequest("ship/create/", Method.Post)
            .AddQueryParameter(name: "playerNumber", value: playerNumber)
            .AddJsonBody(tiles);

        var response = await _restClient.PostAsync<bool>(request);
        return response;
    }

    public async Task<bool> TakeShot(int playerNumber, Tile tile)
    {
        var request = new RestRequest("shot/", Method.Post)
            .AddQueryParameter(name: "playerNumber", value: playerNumber)
            .AddJsonBody(tile);

        var response = await _restClient.PostAsync<bool>(request);
        return response;
    }
}