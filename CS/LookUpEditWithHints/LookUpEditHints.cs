using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraEditors.Popup;

namespace LookUpEditWithHints
{
    class LookUpEditHints : LookUpEdit
    {
        static LookUpEditHints() { RepositoryItemLookUpEditHints.RegisterLookUpEditHints(); }
        public LookUpEditHints() : base() { }

        public override string EditorTypeName
        { get { return RepositoryItemLookUpEditHints.LookUpEditHintsName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemLookUpEditHints Properties
        { get { return base.Properties as RepositoryItemLookUpEditHints; } }

        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm()
        {
            return new PopupLookUpEditHintsForm(this);
        }

        public string DescriptionField {
            set { Properties.DescriptionField = value; OnPropertiesChanged(); }
            get { return Properties.DescriptionField; }
        }

        public event EventHandler BeforeShowingTooltip
        {
            add { Properties.BeforeShowingTooltip += value; }
            remove { Properties.BeforeShowingTooltip -= value; }
        }
    }
}
