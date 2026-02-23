using AcceptanceDocuments.Business.Services.Implements;
using AcceptanceDocuments.Business.Services.Interfaces;
using AcceptanceDocuments.Dal.Data;
using AcceptanceDocuments.Dal.Repositories.Implements;
using AcceptanceDocuments.Dal.Repositories.Interfaces;
using AcceptanceDocuments.Domain.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Documentt>, Repository<Documentt>>();
builder.Services.AddScoped<IRepository<DocumentType>, Repository<DocumentType>>();
builder.Services.AddScoped<IRepository<DocumentFieldDefinition>, Repository<DocumentFieldDefinition>>();
builder.Services.AddScoped<IRepository<DocumentFieldValue>, Repository<DocumentFieldValue>>();
builder.Services.AddScoped<IRepository<DocumentTypeFieldDefinition>, Repository<DocumentTypeFieldDefinition>>();


builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddScoped<IDocumentFieldValueService, DocumentFieldValueService>();
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
