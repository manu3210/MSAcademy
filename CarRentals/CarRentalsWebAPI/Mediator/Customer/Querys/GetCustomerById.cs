using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class GetCustomerById : IRequest<CustomerDto>
    {
        public int Id { get; set; }
        public GetCustomerById(int id)
        {
            Id = id;
        }
        public class GetCustomerByIdHandler : IRequestHandler<GetCustomerById, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            public GetCustomerByIdHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<CustomerDto> Handle(GetCustomerById request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetAsync(request.Id);
                return (customer == null) ? null : new CustomerDto(customer);
            }
        }
    }

}
