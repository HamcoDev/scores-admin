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
            if (args[1] == "1")
            {
                var resultPopulator = new ResultsPopulator();
                resultPopulator.Run();
            }
        }
    }
}
