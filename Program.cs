using Microsoft.EntityFrameworkCore;
using LuxuryHotel.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// --- ĐĂNG KÝ DBCONTEXT TẠI ĐÂY ---
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();