
using Moq;
using MovieRental.Application.Persistence.Infrastructure;
using MovieRental.Application.Pesistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.UnitTests.Mocks
{
    public class MockEmailService
    {
        public static Mock<IEmailSender> GetEmailServiceMock()
        {

            var mockRepo = new Mock<IEmailSender>();

            // Agregar una
            mockRepo.Setup(r => r.SendEmail(new Models.Email())); 

            return mockRepo;
        }
    }

}
