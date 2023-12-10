using DialogWpfPublicApp01.Common;
using DialogWpfPublicApp01.Models;
using DialogWpfPublicApp01.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//  using System.Windows.Forms;

namespace DialogWpfPublicApp01.Models
{
    public class Student : BaseVM
    {   

        public int _id;
        public int Id
        {
            get { return _id; }
            set 
            {
                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }


        public string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }
       
    }
}
