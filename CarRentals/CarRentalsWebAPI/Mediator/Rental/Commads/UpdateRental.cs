using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
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
            private readonly IMapper _mapper;
            public UpdateRentalHandler(IRentalRepository rentalRepository, IMapper mapper)
            {
                _rentalRepository = rentalRepository;
                _mapper = mapper;
            }

            public async Task<RentalDto> Handle(UpdateRental request, CancellationToken cancellationToken)
            {
                var rental = await _rentalRepository.UpdateAsync(request.Id, _mapper.Map<Rental>(request.Rental));
                return (rental == null) ? null : _mapper.Map<RentalDto>(rental);
            }
        }
    }

}
