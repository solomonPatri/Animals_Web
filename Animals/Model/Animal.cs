using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;


namespace Animals_Web.Animals
{

    [Table("animals")]

    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Weight")]
        public double Weight { get; set; }

        [Required]
        [Column("Country")]
        public string Country { get; set; }

        [Required]
        [Column("Age")]
        public int Age { get; set; }








    }






















}