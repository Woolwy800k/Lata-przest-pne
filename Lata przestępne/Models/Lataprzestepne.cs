using System.ComponentModel.DataAnnotations;

namespace Lata_przestępne.Models
{
    public class Lataprzestepne 
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        [Display(Name = "Rok urodzenia")]
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        public int? Rok { get; set; }

        [Display(Name = "Imię")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} nie może przekraczać {1} znaków")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        public string? Imie { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} nie może przekraczać {1} znaków")]
        
        public string Nazwisko { get; set; }

        public string Przestepnosc(int? year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                return "";
            }

            return "nie";
        }
    }
}
