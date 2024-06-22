using AlquilaFacilPlatform.Profiles.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Profiles.Domain.Model.Commands;
using TechTalk.SpecFlow;

namespace AlquilaFacilPlatform.Tests.AcceptanceTests.Steps;

[Binding]
public class ProfileSteps
{
     private Profile profile; 
     private Exception caughtException;

     [Given(@"a profile with the following details:")]
     public void GivenAProfileWithTheFollowingDetails(Table table)
     {
         var row = table.Rows[0]; 
         string name = row["Name"];
         string fatherName = row["FatherName"];
         string motherName = row["MotherName"];
         string dateOfBirth = row["DateOfBirth"];
         string documentNumber = row["DocumentNumber"];
         string phone = row["Phone"];
         int userId = int.Parse(row["UserId"]);

         profile = new Profile(name, fatherName, motherName, dateOfBirth, documentNumber, phone, userId);
     }

     [When(@"the administrator creates the profile")]
     public void WhenTheAdministratorCreatesTheProfile()
     {
     }

     [Then(@"the profile should be created successfully")]
     public void ThenTheProfileShouldBeCreatedSuccessfully()
     { 
         Assert.NotNull(profile);
     }

     [When(@"the administrator updates the profile with the following details:")]
     public void WhenTheAdministratorUpdatesTheProfileWithTheFollowingDetails(Table table)
     {
         var row = table.Rows[0];
         var updateCommand = new UpdateProfileCommand(
             row["Name"],
             row["FatherName"], 
             row["MotherName"], 
             row["DateOfBirth"],
             row["DocumentNumber"],
             row["Phone"],
             int.Parse(row["UserId"])
             ); 
         try
         { 
             profile.Update(updateCommand);
         }
         catch (Exception ex)
         {
             caughtException = ex;
         }
     }

     [Then(@"the profile details should be updated successfully")]
     public void ThenTheProfileDetailsShouldBeUpdatedSuccessfully()
     {
         Assert.Null(caughtException); 
     }

     [Then(@"an error should occur")]
     public void ThenAnErrorShouldOccur()
     {
         Assert.NotNull(caughtException);
     }

     [When(@"the administrator updates the profile with missing required fields:")]
     public void WhenTheAdministratorUpdatesTheProfileWithMissingRequiredFields(Table table)
     {
         var row = table.Rows[0];
         var updateCommand = new UpdateProfileCommand(
             row["Name"],
             row.ContainsKey("FatherName") ? row["FatherName"] : null,
             row.ContainsKey("MotherName") ? row["MotherName"] : null,
             row["DateOfBirth"],
             row.ContainsKey("DocumentNumber") ? row["DocumentNumber"] : null,
             row.ContainsKey("Phone") ? row["Phone"] : null,
             int.Parse(row["UserId"])
             );

         try
         {
             profile.Update(updateCommand);
         }
         catch (Exception ex)
         {
             caughtException = ex;
         }
     }
}