using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using UserAuthentication.Authentication;

namespace UserAuthentication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IConfiguration _configuration;

		public AuthenticationController( UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager, IConfiguration configuration)
		{ 
			this.userManager = userManager;
			this.roleManager = roleManager;
			_configuration = configuration;
		}
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterModel model)
		{
			var userExist = await userManager.FindByNameAsync(model.UserName);

			if (userExist == null)
				return StatusCode(StatusCodes.Status500InternalServerError, new Response
				{
					Status = "Error",
					StatusMessage = "user already exist"
				});
			ApplicationUser user = new ApplicationUser()
			{
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.UserName
			};

			var result = await userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response
				{
					Status = "Error",
					StatusMessage = "user creation Failed"
				});
			}

			return Ok(new Response
			{
				Status = "Success",
				StatusMessage = "user created Successfully"
			});

		}
	}
}
