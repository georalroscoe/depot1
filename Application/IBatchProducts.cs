using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using PrivateWebAPI.DTOs;

namespace Application.Interfaces
{
    public interface IBatchProducts
    {
        void tran(ProductBatcherDto dto);
    }
}
