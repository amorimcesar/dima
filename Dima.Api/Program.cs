var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
builder.Services.AddTransient<Handler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost(
    "/v1/transactions", 
    (Request request, Handler handler) => handler.Handle(request))
    .Produces<Respoonse>();

app.Run();

public class Request
{
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Type { get; set; }
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string  UserId { get; set; } = string.Empty;
}

public class Respoonse
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
}

public class Handler
{
    public Respoonse Handle(Request request)
    {
        return new Respoonse()
        {
            Id = 4,
            Title = request.Title,
        };
    }
}