<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BtnOpenAppDatafolder = New System.Windows.Forms.Button()
        Me.BtnOpenOperaFolder = New System.Windows.Forms.Button()
        Me.btnStartClear = New System.Windows.Forms.Button()
        Me.CheckBoxChrome = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnOpenFirefoxFolder = New System.Windows.Forms.Button()
        Me.BtnOpenChromeFolder = New System.Windows.Forms.Button()
        Me.LBReports = New System.Windows.Forms.ListBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.BWDeleteFiles = New System.ComponentModel.BackgroundWorker()
        Me.CheckBoxOpera = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFirefox = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.CheckBoxInstall = New System.Windows.Forms.CheckBox()
        Me.PictureBoxInfo = New System.Windows.Forms.PictureBox()
        Me.CheckBoxAppDataTemp = New System.Windows.Forms.CheckBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.CheckBoxRecycleBin = New System.Windows.Forms.CheckBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOpenAppDatafolder
        '
        Me.BtnOpenAppDatafolder.FlatAppearance.BorderSize = 0
        Me.BtnOpenAppDatafolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnOpenAppDatafolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.BtnOpenAppDatafolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOpenAppDatafolder.Location = New System.Drawing.Point(284, 0)
        Me.BtnOpenAppDatafolder.Name = "BtnOpenAppDatafolder"
        Me.BtnOpenAppDatafolder.Size = New System.Drawing.Size(24, 19)
        Me.BtnOpenAppDatafolder.TabIndex = 21
        Me.BtnOpenAppDatafolder.Text = "..."
        Me.BtnOpenAppDatafolder.UseVisualStyleBackColor = True
        '
        'BtnOpenOperaFolder
        '
        Me.BtnOpenOperaFolder.FlatAppearance.BorderSize = 0
        Me.BtnOpenOperaFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnOpenOperaFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.BtnOpenOperaFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOpenOperaFolder.Location = New System.Drawing.Point(93, 23)
        Me.BtnOpenOperaFolder.Name = "BtnOpenOperaFolder"
        Me.BtnOpenOperaFolder.Size = New System.Drawing.Size(24, 19)
        Me.BtnOpenOperaFolder.TabIndex = 23
        Me.BtnOpenOperaFolder.Text = "..."
        Me.BtnOpenOperaFolder.UseVisualStyleBackColor = True
        '
        'btnStartClear
        '
        Me.btnStartClear.Location = New System.Drawing.Point(2, 466)
        Me.btnStartClear.Name = "btnStartClear"
        Me.btnStartClear.Size = New System.Drawing.Size(367, 26)
        Me.btnStartClear.TabIndex = 6
        Me.btnStartClear.Text = "Start Clear Cashe"
        Me.btnStartClear.UseVisualStyleBackColor = True
        '
        'CheckBoxChrome
        '
        Me.CheckBoxChrome.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxChrome.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxChrome.Location = New System.Drawing.Point(34, 2)
        Me.CheckBoxChrome.Name = "CheckBoxChrome"
        Me.CheckBoxChrome.Size = New System.Drawing.Size(57, 17)
        Me.CheckBoxChrome.TabIndex = 8
        Me.CheckBoxChrome.Text = "Chrome"
        Me.CheckBoxChrome.UseVisualStyleBackColor = False
        '
        'BtnOpenFirefoxFolder
        '
        Me.BtnOpenFirefoxFolder.FlatAppearance.BorderSize = 0
        Me.BtnOpenFirefoxFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnOpenFirefoxFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.BtnOpenFirefoxFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOpenFirefoxFolder.Location = New System.Drawing.Point(93, 48)
        Me.BtnOpenFirefoxFolder.Name = "BtnOpenFirefoxFolder"
        Me.BtnOpenFirefoxFolder.Size = New System.Drawing.Size(24, 19)
        Me.BtnOpenFirefoxFolder.TabIndex = 22
        Me.BtnOpenFirefoxFolder.Text = "..."
        Me.BtnOpenFirefoxFolder.UseVisualStyleBackColor = True
        '
        'BtnOpenChromeFolder
        '
        Me.BtnOpenChromeFolder.FlatAppearance.BorderSize = 0
        Me.BtnOpenChromeFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnOpenChromeFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.BtnOpenChromeFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOpenChromeFolder.Location = New System.Drawing.Point(93, 0)
        Me.BtnOpenChromeFolder.Name = "BtnOpenChromeFolder"
        Me.BtnOpenChromeFolder.Size = New System.Drawing.Size(24, 19)
        Me.BtnOpenChromeFolder.TabIndex = 24
        Me.BtnOpenChromeFolder.Text = "..."
        Me.BtnOpenChromeFolder.UseVisualStyleBackColor = True
        '
        'LBReports
        '
        Me.LBReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBReports.ForeColor = System.Drawing.Color.DarkOrange
        Me.LBReports.FormattingEnabled = True
        Me.LBReports.Location = New System.Drawing.Point(2, 304)
        Me.LBReports.Name = "LBReports"
        Me.LBReports.Size = New System.Drawing.Size(559, 160)
        Me.LBReports.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(375, 466)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(186, 26)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'BWDeleteFiles
        '
        Me.BWDeleteFiles.WorkerReportsProgress = True
        Me.BWDeleteFiles.WorkerSupportsCancellation = True
        '
        'CheckBoxOpera
        '
        Me.CheckBoxOpera.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxOpera.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxOpera.Location = New System.Drawing.Point(34, 24)
        Me.CheckBoxOpera.Name = "CheckBoxOpera"
        Me.CheckBoxOpera.Size = New System.Drawing.Size(57, 17)
        Me.CheckBoxOpera.TabIndex = 9
        Me.CheckBoxOpera.Text = "Opera"
        Me.CheckBoxOpera.UseVisualStyleBackColor = False
        '
        'CheckBoxFirefox
        '
        Me.CheckBoxFirefox.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxFirefox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxFirefox.Location = New System.Drawing.Point(34, 48)
        Me.CheckBoxFirefox.Name = "CheckBoxFirefox"
        Me.CheckBoxFirefox.Size = New System.Drawing.Size(57, 17)
        Me.CheckBoxFirefox.TabIndex = 12
        Me.CheckBoxFirefox.Text = "Firefox"
        Me.CheckBoxFirefox.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.CleanBrowsersCashe.My.Resources.Resources.opera_32x32
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(13, 23)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 19)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 14
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.CleanBrowsersCashe.My.Resources.Resources.mozilla_firefox_32x32
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(13, 47)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 19)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        '
        'CheckBoxInstall
        '
        Me.CheckBoxInstall.AutoSize = True
        Me.CheckBoxInstall.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxInstall.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxInstall.Location = New System.Drawing.Point(328, 23)
        Me.CheckBoxInstall.Name = "CheckBoxInstall"
        Me.CheckBoxInstall.Size = New System.Drawing.Size(186, 18)
        Me.CheckBoxInstall.TabIndex = 16
        Me.CheckBoxInstall.Text = "Check to Install on Program Files"
        Me.CheckBoxInstall.UseVisualStyleBackColor = False
        '
        'PictureBoxInfo
        '
        Me.PictureBoxInfo.BackgroundImage = Global.CleanBrowsersCashe.My.Resources.Resources.info_32x32
        Me.PictureBoxInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBoxInfo.Location = New System.Drawing.Point(540, 1)
        Me.PictureBoxInfo.Name = "PictureBoxInfo"
        Me.PictureBoxInfo.Size = New System.Drawing.Size(19, 19)
        Me.PictureBoxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxInfo.TabIndex = 17
        Me.PictureBoxInfo.TabStop = False
        '
        'CheckBoxAppDataTemp
        '
        Me.CheckBoxAppDataTemp.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxAppDataTemp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxAppDataTemp.Location = New System.Drawing.Point(152, 2)
        Me.CheckBoxAppDataTemp.Name = "CheckBoxAppDataTemp"
        Me.CheckBoxAppDataTemp.Size = New System.Drawing.Size(130, 17)
        Me.CheckBoxAppDataTemp.TabIndex = 18
        Me.CheckBoxAppDataTemp.Text = "AppData Temp Folder"
        Me.CheckBoxAppDataTemp.UseVisualStyleBackColor = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = Global.CleanBrowsersCashe.My.Resources.Resources.delete_32x32
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Location = New System.Drawing.Point(131, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 19)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 20
        Me.PictureBox4.TabStop = False
        '
        'CheckBoxRecycleBin
        '
        Me.CheckBoxRecycleBin.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxRecycleBin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxRecycleBin.Location = New System.Drawing.Point(152, 24)
        Me.CheckBoxRecycleBin.Name = "CheckBoxRecycleBin"
        Me.CheckBoxRecycleBin.Size = New System.Drawing.Size(130, 17)
        Me.CheckBoxRecycleBin.TabIndex = 25
        Me.CheckBoxRecycleBin.Text = "Recycle Bin"
        Me.CheckBoxRecycleBin.UseVisualStyleBackColor = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImage = Global.CleanBrowsersCashe.My.Resources.Resources.recycle_bin_32x32
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Location = New System.Drawing.Point(131, 23)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(19, 19)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 26
        Me.PictureBox5.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 493)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.CheckBoxRecycleBin)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.CheckBoxAppDataTemp)
        Me.Controls.Add(Me.PictureBoxInfo)
        Me.Controls.Add(Me.CheckBoxInstall)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CheckBoxFirefox)
        Me.Controls.Add(Me.CheckBoxOpera)
        Me.Controls.Add(Me.CheckBoxChrome)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnStartClear)
        Me.Controls.Add(Me.LBReports)
        Me.Controls.Add(Me.BtnOpenChromeFolder)
        Me.Controls.Add(Me.BtnOpenOperaFolder)
        Me.Controls.Add(Me.BtnOpenFirefoxFolder)
        Me.Controls.Add(Me.BtnOpenAppDatafolder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clean Browsers Cashe"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOpenAppDatafolder As System.Windows.Forms.Button
    Friend WithEvents BtnOpenOperaFolder As System.Windows.Forms.Button
    Friend WithEvents btnStartClear As System.Windows.Forms.Button
    Friend WithEvents CheckBoxChrome As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtnOpenFirefoxFolder As System.Windows.Forms.Button
    Friend WithEvents BtnOpenChromeFolder As System.Windows.Forms.Button
    Friend WithEvents LBReports As System.Windows.Forms.ListBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents BWDeleteFiles As System.ComponentModel.BackgroundWorker
    Friend WithEvents CheckBoxOpera As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxFirefox As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBoxInstall As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBoxInfo As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBoxAppDataTemp As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBoxRecycleBin As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox

End Class
