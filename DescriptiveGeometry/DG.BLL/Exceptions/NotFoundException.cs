namespace DG.BLL.Exceptions;

public class NotFoundException : Exception
{
    public int StatusCode { get; } = 404;

    public NotFoundException(): base(){}
    public NotFoundException(string message) : base(message) {}
}
