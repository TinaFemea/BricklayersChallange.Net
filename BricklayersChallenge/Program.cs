using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BricklayersChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            BLChallenge solver = new BLChallenge();
            DateTime startTime = DateTime.Now;
            int tryCounter = 0;
            while (!solver.IsSolved())
            {
                tryCounter++;
                if (tryCounter % 250000 == 0)
                    Console.WriteLine(tryCounter);

                solver.Scramble();
            }
            Console.WriteLine("Solution found after {0} iterations, {1} minutes", tryCounter, (DateTime.Now - startTime).TotalMinutes);
            solver.Print();
        }
    }

    class BLChallenge
    {

        private List<int> row1 = new List<int>(6) {1, 2, 3, 4, 5, 6};
        private List<int> row2 = new List<int>(6) { 1, 2, 3, 4, 5, 6 };
        private List<int> row3 = new List<int>(6) { 1, 2, 3, 4, 5, 6 };
        private List<int> row4 = new List<int>(6) { 1, 2, 3, 4, 5, 6 };
        private List<List<int>> allRows = new List<List<int>>(4); 
        
        private Dictionary<int, bool> columns = new Dictionary<int, bool>(21);
        private Random rnd=new Random();
           
        public BLChallenge()
        {
            allRows.Add(row1);
            allRows.Add(row2);
            allRows.Add(row3);
            allRows.Add(row4);
        }
        public bool IsSolved()
        {
            for (int i = 1; i <= 20; i++)
                columns[i] = false;

            foreach (List<int> thisRow in allRows)
            {
                //  add them up.
                int column = 0;
                for (int i = 0; i < 5; i++ ) //because the last one will always collide
                {
                    column += thisRow[i];
                    if (columns[column] == true) //  we collided
                        return false;
                    columns[column] = true;
                }
            }

            return true;
        }

        public void Print()
        {
            foreach (List<int> thisRow in allRows)
            {
                foreach (int block in thisRow)
                    Console.Write(block);
                Console.Write(" - ");
            }
            Console.WriteLine();
        }

        public void Scramble()
        {
            allRows[0] = allRows[0].OrderBy(x => rnd.Next()).ToList();
            allRows[1] = allRows[1].OrderBy(x => rnd.Next()).ToList();
            allRows[2] = allRows[2].OrderBy(x => rnd.Next()).ToList();
            allRows[3] = allRows[3].OrderBy(x => rnd.Next()).ToList();
        }

    }
}
