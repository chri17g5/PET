using DocumentFormat.OpenXml.Drawing;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data.Linq;
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
using ThePetExamn.Model;

namespace ThePetExamn.View
{
    /// <summary>
    /// Interaction logic for PeopleControl.xaml
    /// </summary>
    public partial class PeopleControl : UserControl
    {
        #region Constructor
        public PeopleControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PeopleControl_Loaded);
        }
        #endregion

        #region Read Operator
        /// <summary>
        /// Loads data and prints it out to the window
        /// also provides user feedback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PeopleControl_Loaded( object sender, RoutedEventArgs e)
        {
            PETexamEntities pet = new PETexamEntities();
            var result = from per in pet.Persons //Takes people data from DB
                         select per;
            if (result.ToList().Count > 1) //If something is printet out it has successfully writen DB.table content
                StatusText.Text = "Success: Read Operation";

            PeopleDataGrid.ItemsSource = result.ToList(); //Prints data to data grid
        }
        #endregion

        #region Create And Update Operation
        /// <summary>
        /// Supposed to be a way to create and update changes happending to the DataGrid and copy it over to the DataTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeopleDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit) //If changes are commited
            {
                PETexamEntities pet = new PETexamEntities();
                Persons persons = e.Row.DataContext as Persons;

                var matchedData = (from per in pet.Set<Persons>()
                                   where per.ID = persons.ID //Find out where this supposed "bool" is
                                   select per).SinleOrDefault();
                //If user eddits a null table it becomes new data for the table!
                if (matchedData == null)
                {
                    Table<Persons> perTable = pet.Set<Persons>();
                    Persons _persons = new Persons();
                    _persons.FirstName = persons.FirstName;
                    _persons.LastName = persons.LastName;
                    _persons.Age = persons.Age;
                    _persons.DateOfBirth = persons.DateOfBirth;
                    _persons.Nationality = persons.Nationality;
                    _persons.HeadShot = persons.HeadShot;
                    _persons.Remarks = persons.Remarks;
                    _persons.GangsID = persons.GangsID;
                    _persons.AgentID = persons.AgentID;

                    perTable.InsertOnSubmit(_persons);
                    perTable.Context.SubmitChanges();

                    StatusText.Text = "Success: Data Inserted";
                }
                //The only else is if the user eddits a table with existing data
                //This takes the data and updates it!
                else
                {
                    matchedData.FirstName = persons.FirstName;
                    matchedData.LastName = persons.LastName;
                    matchedData.Age = persons.Age;
                    matchedData.DateOfBirth = persons.DateOfBirth;
                    matchedData.Nationality = persons.Nationality;
                    matchedData.HeadShot = persons.HeadShot;
                    matchedData.Remarks = persons.Remarks;
                    matchedData.GangsID = persons.GangsID;
                    matchedData.AgentID = persons.AgentID;

                    StatusText.Text = "Success: Data Updated";
                }
            }
        }

        #endregion

        #region
        /// <summary>
        /// Deletes data from datagrid and should also update and delete data in datatable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeopleDataGrid_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PETexamEntities pet = new PETexamEntities();
            Persons persons = PeopleDataGrid.SelectedItem as Persons;

            if (persons != null)
            {
                var matchedPerson = (from per in pet.Set<Persons>()
                                     where per.ID == persons.ID
                                     select per).SingleOrDefault();
                if (e.Command == DataGrid.DeleteCommand)
                {
                    if (e.Command == DataGrid.DeleteCommand)
                    {
                        if (!(MessageBox.Show("Are you sure you want to delete?", "Confirm Delete!", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            pet.Persons.Remove(matchedPerson);
                            pet.SaveChanges();
                            StatusText.Text = "Success: Selected Data Deleted.";
                        }
                    }
                }
            }
        }
        #endregion
    }
}
