using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fictivusforum_topicservice.DataModels
{
    public class Response
    {
        #region fields
        [Key]
        public Guid id;
        public string topicTitle;
        public string userName;
        public DateTime timeOfPosting;
        public string content;
        #endregion
        #region constructors
        public Response()
        {

        }

        public Response(string topicTitle, string userName, DateTime timeOfPosting, string content)
        {

        }
        #endregion
    }
}
