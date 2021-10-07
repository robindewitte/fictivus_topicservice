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
        private DateTime date;
        #endregion

        #region constructors
        //empty constructor for JSON
        public TopicDTO()
        {

        }

        public TopicDTO(string username, string title, DateTime date)
        {
            this.Username = username;
            this.Title = title;
            this.Date = date;
        }
        #endregion

        #region properties

        public string Username { get => username; set => username = value; }
        public string Title { get => title; set => title = value; }
        public DateTime Date { get => date; set => date = value; }


        #endregion
    }
}
