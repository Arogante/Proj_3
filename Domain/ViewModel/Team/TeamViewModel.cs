using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.ViewModel.Team
{
    public class TeamViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")] 
        public string Name { get; set; }
        public string Description { get; set; }
        public int FinishedTasks { get; set; }
        public DateTime CreationTime { get; set; }
        public int Points { get; set; }
        public IFormFile Avatar { get; set; }
        public byte[]? Image { get; set; }
    }
}
