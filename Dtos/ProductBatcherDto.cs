namespace Dtos
{
    public class ProductBatcherDto
    {
        public int OldBatchId { get; set; }
        public int NewBatchId { get; set; }

        public int ManufactoringLotId { get; set; }

        public int Quantity { get; set; }

        public int LocationId { get; set; }

    }
}
