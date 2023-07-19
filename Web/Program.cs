using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IPersonelDAL,EfPersonelDAL>();
builder.Services.AddSingleton<IPersonelService,PersonelManager>();

builder.Services.AddSingleton<IShiftDAL,EfShiftDAL>();
builder.Services.AddSingleton<IShiftService,ShiftManager>();

builder.Services.AddSingleton<IPersonelShiftsDAL,EfPersonelShiftsDAL>();
builder.Services.AddSingleton<IPersonelShiftService,PersonelShiftsManager>();

builder.Services.AddSingleton<IPersonelOvertimeDAL,EfPersonelOvertimeDAL>();
builder.Services.AddSingleton<IPersonelOvertimeService,PersonelOvertimeManager>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
