using MyApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICalculator, Calculator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapGet("/health", () => "OK");

app.Use(async (context, next) =>
{
	try
	{
		await next().ConfigureAwait(false);
	}
	catch (Exception ex)
	{
		context.Response.StatusCode = 500;
		await context.Response.WriteAsJsonAsync<object>(new
		{
			ex.Message
		}).ConfigureAwait(false);
	}
});

app.MapGet("/add", (int a, int b, ICalculator calc) => Results.Ok(calc.Add(a, b)));

app.MapGet("/sub", (int a, int b, ICalculator calc) => Results.Ok(calc.Sub(a, b)));

app.MapGet("/mul", (int a, int b, ICalculator calc) => Results.Ok(calc.Mul(a, b)));

app.Run();
