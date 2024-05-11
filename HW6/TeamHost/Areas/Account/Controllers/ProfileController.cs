using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Interfaces;
using TeamHost.Queries.Profile.GetUserById;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
public class ProfileController : Controller
{
    private readonly IMediator _mediator;
    private readonly IUserContext _userContext;

    public ProfileController(
        IMediator mediator,
        IUserContext userContext)
    {
        _mediator = mediator;
        _userContext = userContext;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var currentUserId = _userContext.CurrentUserId;
        if (currentUserId is null)
            return View();
        
        var result = await _mediator.Send(new GetUserByIdQuery(currentUserId.Value));
        
        return View(result);
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult EditProfile()
    {
        return View();
    }

    public IActionResult Logout()
    {
        return RedirectToAction("Index", "Home", new { area = "Home" });
    }
}