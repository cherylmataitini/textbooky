using System;
namespace TextBooky.Models
{
    public interface IOrderRepository
    {
        // create an order method
        void CreateOrder(Order order);

        // get order
        //Order getOrder(int orderId);
    }
}
