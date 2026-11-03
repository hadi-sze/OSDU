using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace OSDU.Api;
public record LoginInput([Required, EmailAddress] string Email, [Required] string Password, bool RememberMe);
[ApiController]
[Route("api/auth")]
public class AuthController(SignInManager<IdentityUser> signIn, UserManager<IdentityUser> users) : ControllerBase {
 [AllowAnonymous, HttpPost("login")]
 public async Task<IActionResult> Login(LoginInput input) {
  var user = await users.FindByEmailAsync(input.Email);
  if (user is null) return Unauthorized(new { message = "Invalid email or password." });
  var result = await signIn.PasswordSignInAsync(user, input.Password, input.RememberMe, lockoutOnFailure: true);
  return result.Succeeded ? Ok(new { email = user.Email }) : Unauthorized(new { message = "Invalid email or password, or account temporarily locked." });
 }
 [HttpGet("me")]
 public IActionResult Me() => Ok(new { email = User.Identity!.Name });
 [HttpPost("logout")]
 public async Task<IActionResult> Logout() { await signIn.SignOutAsync(); return NoContent(); }
}
