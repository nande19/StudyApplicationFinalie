using System.ComponentModel.DataAnnotations;

namespace StudyApplicationFinalie.Models
{
    public class EnterModules
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string ModuleCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public int Classhours { get; set; }
        public int? Selfhours { get; set; }
        [Required]
        public int Weeks { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CurrentDate { get; set; }
        public int? Enteredhours { get; set; }
        public int? HoursRemaining { get; set; }

    }
}
