using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccControl
{
	/// <summary>
	/// This class contains the control functionality for the TimerButton
	/// control.
	/// </summary>
	public class TimerButton : Button
	{
      #region Private Variables
      // Keeps track of the automatic button click time and the countdown 
      // display time on the button.
      private  Timer       CounterTimer;
      // The context menu used to obtain more time.
      private  ContextMenu mnuTimeSelect;
      // The More Time menu item.
      private  MenuItem    mnuMoreTime;
      // A tool tip that describes the countdown function.
      private  ToolTip     TimeNote;
      // Keeps track of the remaining time.
      private  Int32       TimeLeft;
      // Determines if the button displays the count.
      private  Boolean     _CountdownEnabled;
      // Contains the TimerInterval property value.
      private  Int32       _TimerInterval;
      // Contains the old timer caption.
      private  String      _OldCaption;
      // Determines if the timer is started.
      private  Boolean     _TimerStarted;
      // Determines if the user clicked the button or it automatically
      // clicked.
      private  Boolean     _AutoClick;
      // Tracks the state of the context menu.
      private  Boolean     _NoMoreTime;
      #endregion

      #region Constructor
      /// <summary>
      /// The constructor for the TimerButton control.
      /// </summary>
      [Description("The constructor for the TimerButton control.")]
		public TimerButton()
		{
         // Create the countdown display timer. Set it to
         // display once a second.
         CounterTimer = new Timer();
         CounterTimer.Tick +=
            new System.EventHandler(this.CounterTimer_Tick);
         CounterTimer.Interval = 1000;

         // Create the menu item.
         mnuMoreTime = new MenuItem();
         mnuMoreTime.DefaultItem = true;
         mnuMoreTime.Index = 0;
         mnuMoreTime.Text = "&More Time";
         mnuMoreTime.Click +=
            new System.EventHandler(this.mnuMoreTime_Click);

         // Create the context menu and add the menu item.
         mnuTimeSelect = new ContextMenu(new MenuItem[] {mnuMoreTime});

         // Create the tool tip.
         TimeNote = new ToolTip();
         TimeNote.SetToolTip(
            this, 
            "This is a timed button. Right click the button and choose " +
            "More Time from the context menu to change the time " +
            "interval.");

         // Add the features to the control.
         this.ContextMenu = mnuTimeSelect;
         this.Text = "TimerButton";

         // Initialize the property values.
         _CountdownEnabled = true;
         _TimerInterval = 15;
         _AutoClick = false;
         _TimerStarted = false;
         _NoMoreTime = false;
      }
      #endregion

      #region TimedButton Properties
      /// <summary>
      /// Sets the timing interval for the timer
      /// in seconds.
      /// </summary>
      [Description("Sets the timing interval for the timer " +
                   "in seconds.")]
      public Int32 TimerInterval
      {
         get { return _TimerInterval; }
         set
         {
            if (value > 0)
               _TimerInterval = value;
         }
      }


      /// <summary>
      /// Enables the count down display in the button
      /// caption.
      /// </summary>
      [Description("Enables the count down display in the button " +
                   "caption.")]
      public Boolean CountdownEnabled
      {
         get { return _CountdownEnabled; }
         set { _CountdownEnabled = value; }
      }

      /// <summary>
      /// Returns the amount of time left before the
      /// automatic click takes place.
      /// </summary>
      [Description("Returns the amount of time left before the " +
                   "automatic click takes place.")]
      public Int32 TimerValue
      {
         get { return TimeLeft; }
      }

      /// <summary>
      /// Returns true if the timer is running.
      /// </summary>
      [Description("Returns true if the timer is running.")]
      public Boolean TimerEnabled
      {
         get { return CounterTimer.Enabled; }
      }

      /// <summary>
      /// Returns true when the timer is started.
      /// </summary>
      [Description("Returns true when the timer is started.")]
      public Boolean TimerStarted
      {
         get { return _TimerStarted; }
      }

      /// <summary>
      /// Returns true when the button automatically clicks itself
      /// rather than receiving a click from the user.
      /// </summary>
      [Description("Returns true when the button automatically clicks " +
                   "itself rather than receiving a click from the user.")]
      public Boolean AutoClick
      {
         get { return _AutoClick; }
      }

      /// <summary>
      /// This property turns the More Time context menu On and Off.
      /// Setting this value to true turns the menu Off, which means
      /// the user won't be able to change the timeout value.
      /// </summary>
      [Description("This property turns the More Time context menu On " +
                   "and Off. Setting this value to true turns the " +
                   "menu Off, which means the user won't be able to " +
                   "change the timeout value.")]
      public Boolean NoMoreTimeMenu
      {
         get { return _NoMoreTime; }
         set
         {
            // Provide special handling if the developer chooses to
            // turn the menu option off.
            if (value == true)
            {
               // If the control is in design mode, make sure the
               // developer is aware of the effects of this choice.
               if (this.DesignMode)
               {
                  // Make sure the developer wants to make the change.
                  DialogResult Result = MessageBox.Show(
                     "Setting this value to true will prevent " +
                     "the user from changing the timeout value. Do " +
                     "you want to make this change?",
                     "Value Change Warning",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning);

                  // If the deveveloper does want to make the change set
                  // the property to true and turn off support for the
                  // event handler.
                  if (Result == DialogResult.Yes)
                  {
                     _NoMoreTime = value;
                     this.ContextMenu = null;
                  }
               }
               else
               {
                  // The control is not in design mode, so make the
                  // required changes.
                  _NoMoreTime = value;
                  this.ContextMenu = null;
               }
            }
            // If the developer is returning the control to its default
            // value, then make the change.
            else
            {
               _NoMoreTime = value;
               this.ContextMenu = mnuTimeSelect;
            }
         }
      }
      #endregion
      
      #region TimedButton Methods
      /// <summary>
      /// Turns the button timer on so that the button will
      /// click automatically when time expires.
      /// </summary>
      /// <param name="Start">Set to true to turn the timer on or 
      /// false to turn the timer off.</param>
      [Description("Turns the button timer on so that the button will" +
                   "click automatically when time expires.")]
      public void TimerStart(Boolean Start)
      {
         if (Start)
         {
            // Reset the AutoClick property.
            _AutoClick = false;

            // Save the old caption for later use.
            _OldCaption = this.Text;

            // Set the time keeper and the timer.
            TimeLeft = _TimerInterval;
            CounterTimer.Start();
            _TimerStarted = true;
         }
         else
         {
            // Stop the timer.
            CounterTimer.Stop();

            // Restore the original caption.
            this.Text = _OldCaption;
            _TimerStarted = false;
         }
      }

      /// <summary>
      /// This method resets the AutoClick value to a user click state.
      /// </summary>
      [Description("This method resets the AutoClick value to a " +
                   "user click state.")]
      public void AutoClickReset()
      {
         // Reset the AutoClick value.
         _AutoClick = false;
      }
      #endregion

      #region TimedButton Internal Event Handlers
      private void CounterTimer_Tick(object sender, System.EventArgs e)
      {
         System.EventArgs  EA;   // Used When Raising an Event.

         // Initialize the EventArgs.
         EA = new EventArgs();

         // If the developer enables the count down function, then
         // display the remaining time as the button caption.
         if (_CountdownEnabled)
            this.Text = 
               "&Time: " + TimeLeft.ToString();

         // Click the button automatically when time expires.
         if (TimeLeft == 0)
         {
            // Turn the timer off.
            CounterTimer.Stop();

            // Set the result value to reflect an automatic click.
            _AutoClick = true;

            // Fire the event.
            OnClick(EA);
         }
         else
            // Decrement the counter.
            TimeLeft--;
      }

      private void mnuMoreTime_Click(object sender, System.EventArgs e)
      {
         // Stop the timer so the user has time to make a change.
         if (_TimerStarted)
            CounterTimer.Stop();

         // Create an instance of the time change form.
         FrmMoreTime ChangeData = new FrmMoreTime(TimeLeft);

         // Display the form and obtain a result.
         DialogResult MyResult = ChangeData.ShowDialog(this);

         // If the user clicked OK, change the time value.
         if (MyResult == DialogResult.OK)
            TimeLeft = ChangeData.NewTime;

         // Restart the timer so the button keeps track of the time.
         if (_TimerStarted)
            CounterTimer.Start();
      }
      #endregion
   }
}
