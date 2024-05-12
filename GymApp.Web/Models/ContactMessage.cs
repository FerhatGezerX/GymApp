using System.ComponentModel.DataAnnotations;

namespace GymApp.Web.Models
{
    public class ContactMessage : BaseEntity {
        [Key]

        public int Id { get; set; }

        public string FirstName { get; set; }
       

        public string LastName { get; set; }
      

        public string Email { get; set; }


        public string Title { get; set; }

        public string Message { get; set; }


    }
}
