<%@ Page Inherits="Microsoft.Saturn.Framework.Mobile.UI.MobilePage, Microsoft.Saturn.Framework.Mobile, Version=0.5.464.0, Culture=neutral, PublicKeyToken=6f763c9966660626" Language="C#" ClassName="SimpleTest" Debug="True" Culture="en-US" %>
<%@ Register TagPrefix="Mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<script runat="server">

    // Insert page code here
    //
    
    void btnTest1_Click(Object sender, EventArgs e)
    {
        // Only work with the control on the first form.
        lblOutput1.Text = "This is the first control form.";
        lblOutput3.Text = "This is the first output control.";
    }
    
    void btnTest2_Click(Object sender, EventArgs e)
    {
        // Only work with the control on the second form.
        txtOutput2.Text = "This is the second control form.";
        txtOutput4.Text = "This is the second output control.";
    }

</script>
<Mobile:Form id="frmWelcome" title="Test Mobile Web Page" runat="server" Paginate="True">
    <p>
        Welcome to the<br />
        First Mobile Example 
    </p>
    <p>
        <Mobile:Label id="lblOutput3" runat="server" Visible="False">
            <DeviceSpecific>
                <Choice filter="isPocketIE" visible="True" text="Pocket PC Output"></Choice>
                <Choice filter="isHTML32" visible="True" text="Output HTML32"></Choice>
            </DeviceSpecific>
Label</Mobile:Label>
        <Mobile:Command id="btnTest3" onclick="btnTest1_Click" runat="server" Visible="False">
            <DeviceSpecific>
                <Choice filter="isPocketIE" visible="True" text="Click Me"></Choice>
                <Choice filter="isHTML32" visible="True" text="Click Me HTML32"></Choice>
            </DeviceSpecific>
Command</Mobile:Command>
        <Mobile:Link id="Link1" runat="server" Visible="False" NavigateUrl="#frmSecondControls">
            <DeviceSpecific>
                <Choice filter="isPocketIE" visible="True"></Choice>
                <Choice filter="isHTML32" visible="False"></Choice>
            </DeviceSpecific>
Second Page</Mobile:Link>
        <Mobile:TextBox id="txtOutput4" runat="server" Visible="False">
            <DeviceSpecific>
                <Choice filter="isPocketIE" visible="False" text="Some Output"></Choice>
                <Choice filter="isHTML32" visible="True" text="HTML32 Output"></Choice>
            </DeviceSpecific>
        </Mobile:TextBox>
        <Mobile:Command id="btnTest4" onclick="btnTest2_Click" runat="server" Visible="False">
            <DeviceSpecific>
                <Choice filter="isPocketIE" visible="False" text="Click to Test"></Choice>
                <Choice filter="isHTML32" visible="True" text="Click to Test HTML32"></Choice>
            </DeviceSpecific>
Command</Mobile:Command>
        <Mobile:Link id="Link2" runat="server" NavigateUrl="#frmFirstControls">
            <DeviceSpecific>
                <Choice filter="isPocketIE" visible="False"></Choice>
                <Choice filter="isHTML32" visible="False"></Choice>
            </DeviceSpecific>
Next Page</Mobile:Link>
    </p>
</Mobile:Form>
<mobile:Form id="frmFirstControls" title="Test Mobile Web Page (Page 2)" runat="server" Paginate="True">
    <Mobile:Label id="lblOutput1" runat="server" Alignment="Left">Output</Mobile:Label>
    <Mobile:Command id="btnTest1" onclick="btnTest1_Click" runat="server">
Click Me</Mobile:Command>
    <Mobile:Link id="Link3" runat="server" NavigateUrl="#frmSecondControls">Next Page</Mobile:Link>
</mobile:Form>
<Mobile:Form id="frmSecondControls" title="Test Mobile Web Page (Page 3)" runat="server" Paginate="True">
    <Mobile:TextBox id="txtOutput2" runat="server">Some Output</Mobile:TextBox>
    <Mobile:Command id="btnTest2" onclick="btnTest2_Click" runat="server">Click to Test</Mobile:Command>
    <Mobile:Link id="Link4" runat="server" NavigateUrl="#frmWelcome">First Page</Mobile:Link>
</Mobile:Form>