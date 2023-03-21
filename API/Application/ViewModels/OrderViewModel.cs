using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
    }
}
