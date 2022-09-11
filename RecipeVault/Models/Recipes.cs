using System;
namespace RecipeVault.Models
{
    public class Recipes
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int time { get; set; }
        public string ingredients { get; set; }
        public string method { get; set; }
        public string notes { get; set; }
        public string image_id { get; set; }
    }
}

