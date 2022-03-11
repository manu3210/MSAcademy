using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetAllRentalsHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RentalDto>> Handle(GetAllRentals request, CancellationToken cancellationToken)
        {
            var list = new List<RentalDto>();

            foreach (Rental item in await _rentalRepository.GetAll())
            {
                list.Add(_mapper.Map<RentalDto>(item));
            }

            return list;
        }
    }
}
