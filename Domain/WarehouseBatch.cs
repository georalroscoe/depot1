using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain;
public class WarehouseBatch
{
    public WarehouseBatch(int location)
    {
        Location = location;
    }

    public int Id { get; set; }

    public int Location { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<WarehouseBatchContent> WarehouseBatchContents { get; set; } = new List<WarehouseBatchContent>();
}