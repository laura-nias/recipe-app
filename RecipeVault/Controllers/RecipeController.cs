using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using RecipeVault.Models;
using Microsoft.Extensions.Configuration;
using RecipeVault.Data;

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
        private DataContext _context;
        private IEnumerable<Recipes> Recipes;

        public RecipeController(ILogger<RecipeController> logger, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, DataContext context)
        {
            logger = _logger;
            _config = configuration;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IEnumerable<Recipes> Get()
        {
            //string sql = "SELECT * FROM recipes";

            //Recipes = access.LoadData<Recipes, dynamic>(sql, new { }, _config.GetConnectionString("default"));

            Recipes = _context.Recipes.ToList();

            return Recipes;

        }

        [Route("postcipe")]
        public void PostRecipe([FromForm] Recipes recipe)
        {
            try
            {
                string title = recipe.title;
                string description = recipe.description;
                int time = recipe.time;
                string ingredients = recipe.ingredients;
                string method = recipe.method;
                string notes = recipe.notes;
                string image = recipe.image;

                _context.Recipes.Add(recipe);
                _context.SaveChanges();

            }
            catch (Exception)
            {

            }
        }




        [HttpDelete("{id:int}")]
        [Route("delete/{id:int}")]
        public IActionResult DeleteRecipe(int id)
        {
            try
            {
                Recipes SelectedRecipe = _context.Recipes.Where(c => c.id == id).First();

                _context.Recipes.Remove(SelectedRecipe);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("edit/{id:int}")]
        public IActionResult UpdateRecipe([FromForm] Recipes recipe, int id)
        {
            try
            {
                Recipes selectedRecipe = _context.Recipes.Where(c => c.id == id).First();

                selectedRecipe = recipe;

                _context.SaveChanges();
                
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("uploadtest")]
        public void UploadTest([FromForm]FileModel file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp/public/Resource/Images");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                path += "/" + file.FileName;

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }

            }
            catch (Exception)
            {
                
            }
         
        }
    }
}