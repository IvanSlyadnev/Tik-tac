using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tak
{
    class GameController
    {
        private const int n = 3;
        private bool first;
        private int[,] matrix = new int[n, n];
        public GameController(bool first)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = -1;
                }
            }
            this.first = first;
        }

        public int[,] getMatrix()
        {
            return this.matrix;
        }
        public void setMatrix(int but = -1, int i =-1, int j =-1)//par = true, значит первый игрок
        {
            int x, y;
            if (but >= 0)
            {
                int[] mass = getCoords(but);
                x = mass[1];
                y = mass[0];
            }
            else
            {
                x = j;
                y = i;
            }

            if (this.first)
            {
                this.matrix[y, x] = 1;
            } else
            {
                this.matrix[y, x] = 0;
            }

        }

        private int[] getCoords(int n)
        {
            int[] cors = new int[2];
            if (n <= 3) cors[0] = 0;
            if (n > 3 && n <= 6) cors[0] = 1;
            if (n > 6 && n <= 9) cors[0] = 2;
            if (n % 3 == 1) cors[1] = 0;
            if (n % 3 == 2) cors[1] = 1;
            if (n % 3 == 0) cors[1] = 2;
            return cors;
        }

        public bool getFirst()
        {
            return this.first;
        }

        public void changeFirst()
        {
            if (!this.first) this.first = true;
            else this.first = false;
        }

        public bool check()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 1 || matrix[i, j] == 0)
                    if (this.checkHorLine(i, matrix[i, j]) ||
                        this.checkVerLine(j, matrix[i, j]) ||
                        this.checkKrestLine(i, j, matrix[i,j]))
                        return true;
                }
            }
            return false;
        }

        private bool checkHorLine(int i, int value)
        {
            int c = 0;
            for (int j = 0; j < n; j++)
            {
                if (this.matrix[i, j] == value) c++;
            }
            return c == n;
        }

        private bool checkVerLine(int j, int value)
        {
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (this.matrix[i, j] == value) c++;
            }
            return c == n;
        }

        private bool checkKrestLine(int i, int j, int value)
        {
            int c = 0;
            if (i == 0 && j == 0)
            {
                if (this.matrix[i, j] == value &&
                    this.matrix[i + 1, j + 1] == value &&
                    this.matrix[i + 2, j + 2] == value)
                    return true;
            } else if (i == 0 && j == 2)
            {
                if (this.matrix[i, j] == value &&
                    this.matrix[i + 1, j - 1] == value &&
                    this.matrix[i + 2, j - 2] == value)
                    return true;
            } else if (i == 2 && j == 0)
            {
                if (this.matrix[i, j] == value &&
                    this.matrix[i - 1, j + 1] == value &&
                    this.matrix[i - 2, j + 2] == value)
                    return true;
            } else if (i == 2 && j == 2)
            {
                if (this.matrix[i, j] == value &&
                    this.matrix[i - 1, j - 1] == value &&
                    this.matrix[i - 2, j - 2] == value)
                    return true;
            }
            return false;
        }

        public String getName()
        {
            if (this.getFirst()) return "Ходит первый игрок";
            else return "Ходит второй игрок";
        }

        public String getWinnerName()
        {
            if (!this.getFirst()) return "Выиграл первый игрок";
            else return "Выиграл второй игрок";
        }
    }
}
