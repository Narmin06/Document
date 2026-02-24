using AcceptanceDocuments.Business.Services.Implements;
using AcceptanceDocuments.Business.Services.Interfaces;
using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Implements;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.AddScoped<IDocumentFieldDefinitionRepository, DocumentFieldDefinitionRepository>();
builder.Services.AddScoped<IDocumentFieldValueRepository, DocumentFieldValueRepository>();
builder.Services.AddScoped<IDocumentTypeFieldDefinitionRepository, DocumentTypeFieldDefinitionRepository>();


builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddScoped<IDocumentFieldDefinitionService, DocumentFieldDefinitionService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
