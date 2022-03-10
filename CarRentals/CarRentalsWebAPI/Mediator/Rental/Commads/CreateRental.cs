using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class CreateRental : IRequest<RentalDto>
    {
        public RentalDto Rental { get; set; }

        public CreateRental(RentalDto rental)
        {
            
            Rental = rental;
        }
        public class CreateRentalHandler : IRequestHandler<CreateRental, RentalDto>
        {
            private readonly IRentalRepository _rentalRepository;
            public CreateRentalHandler(IRentalRepository rentalRepository)
            {
                _rentalRepository = rentalRepository;
            }

            public async Task<RentalDto> Handle(CreateRental request, CancellationToken cancellationToken)
            {
                return new RentalDto(await _rentalRepository.CreateAsync(RentalDto.DtoToEntity(request.Rental)));
            }
        }
    }

}
