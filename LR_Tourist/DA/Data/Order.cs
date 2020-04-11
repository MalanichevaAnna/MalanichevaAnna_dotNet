
namespace DA.Data
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TravelVoucherId { get; set; }
    }
}
