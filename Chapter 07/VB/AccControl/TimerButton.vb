Imports System.ComponentModel
Imports System.Windows.Forms

Namespace AccControl
   Public Class TimerButton
      Inherits Button
#Region "Private Variables"
      ' Keeps track of the automatic button click time and the countdown 
      ' display time on the button.
      Private CounterTimer As Timer
      ' The context menu used to obtain more time.
      Private mnuTimeSelect As ContextMenu
      ' The More Time menu item.
      Private mnuMoreTime As MenuItem
      ' A tool tip that describes the countdown function.
      Private TimeNote As ToolTip
      ' Keeps track of the remaining time.
      Private TimeLeft As Int32
      ' Determines if the button displays the count.
      Private _CountdownEnabled As Boolean
      ' Contains the TimerInterval property value.
      Private _TimerInterval As Int32
      ' Contains the old timer caption.
      Private _OldCaption As String
      ' Determines if the timer is started.
      Private _TimerStarted As Boolean
      ' Determines if the user clicked the button or it automatically
      ' clicked.
      Private _AutoClick As Boolean
      ' Tracks the state of the context menu.
      Private _NoMoreTime As Boolean
#End Region

#Region "Constructor"
      <Description("The constructor for the TimerButton control.")> _
      Public Sub New()
         ' Create the countdown display timer. Set it to
         ' display once a second.
         CounterTimer = New Timer
         AddHandler CounterTimer.Tick, AddressOf Me.CounterTimer_Tick
         CounterTimer.Interval = 1000

         ' Create the menu item.
         mnuMoreTime = New MenuItem
         mnuMoreTime.DefaultItem = True
         mnuMoreTime.Index = 0
         mnuMoreTime.Text = "&More Time"
         AddHandler mnuMoreTime.Click, AddressOf Me.mnuMoreTime_Click

         ' Create the context menu and add the menu item.
         mnuTimeSelect = New ContextMenu(New MenuItem() {mnuMoreTime})

         ' Create the tool tip.
         TimeNote = New ToolTip
         TimeNote.SetToolTip( _
            Me, _
            "This is a timed button. Right click the button and choose " + _
            "More Time from the context menu to change the time " + _
            "interval.")

         ' Add the features to the control.
         Me.ContextMenu = mnuTimeSelect
         Me.Text = "TimerButton"

         ' Initialize the property values.
         _CountdownEnabled = True
         _TimerInterval = 15
         _AutoClick = False
         _TimerStarted = False
         _NoMoreTime = False
      End Sub
#End Region

#Region "TimedButton Properties"
      <Description("Sets the timing interval for the timer in seconds.")> _
      Public Property TimerInterval() As Int32
         Get
            Return _TimerInterval
         End Get
         Set(ByVal Value As Int32)
            If (Value > 0) Then
               _TimerInterval = Value
            End If
         End Set
      End Property


      <Description("Enables the count down display in the button caption.")> _
      Public Property CountdownEnabled() As Boolean
         Get
            Return _CountdownEnabled
         End Get
         Set(ByVal Value As Boolean)
            _CountdownEnabled = Value
         End Set
      End Property

      <Description("Returns the amount of time left before the automatic click takes place.")> _
      Public ReadOnly Property TimerValue() As Int32
         Get
            Return TimeLeft
         End Get
      End Property

      <Description("Returns true if the timer is running.")> _
      Public ReadOnly Property TimerEnabled() As Boolean
         Get
            Return CounterTimer.Enabled
         End Get
      End Property

      <Description("Returns true when the timer is started.")> _
      Public ReadOnly Property TimerStarted() As Boolean
         Get
            Return _TimerStarted
         End Get
      End Property

      <Description("Returns true when the button automatically clicks itself rather than receiving a click from the user.")> _
      Public ReadOnly Property AutoClick() As Boolean
         Get
            Return _AutoClick
         End Get
      End Property

      <Description("This property turns the More Time context menu On " + _
                   "and Off. Setting this value to true turns the " + _
                   "menu Off, which means the user won't be able to " + _
                   "change the timeout value.")> _
      Public Property NoMoreTimeMenu() As Boolean
         Get
            Return _NoMoreTime
         End Get
         Set(ByVal Value As Boolean)
            ' Provide special handling if the developer chooses to
            ' turn the menu option off.
            If (Value = True) Then
               ' If the control is in design mode, make sure the
               ' developer is aware of the effects of this choice.
               If (Me.DesignMode) Then
                  ' Make sure the developer wants to make the change.
                  Dim Result As DialogResult
                  Result = MessageBox.Show( _
                     "Setting this value to true will prevent " + _
                     "the user from changing the timeout value. Do " + _
                     "you want to make this change?", _
                     "Value Change Warning", _
                     MessageBoxButtons.YesNo, _
                     MessageBoxIcon.Warning)

                  ' If the deveveloper does want to make the change set
                  ' the property to true and turn off support for the
                  ' event handler.
                  If (Result = DialogResult.Yes) Then
                     _NoMoreTime = Value
                     Me.ContextMenu = Nothing
                  End If
               Else
                  ' The control is not in design mode, so make the
                  ' required changes.
                  _NoMoreTime = Value
                  Me.ContextMenu = Nothing
               End If
               ' If the developer is returning the control to its default
               ' value, then make the change.
            Else
               _NoMoreTime = Value
               Me.ContextMenu = mnuTimeSelect
            End If
         End Set
      End Property
#End Region

#Region "TimedButton Methods"
      <Description("Turns the button timer on so that the button will click automatically when time expires.")> _
      Public Sub TimerStart(ByVal Start As Boolean)
         If (Start) Then
            ' Reset the AutoClick property.
            _AutoClick = False

            ' Save the old caption for later use.
            _OldCaption = Me.Text

            ' Set the time keeper and the timer.
            TimeLeft = _TimerInterval
            CounterTimer.Start()
            _TimerStarted = True
         Else
            ' Stop the timer.
            CounterTimer.Stop()

            ' Restore the original caption.
            Me.Text = _OldCaption
            _TimerStarted = False
         End If
      End Sub

      <Description("This method resets the AutoClick value to a user click state.")> _
      Public Sub AutoClickReset()
         ' Reset the AutoClick value.
         _AutoClick = False
      End Sub
#End Region

#Region "TimedButton Internal Event Handlers"
      Private Sub CounterTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
         Dim EA As System.EventArgs   ' Used When Raising an Event.

         ' Initialize the EventArgs.
         EA = New EventArgs

         ' If the developer enables the count down function, then
         ' display the remaining time as the button caption.
         If (_CountdownEnabled) Then
            Me.Text = "&Time: " + TimeLeft.ToString()
         End If

         ' Click the button automatically when time expires.
         If (TimeLeft = 0) Then
            ' Turn the timer off.
            CounterTimer.Stop()

            ' Set the result value to reflect an automatic click.
            _AutoClick = True

            ' Fire the event.
            OnClick(EA)
         Else
            ' Decrement the counter.
            TimeLeft = TimeLeft - 1
         End If
      End Sub

      Private Sub mnuMoreTime_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         ' Stop the timer so the user has time to make a change.
         If (_TimerStarted) Then
            CounterTimer.Stop()
         End If

         ' Create an instance of the time change form.
         Dim ChangeData As FrmMoreTime
         ChangeData = New FrmMoreTime(TimeLeft)

         ' Display the form and obtain a result.
         Dim MyResult As DialogResult
         MyResult = ChangeData.ShowDialog(Me)

         ' If the user clicked OK, change the time value.
         If (MyResult = DialogResult.OK) Then
            TimeLeft = ChangeData.NewTime
         End If

         ' Restart the timer so the button keeps track of the time.
         If (_TimerStarted) Then
            CounterTimer.Start()
         End If
      End Sub
#End Region
   End Class
End Namespace
