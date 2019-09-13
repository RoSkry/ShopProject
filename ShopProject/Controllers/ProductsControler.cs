using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProject.Controllers
{
    public class ProductsController
    {
        [Route("api/products")]
        public class ProductController : Controller
        {
            ApplicationContext db;
            public ProductController(ApplicationContext context)
            {
                db = context;
                if (!db.Products.Any())
                {
                    db.Products.Add(new Product { Name = "Cola", Type = "Drink", Price = 79, Description = "sdf" });
                    db.Products.Add(new Product { Name = "Pepsi", Type = "Drink", Price = 49, Description = "sdf" });
                    db.Products.Add(new Product { Name = "Big Tasty", Type = "Sandwitch", Price = 120, Description = "sdf" });
                    db.Products.Add(new Product { Name = "Big Mac", Type = "Sandwitch", Price = 150, Description = "sdf" });
                    db.Products.Add(new Product { Name = "pie", Type = "dessert", Price = 120, Description = "sdf" });
                    db.Products.Add(new Product { Name = "chocolate", Type = "dessert", Price = 120, Description = "sdf" });
                    db.Products.Add(new Product { Name = "ice cream", Type = "dessert", Price = 120, Description = "sdf" });
                    db.SaveChanges();
                }
            }
            [HttpGet]
            public IEnumerable<Product> Get()
            {
                return db.Products.ToList();
            }

            [HttpGet("{id}")]
            public Product Get(int id)
            {
                Product product = db.Products.FirstOrDefault(x => x.Id == id);
                return product;
            }

            [HttpPost]
            public IActionResult Post([FromBody]Product product)
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return Ok(product);
                }
                return BadRequest(ModelState);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody]Product product)
            {
                if (ModelState.IsValid)
                {
                    db.Update(product);
                    db.SaveChanges();
                    return Ok(product);
                }
                return BadRequest(ModelState);
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                Product product = db.Products.FirstOrDefault(x => x.Id == id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
                return Ok(product);
            }
        }
    }
}

