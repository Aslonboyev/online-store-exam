
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.CategoryDTOs;
using OnlineStore.Service.DTOs.LocationDTOs;
using OnlineStore.Service.DTOs.ProductDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;


LocationCreationDTO productCreation1 = new LocationCreationDTO()
{
    Name = "TT3",
    Address = "Chilonzor",
    Region = Region.Namangan,
    WorkEndedAt = TimeOnly.MaxValue,
    WorkStartedAt = TimeOnly.MinValue,
};

LocationCreationDTO productCreation2 = new LocationCreationDTO()
{
    Name = "BMW",
    Address = "Yunosobod 7-kv",
    Region = Region.Sirdaryo,
    WorkEndedAt = TimeOnly.MaxValue,
    WorkStartedAt = TimeOnly.MinValue,
};
LocationCreationDTO productCreation3 = new LocationCreationDTO()
{
    Name = "Mers",
    Address = "Olmazor 6-kv",
    Region = Region.Fargona,
    WorkEndedAt = TimeOnly.MaxValue,
    WorkStartedAt = TimeOnly.MinValue,
};
LocationCreationDTO productCreation4 = new LocationCreationDTO()
{
    Name = "Shuhrat",
    Address = "Bunyodkor statidion",
    Region = Region.Qoraqalpogiston,
    WorkEndedAt = TimeOnly.MaxValue,
    WorkStartedAt = TimeOnly.MinValue,
};
LocationCreationDTO productCreation5 = new LocationCreationDTO()
{
    Name = "Bentle",
    Address = "Rayhon choraha 7-kv",
    Region = Region.Sirdaryo,
    WorkEndedAt = TimeOnly.MaxValue,
    WorkStartedAt = TimeOnly.MinValue,
};

ILocationService locationService = new LocationService();

await locationService.CreateAsync(productCreation1);

await locationService.CreateAsync(productCreation2);
await locationService.CreateAsync(productCreation3);
await locationService.CreateAsync(productCreation4);
await locationService.CreateAsync(productCreation5);