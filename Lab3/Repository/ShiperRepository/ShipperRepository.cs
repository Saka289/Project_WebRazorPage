using Lab3.Models;

namespace Lab3.Repository.ShiperRepository
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly NorthwindContext _context;

        public ShipperRepository(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<Shipper> GetAllShipper()
        {
            return _context.Shippers.ToList();
        }
    }
}
