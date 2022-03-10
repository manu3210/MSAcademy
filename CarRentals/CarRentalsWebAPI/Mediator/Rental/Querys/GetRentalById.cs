using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class GetRentalById : IRequest<RentalDto>
    {
        public int Id { get; set; }
        public GetRentalById(int id)
        {
            Id = id;
        }
        public class GetRentalByIdHandler : IRequestHandler<GetRentalById, RentalDto>
        {
            private readonly IRentalRepository _rentalRepository;
            public GetRentalByIdHandler(IRentalRepository rentalRepository)
            {
                _rentalRepository = rentalRepository;
            }

            public async Task<RentalDto> Handle(GetRentalById request, CancellationToken cancellationToken)
            {
                var rental = await _rentalRepository.GetAsync(request.Id);
                return (rental == null) ? null : new RentalDto(rental);
            }
        }
    }

}
