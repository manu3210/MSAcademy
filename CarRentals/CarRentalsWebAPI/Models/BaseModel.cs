using CarRentals.Interfaces;

namespace CarRentalsWebAPI.Models
{
    public class BaseModel : IModelForCrud
    {
        public int Id { get; set; }
    }
}
