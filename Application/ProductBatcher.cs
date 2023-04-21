using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;
using DataAccess.Mapping;
using DataAccess.Repositories;
using Microsoft.Identity.Client;
using System.Diagnostics;
using Application.Interfaces;
using Dtos;
using System.Xml;

namespace Application
{
    public class ProductBatcher : IBatchProducts
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<WarehouseBatchContent> _warehouseBatchContentRepo;
        private readonly IGenericRepository<WarehouseBatch> _warehouseBatchRepo;
        private readonly IGenericRepository<LocationType> _locationTypeRepo;
        private readonly IGenericRepository<Location> _locationRepo;



        public ProductBatcher(IGenericRepository<WarehouseBatchContent> warehouseBatchContentRepo, IUnitOfWork uow, IGenericRepository<WarehouseBatch> warehouseBatch, IGenericRepository<LocationType> locationType, IGenericRepository<Location> locationRepo)
        {
            _warehouseBatchContentRepo = warehouseBatchContentRepo;
            _uow = uow;
            _warehouseBatchRepo = warehouseBatch;
            _locationTypeRepo = locationType;
            _locationRepo = locationRepo;
        }



        /*creating a method which takes all the parameters and is called in the program.cs file*/
        public void BatchMover(ProductBatcherDto dto)
        {
            Console.WriteLine(dto);


            var oldBatch = _warehouseBatchRepo.GetById(dto.OldBatchId);
            var warehousebatchcontent = _warehouseBatchContentRepo.Get(x => x.WarehouseBatchId == dto.OldBatchId).ToList();
            var warehousebatchconten = _warehouseBatchContentRepo.Get(x => x.WarehouseBatchId == dto.NewBatchId).ToList();
            var locationNewBatch = _locationRepo.GetById(dto.LocationType);
            var newBatch = _warehouseBatchRepo.GetById(dto.NewBatchId);
            
            if (dto.NewBatchId == 0)
            {
               newBatch = locationNewBatch.AddNewBatch();
            }
            
            /*var location = _locationRepo.GetById(dto.OldBatchId);
            var locationType = _locationTypeRepo.GetById(dto.OldBatchId);*/

            /*LocationType egg = new LocationType("men", 100);
             if (NewBatchId == null)
        {
            Location newLocation = new Location(LocationType);
           Location.Add(newLocation);
        }

            _locationTypeRepo.Insert(egg);
            */


            var mush = oldBatch.WarehouseBatchContents.ToList().Count();
            

            if (mush == 0)
            {
                throw new Exception("No batch matching the input");
            }
            
            /*Give -= Give.Quantity - QuantityMoving;*/



                /* couldnt get the productid from the products table in this get request ------ Use WarehhouseBatchContent or VAR? ------- question mark to accept nullable?*/
                /*int numberOfRows = _warehouseBatchContentRepo.Get(x => x.WarehouseBatch == dto.WarehouseBatch).ToList().Count;*/

               oldBatch.MoveFromBatch(newBatch, dto.Quantity, dto.ManufactoringLot, dto.LocationType);

                _uow.Save();




            
        }
    }
}
