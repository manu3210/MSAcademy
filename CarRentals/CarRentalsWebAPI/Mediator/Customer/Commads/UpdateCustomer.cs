using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
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
            private readonly IMapper _mapper;
            public UpdateCustomerHandler(ICustomerService customerService, IMapper mapper)
            {
                _customerService = customerService;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(UpdateCustomer request, CancellationToken cancellationToken)
            {
                var customer = await _customerService.UpdateAsync(request.Id, _mapper.Map<Customer>(request.Customer));
                return (customer == null) ? null : _mapper.Map<CustomerDto>(customer);
            }
        }
    }

}
