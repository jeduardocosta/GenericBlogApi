namespace Generic.BlogAPI.Core.Entities
{
    public class Pagination
    {
        public int Limit { get; private set; }
        public int Offset { get; private set; }

        public Pagination(int limit, int offset)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}
