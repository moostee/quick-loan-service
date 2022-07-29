using QLS.Shared.Exceptions;

namespace QLS.Application.Exceptions;


public class DuplicateEntryException : ApplicationException
{
    public DuplicateEntryException(string message = "Duplicate entry") : base(message)
    {
    }
}


public class NotFoundException : ApplicationException
{
    public NotFoundException(string message) : base($"{message}")
    {
    }
}


