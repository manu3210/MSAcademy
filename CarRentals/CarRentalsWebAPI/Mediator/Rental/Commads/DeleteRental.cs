using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class DeleteRental : IRequest
    {
        public int Id { get; set; }

        public DeleteRental(int id)
        {
            Id = id;
        }
        public class DeleteRentalHandler : IRequestHandler<DeleteRental, Unit>
        {
            private readonly IRentalRepository _rentalRepository;
            public DeleteRentalHandler(IRentalRepository rentalRepository)
            {
                _rentalRepository = rentalRepository;
            }

            public async Task<Unit> Handle(DeleteRental request, CancellationToken cancellationToken)
            {
                await _rentalRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }

}