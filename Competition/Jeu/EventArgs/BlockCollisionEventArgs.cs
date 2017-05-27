using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.Jeu.EventArgs
{
    public class BlockCollisionEventArgs
    {
        public int X;
        public int Y;
        public List<CollisionInfo> Info;

        public BlockCollisionEventArgs(int x, int y, List<CollisionInfo> colInfo)
        {
            X = x;
            Y = y;
            Info = colInfo;
        }
    }
}
