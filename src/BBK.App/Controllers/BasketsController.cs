using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BasketsController : Controller
    {
        // GET: api/baskets
        [HttpGet]
        public IEnumerable<Basket> GetAllBasket()
        {
            return new Basket[] {
                new Basket("Basket 1"),
                new Basket("Basket 2"),
                new Basket("Basket 3"),
                new Basket("Basket 4") };
        }

        // GET: api/baskets
        [HttpPost]
        public Basket CreateBasket(BasketSettings newBasket)
        {
            return new Basket("Basket 1");
        }


        // GET: api/baskets/{basketId}
        [HttpGet("{basketId}")]
        public Basket GetBasket(Guid basketId)
        {
            return new Basket("Basket " + basketId);
        }

        // PUT: api/baskets/{basketId}
        [HttpPut("{basketId}")]
        public Basket UpdateBasket(Guid basketId, BasketSettings newBasket)
        {
            return new Basket("Basket " + basketId);
        }

        // DELETE: api/baskets/{basketId}
        [HttpPut("{basketId}")]
        public void DeleteBasket(Guid basketId)
        {
        }


        // GET: api/baskets/{basketId}/items
        [HttpGet("{basketId}/items")]
        public IEnumerable<BasketItem> GetBasketItems(Guid basketId)
        {
            return new BasketItem[] {
                new BasketItem("Item 1"),
                new BasketItem("Item 2"),
                new BasketItem("Item 3"),
                new BasketItem("Item 4") };
        }

        // POST: api/baskets/{basketId}/items
        [HttpPost("{basketId}/items")]
        public void CreateBasketItem(BasketItem item)
        {
            return;
        }


        // GET: api/baskets/{basketId}/items/{itemId}
        // PUT: api/baskets/{basketId}/items/{itemId}
        // DELETE: api/baskets/{basketId}/items/{itemId}

        // POST: api/baskets/{basketId}/order
    }
}
