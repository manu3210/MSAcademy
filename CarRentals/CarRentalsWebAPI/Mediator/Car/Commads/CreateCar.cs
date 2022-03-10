using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class CreateCar : IRequest<CarDto>
    {
        public CarDto Car { get; set; }

        public CreateCar(CarDto car)
        {
            Car = car;
        }
        public class CreateCarHandler : IRequestHandler<CreateCar, CarDto>
        {
            private readonly ICarService _CarService;
            public CreateCarHandler(ICarService carService)
            {
                _CarService = carService;
            }

            public async Task<CarDto> Handle(CreateCar request, CancellationToken cancellationToken)
            {
                return new CarDto(await _CarService.CreateAsync(CarDto.DtoToEntity(request.Car)));
            }
        }
    }

}
