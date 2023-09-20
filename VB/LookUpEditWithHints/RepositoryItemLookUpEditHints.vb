Imports System
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo

Namespace LookUpEditWithHints

    <UserRepositoryItem("RegisterLookUpEditHints")>
    Friend Class RepositoryItemLookUpEditHints
        Inherits RepositoryItemLookUpEdit

        Private descriptionFieldField As String = ""

        Private Shared ReadOnly _beforeShowingTooltip As Object = New Object()

        Shared Sub New()
            Call RegisterLookUpEditHints()
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        ' Unique name for custom control
        Public Const LookUpEditHintsName As String = "LookUpEditHints"

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return LookUpEditHintsName
            End Get
        End Property

        'Register the editor
        Public Shared Sub RegisterLookUpEditHints()
            Call EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(LookUpEditHintsName, GetType(LookUpEditHints), GetType(RepositoryItemLookUpEditHints), GetType(LookUpEditViewInfo), New ButtonEditPainter(), True))
        End Sub

        Public Property DescriptionField As String
            Set(ByVal value As String)
                descriptionFieldField = value
                OnPropertiesChanged()
            End Set

            Get
                Return descriptionFieldField
            End Get
        End Property

        Public Custom Event BeforeShowingTooltip As EventHandler
            AddHandler(ByVal value As EventHandler)
                Events.AddHandler(_beforeShowingTooltip, value)
            End AddHandler

            RemoveHandler(ByVal value As EventHandler)
                Events.RemoveHandler(_beforeShowingTooltip, value)
            End RemoveHandler

            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
            End RaiseEvent
        End Event

        Protected Friend Overridable Sub OnBeforeShowingTooltip(ByVal e As EventArgs)
            Dim handler As EventHandler = CType(Events(_beforeShowingTooltip), EventHandler)
            If handler IsNot Nothing Then handler(GetEventSender(), e)
        End Sub

        Public Overrides Sub Assign(ByVal item As RepositoryItem)
            BeginUpdate()
            MyBase.Assign(item)
            Dim source As RepositoryItemLookUpEditHints = TryCast(item, RepositoryItemLookUpEditHints)
            If source Is Nothing Then Return
            DescriptionField = source.DescriptionField
            EndUpdate()
            Events.AddHandler(_beforeShowingTooltip, source.Events(_beforeShowingTooltip))
        End Sub
    End Class
End Namespace
