namespace CarShop.ViewModels.Issues
{
    using System.Collections.Generic;

    public class CarIssueViewModel
    {
        public string CarId { get; set; }
        public string CarModel { get; set; }
        public List<IssueViewModel> Issues { get; set; }
    }
}
