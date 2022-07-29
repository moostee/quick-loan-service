using MediatR;
using QLS.Application.Queries;

namespace QLS.Application.Contracts.Handlers
{
    public interface IQueryHandler<in TQuery, TResult> :
       IRequestHandler<TQuery, TResult>
       where TQuery : IQuery<TResult>
    {
    }
}
