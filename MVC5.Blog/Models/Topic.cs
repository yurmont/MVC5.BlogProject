using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Mvc.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}