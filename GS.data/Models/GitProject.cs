using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GS.data.Models
{
    public class GitProject
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [DisplayName("��� �������")]
        public string SeacrhString { get; set; }

        [DisplayName("�����")]
        public string Results { get; set; }

    }
}
