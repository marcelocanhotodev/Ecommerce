﻿using Ecommerce.Api._Endpoints_.Product;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Product;
using Ecommerce.Application.UseCases.Models;
using FastEndpoints;
using FluentValidation;
using System.Net;

namespace Ecommerce.Api._Endpoints_.Post.Product
{
    public class Endpoint : Endpoint<ProductCreateRequest, ProductCreateResponse>
    {

        private readonly ICreateProductUseCase _createProductUseCase;

        public Endpoint(ICreateProductUseCase createProductUseCase)
        {
            _createProductUseCase = createProductUseCase ?? throw new ArgumentNullException(nameof(createProductUseCase));
        }

        public override void Configure()
        {
            Post("product");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Create a product";
                s.Response<ProductCreateResponse>(200);
            });
        }

        public override async Task HandleAsync(ProductCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _createProductUseCase.ExecuteAsync(request, cancellationToken);
                await SendAsync(response);
            }
            catch (ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    AddError(error.ErrorMessage);
                }
                await SendErrorsAsync(400, cancellationToken);
            }
        }
    }
}
