using System;
using Microsoft.AspNetCore.Mvc;
using Application;
using Application.Interfaces;
using Dtos;
using DataAccess.Repositories;
using DataAccess;
using Domain;



namespace PrivateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLocationsController : ControllerBase
    {

        private readonly IFindProducts _productFinder;

        public ProductLocationsController(IFindProducts productFinder, DepotContext DbContext)
        {
            _productFinder = productFinder;
        }


        // GET api/<ValuesController>/5
        [HttpGet]
        
        public string Get(int orderId)
        {
            
            _productFinder.GetOrderDetails(orderId);
            return "value";
            
        }

       [HttpGet]
        [Route("Order/{orderId}")]
        public ActionResult<OrderLocationDto> GetProductLocationsForOrder(int orderId)
        {
            OrderLocationDto dto = _productFinder.GetOrderDetails(orderId);
            return Ok(dto);
        }
        
    }
}
