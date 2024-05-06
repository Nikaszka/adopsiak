using AdoPsiak.Data;
using Microsoft.AspNetCore.Mvc;

namespace AdoPsiak.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalPhotoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AnimalPhotoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{photoId}")]
        public async Task<IActionResult> GetPhoto(Guid photoId)
        {
            var photo = await _dataContext.AnimalPhotos.FindAsync(photoId);

            if (photo == null)
            {
                return NotFound();
            }

            var bytes = Convert.FromBase64String(photo.ImageContent);

            return File(bytes, photo.ContentType);
        }
    }
}
