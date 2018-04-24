Namespace Dashboard_LayoutCustomization
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.dashboardViewer1 = New DevExpress.DashboardWin.DashboardViewer(Me.components)
            Me.btnUpdateLayout = New System.Windows.Forms.Button()
            CType(Me.dashboardViewer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' dashboardViewer1
            ' 
            Me.dashboardViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dashboardViewer1.Location = New System.Drawing.Point(0, 0)
            Me.dashboardViewer1.Name = "dashboardViewer1"
            Me.dashboardViewer1.PrintingOptions.DocumentContentOptions.FilterState = DevExpress.DashboardWin.DashboardPrintingFilterState.None
            Me.dashboardViewer1.Size = New System.Drawing.Size(890, 459)
            Me.dashboardViewer1.TabIndex = 0
            ' 
            ' btnUpdateLayout
            ' 
            Me.btnUpdateLayout.Location = New System.Drawing.Point(0, 0)
            Me.btnUpdateLayout.Name = "btnUpdateLayout"
            Me.btnUpdateLayout.Size = New System.Drawing.Size(105, 23)
            Me.btnUpdateLayout.TabIndex = 1
            Me.btnUpdateLayout.Text = "Update Layout"
            Me.btnUpdateLayout.UseVisualStyleBackColor = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(890, 459)
            Me.Controls.Add(Me.btnUpdateLayout)
            Me.Controls.Add(Me.dashboardViewer1)
            Me.Name = "Form1"
            Me.Text = "Dashboard Viewer"
            CType(Me.dashboardViewer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private dashboardViewer1 As DevExpress.DashboardWin.DashboardViewer
        Private WithEvents btnUpdateLayout As System.Windows.Forms.Button
    End Class
End Namespace

