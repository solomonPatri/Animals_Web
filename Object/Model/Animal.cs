using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;


namespace Animals_Web.Object
{

    [Table("animals")]

    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Types")]
        public string Types;

        [Required]
        [Column ("Name")]
        public string Name;

        [Required]
        [Column("Weight")]
        public double Weight;

        [Required]
        [Column("Country")]
        public string Country;

        [Required]
        [Column("Age")]
        public int Age;








    }






















}