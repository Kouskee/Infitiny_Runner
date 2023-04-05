using System.Threading;
using System.Threading.Tasks;

namespace Game.ECS
{
    public interface ITaskSingleMono
    {
        public Task Start(CancellationToken token);
        public void Destroy();
    }
}