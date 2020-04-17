using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdminPro.Core.Entities;
using AdminPro.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AdminPro.Api.Configurations.Middlewares
{
    public class NewUserMiddleware
    {
        private readonly RequestDelegate _next;

        public NewUserMiddleware(RequestDelegate next)
        {
            _next = next;
            //_userRepository = userRepository;
        }

        public async Task Invoke(HttpContext context, IAsyncRepository<User> userRepository)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            var email = claimsIdentity.FindFirst("emails")?.Value;
            var name = claimsIdentity.FindFirst("name")?.Value;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(name))
            {
                var user = await userRepository.GetAsync(x => x.Email == email);

                if (!user.Any())
                {
                    var userNew = new User
                    {
                        Email = email,
                        Name = name
                    };
                    await userRepository.AddAsync(userNew);
                }
            }

            await _next.Invoke(context);
        }
    }
}
