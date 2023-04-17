using System;
using Microsoft.AspNetCore.Mvc;
using Application;
using Application.Interfaces;
using Dtos;
using DataAccess.Repositories;
using DataAccess;
using Domain;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrivateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBatcherController : ControllerBase
    {

        private readonly IBatchProducts _productBatcher;
  
        public ProductBatcherController(IBatchProducts productBatcher, DepotContext DbContext)
        {
            _productBatcher = productBatcher;
        } 


        // POST api/<ProductBatcherController>
        [HttpPost]
        public void Post([FromBody] ProductBatcherDto dto)
        {
            if (dto == null) {
                throw new ArgumentNullException(nameof(dto)); 
            }

            if (_productBatcher == null)
            {
                throw new NullReferenceException("_productBatcher is null.");
            }

            _productBatcher.BatchMover(dto);
            
        }











    }
}
