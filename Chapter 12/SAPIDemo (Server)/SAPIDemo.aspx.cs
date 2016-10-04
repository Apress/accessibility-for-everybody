using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SAPIDemo
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtColor;
		protected Microsoft.Web.UI.SpeechControls.QA Goodbye;
		protected System.Web.UI.WebControls.Label lblColor;
		protected Microsoft.Web.UI.SpeechControls.QA DisplayControls;
		protected System.Web.UI.WebControls.TextBox txtDisplayControl;
		protected System.Web.UI.WebControls.Label Label2;
		protected Microsoft.Web.UI.SpeechControls.SemanticMap Semantics;
		protected Microsoft.Web.UI.SpeechControls.QA GetAColor;
		protected Microsoft.Web.UI.SpeechControls.QA Greeting;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.txtDisplayControl.TextChanged += new System.EventHandler(this.txtDisplayControl_TextChanged);
			this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void txtDisplayControl_TextChanged(object sender, System.EventArgs e)
		{
			if (txtDisplayControl.Text == "Yes")
			{
				// Display the other controls if the user says yes.
				txtColor.Visible = true;
				lblColor.Visible = true;
				GetAColor.Enabled = true;
			}
			else
				// Tell the reader goodbye.
				Goodbye.Enabled = true;
		}

		private void txtColor_TextChanged(object sender, System.EventArgs e)
		{
			// Tell the reader goodbye.
			Goodbye.Enabled = true;
		}
	}
}
