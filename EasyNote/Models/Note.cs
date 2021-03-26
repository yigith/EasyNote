using EasyNote.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyNote.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public NoteVM ToViewModel()
        {
            return new NoteVM()
            {
                Id = Id,
                Title = Title,
                Content = Content
            };
        }
    }
}