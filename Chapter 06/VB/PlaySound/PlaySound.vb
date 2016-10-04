Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace PlaySound
   Public Class PlaySound
      Inherits Component
#Region "Private field values."
      ' Determines if the system will make a sound.
      Private _MakeSound As Boolean
      ' Contains the name of the file to play.
      Private _SoundFileName As String
      ' Describes the sound to the person using ShowSounds.
      Private _ShowSoundsDescription As String
      ' Determines the hover delay for the tooltip
      ' displaying the sound description.
      Private _AutomaticDelay As Int32
      ' Determines the amount of time the tooltip
      ' will appear on screen.
      Private _AutoPopDelay As Int32

      ' Sound Text Description ToolTip
      Private TT As ToolTip

      ' This special object controls the disappearance of
      ' the sound description tooltip.
      Private NoShow As Timer
#End Region

      Public Sub New()
         ' Initialize the property values.
         _MakeSound = True
         _SoundFileName = ""
         _ShowSoundsDescription = "The System Plays a Sound"
         _AutomaticDelay = 300
         _AutoPopDelay = 7000
         NoShow = New Timer
      End Sub

#Region "PlaySound Events"
      <Description("This event fires when the system displays a ShowSounds message.")> _
      Public Event SoundDisplayed As EventHandler

      <Description("This event fires when the system generates a sound.")> _
      Public Event SoundGenerated As EventHandler
#End Region

#Region "PlaySound Properties"
      ' Each of these properties gets and/or sets a Private
      ' field within the component.

      <Description("Determines if the system will make a sound.")> _
      Public Property MakeSound() As Boolean
         Get
            Return _MakeSound
         End Get
         Set(ByVal Value As Boolean)
            _MakeSound = Value
         End Set
      End Property

      ' This property requires a special editor to ensure it works
      ' as intended.
      <Description("Contains the name of the file to play."), _
       EditorAttribute(GetType(FileNameEditor), GetType(UITypeEditor))> _
      Public Property SoundFileName() As String
         Get
            Return _SoundFileName
         End Get
         Set(ByVal Value As String)
            _SoundFileName = Value
         End Set
      End Property

      <Description("Describes the sound to the person using ShowSounds.")> _
      Public Property ShowSoundsDescription() As String
         Get
            Return _ShowSoundsDescription
         End Get
         Set(ByVal Value As String)
            If (Not Value = Nothing) Then
               _ShowSoundsDescription = Value
            End If
         End Set
      End Property

      <Description("Determines the hover delay for the tooltip displaying the sound description. (1 ms minimum)")> _
      Public Property AutomaticDelay() As Int32
         Get
            Return _AutomaticDelay
         End Get
         Set(ByVal Value As Int32)
            If (Value >= 1) Then
               _AutomaticDelay = Value
            End If
         End Set
      End Property

      <Description("Determines the amount of time the tooltip will appear on screen. (3000 ms minimum)")> _
      Public Property AutoPopDelay() As Int32
         Get
            Return _AutoPopDelay
         End Get
         Set(ByVal Value As Int32)
            If (Value >= 3000) Then
               _AutoPopDelay = Value
            End If
         End Set
      End Property
#End Region

#Region "PlaySound Methods"
      <Description("Plays the sound requested by the user or displays a text equivlaent.")> _
      Public Sub GenerateSound(ByVal Parent As Control)
         Dim EA As System.EventArgs   ' Used When Raising an Event.

         ' Initialize the EventArgs.
         EA = New EventArgs

         ' Initialize the ToolTip.
         TT = New ToolTip
         TT.AutomaticDelay = _AutomaticDelay
         TT.AutoPopDelay = _AutoPopDelay

         ' Intitialze the Timer.
         NoShow.Interval = _AutoPopDelay
         AddHandler NoShow.Tick, AddressOf Me.NoShow_Tick

         ' If the ShowSounds option is selected, display text.
         If (IsShowSoundsSelected()) Then
            ' Display the information on screen.
            TT.SetToolTip(Parent, _ShowSoundsDescription)
            TT.Active = True
            NoShow.Start()

            ' Fire the event.
            RaiseEvent SoundDisplayed(Me, EA)
         End If

         If (_MakeSound) Then
            ' Play a sound only when the user requests it.
            WinPlaySound(_SoundFileName, _
               0, _
               SND_FILENAME Or SND_ASYNC)

            ' Fire the event.
            RaiseEvent SoundGenerated(Me, EA)
         End If
      End Sub

      <Description("Returns true when the user has ShowSounds enabled.")> _
      Public Function IsShowSoundsSelected() As Boolean
         Return SystemInformation.ShowSounds
      End Function
#End Region

#Region "Win32 API Code"
      ' Define some constants for using the PlaySound() function.
      Private Const SND_SYNC As Int32 = &H0
      Private Const SND_ASYNC As Int32 = &H1
      Private Const SND_FILENAME As Int32 = &H20000

      ' Import the Windows PlaySound() function.
      <DllImport("winmm.dll", EntryPoint:="PlaySound", CharSet:=CharSet.Auto, SetLastError:=True)> _
      Private Shared Function WinPlaySound(ByVal pszSound As String, _
                                           ByVal hmod As Int32, _
                                           ByVal fdwSound As Int32) As Boolean
      End Function
#End Region

#Region "EventHandlers"
      Private Sub NoShow_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
         ' Stop displaying the sound description.
         TT.Active = False

         ' Stop the timer.
         NoShow.Stop()
      End Sub
#End Region
end class
End Namespace
