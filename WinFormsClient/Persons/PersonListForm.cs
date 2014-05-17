using DataAccessors.Accessors;
using DataAccessors.Data;
using DataAccessors.Entity;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.Phones;

namespace WinFormsClient
{
    public partial class PersonListForm : Form
    {
        private IPersonBll _personBll;
        private IAccessor<Phone> _phoneAccessor;

        public PersonListForm(IPersonBll personBll)
        {
            _personBll = personBll;
            InitializeComponent();       
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        

        private void SetData(IEnumerable<Person> collection)
        {
            dataGridView1.Rows.Clear();
            foreach (Person p in collection)
            {
                dataGridView1.Rows.Add(p.Id, p.Name, p.LastName, p.DayOfBirth);
            }
        }
       
        private void ReloadData()
        {
            IEnumerable<Person> coll = null;
            try
            {
                coll = _personBll.GetPersons();
            }
            catch (SqlException e)
            {
                MessageBox.Show(this, "Database cant perform operation", 
                    "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SetData(coll);
        }

        #region event handlers
        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (col == 4) // delete button
            {
                int personId = (int)dataGridView1.Rows[row].Cells[0].Value;

                try
                {
                    _personBll.DeletePerson(personId);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, "Database cant perform operation",
                        "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (col == 5) // show phone list button
            {
                int personId = (int)dataGridView1.Rows[row].Cells[0].Value;
                PhoneListForm f = Program.ResolveForm<PhoneListForm>();
                f.OwnerId = personId;
                f.ShowDialog();
            }

            ReloadData();
        }

        private void insertPerson_Click(object sender, EventArgs e)
        {
            CreatePersonForm form = Program.ResolveForm<CreatePersonForm>();
            DialogResult res = form.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    _personBll.AddPerson(form.Result);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, "Database cant perform operation",
                        "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ReloadData();
            }
        }

        private void insertPhone_Click(object sender, EventArgs e)
        {
            CreatePhoneForm form = Program.ResolveForm<CreatePhoneForm>();
            DialogResult res = form.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    _phoneAccessor.Insert(form.Result);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, "Database cant perform operation",
                        "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void phoneWindowCall(object sender, EventArgs e)
        {
            PhoneListForm plf = Program.ResolveForm<PhoneListForm>();
            plf.Show();
        }
        #endregion
    }
}
