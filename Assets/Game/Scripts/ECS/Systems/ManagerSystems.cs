using System.Collections.Generic;

namespace Game.ECS
{
    public class ManagerSystems
    {
        private readonly List<ManagerMono> _monos = new List<ManagerMono>();
        
        public void Add(ManagerMono mono)
        {
            _monos.Add(mono);
        }
        
        public void Start()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].Start();
            }
        }
        
        public void Run()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].Update();
            }
        }
        
        public void FixedRun()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].FixedUpdate();
            }
        }
        
        public void LateRun()
        {
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].LateUpdate();
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
            for (int i = 0; i < _monos.Count; i++)
            {
                _monos[i].Destroy();
            }
            _monos.Clear();
        }
    }
}