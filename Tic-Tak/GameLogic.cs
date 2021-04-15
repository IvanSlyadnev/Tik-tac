using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tak
{
    class GameLogic
    {
        private int[,] matrix;
        private int mod, atack;
        private const int n = 3;
        private Random random = new Random();
        public GameLogic(int[,] matrix, int mod)
        {
            this.matrix = matrix;
            this.mod = mod;
            if (this.mod == 1) this.atack = 0;
            else this.atack = 1;
        }

        public int[] step(int level)
        {
            int[] cors = new int[2];

            if (level == 1)
            {
                cors = def(this.mod);
            }
            else if (level == 2)
            {
                cors = def(this.atack);
                if (cors[0] == -1) cors = def(this.mod);
            } else if (level == 3)
            {
                cors = def(this.atack);
                if (cors[0] == -1) cors = def(this.mod);
                if (cors[0] == -1)
                {
                    if (this.matrix[1, 1] == -1)
                    {
                        cors[0] = 1;
                        cors[1] = 1;
                    }
                    else cors = corner();//получаем  координаты свободных угловых
                }
            }

            return cors;
        }

        private int [] def(int val)
        {
            int[] cors = new int[2];
            int[,] enemys = init_enemy();
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (this.matrix[i, j] == val)
                    {
                        enemys[c, 0] = i;
                        enemys[c, 1] = j;
                        c++;
                    }
                }
            }
            if (c > 1)
            {
                for (int i = 0; i < c; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        int i1 = enemys[i, 0]; int j1 = enemys[i, 1];
                        int i2 = enemys[j, 0]; int j2 = enemys[j, 1];
                        if (neighbors(enemys[i, 0], enemys[i, 1], enemys[j,0], enemys[j, 1]))
                        {
                            cors[0] = freeField(i1,j1,i2,j2)[0];
                            cors[1] = freeField(i1, j1, i2, j2)[1];
                            if (matrix[cors[0], cors[1]] < 0) return cors;
                        }
                    }
                }
            }
            cors[0] = -1;
            cors[1] = -1;
            return cors;
        }

        

        private bool neighbors(int i1, int j1, int i2, int j2)
        {
            if (i1 == i2 && j1!=j2) return true;
            if (j1 == j2 && i1!= i2) return true;
            if (Math.Abs(i1 - i2) == 1 && Math.Abs(j1 - j2) == 1) return true;
            return false;
        }

        private int [] freeField (int i1, int j1, int i2, int j2)//координаты соседних значений
        {
            int[] cors = new int[2];
            if (i1 == i2)
            {
                cors[0] = i1;
                cors[1] = free(j1, j2);
            } else if (j1 == j2)
            {
                cors[0] = free(i1, i2);
                cors[1] = j1;
            } else
            {
                if (i1 == 1 && j1 == 1)
                {
                    if (i2 == 0) cors[0] = 2;
                    else cors[0] = 0;
                    if (j2 == 0) cors[1] = 2;
                    else cors[1] = 0;
                } else if (i2 == 1 && j2 == 1)
                {
                    if (i1 == 0) cors[0] = 2;
                    else cors[0] = 0;
                    if (j1 == 0) cors[1] = 2;
                    else cors[1] = 0;
                }
            }
            return cors;
        }

        private int [,] init_enemy ()
        {
            int[,] e = new int[n*n,2];

            for (int i = 0; i < n*n; i++)
            {
                e[i, 0] = -1;
            }
            return e;
        } 

        private int getLength(int [,] e)
        {
            int c = 0;
            for (int i = 0; i < e.Length/2; i++)
            {
                if (e[i, 0] > 0) c++;
            }
            return c;
        }

        private int free(int v1, int v2)
        {
            if (v1 == 0 && v2 == 1) return 2;
            else if (v1 == 0 && v2 == 2) return 1;
            else return 0;
        }

        private int[] corner()
        {
            int[] cors = new int[2];
            int[] variants = new int[4];
            int v = 0;
            cors[0] = -1;
            cors[1] = -1;

            for (int i = 0; i < n; i = i + 2)
            {
                for (int j = 0; j < n; j = j + 2)
                {
                    if (matrix[i, j] == -1)
                    {
                        variants[v] = i*3+j;
                        v++;
                    }
                }
            }
            if (v > 0)
            {
                int variant = variants[random.Next(v)];
                switch (variant)
                {
                    case 0:
                        cors[0] = 0;
                        cors[1] = 0;
                        break;

                    case 2:
                        cors[0] = 0;
                        cors[1] = 2;
                        break;
                    case 6:
                        cors[0] = 2;
                        cors[1] = 0;
                        break;
                    case 8:
                        cors[0] = 2;
                        cors[1] = 2;
                        break;
                }
            }
            return cors;
        }

    }
}
