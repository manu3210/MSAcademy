using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class DeleteCar : IRequest
    {
        public int Id { get; set; }

        public DeleteCar(int id)
        {
            Id = id;
        }
        public class DeleteCarHandler : IRequestHandler<DeleteCar, Unit>
        {
            private readonly ICarService _carService;
            public DeleteCarHandler(ICarService carService)
            {
                _carService = carService;
            }

            public async Task<Unit> Handle(DeleteCar request, CancellationToken cancellationToken)
            {
                await _carService.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }

}