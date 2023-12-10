using DialogWpfPublicApp01.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DialogWpfPublicApp01.Views
{
    /// <summary>
    /// Логика взаимодействия для StudentDialog.xaml
    /// </summary>
    public partial class StudentDialog : Window
    {
        public Student _student { get; set; }
        public StudentDialog(Student student)
        {
            InitializeComponent();
            _student = student;

            DataContext = _student;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
