using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Shop.models;

namespace Shop.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get ()
        {
            MainDBContext DB = new ();
            if (DB == null) return StatusCode(500);
            return Ok(DB.products);
        }
        [HttpPost]
        public ActionResult Add (Product product)
        {
            MainDBContext DB = new ();
            if (DB == null) return StatusCode(500);
            if(product.id != 0)
            {
                DB.products.Update(product);
            } 
            else DB.products.Add(product);
            DB.SaveChanges();
            return Ok(product);
        }
        [HttpDelete]
        public ActionResult Delete (int id) {
            MainDBContext DB = new MainDBContext();
            if (DB == null) return StatusCode(500);
            Product? product = DB.products.Find(id);
            if (product == null) return NotFound();
            DB.products.Remove(product);
            DB.SaveChanges();
            return Ok("Product successfully deleted"); 
        }
    }
}
