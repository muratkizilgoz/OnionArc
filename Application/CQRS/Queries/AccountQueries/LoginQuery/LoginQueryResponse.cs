using System;
using Application.Models.Common;

namespace Application.CQRS.Queries.AccountQueries.LoginQuery
{
    public class LoginQueryResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}

