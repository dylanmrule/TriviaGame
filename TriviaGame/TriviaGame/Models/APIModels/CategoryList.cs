using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaGame.Models.APIModels
{
    public class CategoryList
    {
        [JsonProperty("id")]
        public List<string> Id { get; set; }
        [JsonProperty("name")]
        public List<string> Name { get; set; }

        public CategoryList()
        {

        }

        public CategoryList (string APItext)
        {
            JObject parse = JObject.Parse(APItext);
            this.Id = new List<string>();
            this.Name = new List<string>();

            foreach (var item in parse["trivia_categories"])
            {
                this.Id.Add(item["id"].ToString()); ;
                this.Name.Add(item["name"].ToString());
            }

        }
    }
    
}

