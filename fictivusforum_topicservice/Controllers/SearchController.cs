using fictivusforum_topicservice.DTO;
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
        public async Task<ActionResult<List<ResponseDTO>>> FindMessages(string searchterm)
        {
            /*
             // later oplossen
            List<ResponseDTO> posts = await _context.Posts.Where(b => b.UserName == searchterm || b.HashTag == searchterm).ToListAsync();
            List<PostDTO> returnPosts = convertToDTO(posts);
            return Ok(returnPosts);
            */
            return temporaryDataMock();
        }


        public List<ResponseDTO> temporaryDataMock()
        {
            List<ResponseDTO> toReturn = new List<ResponseDTO>();
            for(int i = 0; i < 100; i++)
            {
                ResponseDTO mockRespone = new ResponseDTO("mockery", "mocklord", DateTime.Now, "lorem " + i + "");
                toReturn.Add(mockRespone);
            }
            return toReturn;
            
        }
    }
}
