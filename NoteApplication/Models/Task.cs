using System;
using System.ComponentModel.DataAnnotations;

namespace NoteApplication.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOfCreate { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Введите дело")]
        public string Description { get; set; }

        public bool IsDone { get; set; }
        
        public Task()
        {
            DateOfCreate = DateTime.Now;
        }
    }
}