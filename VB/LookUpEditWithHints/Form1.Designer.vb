Namespace LookUpEditWithHints

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.lookUpEditHints1 = New LookUpEditWithHints.LookUpEditHints()
            CType((Me.lookUpEditHints1.Properties), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' lookUpEditHints1
            ' 
            Me.lookUpEditHints1.DescriptionField = ""
            Me.lookUpEditHints1.Location = New System.Drawing.Point(47, 12)
            Me.lookUpEditHints1.Name = "lookUpEditHints1"
            Me.lookUpEditHints1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.lookUpEditHints1.Properties.DescriptionField = ""
            Me.lookUpEditHints1.Size = New System.Drawing.Size(100, 20)
            Me.lookUpEditHints1.TabIndex = 0
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(184, 100)
            Me.Controls.Add(Me.lookUpEditHints1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.lookUpEditHints1.Properties), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private lookUpEditHints1 As LookUpEditWithHints.LookUpEditHints
    End Class
End Namespace
