using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using MusicManager.Data.ORM;

public class AlbumService
{
    private readonly HttpClient _httpClient;

    public AlbumService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Album>> GetAlbumsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Album>>("api/albums");
    }

    public async Task<Album> CreateAlbumAsync(Album album)
    {
        var response = await _httpClient.PostAsJsonAsync("api/albums", album);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Album>();
    }
}
