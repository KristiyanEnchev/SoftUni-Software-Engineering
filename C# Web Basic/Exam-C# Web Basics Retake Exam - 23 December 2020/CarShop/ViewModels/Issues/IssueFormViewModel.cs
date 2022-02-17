namespace CarShop.ViewModels.Issues
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstrants.Issue;
    public class IssueFormViewModel
    {
        [MinLength(DescriptionMinLenght, ErrorMessage = "Description shoud be longer than that, please be explicit")]
        public string Description { get; set; }

        public string CarId { get; set; }
    }
}
