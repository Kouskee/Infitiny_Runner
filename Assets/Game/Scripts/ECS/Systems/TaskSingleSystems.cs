using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Game.ECS
{
    public class TaskSingleSystems
    {
        private readonly List<ITaskSingleMono> _monos = new List<ITaskSingleMono>();

        public void Add(ITaskSingleMono mono)
        {
            _monos.Add(mono);
        }
        
        public async Task Start(CancellationToken token)
        {
            var tasks = new Task[_monos.Count];
            for (int i = 0; i < _monos.Count; i++)
            {
                tasks[i] = _monos[i].Start(token);
            }

            await Task.WhenAll(tasks);
        }
        
        public void Destroy()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].Destroy();
            }
            _monos.Clear();
        }
    }
}