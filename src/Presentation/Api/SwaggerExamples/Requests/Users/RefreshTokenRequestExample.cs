﻿namespace Api.SwaggerExamples.Requests.Users
{
    using System;
    using Application.Users.Commands.Jwt.Refresh;
    using Swashbuckle.AspNetCore.Filters;

    public class RefreshTokenRequestExample : IExamplesProvider<JwtRefreshTokenCommand>
    {
        private const string ExampleToken =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxNDFlZjVlOS0wMmQ2LTQ2MTMtOGFmNS05NTE0NzM3YzI5YTEiLCJ1bmlxdWVfbmFtZSI6InRlc3RAdGVzdC5jb20iLCJuYmYiOjE1ODY3MDQ5ODEsImV4cCI6MTU4NzMwOTc4MSwiaWF0IjoxNTg2NzA0OTgxfQ.GTq2tA4KnCrBkcunnet5ijznq9Vy3NQJq1-znwz0vXI";

        public JwtRefreshTokenCommand GetExamples()
            => new JwtRefreshTokenCommand { Token = ExampleToken, RefreshToken = Guid.NewGuid() };
    }
}
