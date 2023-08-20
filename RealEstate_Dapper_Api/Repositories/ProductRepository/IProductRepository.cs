﻿using RealEstate_Dapper_Api.Dtos.ProductDto;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();

    }
}