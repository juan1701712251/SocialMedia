﻿using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using SocialMedia.infrastructure.Repositories;
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
            return Ok(posts);
        }
    }
}