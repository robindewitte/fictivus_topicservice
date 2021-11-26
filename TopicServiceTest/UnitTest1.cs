using fictivusforum_topicservice;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Moq;
using System.Net.Http;
using Xunit;
using fictivusforum_topicservice.DataModels;
using fictivusforum_topicservice.repositories;
using fictivusforum_topicservice.Controllers;
using fictivusforum_topicservice.DTO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TopicServiceTest
{
    public class UnitTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public Microsoft.Extensions.Configuration.IConfigurationRoot Configuration { get; private set; }

        public UnitTest1()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>().ConfigureAppConfiguration(config =>
               {
                   Configuration = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();

                   config.AddConfiguration(Configuration);
               }));
            _client = _server.CreateClient();
        }

        [Fact]
        public void GetMemeTopics_Preset_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<TopicDTO> toAssert = new List<TopicDTO>();
            toAssert.Add(new TopicDTO { Username = "testjong", TimeOfPosting = generate, Subject = "meme", Title = "eeeeeeeee" });
            toAssert.Add(new TopicDTO { Username = "testjong2", TimeOfPosting = generate, Subject = "meme", Title = "eeEeeEeeEee" });


            using (var context = new TopicContext(options))
            {
                context.Topics.Add(new Topic { UserName = "testjong", TimeOfPosting = generate, Subject = "meme", Title = "eeeeeeeee" });
                context.Topics.Add(new Topic { UserName = "testjong2", TimeOfPosting = generate, Subject = "meme", Title = "eeEeeEeeEee" });
                context.Topics.Add(new Topic { UserName = "testjong", TimeOfPosting = generate, Subject = "discussion", Title = "discussioneeeeeeeee" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response =  controller.GetMemeTopics();
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());

            }
        }

        [Fact]
        public void GetDiscussionTopicsByTerm_Preset_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<TopicDTO> toAssert = new List<TopicDTO>();
            toAssert.Add(new TopicDTO { Username = "testjong", TimeOfPosting = generate, Subject = "discussion", Title = "dddeeeeeeeee" });
            toAssert.Add(new TopicDTO { Username = "testjong2", TimeOfPosting = generate, Subject = "discussion", Title = "dddeeEeeEeeEee" });


            using (var context = new TopicContext(options))
            {
                context.Topics.Add(new Topic { UserName = "testjong", TimeOfPosting = generate, Subject = "discussion", Title = "dddeeeeeeeee" });
                context.Topics.Add(new Topic { UserName = "testjong2", TimeOfPosting = generate, Subject = "discussion", Title = "dddeeEeeEeeEee" });
                context.Topics.Add(new Topic { UserName = "testjong", TimeOfPosting = generate, Subject = "meme", Title = "meeeeeeeee" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.GetDiscussionTopics();
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());

            }
        }

        [Fact]
        public void GetModReleasesTopics_Preset_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<TopicDTO> toAssert = new List<TopicDTO>();
            toAssert.Add(new TopicDTO { Username = "testjong", TimeOfPosting = generate, Subject = "modreleases", Title = "modeeeeeeeee" });
            toAssert.Add(new TopicDTO { Username = "testjong2", TimeOfPosting = generate, Subject = "modreleases", Title = "modeeEeeEeeEee" });


            using (var context = new TopicContext(options))
            {
                context.Topics.Add(new Topic { UserName = "testjong", TimeOfPosting = generate, Subject = "modreleases", Title = "modeeeeeeeee" });
                context.Topics.Add(new Topic { UserName = "testjong2", TimeOfPosting = generate, Subject = "modereleases", Title = "modeeEeeEeeEee" });
                context.Topics.Add(new Topic { UserName = "testjong", TimeOfPosting = generate, Subject = "discussion", Title = "discussioneeeeeeeee" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.GetModReleasesTopics();
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());

            }
        }

        [Fact]
        public void GetMemePostsByTerm_Preset_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<ResponseDTO> toAssert = new List<ResponseDTO>();
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmemetopic", UserName="testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "meme" });


            using (var context = new TopicContext(options))
            {
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "meme" });
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote tanden maar ben geen krokodil", TopicSubject = "meme" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik hoor niet in de results", TopicSubject = "discussion" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.GetMemePostsByTerm("Ik heb grote oren maar ik ben geen olifant");
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());
            }
        }

        [Fact]
        public void GetMemePostsByTerm_PresetMultiple_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<ResponseDTO> toAssert = new List<ResponseDTO>();
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmemetopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "meme" });
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmemetopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "meme" });


            using (var context = new TopicContext(options))
            {
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "meme" });
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "meme" });
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote tanden maar ben geen krokodil", TopicSubject = "meme" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik hoor niet in de results", TopicSubject = "discussion" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "discussion" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.GetMemePostsByTerm("Ik heb grote oren maar ik ben geen olifant");
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());
            }
        }

        [Fact]
        public void GetDiscussionPostsByTerm_Preset_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<ResponseDTO> toAssert = new List<ResponseDTO>();
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestdiscussiontopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "discussion" });


            using (var context = new TopicContext(options))
            {
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "discussion" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote tanden maar ben geen krokodil", TopicSubject = "discussion" });
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik hoor niet in de results", TopicSubject = "meme" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.GetDiscussionPostsByTerm("Ik heb grote oren maar ik ben geen olifant");
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());
            }
        }

        [Fact]
        public void GetDiscussionPostsByTerm_PresetMultiple_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<ResponseDTO> toAssert = new List<ResponseDTO>();
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestdiscussiontopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "dicussion" });
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestdicussiontopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "discussion" });


            using (var context = new TopicContext(options))
            {
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "dicussion" });
                context.Responses.Add(new Response { TopicTitle = "unittestdicussiontopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "discussion" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote tanden maar ben geen krokodil", TopicSubject = "dicussion" });
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik hoor niet in de results", TopicSubject = "meme" });
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "meme" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.GetDiscussionPostsByTerm("Ik heb grote oren maar ik ben geen olifant");
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());
            }
        }

        [Fact]
        public void GetModReleasesPostsByTerm_Preset_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<ResponseDTO> toAssert = new List<ResponseDTO>();
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmodreleasestopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });


            using (var context = new TopicContext(options))
            {
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote tanden maar ben geen krokodil", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik hoor niet in de results", TopicSubject = "discussion" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.GetModReleasesPostsByTerm("Ik heb grote oren maar ik ben geen olifant");
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());
            }
        }

        [Fact]
        public void GetModReleasesPostsByTerm_PresetMultiple_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<ResponseDTO> toAssert = new List<ResponseDTO>();
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmodreleasestopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmodreleasestopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });


            using (var context = new TopicContext(options))
            {
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote tanden maar ben geen krokodil", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik hoor niet in de results", TopicSubject = "discussion" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "discussion" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.GetModReleasesPostsByTerm("Ik heb grote oren maar ik ben geen olifant");
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());
            }
        }

        [Fact]
        public void GetPostsByUsername_PresetMultiple_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<ResponseDTO> toAssert = new List<ResponseDTO>();
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmodreleasestopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmodreleasestopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestdiscussiontopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "discussion" });


            using (var context = new TopicContext(options))
            {
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote tanden maar ben geen krokodil", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik hoor niet in de results", TopicSubject = "discussion" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "discussion" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.GetPostsByUsername("testboy1");
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());
            }
        }

        [Fact]
        public void GetPostBySearchTerm_PresetMultiple_True()
        {
            //arrange
            var options = new DbContextOptionsBuilder<TopicContext>()
           .UseInMemoryDatabase(databaseName: "TopicDatabase")
           .Options;

            DateTime generate = new DateTime(1999, 6, 24, 14, 45, 30);

            List<ResponseDTO> toAssert = new List<ResponseDTO>();
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmodreleasestopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmodreleasestopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
            toAssert.Add(new ResponseDTO { TopicTitle = "unittestmemetopicextra", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "meme" });


            using (var context = new TopicContext(options))
            {
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopic", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestmodreleasestopicextra", UserName = "testboy1", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote tanden maar ben geen krokodil", TopicSubject = "modreleases" });
                context.Responses.Add(new Response { TopicTitle = "unittestdiscussiontopic", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik hoor niet in de results", TopicSubject = "discussion" });
                context.Responses.Add(new Response { TopicTitle = "unittestmemetopicextra", UserName = "testboy2", TimeOfPosting = generate, Content = "Ik heb grote oren maar ik ben geen olifant", TopicSubject = "meme" });
                context.SaveChanges();
            }

            //act
            using (var context = new TopicContext(options))
            {
                SearchController controller = new SearchController(context);
                var response = controller.FindMessages("Ik heb grote oren maar ik ben geen olifant");
                OkObjectResult objectResult = Assert.IsType<OkObjectResult>(response.Result.Result);

                //assert
                //Lists comparen geeft een fail zelfs als ze identiek zijn dus string
                Assert.Equal(200, objectResult.StatusCode);
                Assert.Equal(objectResult.Value.ToString(), toAssert.ToString());
            }
        }

    }
}
