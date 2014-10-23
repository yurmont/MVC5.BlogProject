using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Blog.Mvc.Models;
using IdentitySample.Models;

namespace Blog.Mvc.Models
{
    public class BlogContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Topics.Add(
                new Topic
                {
                    Title = "REST API generator",
                    Content = "I'm looking for a REST API generator. I found product like REST United, Swagger, Alpaca, IO-docs, Google API client generator and Postman but they seems to be more documentation or REST client SDK generators. I'looking for the server side REST API generator.",
                    CreationDate = DateTime.Now,
                    UserId = "ryurivilca",
                    Posts = new List<Post>()
                    {
                        new Post(){Content = "Comment 1!", UserId = "user01"},
                        new Post(){Content = "Comment 2! ", UserId = "user02"},

                    }
                });

            context.Topics.Add(
                new Topic
                {
                    Title = "Web API ObservableCollection Returns Null",
                    Content = "I am working on a WPF 4.0 app that calls to the back end via an MVC 4 Web API.I have a view called Injuries. I have an InjuryEntity which contains an ObservableCollection of DocumentEntity. I'm using an ObservableCollection because the WPF UI is bound as such:",
                    CreationDate = DateTime.Now,
                    UserId = "ryurivilca",
                    Posts = new List<Post>()
                    {
                        new Post(){Content = "Have you debug you API method? It may have some logical problems that prevent it to return anything?", UserId = "user01"},
                        new Post(){Content = "I think your issue might be that you're trying to use a stateful collection in a stateless context.  ", UserId = "user02"},

                    }
                });

            context.Topics.Add(
               new Topic
               {
                   Title = "How to develop Notifications feature",
                   Content = "How to implement Facebook like notification in website using asp.net FrameWork 2.0, SignalR can not be used because my website built in 2.0, I want to show only Update Notification Count. My plan is to use JavaScript setTimeout() function in which I will call ajax . but I am worried about is Load on Browser and DB server.",
                   CreationDate = DateTime.Now,
                   UserId = "ryurivilca",
                   Posts = new List<Post>()
                    {
                        new Post(){Content = "Of course there is no such things as a 'best' solution. However, if you are unable to use existing libraries, such as SignalR, then you need to use the manual approach which means doing it in JavaScript as you mentioned.", UserId = "user01"},
                        new Post(){Content = "Typically, your code won't change much as long as you write good code to begin with. Handling an increase in load is done by configuring servers, not changing code. ", UserId = "user02"},

                    }
               });
           
            context.SaveChanges();
        }
    }
}