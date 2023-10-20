using Lab3.Models;

namespace Lab3.Repository.ShiperRepository
{
    public interface IShipperRepository
    {
        public IEnumerable<Shipper> GetAllShipper();
    }
}
