Imports System
Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWin
Imports System.IO

Namespace Dashboard_LayoutCustomization
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			AddHandler dashboardViewer1.CustomizeDashboardTitle, AddressOf DashboardViewer1_CustomizeDashboardTitle
			dashboardViewer1.LoadDashboard("Data\LayoutUnordered.xml")
		End Sub

		Private Sub ChangeLayout(ByVal args As DashboardToolbarItemClickEventArgs)
			Dim dashboard As New Dashboard()
			dashboard.LoadFromXml("Data\LayoutUnordered.xml")
			dashboard.BeginUpdate()
			' Switch off the DateFilter item's AutoHeight arrangement mode so that the DateFilter layout does not ignore its layout weight.
			CType(dashboard.Items("dateFilterDashboardItem1"), DateFilterDashboardItem).ArrangementMode = DateFilterArrangementMode.Horizontal
			' Hide captions.
			dashboard.Items.ForEach(Sub(item) item.ShowCaption = False)
			dashboard.Groups.ForEach(Sub(item) item.ShowCaption = False)
			' Create layout items for the DateFilter and Chart dashboard items.
			Dim dateFilterLayoutItem As New DashboardLayoutItem(dashboard.Items("dateFilterDashboardItem1"), 13)
			Dim chartLayoutItem As New DashboardLayoutItem(dashboard.Items("chartDashboardItem1"), 87)
			' Create a layout item for the dashboard Group item.
			Dim groupLayoutItem As New DashboardLayoutGroup() With {.Orientation = DashboardLayoutGroupOrientation.Vertical, .DashboardItem = dashboard.Groups("dashboardItemGroup1"), .Weight = 70}
			' Connect layout items in the layout tree.
			groupLayoutItem.ChildNodes.AddRange(dateFilterLayoutItem, chartLayoutItem)
			' Create a Grid layout item.
			Dim gridLayoutItem As New DashboardLayoutItem(dashboard.Items("gridDashboardItem1"), 30)
			' Create a group layout item to organize the Grid layout item and a Dashboard Group layout item.
			Dim layoutGroup As New DashboardLayoutGroup(DashboardLayoutGroupOrientation.Horizontal, 85)
			' Connect layout items in the layout tree.
			layoutGroup.ChildNodes.AddRange(gridLayoutItem, groupLayoutItem)
			' Create a RangeFilter layout item.
			Dim rangeFilterLayoutItem As New DashboardLayoutItem(dashboard.Items("rangeFilterDashboardItem1"), 15)
			' Create a root layout group. Its DashboardItem property is null.
			Dim rootGroup As New DashboardLayoutGroup() With {.Orientation = DashboardLayoutGroupOrientation.Vertical, .Weight = 100, .DashboardItem = Nothing}
			' Connect layout items in the layout tree. 
			rootGroup.ChildNodes.AddRange(layoutGroup, rangeFilterLayoutItem)
			' The layout treee is built. Set the dashboard's root layout node to finalize the layout.
			dashboard.LayoutRoot = rootGroup
			dashboard.EndUpdate()

			dashboardViewer1.Dashboard = dashboard
		End Sub

		Private Sub RepositionItems(ByVal args As DashboardToolbarItemClickEventArgs)
			Dim dashboard As Dashboard = dashboardViewer1.Dashboard
			Dim rootGroup As DashboardLayoutGroup = TryCast(dashboard.LayoutRoot.ChildNodes(0), DashboardLayoutGroup)
			If (rootGroup IsNot Nothing) AndAlso (rootGroup.ChildNodes.Count > 1) Then
				rootGroup.ChildNodes(0).MoveRight(rootGroup.ChildNodes(1))
			End If
		End Sub

		Private Sub SaveLayoutToFile(ByVal args As DashboardToolbarItemClickEventArgs)
			dashboardViewer1.SaveDashboardLayout("DashboardLayout.xml")
		End Sub

		Private Sub LoadLayoutFromFile(ByVal obj As DashboardToolbarItemClickEventArgs)
			If File.Exists("DashboardLayout.xml") Then
				dashboardViewer1.LoadDashboardLayout("DashboardLayout.xml")
			End If
		End Sub

		Private Sub DashboardViewer1_CustomizeDashboardTitle(ByVal sender As Object, ByVal e As CustomizeDashboardTitleEventArgs)
			Dim exportItem = e.Items.FirstOrDefault(Function(i) i.ButtonType = DashboardButtonType.Export)
			If exportItem IsNot Nothing Then
				e.Items.Remove(exportItem)
			End If
			Dim btnChangeLayout As New DashboardToolbarItem()
			btnChangeLayout.Caption = "Change Layout"
			btnChangeLayout.ClickAction = New Action(Of DashboardToolbarItemClickEventArgs)(AddressOf ChangeLayout)
			e.Items.Add(btnChangeLayout)
			Dim btnRepositionItems As New DashboardToolbarItem()
			btnRepositionItems.Caption = "Reposition Items"
			btnRepositionItems.ClickAction = New Action(Of DashboardToolbarItemClickEventArgs)(AddressOf RepositionItems)
			e.Items.Add(btnRepositionItems)
			Dim btnSaveLayout As New DashboardToolbarItem()
			btnSaveLayout.Caption = "Save Layout to File"
			btnSaveLayout.ClickAction = New Action(Of DashboardToolbarItemClickEventArgs)(AddressOf SaveLayoutToFile)
			e.Items.Add(btnSaveLayout)
			Dim btnLoadLayout As New DashboardToolbarItem()
			btnLoadLayout.Caption = "Load Layout from File"
			btnLoadLayout.ClickAction = New Action(Of DashboardToolbarItemClickEventArgs)(AddressOf LoadLayoutFromFile)
			e.Items.Add(btnLoadLayout)
		End Sub
	End Class
End Namespace
