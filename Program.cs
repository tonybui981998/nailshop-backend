using backend.Hubs;
using backend.IRepository;
using backend.Models.Data;
using backend.Properties;
using backend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
// ✅ Bật logging ra console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
     builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
     builder.Services.AddScoped<IStaffRepository ,StaffRepository>();
     builder.Services.AddScoped<IBookingRepository,BookingRepository>();
        builder.Services.AddScoped<IFeedBackRepository,FeedBackRepository>();
        builder.Services.AddScoped<ICustomerRequiredRepository,CustomerRequiredRepository>();
        builder.Services.AddScoped<IUserLoginRepository ,UserLoginRepository>();
             builder.Services.AddScoped< IPayrollHistoryRepository,PayrollHistoryRepository>();
                builder.Services.AddScoped< IClientBookingRepository,ClientBookingRepository>();
                builder.Services.AddScoped<IVoucherRepository,VoucherRepository>();
                builder.Services.AddScoped<IVoucherUsageRepository,VoucherUsageRepository>();
                builder.Services.AddScoped<IBookingConfirmRepository ,BookingConfirmRepository>();

     // cors
     

// Thêm CORS vào dịch vụ
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173","http://localhost:5174", "https://nailshopfontend.vercel.app") 
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                 .AllowCredentials();
        });
});
builder.Services.AddSignalR();
var app = builder.Build();
app.Use(async (context, next) =>
{
    Console.WriteLine($"🔥 Request đến API: {context.Request.Method} {context.Request.Path}");
    await next();
});
app.UseStaticFiles();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowReactFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<BookingHubs>("/bookingHub");
app.Run();


