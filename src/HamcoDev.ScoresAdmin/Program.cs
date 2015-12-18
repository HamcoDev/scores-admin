namespace HamcoDev.ScoresAdmin
{
    using System;

    using HamcoDev.ScoresAdmin.Results;
    using HamcoDev.ScoresAdmin.Scores;

    class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            p.Run(args);
        }

        private void Run(string[] args)
        {
            var resultPopulator = new ResultsPopulator();
            resultPopulator.Run();

            Console.WriteLine("Completed");
            Console.Read();
        }
    }
}
