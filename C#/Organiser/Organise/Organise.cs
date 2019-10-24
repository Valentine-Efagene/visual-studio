using System;
using System.Runtime.InteropServices;

namespace Organise
{
    class Organise
    {
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);

        static void Main(string[] args)
        {
            int result = MessageBox(IntPtr.Zero, "Are you sure you want to reorganise this folder?", "Attention!", 4);

            if (result == 6)
            {
                Organiser.Organiser organiser = new Organiser.Organiser();
                organiser.Organise();
                string s = organiser.GetDirectory() + " has been organised\n";
                System.IO.File.AppendAllText(@"C: \Users\valentyne\Desktop\log.txt", s);
            }
        }
    }
}
