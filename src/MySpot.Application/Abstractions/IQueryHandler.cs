namespace MySpot.Application.Abstractions;

public interface IQueryHandler<in TQuery, TResult> where TQuery: class, IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}