using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GS.manager.ViewModels
{
    public class Owner
    {

        [DisplayName("Логин автора")]
        public string login { get; set; }

        [DisplayName("Адрес на страницу")]
        public string url { get; set; }

        [DisplayName("Тип пользователя")]
        public string type { get; set; }
    }
}
