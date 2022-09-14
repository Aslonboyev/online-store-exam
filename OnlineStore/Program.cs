
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.CategoryDTOs;
using OnlineStore.Service.DTOs.LocationDTOs;
using OnlineStore.Service.DTOs.ProductDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;


ProductCreationDTO productCreation1 = new ProductCreationDTO()
{
    Name = "Lambarghini",
    Description="Dunyodagi eng tez manishalardan",
    ImagePath = @"..\..\OnlineStore.Data\Images\CarPhoto.jpg",
    CategoryId = 1,
    Price = 500000,
    ProductParameter = ProductParameter.Piece,
    Quantity = 5, 
};

ProductCreationDTO productCreation2 = new ProductCreationDTO()
{
    Name = "BMW",
    Description = "Dunyodagi eng zo'r manishalardan",
    ImagePath = @"..\..\OnlineStore.Data\Images\Car1.jpg",
    CategoryId = 1,
    Price = 400000,
    ProductParameter = ProductParameter.Piece,
    Quantity = 15,
};
ProductCreationDTO productCreation3 = new ProductCreationDTO()
{
    Name = "Mers",
    Description = "Dunyodagi eng tez manishalardan",
    ImagePath = @"..\..\OnlineStore.Data\Images\Car2.jpg",
    CategoryId = 1,
    Price = 100000,
    ProductParameter = ProductParameter.Piece,
    Quantity = 50,
};
ProductCreationDTO productCreation4 = new ProductCreationDTO()
{
    Name = "Go'sht",
    Description = "Pishirilgan go'sht",
    ImagePath = @"..\..\OnlineStore.Data\Images\Ghosjt(P).jpg",
    CategoryId = 2,
    Price = 100000,
    ProductParameter = ProductParameter.Kg,
    Quantity = 5,
};
ProductCreationDTO productCreation5 = new ProductCreationDTO()
{
    Name = "Bentle",
    Description = "Dunyodagi eng qimmat mashinalardan biri",
    ImagePath = @"..\..\OnlineStore.Data\Images\Car3.jpg",
    CategoryId = 1,
    Price = 1000000,
    ProductParameter = ProductParameter.Piece,
    Quantity = 5,
};
ProductCreationDTO productCreation6 = new ProductCreationDTO()
{
    Name = "Humburger",
    Description = "Issiq yaxshi pishgan)",
    ImagePath = @"..\..\OnlineStore.Data\Images\Humburger.jpg",
    Price = 20000,
    CategoryId = 2,
    ProductParameter = ProductParameter.Piece,
    Quantity = 5
};
ProductCreationDTO productCreation7 = new ProductCreationDTO()
{
    Name = "IPhone 14",
    Description = "Narxiga arzimaydigan telefon",
    ImagePath = @"..\..\OnlineStore.Data\Images\IPhone.jpg",
    Price = 10000000,
    ProductParameter = ProductParameter.Piece,
    CategoryId = 3,
    Quantity = 100,
};
ProductCreationDTO productCreation8 = new ProductCreationDTO()
{
    Name = "KFC",
    Description = "Bir odam kochadan topgan",
    ImagePath = @"..\..\OnlineStore.Data\Images\KFC.jpg",
    Price = 20000,
    ProductParameter = ProductParameter.Piece,
    CategoryId = 2,
    Quantity = 50,
};

ProductCreationDTO productCreation9 = new ProductCreationDTO()
{
    Name = "Sumsung",
    Description = "Narxi olsa boladigan telefonlardan",
    ImagePath = @"..\..\OnlineStore.Data\Images\Sumsung.jpg",
    Price = 1000000,
    ProductParameter = ProductParameter.Piece,
    CategoryId = 3,
    Quantity = 12,
};
ProductCreationDTO productCreation10 = new ProductCreationDTO()
{
    Name = "TV",
    Description = "Yaxshi menga yoqdi",
    ImagePath = @"..\..\OnlineStore.Data\Images\TV.jpg",
    Price = 1000000,
    ProductParameter = ProductParameter.Piece,
    CategoryId = 3,
    Quantity = 50,
};
ProductCreationDTO productCreation11 = new ProductCreationDTO()
{
    Name = "Televezor",
    Description = "Olsa boladi",
    ImagePath = @"..\..\OnlineStore.Data\Images\TV1.jpg",
    Price = 2000000,
    ProductParameter = ProductParameter.Piece,
    CategoryId = 3,
    Quantity = 5,
};


IProductService productService = new ProductService();

await productService.CreateAsync(productCreation1);

await productService.CreateAsync(productCreation2);
await productService.CreateAsync(productCreation3);
await productService.CreateAsync(productCreation4);
await productService.CreateAsync(productCreation5);
await productService.CreateAsync(productCreation6);
await productService.CreateAsync(productCreation7);
await productService.CreateAsync(productCreation8);
await productService.CreateAsync(productCreation9);
await productService.CreateAsync(productCreation11);
