using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.ViewInfo;

namespace LookUpEditWithHints
{
    [UserRepositoryItem("RegisterLookUpEditHints")]
    class RepositoryItemLookUpEditHints : RepositoryItemLookUpEdit
    {
        string descriptionField = "";
        static readonly object _beforeShowingTooltip = new object();

        static RepositoryItemLookUpEditHints() { RegisterLookUpEditHints(); }
        public RepositoryItemLookUpEditHints() : base() { }

        // Unique name for custom control
        public const string LookUpEditHintsName = "LookUpEditHints";
        public override string EditorTypeName { get { return LookUpEditHintsName; } }

        //Register the editor
        public static void RegisterLookUpEditHints()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(
                LookUpEditHintsName, typeof(LookUpEditHints), typeof(RepositoryItemLookUpEditHints),
                typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
        }

        public string DescriptionField {
            set { descriptionField = value; OnPropertiesChanged(); }
            get { return descriptionField; } }

        public event EventHandler BeforeShowingTooltip
        {
            add { Events.AddHandler(RepositoryItemLookUpEditHints._beforeShowingTooltip, value); }
            remove { Events.RemoveHandler(RepositoryItemLookUpEditHints._beforeShowingTooltip, value); }
        }

        protected internal virtual void OnBeforeShowingTooltip(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[RepositoryItemLookUpEditHints._beforeShowingTooltip];
            if (handler != null) handler(GetEventSender(), e);
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            base.Assign(item);
            RepositoryItemLookUpEditHints source = item as RepositoryItemLookUpEditHints;
            if (source == null) return;
            this.DescriptionField = source.DescriptionField;
            EndUpdate();
            Events.AddHandler(RepositoryItemLookUpEditHints._beforeShowingTooltip, source.Events[RepositoryItemLookUpEditHints._beforeShowingTooltip]);
        }
    }
}
