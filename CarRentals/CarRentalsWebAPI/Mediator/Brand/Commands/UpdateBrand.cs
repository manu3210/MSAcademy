using CarRentalsWebAPI.DTO;
using CarRentalsWebAPI.Interfaces;
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
            public UpdateBrandHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<BrandDto> Handle(UpdateBrand request, CancellationToken cancellationToken)
            {
                var brand = await _brandService.UpdateAsync(request.Id, BrandDto.DtoToEntity(request.Brand));
                return (brand == null) ? null : new BrandDto(brand);
            }
        }
    }

}
