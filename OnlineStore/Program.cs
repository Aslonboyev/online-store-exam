
using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.CategoryDTOs;
using OnlineStore.Service.DTOs.LocationDTOs;
using OnlineStore.Service.DTOs.ProductDTOs;
using OnlineStore.Service.Interfaces;
using OnlineStore.Service.Services;


LocationCreationDTO locationCreation = new LocationCreationDTO()
{
    Address = "Chilonzor 10",
    Name = "Golden",
    Region = Region.Qoraqalpogiston,
    WorkEndedAt = TimeOnly.MaxValue,
    WorkStartedAt = TimeOnly.MinValue
};
LocationCreationDTO locationCreation1 = new LocationCreationDTO()
{
    Address = "Chilonzor, Shuhrat",
    Name = "TT3",
    Region = Region.Fargona,
    WorkEndedAt = TimeOnly.MaxValue,
    WorkStartedAt = TimeOnly.MinValue
};
LocationCreationDTO locationCreation2 = new LocationCreationDTO()
{
    Address = " Shuhrat",
    Name = "Qatartol",
    Region = Region.Namangan,
    WorkEndedAt = TimeOnly.MaxValue,
    WorkStartedAt = TimeOnly.MinValue
};
LocationCreationDTO locationCreation3 = new LocationCreationDTO()
{
    Address = "7-kvartal Yunusobod",
    Name = "Big House",
    Region = Region.Navoi,
    WorkEndedAt = TimeOnly.MaxValue,
    WorkStartedAt = TimeOnly.MinValue
};

ILocationService locationService = new LocationService();

locationService.CreateAsync(locationCreation);

locationService.CreateAsync(locationCreation1);
locationService.CreateAsync(locationCreation2);
locationService.CreateAsync(locationCreation3);