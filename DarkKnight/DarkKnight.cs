using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public struct Location
    {
        int x, y;
        public Location(int gx, int gy)
        {
            x = gx;
            y = gy;
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
    }




    struct node
    {
        public int color;
        public int distance;

    }


    public static class DarkKnight
    {




        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given the dimention of the board and the current location of the DarkKnight, calculate the min number of moves to reach the given target or return -1 if can't be reach ed
        /// </summary>
        /// <param name="N">board dimension</param>
        /// <param name="src">current location of the DarkKnight</param>
        /// <param name="target">target location</param>
        /// <returns>min number of moves to reach the target OR -1 if can't reach the target</returns>
        public static int Play(int N, Location src, Location target)
        {
           
            int x_target = target.X;
            int y_target = target.Y;

            if (src.X == x_target && src.Y == y_target)
                return 0;





            node[,] bord = new node[N+1, N+1];
            // 0 white
            //  1 grey



            Queue<Location> Q = new Queue<Location>();
            Q.Enqueue(src);


            while (Q.Count > 0)
            {
                Location u = Q.Dequeue();
                int uX = u.X;
                int uY = u.Y;

                // find neighbours of point u 
                List<Location> neighbours = new List<Location>();
                
                if(uX < x_target)
                {
                    if (uX + 1 <= N)
                    {
                        if (uY + 2 <= N)
                            neighbours.Add(new Location(uX + 1, uY + 2));

                        if (uY - 2 > 0)
                            neighbours.Add(new Location(uX + 1, uY - 2));
                    }
                }
        
                if(uX > x_target)
                {
                    if (uX - 1 > 0)
                    {
                        if (uY + 2 <= N)
                            neighbours.Add(new Location(uX - 1, uY + 2));

                        if (uY - 2 > 0)
                            neighbours.Add(new Location(uX - 1, uY - 2));
                    }
                }
         


                foreach (var node in neighbours)
                {
                    int x = node.X;
                    int y = node.Y;



                    if (bord[x, y].color == 0)
                    {
                        bord[x, y].color = 1;
                        bord[x, y].distance = bord[uX, uY].distance + 1;
                        Q.Enqueue(node);

                    }


                    if (x == x_target && y == y_target)
                    {
 

                        return bord[x, y].distance;
                                            
                    }

                }




            }



            return -1;
        }
        #endregion
    }
}
