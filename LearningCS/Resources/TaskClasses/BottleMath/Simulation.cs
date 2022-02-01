namespace LearningCS.Resources.TaskClasses.BottleMath
{
    internal class Simulation
    {
        public int WantedResult { get; }
        public Bottle Bottle1 { get; }
        public Bottle Bottle2 { get; }
        public bool Solved()
        {
            return Bottle1.Content + Bottle2.Content == WantedResult
                   || Bottle1.Content == WantedResult
                   || Bottle2.Content == WantedResult;
        }

        public Simulation(int wantedResult, int bottle1, int bottle2)
        {
            WantedResult = wantedResult;
            Bottle1 = new Bottle(bottle1);
            Bottle2 = new Bottle(bottle2);
        }


        public Operation Run()
        {
            var numberOfOperations = 1;
            while (numberOfOperations < 20)
            {
                var operationSet = new Operation(numberOfOperations, this);
                operationSet.RunAll();
                if (Solved()) return operationSet;
                numberOfOperations++;
            }

            return null;
        }
    }
}
