using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CanteenSystemsApi.Areas.Identity;
using CanteenSystemsApi.Areas.Identity.Data;
using CanteenSystemsApi.Model;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Konfigurer adgang til Db - Identity & EF Core
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Default' not found.");
builder.Services.AddDbContext<CanteenSystemsApiContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#region Sikkerhed

/**
 * Denne sektion viser at der er klargjort til implementering af Identity som sikkerhedsudbyder.
 * Dog er dette out of scope til nuværende projekt, og vil derfor ikke implementeres yderligere.
 */

//Konfigurer Identity
builder.Services.AddScoped<TokenProvider>();
builder.Services.AddAuthenticationCore();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CanteenSystemsApiContext>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("User", policy => policy.RequireClaim("User"));
});
#endregion


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CanteenSystemsApiContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();


/**
 *  WebService ruter:
 *  Hver tilgang til webservicet kører gennem følgende ruter.
 *  Det er opdelt i ruter for at give et større helhedsbillede, hvilket automatisk giver større overblik. 
 *  Dette gør at det til enhver tid er nemt at tilføje nye ruter til servicet.
 */

#region Services
#region Users
RouteGroupBuilder User = app.MapGroup("/user");
User.MapGet("/", GetAllUser);
User.MapPost("/", CreateUser);
#endregion
#region RegisterBuffet
RouteGroupBuilder Buffet = app.MapGroup("/buffet");
Buffet.MapGet("/", GetAllRegister);
Buffet.MapPost("/", CreateRegister);
#endregion
#region Catering
RouteGroupBuilder Catering = app.MapGroup("/catering");
Catering.MapGet("/", GetAllCatering);
Catering.MapGet("/{id}", GetCatering);
Catering.MapPost("/", CreateCatering);
Catering.MapPut("/{id}", UpdateCatering);
Catering.MapDelete("/{id}", DeleteCatering);
#endregion
#region CateringCategory
RouteGroupBuilder CateringCategory = app.MapGroup("/cateringcategory");
CateringCategory.MapGet("/", GetAllCateringCategory);
CateringCategory.MapGet("/{id}", GetCateringCategory);
CateringCategory.MapPost("/", CreateCateringCategory);
CateringCategory.MapPut("/{id}", UpdateCateringCategory);
CateringCategory.MapDelete("/{id}", DeleteCateringCategory);
#endregion
#region Order
RouteGroupBuilder Order = app.MapGroup("/order");
Order.MapGet("/", GetAllOrder);
Order.MapGet("/{id}", GetOrder);
Order.MapPost("/", CreateOrder);
Order.MapPut("/{id}", UpdateOrder);
Order.MapDelete("/{id}", DeleteOrder);
#endregion
#region Item
RouteGroupBuilder Items = app.MapGroup("/items");
Items.MapGet("/", GetAllItem);
Items.MapGet("/{id}", GetItem);
Items.MapPost("/", CreateItem);
Items.MapPut("/{id}", UpdateItem);
Items.MapDelete("/{id}", DeleteItem);
#endregion
#region ItemGroup
RouteGroupBuilder ItemsGroup = app.MapGroup("/itemsgroup");
ItemsGroup.MapGet("/", GetAllItemGroup);
ItemsGroup.MapGet("/{id}", GetItemGroup);
ItemsGroup.MapPost("/", CreateItemGroup);
ItemsGroup.MapPut("/{id}", UpdateItemGroup);
ItemsGroup.MapDelete("/{id}", DeleteItemGroup);
#endregion
#region BuffetMenu
RouteGroupBuilder BuffetMenu = app.MapGroup("/buffetmenu");
BuffetMenu.MapGet("/", GetAllBuffetMenu);
BuffetMenu.MapGet("/{id}", GetBuffetMenu);
BuffetMenu.MapPost("/", CreateBuffetMenu);
BuffetMenu.MapPut("/{id}", UpdateBuffetMenu);
BuffetMenu.MapDelete("/{id}", DeleteBuffetMenu);
#endregion
#endregion



app.UseAuthentication();
app.UseAuthorization();
app.Run();

/**
 *  WebService metoder:
 */

#region ImportUsers
/**
 * Dette endpoint er brugt for at importere brugere til Auth tabellen,
 * der bruges til at tjekke adgangskort i PowerAppen.
 * Der er angivet et standard hashed password, blot for at vise at dette er muligt gennem Identity. - Til senere brug.
 */
static async Task<IResult> GetAllUser(CanteenSystemsApiContext context)
{
    return TypedResults.Ok(await context.Auths.ToListAsync());
}
static async Task<IResult> CreateUser(IdentityUser user, CanteenSystemsApiContext context)
{
    PasswordHasher<IdentityUser> passwordHasher = new();
    Auth auth = new()
    {
        Username = user.UserName,
        Password = passwordHasher.HashPassword(user, "VerdoKantinen#2023")
    };
    await context.Auths.AddAsync(auth);
    await context.SaveChangesAsync();
    return TypedResults.Created($"/userimport/{auth.Id}");
}
#endregion

#region RegisterBuffet
/**
 *  Dette er hovedfunktionen, og kernen i projektet.
 *  Formålet med dette er at medarbejderne kan registrere sig spisenede i kantinen.
 */
static async Task<IResult> GetAllRegister(CanteenSystemsApiContext context)
{
    return TypedResults.Ok(await context.BuffetRegistrations.ToListAsync());
}
static async Task<IResult> CreateRegister(BuffetRegistration buffetRegistration, CanteenSystemsApiContext context)
{
    await context.BuffetRegistrations.AddAsync(buffetRegistration);
    await context.SaveChangesAsync();
    return TypedResults.Created($"/buffetRegistration/{buffetRegistration.Id}");
}
#endregion

#region Item
/**
 *  Disse metoder definerer hvordan varerne bliver oprettet, ændret, slettet fra systemet.
 *  Her skal bemærkes at ItemGroupId har en løs forbindelse til ItemGroups, og det er op til brugeren af apiet, at sørge for at dette opfyldes korrekt.
 */
static async Task<IResult> GetAllItem(CanteenSystemsApiContext context)
{
    return TypedResults.Ok(await context.Items.ToListAsync());
}

static async Task<IResult> GetItem(int id, CanteenSystemsApiContext context)
{
    return await context.Items.FindAsync(id)
        is Item item
            ? TypedResults.Ok(item)
            : TypedResults.NotFound();
}

static async Task<IResult> CreateItem(Item item, CanteenSystemsApiContext context)
{
    await context.Items.AddAsync(item);
    await context.SaveChangesAsync();
    return TypedResults.Created($"/item/{item.Id}");
}

static async Task<IResult> UpdateItem(int id, Item item, CanteenSystemsApiContext context)
{
    var resultitem = await context.Items.FindAsync(id);
    if (resultitem is null) return TypedResults.NotFound();
    resultitem.Title = item.Title;
    resultitem.Description = item.Description;
    resultitem.Price = item.Price;
    resultitem.ItemGroup = item.ItemGroup;
    resultitem.Amount = item.Amount;
    resultitem.IsHidden = item.IsHidden;
    context.Items.Update(resultitem);
    await context.SaveChangesAsync();
    return TypedResults.NoContent();
}

static async Task<IResult> DeleteItem(int id, CanteenSystemsApiContext context)
{
    if (await context.Items.FindAsync(id) is Item item)
    {
        context.Items.Remove(item);
        await context.SaveChangesAsync();
        return TypedResults.Ok(item);
    }
    return TypedResults.NotFound();
}
#endregion

#region ItemGroups
/**
 *  Disse metoder definerer hvordan varegrupperne bliver oprettet, ændret, slettet fra systemet.
 */
static async Task<IResult> GetAllItemGroup(CanteenSystemsApiContext context)
{
    return TypedResults.Ok(await context.ItemsGroup.ToListAsync());
}

static async Task<IResult> GetItemGroup(int id, CanteenSystemsApiContext context)
{
    return await context.ItemsGroup.FindAsync(id)
        is ItemGroup ItemGroup
            ? TypedResults.Ok(ItemGroup)
            : TypedResults.NotFound();
}

static async Task<IResult> CreateItemGroup(ItemGroup ItemGroup, CanteenSystemsApiContext context)
{
    await context.ItemsGroup.AddAsync(ItemGroup);
    await context.SaveChangesAsync();
    return TypedResults.Created($"/ItemGroup/{ItemGroup.Id}");
}

static async Task<IResult> UpdateItemGroup(int id, ItemGroup ItemGroup, CanteenSystemsApiContext context)
{
    var resultItemGroup = await context.ItemsGroup.FindAsync(id);
    if (resultItemGroup is null) return TypedResults.NotFound();
    resultItemGroup.Title = ItemGroup.Title;
    await context.SaveChangesAsync();
    return TypedResults.NoContent();
}

static async Task<IResult> DeleteItemGroup(int id, CanteenSystemsApiContext context)
{
    if (await context.ItemsGroup.FindAsync(id) is ItemGroup ItemGroup)
    {
        context.ItemsGroup.Remove(ItemGroup);
        await context.SaveChangesAsync();
        return TypedResults.Ok(ItemGroup);
    }
    return TypedResults.NotFound();
}
#endregion

#region Catering
/**
 *  Disse metoder definerer hvordan der bestilles service.
 *  Her skal bemærkes at Category har en løs forbindelse til CateringsCategory, og det er op til brugeren af apiet, at sørge for at dette opfyldes korrekt.
 */
static async Task<IResult> GetAllCatering(CanteenSystemsApiContext context)
{
    return TypedResults.Ok(await context.Caterings.ToListAsync());
}

static async Task<IResult> GetCatering(int id, CanteenSystemsApiContext context)
{
    return await context.Caterings.FindAsync(id)
        is Catering Catering
            ? TypedResults.Ok(Catering)
            : TypedResults.NotFound();
}

static async Task<IResult> CreateCatering(Catering Catering, CanteenSystemsApiContext context)
 {
    await context.Caterings.AddAsync(Catering);
    await context.SaveChangesAsync();
    return TypedResults.Created($"/catering/{Catering.Id}");
}

static async Task<IResult> UpdateCatering(int id, Catering Catering, CanteenSystemsApiContext context)
{
    var resultitem = await context.Caterings.FindAsync(id);
    if (resultitem is null) return TypedResults.NotFound();
    resultitem.Id = Catering.Id;
    resultitem.UserId = Catering.UserId;
    resultitem.ReferenceNumber = Catering.ReferenceNumber;
    resultitem.MeetingRoom = Catering.MeetingRoom;
    resultitem.Category = Catering.Category;
    resultitem.Description = Catering.Description;
    resultitem.Amount = Catering.Amount;
    resultitem.Time = Catering.Time;
    context.Caterings.Update(resultitem);
    await context.SaveChangesAsync();
    return TypedResults.NoContent();
}

static async Task<IResult> DeleteCatering(int id, CanteenSystemsApiContext context)
{
    if (await context.Caterings.FindAsync(id) is Catering Catering)
    {
        context.Caterings.Remove(Catering);
        await context.SaveChangesAsync();
        return TypedResults.Ok(Catering);
    }
    return TypedResults.NotFound();
}
#endregion

#region CateringCategory
/**
 *  Disse metoder definerer hvordan CateringCategories bliver oprettet, ændret, slettet fra systemet.
 */
static async Task<IResult> GetAllCateringCategory(CanteenSystemsApiContext context)
{
    return TypedResults.Ok(await context.CateringsCategory.ToListAsync());
}

static async Task<IResult> GetCateringCategory(int id, CanteenSystemsApiContext context)
{
    return await context.CateringsCategory.FindAsync(id)
        is CateringCategory cateringCategory
            ? TypedResults.Ok(cateringCategory)
            : TypedResults.NotFound();
}

static async Task<IResult> CreateCateringCategory(CateringCategory cateringCategory, CanteenSystemsApiContext context)
{
    await context.CateringsCategory.AddAsync(cateringCategory);
    await context.SaveChangesAsync();
    return TypedResults.Created($"/item/{cateringCategory.Id}");
}

static async Task<IResult> UpdateCateringCategory(int id, CateringCategory cateringCategory, CanteenSystemsApiContext context)
{
    var resultitem = await context.CateringsCategory.FindAsync(id);
    if (resultitem is null) return TypedResults.NotFound();
    resultitem.Title = cateringCategory.Title;
    context.CateringsCategory.Update(resultitem);
    await context.SaveChangesAsync();
    return TypedResults.NoContent();
}

static async Task<IResult> DeleteCateringCategory(int id, CanteenSystemsApiContext context)
{
    if (await context.CateringsCategory.FindAsync(id) is CateringCategory cateringCategory)
    {
        context.CateringsCategory.Remove(cateringCategory);
        await context.SaveChangesAsync();
        return TypedResults.Ok(cateringCategory);
    }
    return TypedResults.NotFound();
}
#endregion

#region Order
/**
 *  Disse metoder definerer hvordan ordrer bliver oprettet, ændret, slettet fra systemet.
 *  Ordre er i dette projekt kun tilknyttet Terminal siden.
 */
static async Task<IResult> GetAllOrder(CanteenSystemsApiContext context)
{
    return TypedResults.Ok(await context.Orders.ToListAsync());
}

static async Task<IResult> GetOrder(int id, CanteenSystemsApiContext context)
{
    return await context.Orders.FindAsync(id)
        is Order Order
            ? TypedResults.Ok(Order)
            : TypedResults.NotFound();
}

static async Task<IResult> CreateOrder(Order Order, CanteenSystemsApiContext context)
{
    await context.Orders.AddAsync(Order);
    await context.SaveChangesAsync();
    return TypedResults.Created($"/Order/{Order.Id}");
}

static async Task<IResult> UpdateOrder(int id, Order Order, CanteenSystemsApiContext context)
{
    var resultOrder = await context.Orders.FindAsync(id);
    if (resultOrder is null) return TypedResults.NotFound();
    resultOrder.UserId = Order.UserId;
    resultOrder.Items = Order.Items;
    resultOrder.TotalPrice = Order.TotalPrice;
    await context.SaveChangesAsync();
    return TypedResults.NoContent();
}

static async Task<IResult> DeleteOrder(int id, CanteenSystemsApiContext context)
{
    if (await context.Orders.FindAsync(id) is Order Order)
    {
        context.Orders.Remove(Order);
        await context.SaveChangesAsync();
        return TypedResults.Ok(Order);
    }
    return TypedResults.NotFound();
}
#endregion

#region BuffetMenu
/**
 *  Disse metoder definerer hvordan buffetmenuen bliver oprettet, ændret, slettet fra systemet.
 */
static async Task<IResult> GetAllBuffetMenu(CanteenSystemsApiContext context)
{
    return TypedResults.Ok(await context.BuffetMenu.ToListAsync());
}

static async Task<IResult> GetBuffetMenu(int id, CanteenSystemsApiContext context)
{
    return await context.BuffetMenu.FindAsync(id)
        is BuffetMenu BuffetMenu
            ? TypedResults.Ok(BuffetMenu)
            : TypedResults.NotFound();
}

static async Task<IResult> CreateBuffetMenu(BuffetMenu BuffetMenu, CanteenSystemsApiContext context)
{
    await context.BuffetMenu.AddAsync(BuffetMenu);
    await context.SaveChangesAsync();
    return TypedResults.Created($"/BuffetMenu/{BuffetMenu.Id}");
}

static async Task<IResult> UpdateBuffetMenu(int id, BuffetMenu BuffetMenu, CanteenSystemsApiContext context)
{
    var resultBuffetMenu = await context.BuffetMenu.FindAsync(id);
    if (resultBuffetMenu is null) return TypedResults.NotFound();
    resultBuffetMenu.Title = BuffetMenu.Title;
    resultBuffetMenu.WeekNumber = BuffetMenu.WeekNumber;
    resultBuffetMenu.DayOfWeek = BuffetMenu.DayOfWeek;
    resultBuffetMenu.Year = BuffetMenu.Year;
    await context.SaveChangesAsync();
    return TypedResults.NoContent();
}

static async Task<IResult> DeleteBuffetMenu(int id, CanteenSystemsApiContext context)
{
    if (await context.BuffetMenu.FindAsync(id) is BuffetMenu BuffetMenu)
    {
        context.BuffetMenu.Remove(BuffetMenu);
        await context.SaveChangesAsync();
        return TypedResults.Ok(BuffetMenu);
    }
    return TypedResults.NotFound();
}
#endregion