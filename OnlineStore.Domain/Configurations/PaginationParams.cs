namespace StoreProject.Domain.Configurations
{
    public class PaginationParams
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int SkipCount
        {
            get
            {
                return PageSize * (PageIndex - 1);
            }
        }
    }
}
