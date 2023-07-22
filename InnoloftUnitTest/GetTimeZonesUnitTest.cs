using InnoloftWebAPI.Business.Abstract;
using InnoloftWebAPI.Business.Concrete;
using InnoloftWebAPI.Models;

namespace InnoloftUnitTest
{
    public class GetTimeZonesUnitTest
    {
        [Test]
        public void GetTimeZones_IsOkay_ResultWithWarning()
        {
            //Act
            ITimeZoneService service = new TimeZoneService(); 

            var result= service.GetTimeZones();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void GetTimeZones_ContainsCorrectTimeZoneProperties()
        {
            // Act
            ITimeZoneService service = new TimeZoneService();

            var result = service.GetTimeZones();

            // Assert
            foreach (TimeZoneModel model in result)
            {
                Assert.IsNotNull(model.Id);
                Assert.IsNotNull(model.DislplayName);
            }
        }
    }
}