namespace App.v1.Models;

public class Pagination
{
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalItems { get; set; }
}