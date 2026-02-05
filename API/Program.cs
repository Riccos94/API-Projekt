var builder = WebApplication.CreateBuilder(args);

// Controllers + SwaggerAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

// Detta måste finnas, annars får du exakt "No operations defined.Hej"
app.MapControllers();

app.Run();
