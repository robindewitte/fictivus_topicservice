using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fictivusforum_topicservice.DataModels
{
    public class Topic
    {
        #region fields
        [Key]
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Title { get; set; }
        public DateTime TimeOfPosting { get; set; }
        public string Subject { get; set; }
        #endregion

        #region constructors
        public Topic()
        {

        }

        public Topic(string username, string title, DateTime date, string subject)
        {
            UserName = username;
            Title = title;
            TimeOfPosting = date;
            Subject = subject;
        }
        #endregion
    }
}
