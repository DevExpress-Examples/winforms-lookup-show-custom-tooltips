Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors.ViewInfo

Namespace LookUpEditWithHints
	<UserRepositoryItem("RegisterLookUpEditHints")> _
	Friend Class RepositoryItemLookUpEditHints
		Inherits RepositoryItemLookUpEdit
		Private descriptionField_Renamed As String = ""
		Private Shared ReadOnly _beforeShowingTooltip As Object = New Object()

		Shared Sub New()
			RegisterLookUpEditHints()
		End Sub
		Public Sub New()
			MyBase.New()
		End Sub

		' Unique name for custom control
		Public Const LookUpEditHintsName As String = "LookUpEditHints"
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return LookUpEditHintsName
			End Get
		End Property

		'Register the editor
		Public Shared Sub RegisterLookUpEditHints()
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(LookUpEditHintsName, GetType(LookUpEditHints), GetType(RepositoryItemLookUpEditHints), GetType(LookUpEditViewInfo), New ButtonEditPainter(), True))
		End Sub

		Public Property DescriptionField() As String
			Set(ByVal value As String)
				descriptionField_Renamed = value
				OnPropertiesChanged()
			End Set
			Get
				Return descriptionField_Renamed
			End Get
		End Property

		Public Custom Event BeforeShowingTooltip As EventHandler
			AddHandler(ByVal value As EventHandler)
				Events.AddHandler(RepositoryItemLookUpEditHints._beforeShowingTooltip, value)
			End AddHandler
			RemoveHandler(ByVal value As EventHandler)
				Events.RemoveHandler(RepositoryItemLookUpEditHints._beforeShowingTooltip, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
			End RaiseEvent
		End Event

		Protected Friend Overridable Sub OnBeforeShowingTooltip(ByVal e As EventArgs)
			Dim handler As EventHandler = CType(Events(RepositoryItemLookUpEditHints._beforeShowingTooltip), EventHandler)
			If handler IsNot Nothing Then
				handler(GetEventSender(), e)
			End If
		End Sub

		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			BeginUpdate()
			MyBase.Assign(item)
			Dim source As RepositoryItemLookUpEditHints = TryCast(item, RepositoryItemLookUpEditHints)
			If source Is Nothing Then
				Return
			End If
			Me.DescriptionField = source.DescriptionField
			EndUpdate()
			Events.AddHandler(RepositoryItemLookUpEditHints._beforeShowingTooltip, source.Events(RepositoryItemLookUpEditHints._beforeShowingTooltip))
		End Sub
	End Class
End Namespace
