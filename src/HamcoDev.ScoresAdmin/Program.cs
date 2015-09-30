namespace HamcoDev.ScoresAdmin
{
    using HamcoDev.ScoresAdmin.Results;

    class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }

        private void Run()
        {
            var resultsProcessor = new ResultsProcessor();
            resultsProcessor.Process();
        }
    }
}
