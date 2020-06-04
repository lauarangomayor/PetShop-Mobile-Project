using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop_Api.Models;

namespace PetShop_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        #region Properties
        private readonly PetshopDBContext dBContext;

        #endregion
        #region Constructor
        public CategoryController (PetshopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion
        #region Method
        [HttpGet("get/{id}")] //http://localhost:5000/Category/get/1
        public async Task<ActionResult<CategoryModel>> GetCategory(long id)
        {
            try {
                var category = await dBContext.Categories.FindAsync(id);
                if (category == null){
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        
        [HttpGet("all")]//http://localhost:5000/Category/all
        public async Task<ActionResult<List<SpecieModel>>> GetAllCategories(){
            try {
                var categories = await dBContext.Categories.ToListAsync();
                if (categories.Count() == 0){
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPost("create")]//http://localhost:5000/Category/create
        public async Task<ActionResult<CategoryModel>> CreateCategory(CategoryModel category){
            try {
                dBContext.Categories.Add(category);
                await dBContext.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }

        [HttpPut("update/{id}")]//http://localhost:5000/Category/update/2
        public async Task<IActionResult> UpdateCategory(CategoryModel category,long id){
            try {
                if (id != category.IdCategory){
                    return BadRequest();
                }
                dBContext.Entry(category).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return NoContent();
                
            }
            catch (Exception e){
                bool categoryExist = dBContext.Categories.Any(e => e.IdCategory == id);
                if (!categoryExist){
                    return NotFound();
                }
                return StatusCode(410);
            }
        }

        [HttpDelete("delete/{id}")] //http://localhost:5000/Category/delete/1
        public async Task<IActionResult> DeleteCategory(long id)
        {
            try {
                var categoria = await dBContext.Categories.FindAsync(id);
                if (categoria == null){
                    return NotFound();
                }
                dBContext.Categories.Remove(categoria);
                await dBContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e){
                return StatusCode(410);
            }
        }
          

        #endregion
    }
}