namespace MarcakiService.Domain.Exceptions;

public class AggregateMismatchException : Exception
{
    public AggregateMismatchException(string msg) : base(msg)
    {
    }
}