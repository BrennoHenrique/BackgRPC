using BackgRPC.Filters;
using BackgRPC.Protos;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace BackgRPC.Services
{
    public class AuthService : AuthProtoService.AuthProtoServiceBase
    {
        [UserAuthorization()]
        public override Task<AuthUserModel> AuthUser(AuthUserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AuthUserModel
            {
                Email = request.Email,
                Token = Guid.NewGuid().ToString()
            });
        }
    }
}