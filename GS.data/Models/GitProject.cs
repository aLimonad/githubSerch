using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GS.data.Models
{
    public class GitProject
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [DisplayName("Имя проекта")]
        public string SeacrhString { get; set; }

        [DisplayName("Автор")]
        public string Results { get; set; }

    }
}
