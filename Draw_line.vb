Imports System.Drawing
Public Class Draw_line
    Dim _startpoint As New Point(5, 10)
    Dim _endpoint As New Point(11, 20)
    Dim Firstend As New Point(0, 0)
    Dim Secondend As New Point(0, 0)
    Dim Thirdend As New Point(0, 0)
    Dim Fourthend As New Point(0, 0)
    Dim _thickness As Single = 1
    Dim _color As System.Drawing.Color = color.Black
    Dim _control As New Windows.Forms.Control
    ''' <summary>
    ''' Reprents the start point for the line   
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property startpoint() As Point
        Get
            Return _startpoint
        End Get
        Set(ByVal value As Point)
            _startpoint = value
        End Set
    End Property
    ''' <summary>
    ''' Reprents the end  point for the line   
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property endpoint() As Point
        Get
            Return _endpoint
        End Get
        Set(ByVal value As Point)
            _endpoint = value
        End Set
    End Property
    ''' <summary>
    ''' Reprents the thickness for the line   
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property thickness() As Single
        Get
            Return _thickness
        End Get
        Set(ByVal value As Single)
            _thickness = value
        End Set
    End Property
    ''' <summary>
    ''' Reprents the color for the line   
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property color() As System.Drawing.Color
        Get
            Return _color
        End Get
        Set(ByVal value As System.Drawing.Color)
            _color = value
        End Set
    End Property
    ''' <summary>
    ''' Reprents the  container control  for the line 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Parent_control() As Windows.Forms.Control
        Get
            Return _control
        End Get
        Set(ByVal value As Windows.Forms.Control)
            _control = value
            _control.Controls.Add(Me)
        End Set
    End Property
    Private Sub Draw_line_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        ' the below variables are defined the x and y coordinates of start and end point.
        Dim start_x As Integer = 0
        Dim start_y As Integer = 0
        Dim end_x As Integer = 0
        Dim end_y As Integer = 0
        start_x = startpoint.X
        start_y = startpoint.Y
        end_x = endpoint.X
        end_y = endpoint.Y

        'The below code is done to get the location in the case of slant lines.
        If (start_x <> end_x) And (start_y <> end_y) Then
            Dim location_x As Integer = 0
            Dim location_y As Integer = 0
            If start_x > end_x Then
                location_x = end_x
            Else
                location_x = start_x
            End If
            If start_y > end_y Then
                location_y = end_y
            Else
                location_y = start_y
            End If
            Me.Location = New Point(location_x, location_y)
        End If

        'The below code is done to get location and size in case of vertical line.
        If start_x = end_x Then
            If start_y > end_y Then
                Me.Location = New Point(_endpoint)
            Else
                Me.Location = New Point(start_x, start_y)
            End If
            Dim size_y As Integer = Math.Abs(start_y - end_y)
            Me.Size = New Size(5, size_y)
            Fourthend = New Point(0, size_y)
            GetLine(e, Firstend, Fourthend)
            'The below code is done to get location and size in case of horizontal line.
        ElseIf start_y = end_y Then
            If start_x < end_x Then
                Me.Location = New Point(_startpoint)
            Else
                Me.Location = New Point(_endpoint)
            End If
            Dim size_x As Integer = Math.Abs(start_x - end_x)
            Me.Size = New Size(size_x, 5)
            Secondend = New Point(size_x, 0)
            GetLine(e, Firstend, Secondend)

        Else
            'The below code is done to get  size in case of slant line.
            Dim size_x As Integer = Math.Abs(end_x - start_x)
            Dim size_y As Integer = Math.Abs(end_y - start_y)
            Me.Size = New Size(size_x, size_y)

            Secondend = New Point(size_x, 0)
            Thirdend = New Point(size_x, size_y)
            Fourthend = New Point(0, size_y)
            If start_x < end_x And start_y < end_y Then
                GetLine(e, Firstend, Thirdend)
            ElseIf start_x > end_x And start_y > end_y Then
                GetLine(e, Firstend, Thirdend)
            Else
                GetLine(e, Secondend, Fourthend)
            End If
        End If
    End Sub
    ''' <summary>
    ''' To draw  a line  on the container   
    ''' </summary>
    ''' <param name="e"></param>Reprents the object of the container  
    ''' <param name="StartPoint"></param>Reprents the start point for the line   
    ''' <param name="EndPoint"></param> Reprents the end  point for the line  
    ''' <remarks></remarks>
    Sub GetLine(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal StartPoint As Point, ByVal EndPoint As Point)
        Dim myPen As Pen
        myPen = New Pen(_color, _thickness)
        e.Graphics.DrawLine(myPen, StartPoint, EndPoint)
    End Sub
End Class
