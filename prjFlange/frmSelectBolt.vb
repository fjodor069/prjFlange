Option Strict Off
Option Explicit On
'Imports VB = Microsoft.VisualBasic
'-----------------------------------------------------------
' bolt11 programma/dialoog
' 
' leest een access database bestand mbv de 
' Jet database engine en zet dit in een Treeview control
' naar een voorbeeld Visual Basic sample programma Datatree
'
' form aangepast als een dialoog box; connection is reeds geopend in hoofdmodule
'-------------------------------------------------------------
Friend Class frmSelectBolt
    Inherits System.Windows.Forms.Form
    '
    '
    ' References:
    ' uses MS ActiveX DataObjects 2.0 (ADO)
    '
    '
    ' imagelist named images : closed, open, beer
    '
    ' private class variables
    Private mNode As System.Windows.Forms.TreeNode
    Private mCurrentIndex As Short
   

    'schakel de treeview om naar een andere imagelist
    'test...
    'Private Sub btnOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    '
    '    Static theOther As Boolean

    '    If theOther Then
    '        TreeView1.ImageList = ImageList2 ';grote iconen
    '        TreeView1.Refresh()

    '        theOther = False

    '    Else
    '        TreeView1.ImageList = ImageList1
    '        TreeView1.Refresh()
    '        theOther = True
    '    End If



    'End Sub


    '
    Private Sub btnTest_Click()
        ' vul de treeview
        'maak een recordset
        Dim rsCode As New ADODB.Recordset


        With rsCode
            .Open("SELECT CodeID,[Code] FROM Codes", cnA, _
                      ADODB.CursorTypeEnum.adOpenStatic, _
                      ADODB.LockTypeEnum.adLockOptimistic)
            .MoveLast()
            .MoveFirst()
        End With
        'maak een child node voor elk record in de recordset
        Do While Not rsCode.EOF

            mNode = TreeView1.Nodes.Insert(1, rsCode.Fields("CodeID").Value & " ID", _
            CStr(rsCode.Fields("Code").Value), "closed")

            mNode.Tag = "Code"
            rsCode.MoveNext()
        Loop


        TreeView1.Nodes.Item(1).Expand()




    End Sub



    'einde van de dialog
    ''
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Me.Close()
        ' End

    End Sub

    '
    Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'zet het window gecentreerd op het scherm
        Me.CenterToParent()


        'initialiseer de treeview control
        TreeView1.Nodes.Clear()
        With TreeView1

            .ImageList = ImageList2
            .BorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            .Sorted = False
            .LabelEdit = False
            .ShowRootLines = True
            .ShowPlusMinus = True
            .ShowNodeToolTips = True
            .ShowLines = True
            .BackColor = Color.White
            '.Style = tvwTreelinesPlusMinusPictureText

        End With

        'maak een root node
        mNode = TreeView1.Nodes.Insert(0, "", "Bolts", "closed")
        'mNode = TreeView1.Nodes.Add("", "Bolts" , "closed")

        mNode.Tag = "root"



        mCurrentIndex = 0
        Label10.Text = ""

        ' Me.Show()
        'fill the treeview
        btnTest_Click()


    End Sub

    Private Sub TreeView1_AfterCollapse(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCollapse

        Dim node As System.Windows.Forms.TreeNode = eventArgs.Node

        If node.Tag = "Code" Or node.Index = 1 Then
            node.ImageKey = "closed"
        End If

    End Sub

    Private Sub TreeView1_AfterExpand(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterExpand

        Dim node As System.Windows.Forms.TreeNode = eventArgs.Node

        'only the top node, and code nodes can be expanded
        '  MsgBox "Node key = " & node.Key
        '        Dim node As System.Windows.Forms.TreeNode = TreeView1.SelectedNode


        If node.Tag = "Code" Or node.Index = 1 Then
            node.ImageKey = "open"
        End If
        If node.Tag = "Code" And mCurrentIndex <> Val(node.Name) Then
            GetTitles(node, Val(node.Name))
        End If

        If node.Tag = "Code" Then PopStatus(node)
        If node.tag = "bolt" Then GiveData(node)




    End Sub

    ' maak child nodes aan parentnode met een uniek nummer
    '
    Private Function GetTitles(ByRef parentNode As System.Windows.Forms.TreeNode, ByRef CodeID As Object) As Boolean

        Dim strQ As String
        Dim rsSizes As New ADODB.Recordset
        Dim newNode As System.Windows.Forms.TreeNode

        'check if node is already populated
        If parentNode.GetNodeCount(False) Then
            Exit Function
        End If

        'SQL query that retrieves all necessary fields
        'keep it simple ..
        strQ = "SELECT * FROM Sizes WHERE Sizes.CodeID = " & CodeID

        'make the query by opening the recordset
        'with the appropriate SQL statement
        With rsSizes
            .Open(strQ, cnA, ADODB.CursorTypeEnum.adOpenStatic, _
            ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)

            If .BOF Then
                'nothing found then exit
                GetTitles = False
                Exit Function
            End If
            .MoveLast()
            .MoveFirst()
        End With

        'MsgBox "aantal records = " & rsSizes.RecordCount


        On Error GoTo childErr


        Do While Not rsSizes.EOF

            AddNode(parentNode, rsSizes)
            rsSizes.MoveNext()
        Loop

        mCurrentIndex = CodeID
        GetTitles = True


        Exit Function


childErr:
        Debug.Print(Err.Number, Err.Description)
        Debug.Print(rsSizes.Fields("SizeID").Value)
        Resume Next
        Exit Function


    End Function

    'let op : de node.key moet absoluut uniek zijn anders werkt het niet
    'hoewel sizeID een unieke key is werkt deze hier niet goed
    Private Sub AddNode(ByRef parentNode As System.Windows.Forms.TreeNode, ByRef rs As ADODB.Recordset)

        Dim nodX As TreeNode = New TreeNode()
        Dim sItemText As String
        'With nodX
        '    .Text = rs.Fields("DiamText").Value
        '    .ImageKey = "beer"
        '    .Tag = "bolt"

        'End With
        'geef de treenode een tekstveld met de omschrijving
        sItemText = rs.Fields("DiamText").Value
        If rs.Fields("Common").Value Then
            'sItemText = sItemText          'dit is een standaard size
        Else
            sItemText = sItemText & "*"     'dit is niet een standaard size
        End If
        nodX = parentNode.Nodes.Add(rs("SizeID").Value & " ID", _
                  sItemText, "beer")
        'nodX = TreeView1.SelectedNode.Nodes.Add(rs("SizeID").Value & " ID", _
        '          rs.Fields("DiamText").Value, "beer")
        nodX.Tag = "bolt"

        '------------------






    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        'TreeView1.SelectedNode.Expand()

        Dim node As System.Windows.Forms.TreeNode = TreeView1.SelectedNode

        If node.Tag = "Code" And mCurrentIndex <> Val(node.Name) Then
            GetTitles(node, Val(node.Name))
        End If

        If node.Tag = "Code" Then PopStatus(node)
        If node.Tag = "bolt" Then GiveData(node)

    End Sub

    'geef naam en aantal van de geselecteerde node op de statusbar
    'alleen voor hoofd nodes

    Private Sub PopStatus(ByRef node As System.Windows.Forms.TreeNode)
        '  Panel is System.Windows.Forms.ToolStripStatusLabel()
        With StatusBar1

            .Items.Clear()
            .Items.Add(node.Text)
            .Items.Add(node.GetNodeCount(True) & " items")
            .Items(1).AutoSize = True

        End With

    End Sub
    'geef data van deze node in de informatie velden/labels
    'álleen voor de lagere nodes
    Private Sub GiveData(ByRef node As System.Windows.Forms.TreeNode)
        'zoek de data van deze node op in de recordset
        Dim strQ As String
        Dim rsA As New ADODB.Recordset
        Dim iSize As Short

        iSize = Val(node.Name)
        strQ = "SELECT * FROM Sizes WHERE Sizes.SizeID = " & iSize
        With rsA
            .Open(strQ, cnA, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
            If .BOF Then
                'nothing found then exit
                Exit Sub
            End If
        End With

        'zet de record velden op de form

        Label10.Text = rsA.Fields("DiamText").Value
        txtNominal.Text = rsA.Fields("NominalDiameter").Value
        txtRoot.Text = rsA.Fields("RootDiameter").Value
        txtThread.Text = rsA.Fields("Thread").Value          'thread pitch P
        txtHole.Text = rsA.Fields("HoleDiameter").Value    'boutgat
        txtHead.Text = rsA.Fields("HeadSize").Value        'sleutelwijdte
        txtFriction.Text = rsA.Fields("Friction").Value
        txtD2.Text = Format(rsA.Fields("RootDiameterd2").Value, "0.00")
        txtD3.Text = Format(rsA.Fields("RootDiameterd3").Value, "0.00")
        If rsA.Fields("Common").Value Then
            txtCommon.Text = "yes"
        Else
            txtCommon.Text = "no"
        End If
        txtSpacing.Text = rsA.Fields("MinPitch").Value       'min circumferential spacing 

        ' Text11.Text = rs.Fields("RootArea").Value
        Dim d3 As Double
        '' public rootarea As Double
        d3 = rsA.Fields("RootDiameterd3").Value

        Dim rootArea As Double
        rootArea = Math.PI / 4 * d3 ^ 2

        txtRootarea.Text = Format(rootarea, "0.00")
        txtRadialmin.Text = rsA.Fields("FreeSize1").Value      'min radial distance R
        txtEdgemin.Text = rsA.Fields("FreeSize2").Value      'min edge distance E

        '----
        'zet de info van het huidige record in de globale data van module1 flangeEN.vb
        'moet eigenlijk pas als user op ok klikt
        Ar = rootArea
        d = rsA.Fields("NominalDiameter").Value
        sBoltName = rsA.Fields("DiamText").Value
        minspacing = rsA.Fields("MinPitch").Value
        Emin = rsA.Fields("FreeSize2").Value
        Rmin = rsA.Fields("FreeSize1").Value
        headsize = rsA.Fields("HeadSize").Value

    End Sub


End Class