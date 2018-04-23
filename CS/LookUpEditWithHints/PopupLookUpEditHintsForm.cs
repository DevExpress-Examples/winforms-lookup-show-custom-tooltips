using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraEditors.Popup;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Drawing;

namespace LookUpEditWithHints
{
    class PopupLookUpEditHintsForm : PopupLookUpEditForm
    {
        Point prevPoint = Point.Empty;
        ToolTipController tt;
        DataTable dt;
        int prevRowIndex = -1;

        public PopupLookUpEditHintsForm(LookUpEditHints ownerEdit) : base(ownerEdit) {
            if (this.OwnerEdit.ToolTipController == null)
                tt = ToolTipController.DefaultController;
            tt.BeforeShow += new ToolTipControllerBeforeShowEventHandler(tt_BeforeShow);
            dt = this.OwnerEdit.Properties.DataSource as DataTable;
        }

        void tt_BeforeShow(object sender, ToolTipControllerShowEventArgs e)
        {
            LookUpEditHints le = OwnerEdit as LookUpEditHints;
            le.Properties.OnBeforeShowingTooltip(e);
        }

        public override void ShowPopupForm()
        {
            SetToolTipController();
            SetDataTable();
            base.ShowPopupForm();
        }

        void SetToolTipController()
        {
            if (this.OwnerEdit.ToolTipController != null && this.OwnerEdit.ToolTipController != tt)
            {
                tt = this.OwnerEdit.ToolTipController;
                tt.BeforeShow += new ToolTipControllerBeforeShowEventHandler(tt_BeforeShow);
            }
        }

        void SetDataTable()
        {
            dt = dt != this.OwnerEdit.Properties.DataSource as DataTable ? this.OwnerEdit.Properties.DataSource as DataTable : dt;
        }

        protected override void CheckMouseCursor(LookUpPopupHitTest ht)
        {
            if (prevPoint.X != ht.Point.X || prevPoint.Y != ht.Point.Y)
            {
                prevPoint = ht.Point;

                LookUpEditHints le = this.OwnerEdit as LookUpEditHints;
                LookUpColumnInfo column;
                int columnPos = -1;

                for (int i = 0; i < this.OwnerEdit.Properties.Columns.Count; i++)
                {
                    column = this.OwnerEdit.Properties.Columns[i];
                    if (column.FieldName == le.Properties.DescriptionField)
                    {
                        columnPos = i;
                        break;
                    }
                }

                if (columnPos != -1)
                {
                    if (ht.HitType == LookUpPopupHitType.Row)
                    {
                        if (ht.Index != prevRowIndex)
                        {
                            tt.HideHint();
                            prevRowIndex = ht.Index;
                        }
                        tt.ShowHint(dt.Rows[ht.Index][columnPos].ToString());
                    }
                }
            }
            base.CheckMouseCursor(ht);
        }
    }
}
