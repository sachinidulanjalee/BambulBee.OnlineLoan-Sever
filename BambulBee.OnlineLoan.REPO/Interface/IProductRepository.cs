using BumbleBee.OnlineLoan.REPOSITORY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumbleBee.OnlineLoan.REPOSITORY
{
    public interface IProductRepository
    {
        List<Product> GetAll(int customerId);
    }
}
