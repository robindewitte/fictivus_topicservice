using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fictivusforum_topicservice.DTO
{
    public class TopicDTO
    {
        #region fields
        private string username;
        private string title;
        private DateTime timeOfPosting;
        private string subject;
        #endregion

        #region constructors
        //empty constructor for JSON
        public TopicDTO()
        {

        }

        public TopicDTO(string username, string title, DateTime date, string subject)
        {
            Username = username;
            Title = title;
            TimeOfPosting = date;
            Subject = subject;
        }
        #endregion

        #region properties

        public string Username { get => username; set => username = value; }
        public string Title { get => title; set => title = value; }
        public DateTime TimeOfPosting { get => timeOfPosting; set => timeOfPosting = value; }
        public string Subject { get => subject; set => subject = value; }


        #endregion
    }
}
