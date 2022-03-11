using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class DeleteCustomer : IRequest
    {
        public int Id { get; set; }

        public DeleteCustomer(int id)
        {
            Id = id;
        }
        public class DeleteCustomerHandler : IRequestHandler<DeleteCustomer, Unit>
        {
            private readonly ICustomerService _customerService;
            public DeleteCustomerHandler(ICustomerService customerService)
            {
                _customerService = customerService;
            }

            public async Task<Unit> Handle(DeleteCustomer request, CancellationToken cancellationToken)
            {
                await _customerService.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }

}