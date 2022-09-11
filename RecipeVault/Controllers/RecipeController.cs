using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using RecipeVault.Models;
using Microsoft.Extensions.Configuration;

namespace RecipeVault.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private MainDataAccess access = new MainDataAccess();
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _config;
        private IEnumerable<Recipes> Recipes;

        public RecipeController(ILogger<RecipeController> logger, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            logger = _logger;
            _config = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IEnumerable<Recipes> Get()
        {
            string sql = "SELECT * FROM recipes";

            Recipes = access.LoadData<Recipes, dynamic>(sql, new { }, _config.GetConnectionString("default"));

            return Recipes;

        }

        [HttpPost]
        [Route("postcipe")]
        public IActionResult PostRecipe([FromForm] Recipes recipe)
        {
            try
            {
                string title = recipe.title;
                string description = recipe.description;
                int time = recipe.time;
                string ingredients = recipe.ingredients;
                string method = recipe.method;
                string notes = recipe.notes;
                string image = recipe.image_id;

                string sql = "INSERT INTO recipes (title, description, time, ingredients, method, notes, image_id) VALUES (@title, @description, @time, @ingredients, @method, @notes, @image)";
                
                access.AddData(sql, new {title = title, description = description, time = time, ingredients = ingredients, method = method, notes = notes, image = image}, _config.GetConnectionString("default"));
                
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        [Route("delete/{id:int}")]
        public IActionResult DeleteRecipe(int id)
        {
            try
            {
                string sql = "DELETE FROM recipes WHERE id = @id";

                access.RemoveData(sql, new { id = id }, _config.GetConnectionString("default"));

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        [Route("edit/{id:int}")]
        public IActionResult UpdateRecipe([FromForm] Recipes recipe, int id)
        {
            try
            {
                string title = recipe.title;
                string description = recipe.description;
                int time = recipe.time;
                string ingredients = recipe.ingredients;
                string method = recipe.method;
                string notes = recipe.notes;
                string image = recipe.image_id;

                string sql = @"UPDATE recipes SET title = @title,
                                                 description = @description,
                                                 time = @time,
                                                 ingredients = @ingredients,
                                                 method = @method,
                                                 notes = @notes
                                                 image_id = @image WHERE id = @id";

                access.UpdateData(sql, new {title = title, description = description, time = time, ingredients = ingredients, method = method, notes = notes, image = image, id = id }, _config.GetConnectionString("default"));
                
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("uploadtest")]
        public IActionResult UploadTest([FromForm]FileModel file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Resource/Images", file.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
         
        }
    }
}