using System.ComponentModel.DataAnnotations;

namespace Worker.Italia.PublicApi.Lazio
{
    public class PostLazioModel
    {
        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }
    }
}