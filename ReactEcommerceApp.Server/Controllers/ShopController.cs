using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReactEcommerceApp.Server.Models;

namespace ReactEcommerceApp.Server.Controllers
{
    public class ShopController : ControllerBase
    {
        private readonly WatchesDBContext _context;
        public ShopController(WatchesDBContext context)
        {
            this._context = context;
        }

        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products.ToList();

            List<Product> productList = new List<Product>();

            if (products != null)
            {
                foreach (var product in products)
                {
                    var Prod = new Product()
                    {
                        Id = product.Id,
                        Title = product.Title,
                        Description = product.Description,
                        Price = product.Price,
                        Qty = product.Qty,
                        Image = product.Image

                    };
                    productList.Add(Prod);
                }
                return productList;
            }
            return productList;
        }

        [HttpGet("GetCartItems")]
        public IEnumerable<Cart> GetCartItems()
        {
            var carts = _context.Carts.ToList();
            
            List<Cart> cartItems = new List<Cart>();

            if (carts is not [])
            {
                foreach (var item in carts)
                {
                    var productDetails = _context.Products.Find(item.productId);
                    var myCart = new Cart()
                    {
                        transactionid = item.transactionid,
                        productId = item.productId,
                        qty = item.qty,
                        Product = productDetails

                    };
                    cartItems.Add(myCart);
                }
                return cartItems;
            } 
            else
            {
                return (IEnumerable<Cart>)Ok();
            }
        }

        [HttpGet("GetTotalCartItems")]
        public IActionResult GetTotalCartItems()
        {
            var carts = _context.Carts.ToList();
            int cartqty = 0;

            if (carts != null)
            {
                foreach (var item in carts)
                {
                        cartqty  += Convert.ToInt32(item.qty);
                }
                
            }
            string totalitems = Convert.ToString(cartqty);
            return Ok(totalitems);
        }

        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _context.Products.Find(id);
            return Ok(result);
        }


        [HttpPost("InsertCartItem/{productid}")]
        public IActionResult InsertCartItem(int productid)
        {
            var Item = _context.Carts.SingleOrDefault(s => s.productId == productid);
            Cart mycart = new Cart();
            if (Item == null)
            {
                mycart.transactionid = "N-" + new Random().Next(0, 999999).ToString("D4");
                mycart.productId = productid;
                mycart.qty = 1;
                _context.Carts.Add(mycart);
            }
            else
            {
                Item.qty = Item.qty + 1;
            }
            _context.SaveChanges();
            return Ok("inserted");
        }

        [HttpPost("UpdateCart/{productid}/{qty}")]
        public IActionResult UpdateCart(int productid, int qty)
        {
            var Item = _context.Carts.SingleOrDefault(s => s.productId == productid);

            if (Item != null)
            {
                Item.qty = qty;
            }
            _context.SaveChanges();
            return Ok("updated");
        }


        [HttpPost("RemoveItem/{productid}")]
        public IActionResult RemoveItem(int productid)
        {
            var Item = _context.Carts.SingleOrDefault(s => s.productId == productid);

            if (Item != null)
            {
                _context.Carts.Remove(Item);
                _context.SaveChanges();
            }
            
            return Ok("removed");
        }

        [HttpPost("CheckoutComplete")]
        public IActionResult CheckoutComplete()
        {
            var carts = _context.Carts.ToList();
            if (carts is [])
            {
                return Ok();
            }
            else
            {
                var orderNum = "P" + new Random().Next(0, 999999999).ToString("D4");
                foreach (var item in carts)
                {
                    Order myorder = new Order();
                    myorder.orderNo = orderNum;
                    myorder.productId = item.productId;
                    myorder.qty = item.qty;
                    _context.Orders.Add(myorder);
                    _context.Carts.Remove(item);
                }
                _context.SaveChanges();
                return Ok(orderNum);
            }

        }
    }
}
