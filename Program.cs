using AutoStore.DTOs;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


builder.Services.AddEndpointsMetadataProviderApiExplorer(); 

app.MapGet("/", () => "Hello World!");


app.Run();
