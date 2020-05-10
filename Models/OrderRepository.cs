using System;
using System.Linq;

namespace TextBooky.Models
{
    public class OrderRepository : IOrderRepository
    {
        // bring in DbContext to work with database
        private readonly AppDbContext _appDbContext;
        // order will come from Shopping Cart:
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            // here create order AND orderdetail
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges(); // we have to save changes before doing orderdetails bc of the one-many relation & we need the OrderId for the OrderDetail

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = shoppingCartItem.Quantity,
                    Price = shoppingCartItem.Textbook.Price,
                    TextBookId = shoppingCartItem.Textbook.Id,
                    OrderId = order.OrderId
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
            //return order.OrderId;
        }


        //public Order getOrder(int orderId)
        //{
        //    return _appDbContext.Orders.FirstOrDefault(o => o.OrderId.Equals(orderId));
        //}
    } 
}
