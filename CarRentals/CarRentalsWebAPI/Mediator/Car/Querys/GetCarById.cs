using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class GetCarById : IRequest<CarDto>
    {
        public int Id { get; set; }
        public GetCarById(int id)
        {
            Id = id;
        }
        public class GetCarByIdHandler : IRequestHandler<GetCarById, CarDto>
        {
            private readonly ICarRepository _CarRepository;
            public GetCarByIdHandler(ICarRepository CarRepository)
            {
                _CarRepository = CarRepository;
            }

            public async Task<CarDto> Handle(GetCarById request, CancellationToken cancellationToken)
            {
                var car = await _CarRepository.GetAsync(request.Id);
                return (car == null) ? null : new CarDto(car);
            }
        }
    }

}
