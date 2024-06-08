using System.Net.Mime;
using AlquilaFacilPlatform.IAM.Application.Internal.CommandServices;
using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.IAM.Domain.Model.Commands;
using AlquilaFacilPlatform.IAM.Domain.Model.Queries;
using AlquilaFacilPlatform.IAM.Domain.Services;
using AlquilaFacilPlatform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using AlquilaFacilPlatform.IAM.Interfaces.REST.Resources;
using AlquilaFacilPlatform.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AlquilaFacilPlatform.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(
    IUserQueryService userQueryService,
    IUserCommandService userCommandService
    ) : ControllerBase
{
    
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user!);
        return Ok(userResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}