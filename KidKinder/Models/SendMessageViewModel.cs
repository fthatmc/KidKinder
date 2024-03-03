using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidKinder.Models
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage ="Lütfen Adınızı Boş Geçmeyin")]
        [StringLength(30, ErrorMessage ="Lütfen en fazla 30 karakter veri girişi yapın")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Lütfen Adınızı Boş Geçmeyin")]
        [StringLength(50, ErrorMessage = "Lütfen en fazla 50 karakter veri girişi yapın")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir email giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Adınızı Boş Geçmeyin")]
        [StringLength(50, ErrorMessage = "Lütfen en fazla 50 karakter veri girişi yapın")]
        [MinLength(5, ErrorMessage = "Lütfen en az 5 karakter veri girişi yapın")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Lütfen Adınızı Boş Geçmeyin")]
        [StringLength(1000, ErrorMessage = "Lütfen en fazla 1000 karakter veri girişi yapın")]
        public string Message { get; set; }
    }
}