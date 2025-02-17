Public Class Form1

    Dim clickedValue As String = ""
    Dim equation As String = ""
    Dim numbers As New List(Of Decimal)
    Dim operators As New List(Of String)
    Dim result As Decimal

    Private Sub OpenLblVisibility(ByVal value As String)
        clickedValueTxtBox.Visible = True
        equationTxtBox.Visible = True

        clickedValue &= value
        clickedValueTxtBox.Text = clickedValue
        equationTxtBox.Text = equation
    End Sub
    Private Sub OpenLblVisibility(ByVal value As String, ByVal operatorSymbol As String)
        clickedValueTxtBox.Visible = True
        equationTxtBox.Visible = True

        If clickedValue <> "" Then
            numbers.Add(Convert.ToDecimal(clickedValue))
            operators.Add(operatorSymbol)
            equation = $"{clickedValue} {operatorSymbol} "
            clickedValue = ""
            clickedValueTxtBox.Text = clickedValue
            equationTxtBox.Text = equation
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clickedValueTxtBox.Visible = False
        equationTxtBox.Visible = False
    End Sub

    Private Sub zeroBtn_Click(sender As Object, e As EventArgs) Handles zeroBtn.Click
        OpenLblVisibility("0")
    End Sub

    Private Sub oneBtn_Click(sender As Object, e As EventArgs) Handles oneBtn.Click
        OpenLblVisibility("1")
    End Sub

    Private Sub twoBtn_Click(sender As Object, e As EventArgs) Handles twoBtn.Click
        OpenLblVisibility("2")
    End Sub

    Private Sub threeBtn_Click(sender As Object, e As EventArgs) Handles threeBtn.Click
        OpenLblVisibility("3")
    End Sub

    Private Sub fourBtn_Click(sender As Object, e As EventArgs) Handles fourBtn.Click
        OpenLblVisibility("4")
    End Sub

    Private Sub fiveBtn_Click(sender As Object, e As EventArgs) Handles fiveBtn.Click
        OpenLblVisibility("5")
    End Sub

    Private Sub sixBtn_Click(sender As Object, e As EventArgs) Handles sixBtn.Click
        OpenLblVisibility("6")
    End Sub

    Private Sub sevenBtn_Click(sender As Object, e As EventArgs) Handles sevenBtn.Click
        OpenLblVisibility("7")
    End Sub

    Private Sub eightBtn_Click(sender As Object, e As EventArgs) Handles eightBtn.Click
        OpenLblVisibility("8")
    End Sub

    Private Sub nineBtn_Click(sender As Object, e As EventArgs) Handles nineBtn.Click
        OpenLblVisibility("9")
    End Sub

    Private Sub equalBtn_Click(sender As Object, e As EventArgs) Handles equalBtn.Click
        If clickedValue <> "" Then
            numbers.Add(Convert.ToDecimal(clickedValue))
            equation &= clickedValue
        End If

        If numbers.Count > 1 Then
            result = numbers(0)

            For i As Integer = 0 To operators.Count - 1
                Dim operatorSymbol As String = operators(i)
                Dim nextNumber As Decimal = numbers(i + 1)

                Select Case operatorSymbol
                    Case "+"
                        result += nextNumber
                    Case "-"
                        result -= nextNumber
                    Case "*"
                        result *= nextNumber
                    Case "/"
                        If nextNumber <> 0 Then
                            result /= nextNumber
                        Else
                            equationTxtBox.Text = "Error: Division by Zero"
                            Exit Sub
                        End If
                End Select
            Next
            equationTxtBox.Text = $"{equation} = "
            clickedValue = result.ToString()
            clickedValueTxtBox.Text = clickedValue
            numbers.Clear()
            operators.Clear()

        End If
    End Sub

    Private Sub plusBtn_Click(sender As Object, e As EventArgs) Handles plusBtn.Click
        OpenLblVisibility(clickedValue, "+")
    End Sub

    Private Sub minusBtn_Click(sender As Object, e As EventArgs) Handles minusBtn.Click
        OpenLblVisibility(clickedValue, "-")
    End Sub

    Private Sub asteriskBtn_Click(sender As Object, e As EventArgs) Handles asteriskBtn.Click
        OpenLblVisibility(clickedValue, "*")
    End Sub

    Private Sub divideBtn_Click(sender As Object, e As EventArgs) Handles divideBtn.Click
        OpenLblVisibility(clickedValue, "/")
    End Sub

    Private Sub eraseBtn_Click(sender As Object, e As EventArgs) Handles eraseBtn.Click
        If clickedValue.Length > 0 Then
            clickedValue = clickedValue.Substring(0, clickedValue.Length - 1)
        End If
        clickedValueTxtBox.Text = clickedValue.ToString()
        equationTxtBox.Text = equation
    End Sub

    Private Sub clrBtn_Click(sender As Object, e As EventArgs) Handles clrBtn.Click
        numbers.Clear()
        operators.Clear()
        clickedValue = ""
        equation = ""
        clickedValueTxtBox.Text = ""
        equationTxtBox.Text = ""
    End Sub
End Class
