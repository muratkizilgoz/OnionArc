using System;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Queries.AccountQueries.LoginQuery
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, LoginQueryResponse>
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginQueryHandler(ITokenService tokenService, UserManager<ApplicationUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }


        public async Task<LoginQueryResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByEmailAsync(request.Email);
            if (appUser == null) return new LoginQueryResponse { Status = false, Message = "User not found" };

            var result = await _userManager.CheckPasswordAsync(appUser, request.Password);
            if (result)
            {
                var token = await _tokenService.CreateTokenAsync(appUser);
                return new LoginQueryResponse { Status = true, Token = token };
            }
            return new LoginQueryResponse { Status = false, Message = "error" };
        }
    }
}

