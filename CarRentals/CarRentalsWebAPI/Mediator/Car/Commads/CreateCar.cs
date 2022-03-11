using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
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
            private readonly IMapper _mapper;
            public CreateCarHandler(ICarService carService, IMapper mapper)
            {
                _CarService = carService;
                _mapper = mapper;
            }

            public async Task<CarDto> Handle(CreateCar request, CancellationToken cancellationToken)
            {
                return _mapper.Map<CarDto>(await _CarService.CreateAsync(_mapper.Map<Car>(request.Car)));
            }
        }
    }

}
