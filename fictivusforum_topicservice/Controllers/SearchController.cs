using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fictivusforum_topicservice.Controllers
{
    [Produces("application/json")]
    [Route("api/search")]
    [ApiController]
    public class SearchController : Controller
    {
       [HttpGet]
       [Route("getpostsbyterm")]
        public async Task<ActionResult<List<PostDTO>>> FindMessages(string searchterm)
        {
            List<Post> posts = await _context.Posts.Where(b => b.UserName == searchterm || b.HashTag == searchterm).ToListAsync();
            List<PostDTO> returnPosts = convertToDTO(posts);
            return Ok(returnPosts);
        }
    }
}
