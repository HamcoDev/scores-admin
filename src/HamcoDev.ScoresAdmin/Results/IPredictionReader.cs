using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamcoDev.ScoresAdmin.Results
{
    public interface IPredictionReader
    {
        List<FixtureResult> GetPredictions(string userId, int matchday);
    }
}
