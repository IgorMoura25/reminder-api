using Xunit;
using IgorMoura.Reminder.DAL.SqlServer;
using IgorMoura.Util.Data.DbConnectors;
using IgorMoura.Reminder.Models.DataObjects.Reminder;

namespace IgorMoura.Reminder.ApiTest.ReminderHandler
{
    public class ReminderHandlerTest
    {
        private readonly Services.Handlers.ReminderHandler _reminderHandler = new
            Services.Handlers.ReminderHandler(new ReminderSqlServerDao(new SqlServerConnector(TestConfiguration.ConnectionString)));

        [Fact]
        public void GetReminderById_ValidGetReminderByIdRequestModel_ResponseModelNotNull()
        {
            //Arrange
            //Act
            var responseModel = _reminderHandler.GetReminderById(new GetReminderByIdRequestModel()
            {
                ReminderId = 1
            });

            //Assert
            Assert.True(responseModel != null, "Response model was null");
        }
    }
}
