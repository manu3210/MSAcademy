using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class GetBrandById : IRequest<BrandDto>
    {
        public int Id { get; set; }
        public GetBrandById(int id)
        {
            Id = id;
        }
        public class GetBrandsByIdHandler : IRequestHandler<GetBrandById, BrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            public GetBrandsByIdHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandDto> Handle(GetBrandById request, CancellationToken cancellationToken)
            {
                var brand = await _brandRepository.GetAsync(request.Id);
                return (brand == null) ? null : _mapper.Map<BrandDto>(brand);
            }
        }
    }

}
