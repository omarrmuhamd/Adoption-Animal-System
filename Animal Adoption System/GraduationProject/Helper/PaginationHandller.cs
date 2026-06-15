namespace GraduationProject.Helper
{
    public class PaginationHandller <T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public IReadOnlyList<T> Data { get; set; }

        public int Count { get; set; }

        public PaginationHandller(int pageindex , int pagesize, IReadOnlyList<T> data , int count)
        {
            
            PageSize = pagesize;
            PageIndex = pageindex;
            Data = data;
            Count = count;
        }
    }
}
