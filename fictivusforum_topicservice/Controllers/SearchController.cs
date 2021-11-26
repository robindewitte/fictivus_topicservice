using fictivusforum_topicservice.DataModels;
using fictivusforum_topicservice.DTO;
using fictivusforum_topicservice.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
       TopicContext _context;

        public SearchController(TopicContext context)
        {
            _context = context;
        }

       [HttpGet]
       [Route("getpostsbyterm/{searchterm}")]
        public async Task<ActionResult<ICollection<ResponseDTO>>> FindMessages(string searchterm)
        {
          
            List<Response> posts = await _context.Responses.Where(b => b.UserName == searchterm || b.Content == searchterm).ToListAsync();
            List<ResponseDTO> returnPosts = convertToResponseDTO(posts);
            return Ok(returnPosts);
        }


        [HttpGet]
        [Route("GetPostsByUsername/{username}")]
        public async Task<ActionResult<ICollection<ResponseDTO>>> GetPostsByUsername(string username)
        {

            List<Response> posts = await _context.Responses.Where(b => b.UserName == username).ToListAsync();
            List<ResponseDTO> returnPosts = convertToResponseDTO(posts);
            return Ok(returnPosts);
        }


        #region meme
        [HttpGet]
        [Route("GetMemeTopics")]
        public async Task<ActionResult<ICollection<TopicDTO>>> GetMemeTopics()
        {
            List<Topic> posts = await _context.Topics.Where(b => b.Subject == "meme").ToListAsync();
            List<TopicDTO> returnPosts = convertToTopicDTO(posts);
            return Ok(returnPosts);
        }

        [HttpGet]
        [Route("GetMemePostsBySearchTerm/{searchTerm}")]
        public async Task<ActionResult<ICollection<TopicDTO>>> GetMemePostsByTerm(string searchTerm)
        {
            List<Response> posts = await _context.Responses.Where(b => b.TopicSubject == "meme" && b.Content == searchTerm).ToListAsync();
            List<ResponseDTO> returnPosts = convertToResponseDTO(posts);
            return Ok(returnPosts);
        }

        #endregion

        #region discussion
        [HttpGet]
        [Route("GetDiscussionTopics")]
        public async Task<ActionResult<ICollection<TopicDTO>>> GetDiscussionTopics()
        {
            List<Topic> posts = await _context.Topics.Where(b => b.Subject == "discussion").ToListAsync();
            List<TopicDTO> returnPosts = convertToTopicDTO(posts);
            return Ok(returnPosts);
        }

        [HttpGet]
        [Route("GetDiscussionPostsBySearchTerm/{searchTerm}")]
        public async Task<ActionResult<ICollection<TopicDTO>>> GetDiscussionPostsByTerm(string searchTerm)
        {
            List<Response> posts = await _context.Responses.Where(b => b.TopicSubject == "discussion" && b.Content == searchTerm).ToListAsync();
            List<ResponseDTO> returnPosts = convertToResponseDTO(posts);
            return Ok(returnPosts);
        }
        #endregion

        #region modreleases
        [HttpGet]
        [Route("GetModReleasesTopics")]
        public async Task<ActionResult<ICollection<TopicDTO>>> GetModReleasesTopics()
        {
            List<Topic> posts = await _context.Topics.Where(b => b.Subject == "modreleases").ToListAsync();
            List<TopicDTO> returnPosts = convertToTopicDTO(posts);
            return Ok(returnPosts);
        }

        [HttpGet]
        [Route("GetModReleasesPostsBySearchTerm/{searchTerm}")]
        public async Task<ActionResult<ICollection<TopicDTO>>> GetModReleasesPostsByTerm(string searchTerm)
        {
            List<Response> posts = await _context.Responses.Where(b => b.TopicSubject == "modreleases" && b.Content == searchTerm).ToListAsync();
            List<ResponseDTO> returnPosts = convertToResponseDTO(posts);
            return Ok(returnPosts);
        }
        #endregion


        protected ICollection<ResponseDTO> temporaryDataMock()
        {
            ICollection<ResponseDTO> toReturn = new List<ResponseDTO>();
            for(int i = 0; i < 100; i++)
            {
                ResponseDTO mockRespone = new ResponseDTO("mockery", "mocklord", DateTime.Now, "lorem " + i + "", "meme");
                toReturn.Add(mockRespone);
            }
            return toReturn;
            
        }

        private List<ResponseDTO> convertToResponseDTO(List<Response> input)
        {
            List<ResponseDTO> toReturn = new List<ResponseDTO>();
            foreach(Response entry in input)
            {
                ResponseDTO toAdd = new ResponseDTO(entry.TopicTitle, entry.UserName, entry.TimeOfPosting, entry.Content, entry.TopicSubject);
                toReturn.Add(toAdd);
            }
            return toReturn;
        }

        private List<TopicDTO> convertToTopicDTO(List<Topic> input)
        {
            List<TopicDTO> toReturn = new List<TopicDTO>();
            foreach (Topic entry in input)
            {
                TopicDTO toAdd = new TopicDTO(entry.Title, entry.UserName, entry.TimeOfPosting, entry.Subject);
                toReturn.Add(toAdd);
            }
            return toReturn;
        }
    }
}
