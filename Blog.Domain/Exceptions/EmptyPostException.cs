namespace Blog.Domain.Exceptions
{
    public class EmptyPostException : Exception
    {
        public EmptyPostException() : base("Post cannot be empty")
        {
        }
    }
}