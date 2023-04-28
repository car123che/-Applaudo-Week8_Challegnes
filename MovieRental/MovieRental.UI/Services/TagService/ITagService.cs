using MovieRental.Application.DTOs.Tag;

namespace MovieRental.UI.Services.TagService
{
    public interface ITagService
    {
        Task<List<TagDto>> GetAllTags();
    }
}
