using Microsoft.AspNetCore.Mvc;
using SocialMedia.infrastructure.Repositories;

namespace SocialMedia.api.Controllers
{
    //La ruta se forma como api/Post, sin el controller
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //Este método se encarga de tomar las peticiones GET de la API y devolver en este caso los POSTS como JSON
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = new PostRepository().GetPosts();
            return Ok(posts);
        }
    }
}
