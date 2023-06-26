using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Shop.models;

namespace Shop.Controllers
{
    [ApiController]
    [Route("/Seller")]
    public class SellerController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get ()
        {
            MainDBContext DB = new();
            if (DB == null) return StatusCode(500);
            return Ok(DB.sellers);
        }
        [HttpPost]
        public ActionResult Add (Seller seller)
        {
            MainDBContext DB = new();
            if (DB == null) return StatusCode(500);
            if (seller.Id != 0)
            {
                DB.sellers.Update(seller);
            }
            else DB.sellers.Add(seller);
            DB.SaveChanges();
            return Ok(seller);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            MainDBContext DB = new();
            if (DB == null) return StatusCode(500);
            Seller? seller = DB.sellers.Find(id);
            if (seller != null) return NotFound();
            DB.sellers.Remove(seller);
            DB.SaveChanges();
            return Ok("Product successfully deleted");
        }
    }
}
