using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
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
            public UpdateCarHandler(ICarService carService)
            {
                _carService = carService;
            }

            public async Task<CarDto> Handle(UpdateCar request, CancellationToken cancellationToken)
            {
                var car = await _carService.UpdateAsync(request.Id, CarDto.DtoToEntity(request.Car));
                return (car == null) ? null : new CarDto(car);
            }
        }
    }

}
