﻿namespace Application.Users.Commands.Jwt
{
    using MediatR;

    public class GenerateJwtTokenCommand : IRequest<AuthSuccessResponse>
    {
        public GenerateJwtTokenCommand(string userId, string username)
        {
            this.UserId = userId;
            this.Username = username;
        }

        public string UserId { get; }

        public string Username { get; }
    }
}