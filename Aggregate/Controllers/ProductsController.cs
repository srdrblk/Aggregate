using Aggregate.Dtos;
using Aggregate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        IA101Service a101Service;
        ICarfoureService carfoureService;



        public ProductsController(IA101Service _a101Service, ICarfoureService _carfoureService )
        {
            a101Service = _a101Service;
            carfoureService = _carfoureService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            List<Product> productDtos = new List<Product>();
            var productsA101 = a101Service.GetProducts().Result.ToList();
            productDtos.AddRange(productsA101);
            var productsCarfoure = carfoureService.GetProducts().Result.ToList();
            productDtos.AddRange(productsCarfoure);
            return productDtos.OrderByDescending(p=>p.Price);


        }
    }
}
