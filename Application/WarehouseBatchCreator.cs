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
    //public class WarehouseBatchCreator : ICreateWarehouseBatches
    //{
    //    private readonly IUnitOfWork _uow;

    //    private readonly IGenericRepository<Location> _locationRepo;

    //    public WarehouseBatchCreator(IUnitOfWork uow, IGenericRepository<Location> locationRepo)
    //    {
    //        _uow = uow;

    //        _locationRepo = locationRepo;
    //    }
    //    public WarehouseBatch CreateWarehouseBatch(int location)
    //    {

    //        var locationNewBatch = _locationRepo.GetById(location);

    //        //        if (locationNewBatch == null)
    //        {
    //            throw new Exception("location null");
    //        }
    //        locationNewBatch.AddNewBatch();


    //    }
    //}
}
