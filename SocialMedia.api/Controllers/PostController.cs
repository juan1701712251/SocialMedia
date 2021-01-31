using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.infrastructure.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.api.Controllers
{
    //La ruta se forma como api/Post, sin el controller
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        //Este método se encarga de tomar las peticiones GET de la API y devolver en este caso los POSTS como JSON
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            var postsDto = posts.Select(x => new PostDto
            {
                PostId = x.PostId,
                Date = x.Date,
                Description = x.Description,
                Image = x.Image,
                UserId = x.UserId
            });
            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            var postDto = new PostDto
            {
                PostId = post.PostId,
                Date = post.Date,
                Description = post.Description,
                Image = post.Image,
                UserId = post.UserId
            };
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDto postDto)
        {
            var post = new Post
            {
                Date = postDto.Date,
                Description = postDto.Description,
                Image = postDto.Image,
                UserId = postDto.UserId
            };
            await _postRepository.InsertPost(post);

            return Ok(postDto);
        }
    }
}
