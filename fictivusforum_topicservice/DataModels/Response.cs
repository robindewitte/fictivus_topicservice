using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fictivusforum_topicservice.DataModels
{
    public class Response
    {
        #region properties
        [Key]
        public Guid Id { get; set; }

        public string TopicTitle { get; set; }
        public string UserName { get; set; }
        public DateTime TimeOfPosting { get; set; }
        public string Content { get; set; }
        public string TopicSubject { get; set; }
        #endregion
        #region constructors
        public Response()
        {

        }

        public Response(string topicTitle, string userName, DateTime timeOfPosting, string content, string topicSubject)
        {
            TopicTitle = topicTitle;
            UserName = userName;
            TimeOfPosting = timeOfPosting;
            Content = content;
            TopicSubject = topicSubject;
        }
        #endregion
    }
}
