using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GS.manager.ViewModels
{
    public class Project
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [DisplayName("Имя проекта")]
        public string name { get; set; }

        [DisplayName("Количество звезд")]
        public int? stargazers_count { get; set; }

        [DisplayName("Количество просмотров")]
        public int? watchers_count { get; set; }

        [DisplayName("Адрес")]
        public string html_url { get; set; }

        [DisplayName("Владелец")]
        public Owner owner { get; set; }
    }
}
