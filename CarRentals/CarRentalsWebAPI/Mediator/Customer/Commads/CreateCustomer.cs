using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class CreateCustomer : IRequest<CustomerDto>
    {
        public CustomerDto Customer { get; set; }

        public CreateCustomer(CustomerDto customer)
        {
            Customer = customer;
        }
        public class CreateCustomerHandler : IRequestHandler<CreateCustomer, CustomerDto>
        {
            private readonly ICustomerService _customerService;
            public CreateCustomerHandler(ICustomerService customerService)
            {
                _customerService = customerService;
            }

            public async Task<CustomerDto> Handle(CreateCustomer request, CancellationToken cancellationToken)
            {
                return new CustomerDto(await _customerService.CreateAsync(CustomerDto.DtoToEntity(request.Customer)));
            }
        }
    }

}
