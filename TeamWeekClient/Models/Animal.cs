using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamWeekClient.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required]
        public string Image { get; set; } = default!;
        [Required]
        [StringLength(20)]
        public string Name { get; set; } = default!;
        [Required]
        [Range(1, 20)]
        public int HP { get; set; }
        [Required]
        [Range(1, 9)]
        public int Attack { get; set; }

        public static List<Animal> GetAnimals()
        {
          var apiCallTask = ApiHelper.GetAllAnimals();
          var result = apiCallTask.Result;

          JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
          List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

          return animalList;
        }

        public static Animal GetDetails(int id)
        {
          var apiCallTask = ApiHelper.GetAnimal(id);
          var result = apiCallTask.Result;

          JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
          Animal animal  = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

          return animal;
        }
    }
}