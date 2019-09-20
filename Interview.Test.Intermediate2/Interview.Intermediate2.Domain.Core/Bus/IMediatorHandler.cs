using Interview.Intermediate2.Domain.Core.Events;
using System.Threading.Tasks;

namespace Interview.Intermediate2.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
