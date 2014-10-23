using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Mvc.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        public Topic Topic { get; set; }

        public string UserId { get; set; }
    }
}