'-------------------------------------------------------
' frmTubeSheet.vb
'main form 
'VB2000
'-------------------------------------------------------

Option Strict Off
Option Explicit On
Friend Class frmTubesheet
	Inherits System.Windows.Forms.Form
	'----------------------------------------
	' frmTubesheet
	' (main Form )
	'-----------------------------------------
	
	Private Sub cmdCalc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalc.Click
		
		'retrieve input from the input form (this form)
		ReadInput()
		
		'do the bloody calc
        Test_calc()

        Label2.Text = Format(Estar, "#0.###")
        Label6.Text = Format(vstar, "#0.###")
		'show results on a separate form
        'frmResults.ShowDialog()
		
		
	End Sub
	

	Private Sub frmTubesheet_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		Invullen()
		
    
		
		
	End Sub
	
	Private Sub frmTubesheet_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
        Init_example() ' take values from hard coded example input
		
		
	End Sub
	
	
	
	Public Sub Invullen()
        'invullen van text velden met getals waarden
		'update this form's input cells with current input values
		'may also be from a loaded file
		

        Text_ep.Text = CStr(ep)
        Text_mu.Text = CStr(mu)
        If (pat) Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If


    End Sub
	
	Public Sub ReadInput()
        'alle variabelen (double vars) lezen uit de huidige text velden
		'retrieve input variables from the textbox input values
		'no error checking
		
		'UPGRADE_WARNING: Couldn't resolve default property of object p1. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ep = CDbl(Text_ep.Text)
        mu = CDbl(Text_mu.Text)
		
        If (RadioButton1.Checked = True) Then
            pat = True
        Else
            pat = False
        End If
		
		
	End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'ends the program

        End
    End Sub
End Class