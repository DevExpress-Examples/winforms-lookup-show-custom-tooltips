Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Controls

Namespace LookUpEditWithHints

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            lookUpEditHints1.Properties.DataSource = FillTable()
            lookUpEditHints1.Properties.DisplayMember = "Customer"
            lookUpEditHints1.Properties.DescriptionField = "Description"
            AddHandler lookUpEditHints1.BeforeShowingTooltip, New EventHandler(AddressOf lookUpEditHints1_BeforeShowingTooltip)
            ' LookUpEdit customization: adding two columns from DataSource
            ' and making one of them invisible
            Dim coll As LookUpColumnInfoCollection = lookUpEditHints1.Properties.Columns
            coll.Add(New LookUpColumnInfo("Customer"))
            coll.Add(New LookUpColumnInfo("Description"))
            lookUpEditHints1.Properties.Columns("Description").Visible = False
        End Sub

        Private Sub lookUpEditHints1_BeforeShowingTooltip(ByVal sender As Object, ByVal e As EventArgs)
            Dim ee As ToolTipControllerShowEventArgs = TryCast(e, ToolTipControllerShowEventArgs)
            ee.ToolTip += " + custom tool tip also can be added"
        End Sub

        Private Function FillTable() As DataTable
            Dim _customersTable As DataTable = New DataTable()
            Dim col As DataColumn
            Dim row As DataRow
            _customersTable.TableName = "Customers"
            col = New DataColumn()
            col.ColumnName = "Customer"
            col.DataType = Type.GetType("System.String")
            _customersTable.Columns.Add(col)
            col = New DataColumn()
            col.ColumnName = "Description"
            col.DataType = Type.GetType("System.String")
            _customersTable.Columns.Add(col)
            row = _customersTable.NewRow()
            row("Customer") = "John"
            row("Description") = "A description for customer John"
            _customersTable.Rows.Add(row)
            row = _customersTable.NewRow()
            row("Customer") = "Jane"
            row("Description") = "A description for customer Jane"
            _customersTable.Rows.Add(row)
            row = _customersTable.NewRow()
            row("Customer") = "Jack"
            row("Description") = "A description for customer Jack"
            _customersTable.Rows.Add(row)
            Return _customersTable
        End Function
    End Class
End Namespace
