using Application.Dto;
using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery :IRequest<ServiceResponse<List<ProdcutViewDto>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProdcutViewDto>>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }
            public async Task<ServiceResponse<List<ProdcutViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await productRepository.GetAllAsync();

                var viewModel = mapper.Map<List<ProdcutViewDto>>(products);

                // var dto = products.Select(x => new ProdcutViewDto { id = x.Id, Name= x.Name}).ToList();

                return new ServiceResponse<List<ProdcutViewDto>>(viewModel);
            }
        }
    }
}
