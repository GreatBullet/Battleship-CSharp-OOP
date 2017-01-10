using System;

namespace Battleship
{
    class Field
    {
        FieldType fieldType;

        int[,] FieldArray = new int[10, 10];
        int[,] OperationArray = new int[10, 10];
        public void set(int y, int x, int z)
        {
            this.FieldArray[y, x] = z;
        }

        public void setOperationArray(int y, int x, int z, int direction)
        {
            switch(direction)
            {
                case 1:
                    this.OperationArray[y, x] = z;
                    this.OperationArray[y, x--] = z;
                    this.OperationArray[y, x--] = z;
                    this.OperationArray[y, x--] = z;
                    this.OperationArray[y, x--] = z;
                    this.OperationArray[y, x--] = z;
                    break;
                case 2:
                    this.OperationArray[y, x] = z;
                    this.OperationArray[y--, x] = z;
                    this.OperationArray[y--, x] = z;
                    this.OperationArray[y--, x] = z;
                    this.OperationArray[y--, x] = z;
                    this.OperationArray[y--, x] = z;
                    break;
            }
                

        }
        public int get(int y, int x)
        {
            return this.FieldArray[y, x];
        }
        public int getOperationArray(int y, int x)
        {
            return this.OperationArray[y, x];
        }
        /*
         * These Counters are for the InitialShipSetup() 
         * to count how many ships are left for the setup
         */
        static int battleshipCount = 1;
        static int cruiserCount = 2;
        static int destroyerCount = 3;
        static int submarineCount = 4;
        public static int BattleshipCount
        {
            get
            {
                return battleshipCount;
            }

            set
            {
                battleshipCount = value;
            }
        }

        public static int CruiserCount
        {
            get
            {
                return cruiserCount;
            }

            set
            {
                cruiserCount = value;
            }
        }

        public static int DestroyerCount
        {
            get
            {
                return destroyerCount;
            }

            set
            {
                destroyerCount = value;
            }
        }

        public static int SubmarineCount
        {
            get
            {
                return submarineCount;
            }

            set
            {
                submarineCount = value;
            }
        }

        /*
         * // defines the Field constructor
         */
        public Field(FieldType fieldType, int FieldLengthY, int FielLengthX)
        {
            this.fieldType = fieldType;
            this.FieldArray = new int[FieldLengthY, FielLengthX];
        }

        public void Draw() // draws out the field. 
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(FieldArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void DrawOperationArray() // draws out the field. 
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(OperationArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #region Controller region
        private ConsoleKeyInfo key;

        bool Running = true;
        int posx = 5, posy = 5;
        int Tempnumber;
        const int FieldLengthY = 10;
        const int FieldLengthX = 10;

        public void Fail()
        {
            Console.WriteLine("Das ist nicht möglich.");// System.IndexOutOfRangeException 
        }

        public void InputLoop()
        {
            DrawOperationArray();

            while (Running)
            {
                Buffer.BlockCopy(FieldArray, 0, OperationArray, 0, FieldArray.Length*sizeof(int));
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (posx == 0)
                        {
                            Fail();
                        }
                        else
                        {
                            
                            setOperationArray(posy, posx, 0, 2);
                            setOperationArray(posy, --posx, 1,2);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (posx == 9)
                        {
                            Fail();
                        }
                        else
                        {
                           
                            setOperationArray(posy, posx, 0,2);
                            setOperationArray(posy, ++posx, 1,2);
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (posy == 4)
                        {
                            Fail();
                        }
                        else
                        {
                           
                            setOperationArray(posy, posx, 0,2);
                            setOperationArray(--posy, posx, 1,2);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (posy == 9)
                        {
                            Fail();
                        }
                        else
                        {
                           
                            setOperationArray(posy, posx, 0,2);
                            setOperationArray(++posy, posx, 1,2);
                        }
                        break;
                    case ConsoleKey.Escape:
                        Running = false;
                        break;
                    case ConsoleKey.Enter:
                        setOperationArray(posy, posx, 2,2);
                        set(posy, posx, 2);
                        break;
                }
                Console.Clear();
                DrawOperationArray();
            }
            #endregion
        }
    }
}
