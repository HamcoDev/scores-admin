namespace HamcoDev.ScoresAdmin
{
    using HamcoDev.ScoresAdmin.Results;

    class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            p.Run(args);
        }

        private void Run(string[] args)
        {
            var resultPopulator = new ResultsPopulator(9);
            resultPopulator.Run();
        }
    }
}
