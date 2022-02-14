namespace Git.ViewModels.Repository
{
    public class AllRepositoriesViewModel
    {
        public string RepositoryId { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryOwner { get; set; }
        public string CreatedOn { get; set; }
        public int CommitCount { get; set; }
    }
}
