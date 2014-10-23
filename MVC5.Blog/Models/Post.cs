using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Mvc.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }     
    }
}