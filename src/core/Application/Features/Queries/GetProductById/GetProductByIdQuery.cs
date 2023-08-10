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

namespace Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery: IRequest<ServiceResponse<GetProductDetailViewModel>>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<GetProductDetailViewModel>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }
            public async Task<ServiceResponse<GetProductDetailViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await productRepository.GetByIdAsync(request.Id);

                var dto = mapper.Map<GetProductDetailViewModel>(product);

                return new ServiceResponse<GetProductDetailViewModel>(dto);
            }
        }
    }
}
