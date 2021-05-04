using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePetExamn.ViewModel
{
    /// <summary>
    /// This class will interfiere alot with diffrent views
    /// the person data varries alot, and relevant information varrier from view to view
    ///
    /// Notifies cilent something has changed
    /// 
    /// </summary>
    class PeopleViewModel : INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private int _age;
        private DateTime _dateOfBirth;
        private string _nationality;
        private string _personalAddress;
        private string _headShot; //Picture path string
        private string _remarks;
        private int _gangsID;
        private int _agentID;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange("ID");
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange("FirstName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange("LastName");
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                NotifyOfPropertyChange("Age");
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                //this doesn't work due to that fact it is already a datetime the toturials i have seen all use string for datetime (for somereason)
      //          _dateOfBirth = Convert.ToDateTime(value).ToString("MM/dd/yyyy");
      //          NotifyOfPropertyChange("DateOfBirth");

            }
        }
        public string Nationality
        {
            get { return _nationality; }
            set
            {
                _nationality = value;
                NotifyOfPropertyChange("Nationality");
            }
        }
        public string PersonalAddress
        {
            get { return _personalAddress; }
            set
            {
                _personalAddress = value;
                NotifyOfPropertyChange("PersonalAddress");
            }
        }
        public string HeadShot
        {
            get { return _headShot; }
            set
            {
                _headShot = value;
                NotifyOfPropertyChange("HeadShot");
            }
        }
        public string Remarks
        {
            get { return _remarks; }
            set
            {
                _remarks = value;
                NotifyOfPropertyChange("Remarks");
            }
        }
        public int AgentID
        {
            get { return _agentID; }
            set
            {
                _agentID = value;
                NotifyOfPropertyChange("AgentID");
            }
        }
        public int GangsID
        {
            get { return _gangsID; }
            set
            {
                _gangsID = value;
                NotifyOfPropertyChange("GangsID");
            }
        }

        #region INotifyPropertyChanged Members
        //Checks if property has changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyOfPropertyChange(string propertName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertName));
            }
        }
        #endregion
    }
}
