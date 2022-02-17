namespace CarShop.Services.Contracts
{
    using CarShop.ViewModels.Issues;
    using System.Collections.Generic;

    public interface IIssueService
    {
        CarIssueViewModel GetCarIssues(string carId);
        List<string> AddNewIssue(IssueFormViewModel model, string carId);
        string FixIssue(string issueId, string carId, string userId);
        string DeleteIssue(string issueId, string carId, string userId);
    }
}
