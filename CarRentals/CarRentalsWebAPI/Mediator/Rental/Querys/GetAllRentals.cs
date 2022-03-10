using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class GetAllRentals : IRequest<IEnumerable<RentalDto>> { }
    public class GetAllRentalsHandler : IRequestHandler<GetAllRentals, IEnumerable<RentalDto>>
    {
        private readonly IRentalRepository _rentalRepository;
        public GetAllRentalsHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public async Task<IEnumerable<RentalDto>> Handle(GetAllRentals request, CancellationToken cancellationToken)
        {
            var list = new List<RentalDto>();

            foreach (Rental item in await _rentalRepository.GetAll())
            {
                list.Add(new RentalDto(item));
            }

            return list;
        }
    }
}
