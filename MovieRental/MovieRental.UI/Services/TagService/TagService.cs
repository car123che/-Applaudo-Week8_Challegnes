using MovieRental.Application.DTOs.Tag;

namespace MovieRental.UI.Services.TagService
{
    public class TagService : ITagService
    {
        private readonly HttpClient _httpClient;
        private const string URL = "https://localhost:7257/api/Tag";
        public TagService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<TagDto>> GetAllTags()
        {
            var tags = await _httpClient.GetFromJsonAsync<List<TagDto>>(URL);
            if (tags == null)
                tags = new List<TagDto>();

            return tags;
        }
    }
}
