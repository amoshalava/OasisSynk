<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOasisSynk
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("amos")
        Me.picbLogo = New System.Windows.Forms.PictureBox()
        Me.lstvSynkList = New System.Windows.Forms.ListView()
        Me.btnAdd = New System.Windows.Forms.Button()
        CType(Me.picbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picbLogo
        '
        Me.picbLogo.BackgroundImage = Global.OasisSynk.My.Resources.Resources.Oasis_2
        Me.picbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picbLogo.Location = New System.Drawing.Point(12, 12)
        Me.picbLogo.Name = "picbLogo"
        Me.picbLogo.Size = New System.Drawing.Size(309, 135)
        Me.picbLogo.TabIndex = 0
        Me.picbLogo.TabStop = False
        '
        'lstvSynkList
        '
        Me.lstvSynkList.HideSelection = False
        Me.lstvSynkList.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lstvSynkList.Location = New System.Drawing.Point(12, 153)
        Me.lstvSynkList.Name = "lstvSynkList"
        Me.lstvSynkList.Size = New System.Drawing.Size(775, 217)
        Me.lstvSynkList.TabIndex = 1
        Me.lstvSynkList.UseCompatibleStateImageBehavior = False
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(740, 376)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(47, 43)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "+"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'frmOasisSynk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 433)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lstvSynkList)
        Me.Controls.Add(Me.picbLogo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOasisSynk"
        Me.Text = "OasisSynk"
        CType(Me.picbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picbLogo As PictureBox
    Friend WithEvents lstvSynkList As ListView
    Friend WithEvents btnAdd As Button
End Class
