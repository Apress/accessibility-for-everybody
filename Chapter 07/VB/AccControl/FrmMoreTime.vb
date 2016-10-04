Imports System.ComponentModel

Public Class FrmMoreTime
   Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

   <Description("The constructor for the form that allows the user to select more time.")> _
Public Sub New(ByVal CurrentTime As Int32)
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Initize the current time value.
      lblCurrentTime.Text = "The Current Time is: " + CurrentTime.ToString()

      ' Initialize the up/down control value.
      txtNewValue.Value = CurrentTime
   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents MoreTimeToolTip As System.Windows.Forms.ToolTip
   Friend WithEvents txtNewValue As System.Windows.Forms.NumericUpDown
   Friend WithEvents label2 As System.Windows.Forms.Label
   Friend WithEvents lblCurrentTime As System.Windows.Forms.Label
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOK As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.MoreTimeToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me.txtNewValue = New System.Windows.Forms.NumericUpDown
      Me.label2 = New System.Windows.Forms.Label
      Me.lblCurrentTime = New System.Windows.Forms.Label
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOK = New System.Windows.Forms.Button
      CType(Me.txtNewValue, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtNewValue
      '
      Me.txtNewValue.AccessibleDescription = "Use this control to change the value of the timer interval in seconds."
      Me.txtNewValue.AccessibleName = "Timer Value Change"
      Me.txtNewValue.AccessibleRole = System.Windows.Forms.AccessibleRole.SpinButton
      Me.txtNewValue.Location = New System.Drawing.Point(8, 88)
      Me.txtNewValue.Name = "txtNewValue"
      Me.txtNewValue.TabIndex = 5
      Me.MoreTimeToolTip.SetToolTip(Me.txtNewValue, "Use this control to change the value of the timer interval in seconds.")
      '
      'label2
      '
      Me.label2.Location = New System.Drawing.Point(8, 64)
      Me.label2.Name = "label2"
      Me.label2.TabIndex = 4
      Me.label2.Text = "&New Timer Value"
      '
      'lblCurrentTime
      '
      Me.lblCurrentTime.AccessibleDescription = "This label tells how many seconds are left on the current timer."
      Me.lblCurrentTime.AccessibleName = "Current Timer Value"
      Me.lblCurrentTime.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText
      Me.lblCurrentTime.Location = New System.Drawing.Point(8, 16)
      Me.lblCurrentTime.Name = "lblCurrentTime"
      Me.lblCurrentTime.Size = New System.Drawing.Size(176, 40)
      Me.lblCurrentTime.TabIndex = 8
      Me.lblCurrentTime.Text = "label1"
      Me.MoreTimeToolTip.SetToolTip(Me.lblCurrentTime, "This label tells how many seconds are left on the current timer.")
      '
      'btnCancel
      '
      Me.btnCancel.AccessibleDescription = "This button cancels any change to the timer value."
      Me.btnCancel.AccessibleName = "Timer Value Change Cancel"
      Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(208, 40)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.TabIndex = 7
      Me.btnCancel.Text = "&Cancel"
      Me.MoreTimeToolTip.SetToolTip(Me.btnCancel, "This button cancels any change to the timer value.")
      '
      'btnOK
      '
      Me.btnOK.AccessibleDescription = "This button accepts the changed time value."
      Me.btnOK.AccessibleName = "Timer Value Change Accept"
      Me.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(208, 8)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.TabIndex = 6
      Me.btnOK.Text = "&OK"
      Me.MoreTimeToolTip.SetToolTip(Me.btnOK, "This button accepts the changed time value.")
      '
      'FrmMoreTime
      '
      Me.AcceptButton = Me.btnOK
      Me.AccessibleDescription = "This dialog box enables the user to add more time to the timer interval."
      Me.AccessibleName = "Add Time to the Timer"
      Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.Add(Me.txtNewValue)
      Me.Controls.Add(Me.label2)
      Me.Controls.Add(Me.lblCurrentTime)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Name = "FrmMoreTime"
      Me.Text = "Add Time to the Timer"
      Me.MoreTimeToolTip.SetToolTip(Me, "This dialog box enables the user to add more time to the timer interval.")
      CType(Me.txtNewValue, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   ' Internal time track variable and associated public property.
   Private _NewTime As Int32

   '/ <summary>
   '/ The new time value the user selected for the automatic
   '/ click value.
   '/ </summary>
   <Description("The new time value the user selected for the automatic click value.")> _
   Public ReadOnly Property NewTime() As Int32
      Get
         Return _NewTime
      End Get
   End Property

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      ' Save the new value.
      _NewTime = Convert.ToInt32(txtNewValue.Value)

      ' Exit the form.
      Close()
   End Sub

   Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      ' Exit the form.
      Close()
   End Sub
End Class
