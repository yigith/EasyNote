using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyNote.ViewModels
{
    public class PostNoteVM
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}