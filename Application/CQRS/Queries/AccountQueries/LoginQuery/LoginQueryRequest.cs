using System;
using MediatR;

namespace Application.CQRS.Queries.AccountQueries.LoginQuery
{
    public class LoginQueryRequest : IRequest<LoginQueryResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

