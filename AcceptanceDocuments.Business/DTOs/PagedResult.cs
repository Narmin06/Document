namespace AcceptanceDocuments.Business.DTOs;

public class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; set; } = new List<T>();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; } // cari sehife nomresi
    public int PageSize { get; set; }  // 1 sehifedeki data sayi

    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);  // umumi sehife sayi
    public bool HasNextPage => PageNumber < TotalPages;
    public bool HasPreviousPage => PageNumber > 1;
}