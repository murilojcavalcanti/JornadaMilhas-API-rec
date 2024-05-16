using JornadaMilhas.API.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Integration.Test.API
{
    public class JornadasMilhas_AuthTest
    {
        [Fact]
        public async Task Post_Efetua_Login_Com_Sucesso()
        {
            //Arrange
            var app = new JornadaMilhasWebApplicationFactory();
            var user = new UserDTO
            {
                Email = "tester@email.com",
                Password = "Senha123@"
            };
            using var client = app.CreateClient();
            //act
            var resultado = await client.PostAsJsonAsync("/auth-login", user);


            //assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);

        }
        [Fact]
        public async Task Post_Efetua_Login_Sem_Sucesso()
        {
            //Arrange
            var app = new JornadaMilhasWebApplicationFactory();
            var user = new UserDTO
            {
                Email = "tester@alura.com",
                Password = "Senha123"
            };
            using var client = app.CreateClient();
            //act
            var resultado = await client.PostAsJsonAsync("/auth-login", user);


            //assert
            Assert.Equal(HttpStatusCode.BadRequest, resultado.StatusCode);

        }
    }
}