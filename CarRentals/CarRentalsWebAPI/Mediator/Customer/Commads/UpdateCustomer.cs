using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class UpdateCustomer : IRequest<CustomerDto>
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }

        public UpdateCustomer(int id, CustomerDto customer)
        {
            Id = id;
            Customer = customer;
        }
        public class UpdateCustomerHandler : IRequestHandler<UpdateCustomer, CustomerDto>
        {
            private readonly ICustomerService _customerService;
            public UpdateCustomerHandler(ICustomerService customerService)
            {
                _customerService = customerService;
            }

            public async Task<CustomerDto> Handle(UpdateCustomer request, CancellationToken cancellationToken)
            {
                var customer = await _customerService.UpdateAsync(request.Id, CustomerDto.DtoToEntity(request.Customer));
                return (customer == null) ? null : new CustomerDto(customer);
            }
        }
    }

}
