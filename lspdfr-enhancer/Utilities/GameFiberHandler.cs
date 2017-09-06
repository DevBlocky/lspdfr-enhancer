using System.Collections.Generic;
using Rage;

namespace LSPDFR_Enhancer.Utilities
{
    public class GameFiberHandler
    {
        public List<GameFiber> GameFibers => GameFibersPriv;
        private List<GameFiber> GameFibersPriv { get; set; }
        public int Count { get { return GameFibers.Count; } }

        public GameFiberHandler(List<GameFiber> gamefibers)
        {
            GameFibersPriv = gamefibers;
        }

        public List<string> GameFiberNames()
        {
            List<string> e = new List<string>();

            foreach (GameFiber gf in GameFibers)
            {
                e.Add(gf.Name);
            }

            return e;
        }
        public void RemoveGameFiber(GameFiber fiber)
        {
            GameFibers.Remove(fiber);
        }
        public void RemoveAllGameFibers()
        {
            foreach (GameFiber gf in GameFibers)
            {
                GameFibers.Remove(gf);
            }
        }
        public int ItemToIndex(GameFiber fiber)
        {
            return GameFibers.IndexOf(fiber);
        }
        public GameFiber IndexToItem(int index)
        {
            if (GameFibers.Count >= index)
            {
                return GameFibers[index];
            }
            return new GameFiber(() => { });
        }
        public int Duplicates()
        {
            if (GameFibers.Count == 0) return 0;

            int e = 0;

            for (int i = 0; i < GameFibers.Count; i++)
            {
                for (int x = 0; x < GameFibers.Count; x++)
                {
                    if (GameFibers[i] == GameFibers[x] && i != x)
                    {
                        e++;
                    }
                }
            }

            return e;
        }
        public void DeleteDuplicates()
        {
            if (Duplicates() == 0) return;

            for (int i = 0; i < GameFibers.Count; i++)
            {
                for (int x = 0; x < GameFibers.Count; x++)
                {
                    if (GameFibers[i] == GameFibers[x] && i != x)
                    {
                        GameFibers.Remove(GameFibers[x]);
                    }
                }
            }
        }
    }
}
