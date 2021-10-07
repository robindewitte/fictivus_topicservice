using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fictivusforum_topicservice.DTO
{
    public class ResponseDTO
    {
        #region fields
        private string topicTitle;
        private string userName;
        private DateTime timeOfPosting;
        private string content;
        #endregion
        #region constructors
        public ResponseDTO()
        {

        }

        public ResponseDTO(string topicTitle, string userName, DateTime timeOfPosting, string content)
        {

        }
        #endregion

        #region Properties
        public string TopicTitle { get => topicTitle; set => topicTitle = value; }
        public string UserName { get => userName; set => userName = value; }
        public DateTime TimeOfPosting { get => timeOfPosting; set => timeOfPosting = value; }
        public string Content { get => content; set => content = value; }
        #endregion
    }
}
