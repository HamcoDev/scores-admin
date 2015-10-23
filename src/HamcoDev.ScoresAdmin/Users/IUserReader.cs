namespace HamcoDev.ScoresAdmin.Users
{
    using System.Collections.Generic;

    public interface IUserReader
    {
        List<string> GetUserIds();
    }
}