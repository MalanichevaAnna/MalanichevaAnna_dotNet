﻿
namespace DA.Data
{
    public class HotelDTO : IEntityBase
    {
        public int Id { get; }

        public string Name { get; set; }

        public int Star { get; set; }

        public string Phone { get; set; }
        
    }
}
