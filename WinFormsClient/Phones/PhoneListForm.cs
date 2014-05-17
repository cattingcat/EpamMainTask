using BusinessLogic;
using DataAccessors.Accessors;
using DataAccessors.Entity;
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

namespace WinFormsClient.Phones
{
    public partial class PhoneListForm : Form
    {
        private IPhoneBll _phoneBll;

        public int? OwnerId { get; set; }

        public PhoneListForm(IPhoneBll phoneBll)
        {
            _phoneBll = phoneBll;
            InitializeComponent();
        }

        private void SetData(IEnumerable<Phone> phones)
        {
            foreach (var p in phones)
            {
                dataGridView1.Rows.Add(p.Id, p.Number);
            }
        }

        private void ReloadData()
        {
            dataGridView1.Rows.Clear();
            IEnumerable<Phone> phones = null;
            try
            {
                if (OwnerId.HasValue)
                {
                    phones =  _phoneBll.GetPhones(OwnerId.Value);
                }
                else
                {
                    phones = _phoneBll.GetPhones();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, "Database cant perform operation",
                    "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SetData(phones);
        }


        private void PhoneListForm_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (col == 2)
            {
                int phoneId = (int)dataGridView1.Rows[row].Cells[0].Value;
                try
                {
                    _phoneBll.DeletePhone(phoneId);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(this, "Database cant perform operation",
                        "DatabaseException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            ReloadData();
        }
    }
}
