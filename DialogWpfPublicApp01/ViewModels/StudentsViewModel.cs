using DialogWpfPublicApp01.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using DialogWpfPublicApp01.Data;
using System.Diagnostics;
using System.Windows.Input;
using System.Data.Entity;
using DialogWpfPublicApp01.Common;
using DialogWpfPublicApp01.Views;
// using DialogWpfPublicApp01.Commands;

namespace DialogWpfPublicApp01.ViewModels
{
    public class StudentsViewModel : BaseVM
    {
        DbContextApp _dataContextApp;
        
        public StudentsViewModel()
        {
            this._dataContextApp = new DbContextApp();
            
            LoadData();
        }
        
        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set 
            {
                students = value;

                Debug.WriteLine($"ObservableCollection<Student> Students -- set ");
                // _dataContextApp.SaveChanges();

                RaisePropertyChanged(nameof(Students));
            }
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set 
            {
                Debug.WriteLine($"Prop: SelectedStudent-- set ");
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    
                    Debug.WriteLine($"_selectedStudent.FirstName {_selectedStudent.FirstName}");
                    
                    RaisePropertyChanged(nameof(SelectedStudent));
                }
            }
        }
        
        RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand((selectedStudent) =>
                    {
                        Debug.WriteLine($"RelayCommand EditCommand -- get");
                        // получаем выделенный объект
                        Student studentSelected = selectedStudent as Student;
                        if (studentSelected == null) return;

                        Student studentNew = new Student
                        {
                            Id = studentSelected.Id,
                            LastName  = studentSelected.LastName,
                            FirstName = studentSelected.FirstName
                        };

                        StudentDialogVievModel studentDialogVievModel = new StudentDialogVievModel(studentNew);
                        StudentDialog studentDialog = new StudentDialog(studentNew);
                        studentDialog.DataContext = studentDialogVievModel;

                        if (studentDialog.ShowDialog() == true)
                        {
                            studentSelected.Id = studentDialogVievModel.Id;
                            studentSelected.FirstName = studentDialogVievModel.FirstName;
                            studentSelected.LastName  = studentDialogVievModel.LastName;

                            _dataContextApp.Entry(studentSelected).State = EntityState.Modified;
                            _dataContextApp.SaveChanges();                            
                        }
                    }));
            }
        }

        public void LoadData()
        {          
            this._dataContextApp.Students.Load();           // +***
            Students = this._dataContextApp.Students.Local; // 
        }
    }
}
