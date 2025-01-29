using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Animals_Web.Object.Dtos
{
    public class CreateAnimalRequest
    {

        public string Name { get; set; }

        public double Weight { get; set; }

        
        public string Country { get; set; }

        public int Age { get; set; }





    }
}
