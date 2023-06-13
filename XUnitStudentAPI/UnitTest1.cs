using Microsoft.AspNetCore.Mvc;
using Student.API.Controllers;
using Student.API.Service;
using Student.API.Service.Interface;
using Xunit;

namespace XUnitStudentAPI
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            var teste = new PropostaSolicitacaoProjetoController();
        }
    }
}