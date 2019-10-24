namespace Organise
{
    class Organise
    {
        static void Main(string[] args)
        {
            Organiser.Organiser organiser = new Organiser.Organiser();
            organiser.Organise();
            string s = organiser.GetDirectory() + " have been organised";
            System.IO.File.AppendAllText(@"C: \Users\valentyne\Desktop\log.txt", s);
        }
    }
}
