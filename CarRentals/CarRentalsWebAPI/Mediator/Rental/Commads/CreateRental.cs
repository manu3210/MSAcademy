using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
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
            private readonly IMapper _mapper;
            public CreateRentalHandler(IRentalRepository rentalRepository, IMapper mapper)
            {
                _rentalRepository = rentalRepository;
                _mapper = mapper;
            }

            public async Task<RentalDto> Handle(CreateRental request, CancellationToken cancellationToken)
            {
                return _mapper.Map<RentalDto>(await _rentalRepository.CreateAsync(_mapper.Map<Rental>(request.Rental)));
            }
        }
    }

}
