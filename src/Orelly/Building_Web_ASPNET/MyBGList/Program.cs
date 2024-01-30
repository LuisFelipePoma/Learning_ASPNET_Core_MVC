var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// This add the OpenAPI document to the service collection
// We’re telling Swagger to resolve all conflicts related to duplicate routing handlers by always taking the first one found and ignoring the others. 
builder.Services.AddSwaggerGen(opts =>
	opts.ResolveConflictingActions(apiDesc => apiDesc.First())
	);
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Configuration.GetValue<bool>("UseSwagger"))
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
	app.UseDeveloperExceptionPage();
else
	app.UseExceptionHandler("/error");


app.UseHttpsRedirection();
// Minimal API
app.MapGet("/error", () => Results.Problem());
app.MapGet("/error/test", () => { throw new Exception("test"); });

// Controllers
app.MapControllers();

app.Run();
