using Hackathon_Best_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMyDependencyGroup();
builder.Services.AddCors(options => options.AddPolicy(name: "FrontendUI",

    policy =>

    {

        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();

    }

));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("FrontendUI");
app.UseAuthorization();

app.MapControllers();

app.Run();
