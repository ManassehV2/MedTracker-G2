using Castle.DynamicProxy;
using FakeItEasy;
using FluentAssertions;
using MedAdvisor.Api.Controllers;
using MedAdvisor.Api.DataClass;
using MedAdvisor.DataAccess.MySql;
using MedAdvisor.DataAccess.MySql.Repositories;
using MedAdvisor.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedAdvisor.API.Test.ControllerTests
{
    public class DiagnosisControllerTest
    {
        private readonly UserDiagnosisRepository _repo;
        public DiagnosisControllerTest() { 
            _repo = A.Fake<UserDiagnosisRepository>();
        
        }

        [Fact]
        public void DiagnosisController_GetDiagnosis_ReturnOk()
        {
            string Authorization = A.Fake<String>();
            int userid = 0;
             A.CallTo(() => UserFromToken.getId(Authorization)).Returns(userid);

            ICollection<Diagnosis> result = A.Fake<ICollection<Diagnosis>>();
            var controller = new DiagnosisController(_repo);

            var diagnosisResult = controller.GetDiagnosis(Authorization);

            diagnosisResult.Should().NotBeNull();
            diagnosisResult.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void DiagnosisController_AddDiagnosis()
        {
            var data = A.Fake<DiagnosisData>();
            string Authorization = A.Fake<String>();
            int userid = 0;
            A.CallTo(() => UserFromToken.getId(Authorization)).Returns(userid);
            A.CallTo(() => _repo.AddDiagnosis(userid, data.diagnosisId)).Returns(true);
            var controller = new DiagnosisController(_repo);

            var add_result = controller.AddDiagnosis(data,Authorization);

            add_result.Should().NotBeNull();


        }

        [Fact]
        public void DiagnosisController_DeleteDiagnosis()
        {
            var data = A.Fake<DiagnosisDeleteData>();
            string Authorization = A.Fake<String>();

            int userid = 0;
            A.CallTo(() => UserFromToken.getId(Authorization)).Returns(userid);
            A.CallTo(() => _repo.RemoveDiagnoses(userid, data.diagnosisId)).Returns(true);
            var controller = new DiagnosisController(_repo);

            var delete_result  = controller.DeleteDiagnosis(data,Authorization);

            delete_result.Should().NotBeNull();


        }
    }
}
