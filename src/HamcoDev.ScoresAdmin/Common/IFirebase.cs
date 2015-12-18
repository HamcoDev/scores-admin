namespace HamcoDev.ScoresAdmin.Common
{
    public interface IFirebase
    {
        string Read(string url);

        int ReadInt(string url);

        string Write(string url, string data);
    }
}