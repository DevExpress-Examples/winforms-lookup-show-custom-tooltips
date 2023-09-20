Imports System
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Popup

Namespace LookUpEditWithHints

    Friend Class LookUpEditHints
        Inherits LookUpEdit

        Shared Sub New()
            RepositoryItemLookUpEditHints.RegisterLookUpEditHints()
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return RepositoryItemLookUpEditHints.LookUpEditHintsName
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Overloads ReadOnly Property Properties As RepositoryItemLookUpEditHints
            Get
                Return TryCast(MyBase.Properties, RepositoryItemLookUpEditHints)
            End Get
        End Property

        Protected Overrides Function CreatePopupForm() As PopupBaseForm
            Return New PopupLookUpEditHintsForm(Me)
        End Function

        Public Property DescriptionField As String
            Set(ByVal value As String)
                Properties.DescriptionField = value
                OnPropertiesChanged()
            End Set

            Get
                Return Properties.DescriptionField
            End Get
        End Property

        Public Custom Event BeforeShowingTooltip As EventHandler
            AddHandler(ByVal value As EventHandler)
                AddHandler Properties.BeforeShowingTooltip, value
            End AddHandler

            RemoveHandler(ByVal value As EventHandler)
                RemoveHandler Properties.BeforeShowingTooltip, value
            End RemoveHandler

            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
            End RaiseEvent
        End Event
    End Class
End Namespace
