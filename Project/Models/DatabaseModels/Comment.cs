namespace Project.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentData { get; set; }

        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
