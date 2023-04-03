using BumbleBee.OnlineLoan.REPOSITORY.Interface;
using BumbleBee.OnlineLoan.REPOSITORY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumbleBee.OnlineLoan.REPOSITORY
{
    public  class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            this._context = context;
        }

        public List<Product> GetAll(int customerId)
        {
          
            try
            {
                return _context.Product.Where(x => x.CustomerId == customerId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
