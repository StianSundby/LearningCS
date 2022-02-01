using System;

namespace LearningCS.Resources.TaskClasses.BottleMath
{
    internal class Operation
    {
        private readonly int[] _operations;
        private readonly Simulation _simulation;
        public int Length => _operations.Length;

        private static readonly string[] OperationNames = new[]
        {
            "Fill bottle 1 from the tap",
            "Fill bottle 2 from the tap",
            "Empty bottle 1 into bottle 2",
            "Empty bottle 2 into bottle 1",
            "Fill up bottle 2 with bottle 1",
            "Fill up bottle 1 with bottle 2",
            "Empty bottle 1",
            "Empty bottle 1",
        };


        public Operation(int opCount, Simulation simulation)
        {
            _simulation = simulation;
            _operations = new int[opCount];
        }

        public string GetDescription()
        {
            var description = "";
            for (var i = 0; i < _operations.Length; i++)
            {
                var op = _operations[i];
                description += (i + 1) + ": " + OperationNames[op] + "\n";
            }

            return description;
        }

        public void RunAll()
        {
            Console.WriteLine("Trying with " + _operations.Length + " operation(s).");
            do
            {
                RunOne();
                if (_simulation.Solved())
                {
                    return;
                }
            } while (Next());
        }
        public bool Next()
        {
            int i;
            for (i = _operations.Length - 1; i >= 0; i--)
            {
                if (_operations[i] < 7)
                {
                    _operations[i]++;
                    break;
                }
                _operations[i] = 0;
            }
            return i != -1;
        }

        public void RunOne()
        {
            var bottle1 = _simulation.Bottle1;
            var bottle2 = _simulation.Bottle2;
            bottle1.Empty();
            bottle2.Empty();
            foreach (var op in _operations)
            {
                if (op == 0) bottle1.FillAllTheWay();                 //Fill bottle 1
                else if (op == 1) bottle2.FillAllTheWay();            //Fill bottle 2
                else if (op == 2) bottle2.Fill(bottle1.Empty());//Empty bottle 1 into bottle 2 - Empty returns the content before it was emptied
                else if (op == 3) bottle1.Fill(bottle2.Empty());//Empty bottle 2 into bottle 1 - Empty returns the content before it was emptied
                else if (op == 4) bottle2.TransferContent(bottle1);   //Fill up bottle 2 with bottle 1 - Transfers content from parameter
                else if (op == 5) bottle1.TransferContent(bottle2);   //Fill up bottle 1 with bottle 2 - Transfers content from parameter
                else if (op == 6) bottle1.Empty();                    //Empty bottle 1
                else if (op == 7) bottle2.Empty();                    //Empty bottle 2
            }
        }
    }
}
