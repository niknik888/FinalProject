using Blog2.DAL.Models;
using Blog2.DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Blog2.BLL;
using Blog2.DAL.Repositories.IRepositories;
using Blog2.DAL.Repositories;
using NLog.Web;
using Blog2.BLL.Services.IServices;
using Blog2.BLL.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var mapperConfig = new MapperConfiguration((v) =>{
    v.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Blog2DbContext>(options => options.UseSqlServer(connection))
    .AddIdentity<User, Role>(opts =>
    {
        opts.Password.RequiredLength = 6;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequireLowercase = false;
        opts.Password.RequireUppercase = false;
        opts.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<Blog2DbContext>();

builder.Services
                .AddSingleton(mapper)
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ITagRepository, TagRepository>()
                .AddTransient<IPostRepository, PostRepository>()
                .AddTransient<IAccountService, AccountService>()
                .AddTransient<ICommentService, CommentService>()
                .AddTransient<IHomeService, HomeService>()
                .AddTransient<IPostService, PostService>()
                .AddTransient<ITagService, TagService>()
                .AddTransient<IRoleService, RoleService>();

builder.Logging
                .ClearProviders()
                .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
                .AddConsole()
                .AddNLog("nlog");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
