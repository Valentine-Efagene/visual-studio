using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FPCourseRegistration
{
    /// <summary>
    /// Interaction logic for UserControlRegister.xaml
    /// </summary>
    public partial class UserControlRegister : UserControl
    {
        private ObservableCollection<Course> courses = null;

        public UserControlRegister( LoginData data)
        {
            InitializeComponent();
            courses = LoadCollectionData();
            DataGridCourseReg.DataContext = courses;
        }

        private ObservableCollection<Course> LoadCollectionData()
        {
            ObservableCollection<Course> courses = new ObservableCollection<Course>();
            courses.Add(new Course(){ Code = "CPE575", Credit = 3});

            return courses;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            uint credit = 0;

            try
            {
                Convert.ToUInt64(TextBoxCredit.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Please enter a positive number");
                return;
            }

            courses.Add(new Course() { Code = TextBoxCode.Text, Credit = credit});
            TextBoxCode.Text = "";
            TextBoxCredit.Text = "";
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
