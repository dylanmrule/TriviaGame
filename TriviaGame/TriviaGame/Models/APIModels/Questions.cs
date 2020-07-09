using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaGame.Models.APIModels
{
    public class Questions
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }
        
        public List<string> IncorrectAnswers { get; set; }


        public Questions()
        {

        }

        public Questions(string APItext)
        {
            JObject parse = JObject.Parse(APItext);
            this.Category = (string)parse["results"][0]["category"];
            this.Type = (string)parse["results"][0]["type"];
            this.Difficulty = (string)parse["results"][0]["difficulty"];
            this.Question = (string)parse["results"][0]["question"];
            this.CorrectAnswer = (string)parse["results"][0]["correct_answer"];
            this.IncorrectAnswers = new List<string>();

            
            foreach (var item in parse["results"])
            {
                this.IncorrectAnswers.Add(item["incorrect_answers"].ToString()); ;
                
            }

        }
    }

}


