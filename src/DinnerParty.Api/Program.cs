using DinnerParty.Api.Errors;
using DinnerParty.Application;
using DinnerParty.Application.Services;
using DinnerParty.Contracts.Dinner;
using DinnerParty.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
        {
            c.Authority = builder.Configuration["Auth0Settings:Domain"];
            c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidAudience = builder.Configuration["Auth0Settings:Audience"],
                ValidIssuer = builder.Configuration["Auth0Settings:Domain"]
            };
        });

    builder.Services
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddSingleton<ProblemDetailsFactory, DinnerPartyProblemDetailsFactory>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");

    app.Map(
        "/error",
        (HttpContext httpContext) =>
        {
            Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            return Results.Problem(title: exception?.Message);
        }
    );

    app.MapPost("/dinner",
        async (
            IDinnerService dinnerService,
            [FromBody] DinnerRequest dinnerRequest) =>
        {
            var apiResponse = await dinnerService.Create(dinnerRequest.Description, dinnerRequest.Location, dinnerRequest.Date);

            return Results.Ok(apiResponse);
        });

    app.MapGet("/dinner/{id}",
        async (
            IDinnerService dinnerService,
            [FromRoute] Guid id) =>
        {
            var apiResponse = await dinnerService.GetById(id);

            return Results.Ok(apiResponse);
        });

    app.UseHttpsRedirection();

    app.UseAuthentication();
    // app.UseAuthorization();

    app.Run();
}