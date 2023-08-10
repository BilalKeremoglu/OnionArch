using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class GetProductDetailViewModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
