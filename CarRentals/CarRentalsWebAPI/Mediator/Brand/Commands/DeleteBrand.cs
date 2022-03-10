using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class DeleteBrand : IRequest
    {
        public int Id { get; set; }

        public DeleteBrand(int id)
        {
            Id = id;
        }
        public class DeleteBrandHandler : IRequestHandler<DeleteBrand, Unit>
        {
            private readonly IBrandService _brandService;
            public DeleteBrandHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<Unit> Handle(DeleteBrand request, CancellationToken cancellationToken)
            {
                await _brandService.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }

}