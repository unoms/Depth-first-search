using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Program
    {   
        //Description of pixels
        enum State
        {
            Empty,
            Wall,
            Visited
        }

        static void Visit(State[,] map, int x, int y)
        {
            if ( x >= labyrinth.Length || x < 0 || y < 0 || y >= labyrinth[0].Length) return;
            if (map[x, y] != State.Empty)  return;
            map[x, y] = State.Visited;
            PrintMap(map);
            //Recursive calls
            Visit(map, x + 1, y);
            Visit(map, x - 1, y);
            Visit(map, x, y + 1);
            Visit(map, x, y - 1);
        }

        static void Main(string[] args)
        {
            //Make an empty field
            #region
            ////Two-dimensional array synrax
            //int[,] = new int[row, col]
            #endregion
            var map = new State[labyrinth.Length, labyrinth[0].Length];

            //Filling the map
            for (int x = 0; x < labyrinth.Length; x++)//row
            {
                for (int y = 0; y < labyrinth[0].Length; y++)//columns
                {
                    map[x, y] = labyrinth[x][y] == 'X' ? State.Wall : State.Empty;
                }
            }

            Visit(map, 0, 0);

            //PrintMap(map); 

        }

        static string[] labyrinth = new string[]
        {
            " X   X    ",
            " X XXXXX X",
            "      X   ",
            "XXXX XXX X",
            "         X",
            " XXX XXXXX",
            " X        ",
         };

        static void PrintMap(State[,] map)
        {
            //To print on the same spot
            Console.CursorLeft = 0;
            Console.CursorTop = 0;

            for (int x = 0; x < labyrinth.Length; x++)//row
            {
                
                for (int y = 0; y < labyrinth[0].Length; y++)//columns
                {
                    
                    switch (map[x, y])
                    {
                        case State.Empty:
                            Console.Write(' ');
                            break;
                        case State.Visited:
                            Console.Write('.');
                            break;
                        case State.Wall:
                            Console.Write('X');
                            break;
                    }
                   
                }
                Console.WriteLine();
                
            }
           Console.ReadKey();
        }
    }
}
