namespace CarShop.Controllers
{
    using CarShop.Services.Contracts;
    using CarShop.ViewModels.Issues;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class IssuesController : Controller
    {
        private readonly IIssueService IssueService;

        public IssuesController(IIssueService issueService)
        {
            IssueService = issueService;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId) 
        {
            var issues = IssueService.GetCarIssues(carId);

            return this.View(issues);
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId) 
        {
           var result = IssueService.FixIssue(issueId, carId, this.User.Id);

            if (!string.IsNullOrEmpty(result) || !string.IsNullOrWhiteSpace(result))
            {
                return Error(result);
            }

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            var result = IssueService.DeleteIssue(issueId, carId, this.User.Id);

            if (!string.IsNullOrEmpty(result) || !string.IsNullOrWhiteSpace(result))
            {
                return Error(result);
            }

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            return this.View(new IssueFormViewModel { CarId = carId});
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(IssueFormViewModel model,string carId)
        {
            var errors = IssueService.AddNewIssue(model, carId);

            if (errors.Count != 0)
            {
                return Error(errors);
            }
            
            return Redirect($"/Issues/CarIssues?carId={carId} ");
        }
    }
}
