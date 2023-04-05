using System.Collections.Generic;

namespace Game.ECS
{
    public class RunSystems
    {
        private readonly List<RunMono> _monos = new List<RunMono>();

        public RunSystems(){}

        public void Add(RunMono mono)
        {
            _monos.Add(mono);
        }
        
        public void Run()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].Update();
            }
        }

        public void Stop()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].Stop();
            }
        }

        public void Continue()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].Continue();
            }
        }

        public void Destroy()
        {
            _monos.Clear();
        }
    }
}