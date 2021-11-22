using fictivusforum_topicservice.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fictivusforum_topicservice.repositories
{
    public class TopicContext: DbContext
    {
        public TopicContext(DbContextOptions<TopicContext> options)
       : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Response> Responses { get; set; }


    }
}
