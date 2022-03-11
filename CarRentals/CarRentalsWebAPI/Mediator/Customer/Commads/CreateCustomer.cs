using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
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
            private readonly IMapper _mapper;
            public CreateCustomerHandler(ICustomerService customerService, IMapper mapper)
            {
                _customerService = customerService;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(CreateCustomer request, CancellationToken cancellationToken)
            {
                return _mapper.Map<CustomerDto>(await _customerService.CreateAsync(_mapper.Map<Customer>(request.Customer)));
            }
        }
    }

}
