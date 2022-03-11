using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class UpdateCar : IRequest<CarDto>
    {
        public int Id { get; set; }
        public CarDto Car { get; set; }

        public UpdateCar(int id, CarDto car)
        {
            Id = id;
            Car = car;
        }
        public class UpdateCarHandler : IRequestHandler<UpdateCar, CarDto>
        {
            private readonly ICarService _carService;
            private readonly IMapper _mapper;
            public UpdateCarHandler(ICarService carService, IMapper mapper)
            {
                _carService = carService;
                _mapper = mapper;
            }

            public async Task<CarDto> Handle(UpdateCar request, CancellationToken cancellationToken)
            {
                var car = await _carService.UpdateAsync(request.Id, _mapper.Map<Car>(request.Car));
                return (car == null) ? null : _mapper.Map<CarDto>(car);
            }
        }
    }

}
