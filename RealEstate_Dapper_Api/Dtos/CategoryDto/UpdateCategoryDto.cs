﻿namespace RealEstate_Dapper_Api.Dtos.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }
}
