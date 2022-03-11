using AutoMapper;
using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
using CarRentalsWebAPI.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalsWebAPI.Mediator.Querys
{
    public class UpdateBrand : IRequest<BrandDto>
    {
        public int Id { get; set; }
        public BrandDto Brand { get; set; }

        public UpdateBrand(int id, BrandDto brand)
        {
            Id = id;
            Brand = brand;
        }
        public class UpdateBrandHandler : IRequestHandler<UpdateBrand, BrandDto>
        {
            private readonly IBrandService _brandService;
            private readonly IMapper _mapper;
            public UpdateBrandHandler(IBrandService brandService, IMapper mapper)
            {
                _brandService = brandService;
                _mapper = mapper;
            }

            public async Task<BrandDto> Handle(UpdateBrand request, CancellationToken cancellationToken)
            {
                var brand = await _brandService.UpdateAsync(request.Id, _mapper.Map<Brand>(request.Brand));
                return (brand == null) ? null : _mapper.Map<BrandDto>(brand);
            }
        }
    }

}
