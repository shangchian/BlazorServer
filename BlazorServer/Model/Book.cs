namespace BlazorServer.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;  // 驚嘆號表示: 暫時為空值，初始化一定會有初值
        public int Price { get; set; }
        public DateTime PublishDate { get; set; }
        public bool InStock { get; set; }
        public string? Description { get; set; }    // ?: 代表可為空值
    }
}
