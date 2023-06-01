using System.ComponentModel.DataAnnotations;

namespace MyModels
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} must be less than {1}")]
        public string Title { get; set; } = null!;  // 驚嘆號表示: 暫時為空值，初始化一定會有初值
        [Range(10,500, ErrorMessage ="{0} must be between {1} - {2}")]
        public int Price { get; set; }
        public DateTime PublishDate { get; set; }
        public bool InStock { get; set; }
        public string? Description { get; set; }    // ?: 代表可為空值

        [Range(1, int.MaxValue, ErrorMessage = "{0} must be between {1} - {2}")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } = null!;
    }
}
