using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace fictivusforum_topicservice.repositories
{
    public class ResponseContext: DbContext
    {
        public ResponseContext(DbContextOptions<ResponseContext> options)
         : base(options)
        {
        }

        public DbSet<> Posts { get; set; }

    }
}
