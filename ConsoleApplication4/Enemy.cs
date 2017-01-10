using System;

namespace Battleship
{
    class Enemy : Field
    {
        public Enemy(FieldType fieldType, int FieldLengthY, int FieldLengthX) : base(fieldType, FieldLengthY, FieldLengthX)
        {
        }

        #region this is to indicate if a shot has been twice to the same coordinates;
        static int[,] fireMemory = new int[10, 10];
        static int fireY, fireX;

        public static int RandNumber(int Low, int High)
        {
            Random rndNum = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));

            int rnd = rndNum.Next(Low, High);

            return rnd;
        }


        public static void ComputerFire()
        {
            fireX = RandNumber(0, 10);
            fireY = RandNumber(0, 10);

            if (fireMemory[fireY, fireX] == 0)
            {
                fireMemory[fireY, fireX] = 1;
                Program.succsesscount++;
            }
            else
            {

                ComputerFire();
            }
        }
        public static void DrawFireMemoryMAP() // draws out the field. 
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(fireMemory[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion

    }
}
