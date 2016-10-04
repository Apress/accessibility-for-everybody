<%@ Register TagPrefix="speech1" Namespace="Microsoft.Web.UI.SpeechControls.ApplicationControls" Assembly="Microsoft.Web.UI.SpeechControls.ApplicationControls, Version=1.0.3200.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Page language="c#" Codebehind="SAPIDemo.aspx.cs" AutoEventWireup="false" Inherits="SAPIDemo.WebForm1" %>
<%@ Register TagPrefix="speech" Namespace="Microsoft.Web.UI.SpeechControls" Assembly="Microsoft.Web.UI.SpeechControls, Version=1.0.3200.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Simple SAPI Demonstration</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK media="screen" href="MyStyle.css" type="text/css" rel="StyleSheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" xmlns:speech="http://schemas.microsoft.com/AspNet/SpeechControls">
		<script src="SAPIDemo.pf" type="text/jscript"></script>
		<form id="SomeForm" method="post" runat="server">
			<!-- PROMPT FUNCTION HELPER -->
			<script language="C#" runat="server">
				string GetDatabases()
				{
					string allDatabases = System.Configuration.ConfigurationSettings.AppSettings["MSPromptDatabases"];
					if (null == allDatabases) {return "";}
					string[] arrayDatabases = allDatabases.Split(';');
					string tagDatabases = "";
					for (int i = 0; i < arrayDatabases.GetLength(0); i++)
					{
						string dbFile = arrayDatabases[i].Replace("file:///","");
						dbFile = dbFile.Replace("\\","\\\\");
						tagDatabases += "<DATABASE FNAME='" + dbFile + "'/>";
					}
					return tagDatabases;
				}
			</script>
			<!-- PROMPT FUNCTION HELPER -->
			<script language="jscript">
			<!--
				var _app_promptprefix = "<PROMPT_OUTPUT><%= GetDatabases() %>";
				var _app_promptsuffix = "</PROMPT_OUTPUT>";
			//-->
			</script>
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 52px; POSITION: absolute; TOP: 28px" runat="server">Welcome to the SAPI Demonstration page!</asp:label>
			<asp:Label id="Label2" style="Z-INDEX: 110; LEFT: 219px; POSITION: absolute; TOP: 56px" runat="server">Do you want to display the rest of the controls? (Yes or No)</asp:Label>
			<asp:TextBox id="txtDisplayControl" style="Z-INDEX: 109; LEFT: 52px; POSITION: absolute; TOP: 54px" accessKey="D" runat="server" ToolTip="Type Yes to display the controls and No to end the application."></asp:TextBox>
			<asp:TextBox id="txtColor" style="Z-INDEX: 105; LEFT: 52px; POSITION: absolute; TOP: 92px" accessKey="C" runat="server" ToolTip="Type or say one of the three selected colors." Visible="False"></asp:TextBox>
			<asp:Label id="lblColor" style="Z-INDEX: 104; LEFT: 219px; POSITION: absolute; TOP: 96px" runat="server" Width="184px" Visible="False">Type Red, Green, or Blue.</asp:Label>
			<speech:qa id="Greeting" style="Z-INDEX: 102; LEFT: 76px; POSITION: absolute; TOP: 155px" runat="server" PlayOnce="True">
				<Prompt InlinePrompt="Greetings! Welcome to the SAPI Demonstration page!" BargeIn="False" ID="SayGreeting"></Prompt>
			</speech:qa><speech:semanticmap id="Semantics" style="Z-INDEX: 103; LEFT: 194px; POSITION: absolute; TOP: 154px" runat="server">
				<SemItems>
					<speech:SemanticItem TargetAttribute="value" ID="siDisplayControl" TargetElement="txtDisplayControl"></speech:SemanticItem>
					<speech:SemanticItem TargetAttribute="value" ID="siColor" TargetElement="txtColor"></speech:SemanticItem>
				</SemItems>
			</speech:semanticmap>
			<speech:QA id="DisplayControls" style="Z-INDEX: 108; LEFT: 332px; POSITION: absolute; TOP: 151px" runat="server">
				<Prompt InlinePrompt="Do you want to display the rest of the controls?"></Prompt>
				<Answers>
					<speech:Answer SemanticItem="siDisplayControl" XpathTrigger="./DisplayControls"></speech:Answer>
				</Answers>
				<Reco InitialTimeout="5000" BabbleTimeout="10000" EndSilence="2000" MaxTimeout="30000">
					<Grammars>
						<speech:Grammar Src="SAPIDemo.grxml#Group1"></speech:Grammar>
					</Grammars>
				</Reco>
				<ExtraAnswers>
					<speech:Answer SemanticItem="siColor" XpathTrigger="./GetColor"></speech:Answer>
				</ExtraAnswers>
			</speech:QA>
			<speech:QA id="GetAColor" style="Z-INDEX: 106; LEFT: 462px; POSITION: absolute; TOP: 153px" runat="server" Enabled="False">
				<Prompt InlinePrompt="Which color would you like to use, Red, Green, or Blue?"></Prompt>
				<Answers>
					<speech:Answer SemanticItem="siColor" XpathTrigger="./GetColor"></speech:Answer>
				</Answers>
				<Reco InitialTimeout="5000" BabbleTimeout="10000" EndSilence="2000" MaxTimeout="30000">
					<Grammars>
						<speech:Grammar Src="SAPIDemo.grxml#Group2"></speech:Grammar>
					</Grammars>
				</Reco>
			</speech:QA>
			<speech:QA id="Goodbye" style="Z-INDEX: 107; LEFT: 587px; POSITION: absolute; TOP: 155px" runat="server" PlayOnce="True" Enabled="False">
				<Prompt PromptSelectFunction="Goodbye_prompt" BargeIn="False"></Prompt>
			</speech:QA>
		</form>
	</body>
</HTML>
