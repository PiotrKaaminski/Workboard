using Core.Domain.Task.Services;
using Core.Domain.Task.Services.Impl;
using Workboard.Services.Task;
using Workboard.Services.Task.Impl;
using Workboard.Services.TaskStatus;
using Workboard.Services.TaskStatus.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITaskStatusService, TaskStatusService>();

builder.Services.AddScoped<IAddTaskService, AddTaskService>();
builder.Services.AddScoped<IDeleteTaskService, DeleteTaskService>();
builder.Services.AddScoped<IGetTasksService, GetTasksService>();
builder.Services.AddScoped<IModifyTaskService, ModifyTaskService>();
builder.Services.AddScoped<ITaskFacade, TaskFacade>();


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