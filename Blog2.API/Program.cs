using AutoMapper;
using Blog2.API.Contracts;
using Blog2.API.Contracts.Services;
using Blog2.API.Contracts.Services.IServises;
using Blog2.API.Data.Models;
using Blog2.API.Data.Models.Response;
using Blog2.API.Data.Repositories;
using Blog2.API.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var filepath = Path.Combine(AppContext.BaseDirectory, "Blog2.API.xml");
    c.IncludeXmlComments(filepath);
});

// Connect AutoMapper
var mapperConfig = new MapperConfiguration((v) =>
{
    v.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

// Connect DataBase
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connection))
    .AddIdentity<User, Role>(opts =>
    {
        opts.Password.RequiredLength = 5;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequireLowercase = false;
        opts.Password.RequireUppercase = false;
        opts.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<BlogDbContext>();

// Services AddSingletons/Transient
builder.Services
    .AddSingleton(mapper)
    .AddTransient<ICommentRepository, CommentRepository>()
    .AddTransient<ITagRepository, TagRepository>()
    .AddTransient<IPostRepository, PostRepository>()
    .AddTransient<IAccountService, AccountService>()
    .AddTransient<ICommentService, CommentService>()
    .AddTransient<IPostService, PostService>()
    .AddTransient<ITagService, TagService>()
    .AddTransient<IRoleService, RoleService>();

builder.Services.AddAuthentication(optionts => optionts.DefaultScheme = "Cookies")
               .AddCookie("Cookies", options =>
               {
                   options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                   {
                       OnRedirectToLogin = redirectContext =>
                       {
                           redirectContext.HttpContext.Response.StatusCode = 401;
                           return Task.CompletedTask;
                       }
                   };
               });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
