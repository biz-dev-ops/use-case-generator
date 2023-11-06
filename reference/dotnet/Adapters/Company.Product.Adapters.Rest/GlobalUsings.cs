global using Company.Product.Adapters.Rest.Attributes;
global using Company.Product.Adapters.Rest.Models;
global using Company.Product.Domain.UseCases;

global using System.ComponentModel.DataAnnotations;
global using System.Reflection;
global using System.Text.Json.Serialization;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.OpenApi.Models;
global using Microsoft.Extensions.Hosting;
global using Swashbuckle.AspNetCore.SwaggerGen;