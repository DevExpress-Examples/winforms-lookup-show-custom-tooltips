Imports System.Data
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Utils
Imports System.Drawing

Namespace LookUpEditWithHints

    Friend Class PopupLookUpEditHintsForm
        Inherits PopupLookUpEditForm

        Private prevPoint As Point = Point.Empty

        Private tt As ToolTipController

        Private dt As DataTable

        Private prevRowIndex As Integer = -1

        Public Sub New(ByVal ownerEdit As LookUpEditHints)
            MyBase.New(ownerEdit)
            If Me.OwnerEdit.ToolTipController Is Nothing Then tt = ToolTipController.DefaultController
            AddHandler tt.BeforeShow, New ToolTipControllerBeforeShowEventHandler(AddressOf tt_BeforeShow)
            dt = TryCast(Me.OwnerEdit.Properties.DataSource, DataTable)
        End Sub

        Private Sub tt_BeforeShow(ByVal sender As Object, ByVal e As ToolTipControllerShowEventArgs)
            Dim le As LookUpEditHints = TryCast(OwnerEdit, LookUpEditHints)
            le.Properties.OnBeforeShowingTooltip(e)
        End Sub

        Public Overrides Sub ShowPopupForm()
            SetToolTipController()
            SetDataTable()
            MyBase.ShowPopupForm()
        End Sub

        Private Sub SetToolTipController()
            If OwnerEdit.ToolTipController IsNot Nothing AndAlso OwnerEdit.ToolTipController IsNot tt Then
                tt = OwnerEdit.ToolTipController
                AddHandler tt.BeforeShow, New ToolTipControllerBeforeShowEventHandler(AddressOf tt_BeforeShow)
            End If
        End Sub

        Private Sub SetDataTable()
            dt = If(dt IsNot TryCast(OwnerEdit.Properties.DataSource, DataTable), TryCast(OwnerEdit.Properties.DataSource, DataTable), dt)
        End Sub

        Protected Overrides Sub CheckMouseCursor(ByVal ht As LookUpPopupHitTest)
            If prevPoint.X <> ht.Point.X OrElse prevPoint.Y <> ht.Point.Y Then
                prevPoint = ht.Point
                Dim le As LookUpEditHints = TryCast(OwnerEdit, LookUpEditHints)
                Dim column As LookUpColumnInfo
                Dim columnPos As Integer = -1
                For i As Integer = 0 To OwnerEdit.Properties.Columns.Count - 1
                    column = OwnerEdit.Properties.Columns(i)
                    If Equals(column.FieldName, le.Properties.DescriptionField) Then
                        columnPos = i
                        Exit For
                    End If
                Next

                If columnPos <> -1 Then
                    If ht.HitType = LookUpPopupHitType.Row Then
                        If ht.Index <> prevRowIndex Then
                            tt.HideHint()
                            prevRowIndex = ht.Index
                        End If

                        tt.ShowHint(dt.Rows(ht.Index)(columnPos).ToString())
                    End If
                End If
            End If

            MyBase.CheckMouseCursor(ht)
        End Sub
    End Class
End Namespace
