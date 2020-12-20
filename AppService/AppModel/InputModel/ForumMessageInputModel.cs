using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppService.AppModel.InputModel
{
    public class ForumMessageInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Description { get; set; }

        public int? ForumId { get; set; }

        [Required]
        public int ForumMessageTypeId { get; set; }

        public List<string> Receivers { get; set; }
    }
}
