<%@ Language = "JavaScript" %>
<% Response.Buffer = true %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Accessible Friendly Script Demonstration</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language=javascript>
			function DoAdd()
			{
				var Value1 = parseInt(TheForm.InValue1.value);
				var Value2 = parseInt(TheForm.InValue2.value);
				TheForm.Output.value = Value1 + Value2;
			}
		</script>
	</head>
	<body>
	<form method=get id=TheForm>
		<H1 align="center">Math Demonstration</H1>
		<DIV>
			<INPUT type=text 
			       id="InValue1" 
			       accesskey=1 
			       title="This is the first input value." 
				   <%if (Request.QueryString("Input1").Count > 0)
				   {
						Response.Write("value=")
						Response.Write(Request.QueryString("Input1")(1))
				   }
				   else
						Response.Write("value=0")%>
			       tabindex=1 
			       name=Input1>
			<LABEL> Input Value 1</LABEL>
		</DIV>
		<DIV>
			<INPUT type=text 
			       id="InValue2" 
			       accesskey=2 
			       title="This is the second input value." 
				   <%if (Request.QueryString("Input2").Count > 0)
				   {
						Response.Write("value=")
						Response.Write(Request.QueryString("Input2")(1))
				   }
				   else
						Response.Write("value=0")%>
			       tabindex=2 
			       name=Input2>
			<LABEL> Input Value 2</LABEL>
		</DIV>
		<DIV>
			<INPUT type=text 
			       id="Output" 
			       accesskey=O 
			       title="This is the output value." 
				   <%if ((Request.QueryString("Input1").Count > 0) &&
				         (Request.QueryString("Input2").Count > 0))
				   {
						var Value1 = parseInt(Request.QueryString("Input1")(1));
						var Value2 = parseInt(Request.QueryString("Input2")(1));
						var Sum = Value1 + Value2;
						Response.Write("value=")
						Response.Write(Sum)
				   }
				   else
						Response.Write("value=0")%>
			       tabindex=3 
			       readonly >
			<LABEL> Output Value</LABEL>
		</DIV>
		<DIV>
			<BUTTON onclick=DoAdd() 
			        title="Click this button to add the numbers." 
			        tabindex=4 
			        id=AddNumbers 
			        accesskey=A>
				Add
			</BUTTON>
		</DIV>
		<DIV>
			<NOSCRIPT>
				<DIV>
				     Your browser doesn't support scripts. 
				     Use this button instead.
				</DIV>
				<BUTTON type=submit 
				        title="Click this button to add the numbers." 
				        id=NoScriptAdd 
				        accesskey=N 
				        tabindex=5>
					No Script Add
				</BUTTON>
			</NOSCRIPT>
		</DIV>
	</form>
	</body>
</html>
