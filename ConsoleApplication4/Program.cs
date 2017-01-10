using System;

namespace Battleship
{
    public enum FieldType { View, Enemy, Player }
    class Program
    {
        const int FieldLengthY = 10;
        const int FieldLengthX = 10;
        public static int succsesscount = 0;
        static void Main(string[] args)
        {
            
               
            Field ViewField = new Field(FieldType.View, FieldLengthY, FieldLengthX);
                
            Enemy EnemyField = new Enemy(FieldType.Enemy, FieldLengthY, FieldLengthX);
            Player PlayerField = new Player(FieldType.Player, FieldLengthY, FieldLengthX);
            PlayerField.InputLoop();
            
         // PlayerField.Draw();
         //   ViewField.Draw();

                
                
            while (Program.succsesscount < 100)
            {
                Enemy.ComputerFire();
                Console.Clear();
                Enemy.DrawFireMemoryMAP();

            }
            
            Console.ReadKey();          
        }
    }
}
