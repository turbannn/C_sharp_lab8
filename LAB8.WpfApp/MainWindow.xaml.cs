using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LAB8.BLL;

namespace LAB8.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IList<Student> Students { get; set; }
        public MainWindow()
        {
            Students = new List<Student>()
            {
                new Student("Heorhii", "Mikula", "WIMII", 228666),
                new Student("Jan", "Kowalski", "WIMII", 101010),
                new Student("Michal", "Nowak", "WIMII", 221122),
                new Student("Jacek", "Makieta", "WIMII", 332222)
            };
            foreach (var student in Students)
            {
                Random rnd = new Random();
                student.Grades.Add(Math.Truncate((rnd.NextDouble() * 4 + 1) * 100) / 100);
                student.Grades.Add(Math.Truncate((rnd.NextDouble() * 4 + 1) * 100) / 100);
                student.Grades.Add(Math.Truncate((rnd.NextDouble() * 4 + 1) * 100) / 100);
                student.Grades.Add(Math.Truncate((rnd.NextDouble() * 4 + 1) * 100) / 100);
            }
            InitializeComponent();
            DataGridTable.ItemsSource = Students;
            /*
            DataGridTable.Columns.Add(item: new DataGridTextColumn() { Header = "FirstName", Binding = new Binding(path: "FirstName") });
            DataGridTable.Columns.Add(item: new DataGridTextColumn() { Header = "LastName", Binding = new Binding(path: "LastName") });
            DataGridTable.Columns.Add(item: new DataGridTextColumn() { Header = "Faculty", Binding = new Binding(path: "Faculty") });
            DataGridTable.Columns.Add(item: new DataGridTextColumn() { Header = "Index", Binding = new Binding(path: "Index") });

            DataGridTable.AutoGenerateColumns = false;
            */

        }
        private void MainRemoveButtonStudentClick(object sender, RoutedEventArgs e)
        {
            if (DataGridTable.SelectedItem is Student std)
            {
                Students.Remove(std);
                DataGridTable.Items.Refresh();
            }
        }
        private void MainAddStudentButtonClick(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.ShowDialog();
            Students.Add(addStudentWindow.Student);
            DataGridTable.Items.Refresh();
        }
        private void MainAddGradesToStudentClick(object sender, RoutedEventArgs e)
        {
            if (DataGridTable.SelectedItem is Student std)
            {
                AddGrade addGrade = new AddGrade();
                addGrade.ShowDialog();
                std.Grades.Add(addGrade.Value);
                DataGridTable.Items.Refresh();
            }
        }
    }
}