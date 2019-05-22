Option Explicit On
Option Strict On
Option Compare Binary

Public Structure typeGasket
    Public m_name As String
    Public m_m As Double
    Public m_y As Double
End Structure

Public Class vbGasket

    ' this is an object in an arraylist
    ' implements a gasket factor definition for ASME or EN flange calculations
    ' example: spiral wound metal, with filler (carbon)	m = 2,50	y = 69,0 N/mm2

    'Dim gasketList As typeGasket() = {{"elastomer without fabric (rubber),  <75 IRH", 0.5, 0.0},
    '                                      {"elastomer without fabric (rubber),  >75 IRH", 1.0, 1.4},
    '                                      {"asbestos, 3.2 mm	", 2.0, 11.0}}

    Private m_strName As String
    Private m_dblm As Double
    Private m_dbly As Double

    'example add(new vbGasket("spiral wound",2.5,69.0))
    Public Sub New(ByVal name As String, ByVal m As Double, ByVal y As Double)
        m_strName = name
        m_dblm = m
        m_dbly = y
    End Sub
    Public Property Name() As String
        Get
            Return m_strName
        End Get
        Set(ByVal value As String)
            m_strName = value
        End Set
    End Property
    Public Property m() As Double
        Get
            Return m_dblm
        End Get
        Set(ByVal value As Double)
            m_dblm = value
        End Set
    End Property
    Public Property y() As Double
        Get
            Return m_dbly
        End Get
        Set(ByVal value As Double)
            m_dbly = value
        End Set
    End Property
End Class
