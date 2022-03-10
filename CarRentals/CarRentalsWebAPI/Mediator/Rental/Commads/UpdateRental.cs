using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class UpdateRental : IRequest<RentalDto>
    {
        public int Id { get; set; }
        public RentalDto Rental { get; set; }

        public UpdateRental(int id, RentalDto rental)
        {
            Id = id;
            Rental = rental;
        }
        public class UpdateRentalHandler : IRequestHandler<UpdateRental, RentalDto>
        {
            private readonly IRentalRepository _rentalRepository;
            public UpdateRentalHandler(IRentalRepository rentalRepository)
            {
                _rentalRepository = rentalRepository;
            }

            public async Task<RentalDto> Handle(UpdateRental request, CancellationToken cancellationToken)
            {
                var rental = await _rentalRepository.UpdateAsync(request.Id, RentalDto.DtoToEntity(request.Rental));
                return (rental == null) ? null : new RentalDto(rental);
            }
        }
    }

}
