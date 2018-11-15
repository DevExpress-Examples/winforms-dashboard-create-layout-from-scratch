<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Dashboard_LayoutCustomization/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_LayoutCustomization/Form1.vb))
<!-- default file list end -->
# How to create a dashboard layout from scratch


<p>The following example demonstrates how to customize a dashboard layout in code.</p>
<br />
<p>In this example, the DashboardViewer loads an existing dashboard with the predefined layout form an XML file. The dashboard contains three dashboard items that are placed horizontally side-by-side.</p>
<p>The following steps are performed to create a new layout:</p>
<p>- Three layout items are created to display the existing dashboard items. The weight parameter specifies the layout item size.</p>
<p>- A new layout group is created to display the Grid and Chart dashboard items. The orientation parameter specifies the orientation of layout items within this group.</p>
<p>- A root layout group is created. This group contains the previously created group and the layout item displaying the Range Filter dashboard item.</p>
<p>- The root layout group is assigned to the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonDashboard_LayoutRoottopic"><u>Dashboard.LayoutRoot</u></a> property.<br /><br /><strong>See Also:</strong> <br /><a href="https://www.devexpress.com/Support/Center/p/E4768">How to create a new Dashboard, add a Grid dashboard item to it and bind it to data in code</a></p>

<br/>


