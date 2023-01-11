Imports System.ComponentModel
Imports Microsoft.Win32
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Threading

Public Class Form1

    'Variables cleaning recyclebin
    Private Declare Function SHEmptyRecycleBin Lib "shell32.dll" Alias "SHEmptyRecycleBinA" (ByVal hWnd As Int32, ByVal pszRootPath As String, ByVal dwFlags As Int32) As Int32
    Private Declare Function SHUpdateRecycleBinIcon Lib "shell32.dll" () As Int32
    Private Const SHERB_NOCONFIRMATION = &H1
    Private Const SHERB_NOPROGRESSUI = &H2
    Private Const SHERB_NOSOUND = &H4

    <DllImport("Shell32.dll", SetLastError:=False)>
    Public Shared Function SHDefExtractIcon(ByVal iconFile As String,
                                        ByVal iconIndex As Integer,
                                        ByVal flags As UInteger,
                                        ByRef hiconLarge As IntPtr,
                                        ByRef hiconSmall As IntPtr,
                                        ByVal iconSize As UInteger
) As Integer
    End Function

    ' Variable
    Public FolderBrowsersChashe As String
    Private ProfileNameOfMozilla As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.Show()
        Me.Text = "Clean Browsers Cashe - v." & My.Application.Info.Version.ToString

        CheckBoxChrome.Checked = My.Settings.CheckBoxChrome
        CheckBoxOpera.Checked = My.Settings.CheckBoxOpera
        CheckBoxFirefox.Checked = My.Settings.CheckBoxFirefox
        CheckBoxAppDataTemp.Checked = My.Settings.CheckBoxAppDataTemp
        CheckBoxRecycleBin.Checked = My.Settings.CheckBoxRecycleBin



        Dim AppName As String = System.IO.Path.GetFileName(Application.ExecutablePath)
        If My.Computer.FileSystem.FileExists("C:\Program Files\CleanBrowsersCashe\" & AppName) = True Then
            CheckBoxInstall.Checked = True
            CheckBoxInstall.Text = "Uncheck to uninstall from program files"
        Else
            CheckBoxInstall.Text = "Check to install on program files"
        End If

        LBReports.Items.Clear()
        LBReports.Items.Add("Click 'Start clear cashe'")

        Dim readValue As String
        readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\CleanBrowsersCashe", "SetAutoSartCleanBrowsersCashe", Nothing)
        ' If find value, run clear
        If readValue = "True" Or readValue = "true" Then
            btnStartClear.PerformClick()
        End If

    End Sub
    Private Sub BtnStartClear_Click(sender As Object, e As EventArgs) Handles btnStartClear.Click
        If CheckBoxOpera.Checked = False And CheckBoxFirefox.Checked = False And CheckBoxChrome.Checked = False And CheckBoxAppDataTemp.Checked = False Then
            LBReports.Items.Clear()
            LBReports.Items.Add("Υou have not selected anything for cleaning.")
            Exit Sub
        End If

        If CheckBoxChrome.Checked = True Then
            ' Check if Chrome is running
            If Process.GetProcessesByName("chrome").Length > 0 Then
                Dim result As DialogResult = MessageBox.Show("Chrome is still running. If you want to clean cashe, must close. Do you want to close Chrome?", "Critical Message", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then
                    Try
                        Dim Proc() As Process = Process.GetProcessesByName("Chrome")
                        '[KILL ALL Steam PROCESSES]
                        For Each Process As Process In Proc
                            Process.Kill()
                        Next
                    Catch x As Exception
                    End Try
                Else
                    CheckBoxChrome.Checked = False
                End If
            End If
        End If

        If CheckBoxOpera.Checked = True Then
            ' Check if Chrome is running
            If Process.GetProcessesByName("opera").Length > 0 Then
                Dim result As DialogResult = MessageBox.Show("Opera is still running. If you want to clean cashe, must close. Do you want to close Opera?", "Critical Message", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then
                    Try
                        Dim Proc() As Process = Process.GetProcessesByName("opera")
                        For Each Process As Process In Proc
                            Process.Kill()
                        Next
                    Catch x As Exception
                    End Try
                Else
                    CheckBoxOpera.Checked = False
                End If
            End If
        End If

        If CheckBoxOpera.Checked = True Then
            ' Check if Chrome is running
            If Process.GetProcessesByName("firefox").Length > 0 Then
                Dim result As DialogResult = MessageBox.Show("Firefox is still running. If you want to clean cashe, must close. Do you want to close Firefox?", "Critical Message", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then
                    Try
                        Dim Proc() As Process = Process.GetProcessesByName("firefox")
                        For Each Process As Process In Proc
                            Process.Kill()
                        Next
                    Catch x As Exception
                    End Try
                Else
                    CheckBoxOpera.Checked = False
                End If
            End If
        End If

        LBReports.Items.Clear()
        btnCancel.Enabled = True
        btnStartClear.Enabled = False

        BWDeleteFiles.RunWorkerAsync()
        Do While BWDeleteFiles.IsBusy
            Application.DoEvents()
        Loop

        Dim thread As New Thread(AddressOf CountToClose)
        thread.Start()
    End Sub
    Private Sub CountToClose()
        Dim readValue As String
        readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\CleanBrowsersCashe", "SetCloseAutoCleanBrowsersCashe", Nothing)
        ' If value is true then close app in 10 seconds
        If readValue = "True" Or readValue = "true" Then
            Dim NumSec As Integer = 10
            Dim SetSecondName As String = "seconds"
            LBReports.Items.Add("----")
            For i = 1 To 10 Step 1

                LBReports.Items.Add("The application will close in " & NumSec & " " & SetSecondName)
                LBReports.SelectedIndex = LBReports.Items.Count - 1
                Threading.Thread.Sleep(1000)
                NumSec -= 1
                If NumSec = 1 Then
                    SetSecondName = "second"
                End If
                If NumSec = 0 Then Exit For
                LBReports.Items.RemoveAt(LBReports.Items.Count - 1)
            Next
            Application.Exit()
        End If

    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        BWDeleteFiles.CancelAsync()
        btnStartClear.Enabled = True
        btnCancel.Enabled = False
        LBReports.Items.Add("-----")
        LBReports.Items.Add("The process was interrupted by the user")
        LBReports.SelectedIndex = LBReports.Items.Count - 1
    End Sub
    Private Sub BWDeleteFiles_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWDeleteFiles.DoWork
        'Clean Recycle Bin
        If CheckBoxRecycleBin.Checked = True Then
            LBReports.Items.Add("-----")
            LBReports.Items.Add("Starting cleaning Recycle bin")
            EmptyRecycleBin()
        End If

        'Clean Appdata Temp folder
        If CheckBoxAppDataTemp.Checked = True Then
            FolderBrowsersChashe = "C:\Users\" & GetUserName() & "\AppData\Local\Temp"
            If My.Computer.FileSystem.DirectoryExists(FolderBrowsersChashe) Then
                LBReports.Items.Add("-----")
                LBReports.Items.Add("Starting cleaning AppData Temp Folder")
                LBReports.Items.Add(FolderBrowsersChashe)
                For Each file As IO.FileInfo In New IO.DirectoryInfo(FolderBrowsersChashe).GetFiles("*.*")
                    Try
                        file.Delete()
                        LBReports.Items.Add(file.Name)
                        LBReports.SelectedIndex = LBReports.Items.Count - 1
                    Catch ex As Exception
                        LBReports.Items.Add(">> Error: " & ex.Message)
                    End Try
                Next

                For Each dir As IO.DirectoryInfo In New IO.DirectoryInfo(FolderBrowsersChashe).GetDirectories("*.*")
                    Try
                        System.IO.Directory.Delete(dir.FullName, True)
                        'dir.Delete()
                        LBReports.Items.Add(dir.FullName)
                        LBReports.SelectedIndex = LBReports.Items.Count - 1
                    Catch ex As Exception
                        LBReports.Items.Add(">> Error: " & ex.Message)
                    End Try
                Next
            Else
                LBReports.Items.Add("-----")
                LBReports.Items.Add("Cannot find folder: " & FolderBrowsersChashe)
                LBReports.SelectedIndex = LBReports.Items.Count - 1
            End If
        End If

        'Clean Chrome cashe
        If CheckBoxChrome.Checked = True Then
            FolderBrowsersChashe = "C:\Users\" & GetUserName() & "\AppData\Local\Google\Chrome\User Data\Default\Code Cache\js"
            If My.Computer.FileSystem.DirectoryExists(FolderBrowsersChashe) Then
                LBReports.Items.Add("-----")
                LBReports.Items.Add("Starting cleaning Chrome cashe")
                LBReports.Items.Add(FolderBrowsersChashe)
                For Each file As IO.FileInfo In New IO.DirectoryInfo(FolderBrowsersChashe).GetFiles("*.*")
                    Try
                        file.Delete()
                        LBReports.Items.Add(file.Name)
                        LBReports.SelectedIndex = LBReports.Items.Count - 1
                    Catch ex As Exception
                        LBReports.Items.Add(">> Error: " & ex.Message)
                    End Try
                Next
            Else
                LBReports.Items.Add("-----")
                LBReports.Items.Add("Cannot find folder: " & FolderBrowsersChashe)
                LBReports.SelectedIndex = LBReports.Items.Count - 1
            End If
        End If

        'Clean Opera cashe
        If CheckBoxOpera.Checked = True Then
            FolderBrowsersChashe = "C:\Users\" & GetUserName() & "\AppData\Local\Opera Software\Opera Stable\Cache"
            If My.Computer.FileSystem.DirectoryExists(FolderBrowsersChashe) Then
                LBReports.Items.Add("-----")
                LBReports.Items.Add("Starting cleaning Opera cashe")
                LBReports.Items.Add(FolderBrowsersChashe)
                For Each file As IO.FileInfo In New IO.DirectoryInfo(FolderBrowsersChashe).GetFiles("*.*", SearchOption.AllDirectories)
                    Try
                        file.Delete()
                        LBReports.Items.Add(file.Name)
                        LBReports.SelectedIndex = LBReports.Items.Count - 1
                    Catch ex As Exception
                        LBReports.Items.Add(">> Error: " & ex.Message)
                    End Try
                Next
            Else
                LBReports.Items.Add("-----")
                LBReports.Items.Add("Cannot find folder: " & FolderBrowsersChashe)
                LBReports.SelectedIndex = LBReports.Items.Count - 1
            End If
        End If

        'Clean Firefox cashe
        If CheckBoxFirefox.Checked = True Then
            'Get Profile directory name of firefox
            Dim filePath As String = "C:\Users\" & GetUserName() & "\AppData\Local\Mozilla\Firefox\Profiles"
            For Each foundDirectory As String In My.Computer.FileSystem.GetDirectories(filePath, FileIO.SearchOption.SearchTopLevelOnly, "*.default-release*")
                ProfileNameOfMozilla = Path.GetFileName(foundDirectory.TrimEnd(Path.DirectorySeparatorChar))
            Next
            FolderBrowsersChashe = "C:\Users\" & GetUserName() & "\AppData\Local\Mozilla\Firefox\Profiles\" & ProfileNameOfMozilla & "\cache2"

            If My.Computer.FileSystem.DirectoryExists(FolderBrowsersChashe) Then
                LBReports.Items.Add("-----")
                LBReports.Items.Add("Starting cleaning Firefox cashe")
                LBReports.Items.Add(FolderBrowsersChashe)
                For Each file As IO.FileInfo In New IO.DirectoryInfo(FolderBrowsersChashe).GetFiles("*.*", SearchOption.AllDirectories)
                    Try
                        file.Delete()
                        LBReports.Items.Add(file.Name)
                        LBReports.SelectedIndex = LBReports.Items.Count - 1
                    Catch ex As Exception
                        LBReports.Items.Add(">> Error: " & ex.Message)
                    End Try
                Next
            Else
                LBReports.Items.Add("-----")
                LBReports.Items.Add("Cannot find folder: " & FolderBrowsersChashe)
                LBReports.SelectedIndex = LBReports.Items.Count - 1
            End If
        End If

    End Sub
    Private Sub BWDeleteFiles_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BWDeleteFiles.RunWorkerCompleted
        LBReports.Items.Add("-----")
        LBReports.Items.Add("The process completed")
        LBReports.SelectedIndex = LBReports.Items.Count - 1
        btnStartClear.Enabled = True
        btnCancel.Enabled = False
    End Sub
    Private Sub EmptyRecycleBin()
        SHEmptyRecycleBin(Me.Handle.ToInt32, vbNullString, SHERB_NOPROGRESSUI + SHERB_NOCONFIRMATION + SHERB_NOSOUND)
        SHUpdateRecycleBinIcon()
    End Sub
    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function
    Private Sub CheckBoxChrome_Click(sender As Object, e As EventArgs) Handles CheckBoxChrome.Click
        If CheckBoxChrome.Checked = True Then
            My.Settings.CheckBoxChrome = True
            LBReports.Items.Clear()
            LBReports.Items.Add("Now selected 'Chrome' browser")
            LBReports.Items.Add("Click 'Start clear cashe'")
        Else
            LBReports.Items.Clear()
            LBReports.Items.Add("Now deselected 'Chrome' browser")
            My.Settings.CheckBoxChrome = False
        End If
        My.Settings.Save()
    End Sub
    Private Sub CheckBoxOpera_Click(sender As Object, e As EventArgs) Handles CheckBoxOpera.Click
        If CheckBoxOpera.Checked = True Then
            My.Settings.CheckBoxOpera = True
            LBReports.Items.Clear()
            LBReports.Items.Add("Now selected 'Opera' browser")
            LBReports.Items.Add("Click 'Start clear cashe'")
        Else
            LBReports.Items.Clear()
            LBReports.Items.Add("Now deselected 'Opera' browser")
            My.Settings.CheckBoxOpera = False
        End If
        My.Settings.Save()
    End Sub
    Private Sub CheckBoxFirefox_Click(sender As Object, e As EventArgs) Handles CheckBoxFirefox.Click
        If CheckBoxFirefox.Checked = True Then
            My.Settings.CheckBoxFirefox = True
            LBReports.Items.Clear()
            LBReports.Items.Add("Now selected 'Firefox' browser")
            LBReports.Items.Add("Click 'Start clear cashe'")
        Else
            LBReports.Items.Clear()
            LBReports.Items.Add("Now deselected 'Firefox' browser")
            My.Settings.CheckBoxFirefox = False
        End If
        My.Settings.Save()
    End Sub

  
    Private Sub ExtractIcoFromFile(ByVal NameEXEFileWithPath As String, ByVal NamePNGExtraxtFileWithPath As String, ByVal NameICOExtraxtFileWithPath As String)
        'Use: ExtractIcoFromFile(CurDir() & "\CleanBrowsersChash.exe", CurDir() & "\CleanBrowsersChash.png", CurDir() & "\CleanBrowsers.ico")
        Try
            Dim hiconLarge As IntPtr
            If My.Computer.FileSystem.FileExists(NameEXEFileWithPath) Then
                SHDefExtractIcon(NameEXEFileWithPath, 0, 0, hiconLarge, Nothing, 256)
            Else
                Exit Sub
            End If
            ' ToDO: Handle HRESULT.

            Dim ico As Icon = Icon.FromHandle(hiconLarge)
            Dim bmp As Bitmap = ico.ToBitmap()

            ' Save as .png with transparency. success.
            If My.Computer.FileSystem.FileExists(NamePNGExtraxtFileWithPath) = True Then
            Else
                bmp.Save(NamePNGExtraxtFileWithPath, ImageFormat.Png)
            End If

            'Save as .ico with transparency. failure. Wrong transparency.
            If My.Computer.FileSystem.FileExists(NameICOExtraxtFileWithPath) = True Then
            Else
                Using ms As New MemoryStream
                    ico.Save(ms)
                    Using fs As New FileStream(NameICOExtraxtFileWithPath, FileMode.CreateNew)
                        ms.WriteTo(fs)
                    End Using
                End Using
            End If

        Catch ex As Exception
            MessageBox.Show("Extract ico from main execute file >> Error: " & ex.Message)
        End Try
    End Sub
    Private Function CreateShortCut(ByVal ShortCutworkingDir As String, ByVal ShortCutTarget As String, ByVal Shortcutname As String, ByVal DirIcon As String, ByVal ShortcutKey As String, ByVal ShortCutDescription As String) As Boolean
        Try
            ' Start script and set location path who saved the shortcut
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim DesktopDir As String = CType(WSHShell.SpecialFolders.Item("Desktop"), String)
            Dim Shortcut As Object
            'Set dir and name file
            Shortcut = WSHShell.CreateShortcut(DesktopDir & "\" & Shortcutname & ".lnk")
            'Set all arguments for shortcut
            Shortcut.TargetPath = ShortCutTarget
            Shortcut.WindowStyle = 2
            Shortcut.Hotkey = ShortcutKey
            Shortcut.Description = ShortCutDescription
            Shortcut.WorkingDirectory = ShortCutworkingDir
            'Set dir of ico
            Shortcut.IconLocation = DirIcon
            ' Save the shortcut
            Shortcut.Save()
            'MessageBox.Show("Shortcut saved in desktop area.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show("Failed to save shortcut on desktop area." & vbCrLf & ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function
    Private Sub PictureBoxInfo_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxInfo.MouseEnter
        LBReports.Items.Clear()
        LBReports.Items.Add("Information about application")
        LBReports.Items.Add("")
        LBReports.Items.Add("Installation instructions")
        LBReports.Items.Add("1. Check 'Check to Install on Program Files' and wait to finish installation.")
        LBReports.Items.Add("2. Check who browsers you want to clean cashe or appdata temp folder or recycle bin.")
        LBReports.Items.Add("3. Finally check 'Start with windows and clean auto' if you want to start appl with windows")
        LBReports.Items.Add("")
        LBReports.Items.Add("DONE.")
        LBReports.Items.Add("")
        LBReports.Items.Add("Uninstallation instructions")
        LBReports.Items.Add("For uninstalling just check 'Uncheck to uninstall from program files' and")
        LBReports.Items.Add("now application removed from your system and deleted registry keys.")
        LBReports.Items.Add("")
        LBReports.Items.Add("Enjoy.")
    End Sub
    Private Sub PictureBoxInfo_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxInfo.MouseLeave
        LBReports.Items.Clear()
        LBReports.Items.Add("Click 'Start clear cashe'")
    End Sub
   
    Private Sub CheckBoxAppDataTemp_Click(sender As Object, e As EventArgs) Handles CheckBoxAppDataTemp.Click
        If CheckBoxAppDataTemp.Checked = True Then
            My.Settings.CheckBoxAppDataTemp = True
            LBReports.Items.Clear()
            LBReports.Items.Add("Now selected to clean appdata temp directory")
            LBReports.Items.Add("Click 'Start clear cashe'")
        Else
            LBReports.Items.Clear()
            LBReports.Items.Add("Now deselected to clean appdata temp directory")
            My.Settings.CheckBoxAppDataTemp = False
        End If

        My.Settings.Save()
    End Sub
    Private Sub BtnOpenAppDatafolder_Click(sender As Object, e As EventArgs) Handles BtnOpenAppDatafolder.Click
        If My.Computer.FileSystem.DirectoryExists("C:\Users\" & GetUserName() & "\AppData\Local\temp") = True Then
            Process.Start("explorer.exe", "C:\Users\" & GetUserName() & "\AppData\Local\temp")
        Else
            MsgBox("Folder not found.", MsgBoxStyle.Critical, "Critical message")
        End If
    End Sub
    Private Sub BtnOpenChromeFolder_Click(sender As Object, e As EventArgs) Handles BtnOpenChromeFolder.Click
        If My.Computer.FileSystem.DirectoryExists("C:\Users\" & GetUserName() & "\AppData\Local\Google\Chrome\User Data\Default\Code Cache\js") = True Then
            Process.Start("explorer.exe", "C:\Users\" & GetUserName() & "\AppData\Local\Google\Chrome\User Data\Default\Code Cache\js")
        Else
            MsgBox("Folder not found.", MsgBoxStyle.Critical, "Critical message")
        End If
    End Sub
    Private Sub BtnOpenOperaFolder_Click(sender As Object, e As EventArgs) Handles BtnOpenOperaFolder.Click
        If My.Computer.FileSystem.DirectoryExists("C:\Users\" & GetUserName() & "\AppData\Local\Opera Software\Opera Stable\Cache") = True Then
            Process.Start("explorer.exe", "C:\Users\" & GetUserName() & "\AppData\Local\Opera Software\Opera Stable\Cache")
        Else
            MsgBox("Folder not found.", MsgBoxStyle.Critical, "Critical message")
        End If
    End Sub
    Private Sub BtnOpenFirefoxFolder_Click(sender As Object, e As EventArgs) Handles BtnOpenFirefoxFolder.Click

        'Get Profile directory name of firefox
        Dim filePath As String = "C:\Users\" & GetUserName() & "\AppData\Local\Mozilla\Firefox\Profiles"
        For Each foundDirectory As String In My.Computer.FileSystem.GetDirectories(filePath, FileIO.SearchOption.SearchTopLevelOnly, "*.default-release*")
            ProfileNameOfMozilla = Path.GetFileName(foundDirectory.TrimEnd(Path.DirectorySeparatorChar))
        Next
        FolderBrowsersChashe = "C:\Users\" & GetUserName() & "\AppData\Local\Mozilla\Firefox\Profiles\" & ProfileNameOfMozilla & "\cache2"

        If My.Computer.FileSystem.DirectoryExists(FolderBrowsersChashe) = True Then
            Process.Start("explorer.exe", FolderBrowsersChashe)
        Else
            MsgBox("Folder not found.", MsgBoxStyle.Critical, "Critical message")
        End If
    End Sub
    Private Sub CheckBoxRecycleBin_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRecycleBin.CheckedChanged
        If CheckBoxRecycleBin.Checked = True Then
            My.Settings.CheckBoxRecycleBin = True
            LBReports.Items.Clear()
            LBReports.Items.Add("Now selected to clean Recycle Bin")
            LBReports.Items.Add("Click 'Start clear cashe'")
        Else
            LBReports.Items.Clear()
            LBReports.Items.Add("Now deselected to clean Recycle Bin")
            My.Settings.CheckBoxRecycleBin = False
        End If

        My.Settings.Save()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBoxChrome_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxChrome.CheckedChanged

    End Sub
End Class
