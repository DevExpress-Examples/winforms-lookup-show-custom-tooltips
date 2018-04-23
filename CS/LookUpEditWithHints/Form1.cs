using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace LookUpEditWithHints
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lookUpEditHints1.Properties.DataSource = FillTable();
            lookUpEditHints1.Properties.DisplayMember = "Customer";
            lookUpEditHints1.Properties.DescriptionField = "Description";
            lookUpEditHints1.BeforeShowingTooltip += new EventHandler(lookUpEditHints1_BeforeShowingTooltip);

            // LookUpEdit customization: adding two columns from DataSource
            // and making one of them invisible
            LookUpColumnInfoCollection coll = lookUpEditHints1.Properties.Columns;
            coll.Add(new LookUpColumnInfo("Customer"));
            coll.Add(new LookUpColumnInfo("Description"));
            lookUpEditHints1.Properties.Columns["Description"].Visible = false;
        }

        void lookUpEditHints1_BeforeShowingTooltip(object sender, EventArgs e)
        {
            ToolTipControllerShowEventArgs ee = e as ToolTipControllerShowEventArgs;
            ee.ToolTip += " + custom tool tip also can be added";
        }

        DataTable FillTable()
        {
            DataTable _customersTable = new DataTable();
            DataColumn col;
            DataRow row;

            _customersTable.TableName = "Customers";

            col = new DataColumn();
            col.ColumnName = "Customer";
            col.DataType = System.Type.GetType("System.String");
            _customersTable.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "Description";
            col.DataType = System.Type.GetType("System.String");
            _customersTable.Columns.Add(col);

            row = _customersTable.NewRow();
            row["Customer"] = "John";
            row["Description"] = "A description for customer John";
            _customersTable.Rows.Add(row);

            row = _customersTable.NewRow();
            row["Customer"] = "Jane";
            row["Description"] = "A description for customer Jane";
            _customersTable.Rows.Add(row);

            row = _customersTable.NewRow();
            row["Customer"] = "Jack";
            row["Description"] = "A description for customer Jack";
            _customersTable.Rows.Add(row);

            return _customersTable;
        }
    }
}
