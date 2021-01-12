using Aggregate.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregate.Services
{
    public interface ICarfoureService
    {
        [Get("/Product")]
        Task<List<Product>> GetProducts();
    }
}
