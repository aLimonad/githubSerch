using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GS.manager.ViewModels
{
    public class Project
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [DisplayName("��� �������")]
        public string name { get; set; }

        [DisplayName("���������� �����")]
        public int? stargazers_count { get; set; }

        [DisplayName("���������� ����������")]
        public int? watchers_count { get; set; }

        [DisplayName("�����")]
        public string html_url { get; set; }

        [DisplayName("��������")]
        public Owner owner { get; set; }
    }
}
