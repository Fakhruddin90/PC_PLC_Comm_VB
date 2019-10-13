
Imports System.Windows.Forms


Public Class Form1
    Private Sub cmdOpen_Click(sender As Object, e As EventArgs) Handles cmdOpen.Click
        Dim lRet As Long
        ActEasyIF2.CreateControl()
        lRet = ActEasyIF2.Open()
        If lRet = 0 Then
            txtStatus.Text = "Communication Line Was Open Normally. "
            cmdOpen.Enabled = False
            cmdClose.Enabled = True
            cmdMonitor.Enabled = True
            cmdExit.Enabled = False
        Else
            txtStatus.Text = "Error occurrence (Error Code: " + Hex$(lRet) + ")"
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Dim lRet As Long
        ActEasyIF2.CreateControl()
        lRet = ActEasyIF2.Close()
        If lRet = 0 Then
            txtStatus.Text = "Communication Line Was Close Normally. "
            cmdOpen.Enabled = True
            cmdClose.Enabled = False
            cmdMonitor.Enabled = False
            cmdExit.Enabled = True
        Else
            txtStatus.Text = "Error occurrence (Error Code: " + Hex$(lRet) + ")"
        End If
    End Sub

    Private Sub cmdMonitor_Click(sender As Object, e As EventArgs) Handles cmdMonitor.Click
        If tmrTime.Enabled() = False Then
            tmrTime.Start()
            txtStatus.Text = "Monitoring"
            cmdMonitor.Text = "Monitor stop"
            cmdClose.Enabled = False
        Else
            tmrTime.Stop()
            txtStatus.Text = "Monitoring was stopped"
            cmdMonitor.Text = "Monitor Start"
            cmdClose.Enabled = True
        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        End
    End Sub

    Private Sub tmrTime_Tick(sender As Object, e As EventArgs) Handles tmrTime.Tick
        Dim lData(21) As Long
        Dim lRet As Long
        Dim Limit As Integer = 10


        lRet = ActEasyIF2.GetDevice("Y20", lData(0))
        lRet = ActEasyIF2.GetDevice("Y21", lData(1))
        lRet = ActEasyIF2.GetDevice("Y22", lData(2))
        lRet = ActEasyIF2.GetDevice("Y23", lData(3))
        lRet = ActEasyIF2.GetDevice("Y24", lData(4))
        lRet = ActEasyIF2.GetDevice("Y25", lData(5))
        lRet = ActEasyIF2.GetDevice("Y26", lData(6))
        lRet = ActEasyIF2.GetDevice("Y27", lData(7))

        lRet = ActEasyIF2.GetDevice("X0", lData(13))
        lRet = ActEasyIF2.GetDevice("X1", lData(14))
        lRet = ActEasyIF2.GetDevice("X2", lData(15))
        lRet = ActEasyIF2.GetDevice("X3", lData(16))
        lRet = ActEasyIF2.GetDevice("X4", lData(17))
        lRet = ActEasyIF2.GetDevice("X5", lData(18))
        lRet = ActEasyIF2.GetDevice("X6", lData(19))
        lRet = ActEasyIF2.GetDevice("X7", lData(20))


        lRet = ActEasyIF2.GetDevice("D0", lData(8))
        lRet = ActEasyIF2.GetDevice("D1", lData(9))
        lRet = ActEasyIF2.GetDevice("D2", lData(10))
        lRet = ActEasyIF2.GetDevice("D3", lData(11))
        lRet = ActEasyIF2.GetDevice("D4", lData(12))
        lRet = ActEasyIF2.GetDevice("D302", lData(21))

        If lRet <> 0 Then
            txtStatus.Text = "Error occurrence (Error code: " + (lRet).ToString + ")"
        End If

        'For Y0 -> Y7

        If lData(0) = 1 Then
            lblON_OFF1.Text = "1"
        Else
            lblON_OFF1.Text = "0"
        End If

        If lData(1) = 1 Then
            lblON_OFF2.Text = "1"
        Else
            lblON_OFF2.Text = "0"
        End If

        If lData(2) = 1 Then
            lblON_OFF3.Text = "1"
        Else
            lblON_OFF3.Text = "0"
        End If

        If lData(3) = 1 Then
            lblON_OFF4.Text = "1"
        Else
            lblON_OFF4.Text = "0"
        End If

        If lData(4) = 1 Then
            lblON_OFF5.Text = "1"
        Else
            lblON_OFF5.Text = "0"
        End If

        If lData(5) = 1 Then
            lblON_OFF6.Text = "1"
        Else
            lblON_OFF6.Text = "0"
        End If

        If lData(6) = 1 Then
            lblON_OFF7.Text = "1"
        Else
            lblON_OFF7.Text = "0"
        End If

        If lData(7) = 1 Then
            lblON_OFF8.Text = "1"
        Else
            lblON_OFF8.Text = "0"
        End If


        'For X0 -> X7
        If lData(13) = 1 Then
            lblX0.Text = "1"
        Else
            lblX0.Text = "0"
        End If

        If lData(14) = 1 Then
            lblX1.Text = "1"
        Else
            lblX1.Text = "0"
        End If

        If lData(15) = 1 Then
            lblX2.Text = "1"
        Else
            lblX2.Text = "0"
        End If

        If lData(16) = 1 Then
            lblX3.Text = "1"
        Else
            lblX3.Text = "0"
        End If

        If lData(17) = 1 Then
            lblX4.Text = "1"
        Else
            lblX4.Text = "0"
        End If

        If lData(18) = 1 Then
            lblX5.Text = "1"
        Else
            lblX5.Text = "0"
        End If

        If lData(19) = 1 Then
            lblX6.Text = "1"
        Else
            lblX6.Text = "0"
        End If

        If lData(20) = 1 Then
            lblX7.Text = "1"
        Else
            lblX7.Text = "0"
        End If

        'D0 -> D4
        lbl_Dvalue1.Text = lData(8)
        lbl_Dvalue2.Text = lData(9)
        lbl_Dvalue3.Text = lData(10)
        lbl_Dvalue4.Text = lData(11)
        lbl_Dvalue5.Text = lData(12)
        lbl_Dvalue6.Text = lData(21)

        'Chart
        'Try
        '    Chart1.Series("D4").Points.AddY(lData(12).ToString)
        '    If Chart1.Series(0).Points.Count = 100 Then
        '        Chart1.Series(0).Points.RemoveAt(0)
        '    End If
        '    Chart1.ChartAreas(0).AxisY.Maximum = 10
        'Catch ex As Exception

        'End Try

        'Dim lData(8), lData(9), lData(10) As String
        Dim DT As DateTime = Now

        Chart1.Series("D0").Points.AddXY(DateTime.Now.ToLongTimeString, lData(8))
        If Chart1.Series(0).Points.Count = Limit Then
            Chart1.Series(0).Points.RemoveAt(0)
        End If

        Chart1.Series("D1").Points.AddY(lData(9))
        If Chart1.Series(1).Points.Count = Limit Then
            Chart1.Series(1).Points.RemoveAt(0)
        End If

        Chart1.Series("D2").Points.AddY(lData(10))
        If Chart1.Series(2).Points.Count = Limit Then
            Chart1.Series(2).Points.RemoveAt(0)
        End If

        Chart1.Series("D3").Points.AddY(lData(11))
        If Chart1.Series(3).Points.Count = Limit Then
            Chart1.Series(3).Points.RemoveAt(0)
        End If

        Chart1.Series("D4").Points.AddY(lData(12))
        If Chart1.Series(4).Points.Count = Limit Then
            Chart1.Series(4).Points.RemoveAt(0)
        End If

        Chart1.Series("D5").Points.AddY(lData(21))
        If Chart1.Series(5).Points.Count = Limit Then
            Chart1.Series(5).Points.RemoveAt(0)
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Limit As Integer = 10
        'Dim aw As String
        'aw = 4

        'Chart1.Series("D4").Points.AddY(aw)
        'Chart1.Series("D4").IsValueShownAsLabel = False
        'Chart1.ChartAreas("ChartArea1").AxisX.Enabled = DataVisualization.Charting.AxisEnabled.False

        For i = 0 To 30 Step 1
            Chart1.Series("D0").Points.AddXY(DateTime.Now.ToLongTimeString, 0)
            If Chart1.Series(0).Points.Count = Limit Then
                Chart1.Series(0).Points.RemoveAt(0)
            End If
            Chart1.ChartAreas(0).AxisY.Maximum = 1100

            Chart1.Series("D1").Points.AddY(0)
            If Chart1.Series(1).Points.Count = Limit Then
                Chart1.Series(1).Points.RemoveAt(0)
            End If

            Chart1.Series("D2").Points.AddY(0)
            If Chart1.Series(2).Points.Count = Limit Then
                Chart1.Series(2).Points.RemoveAt(0)
            End If

            Chart1.Series("D3").Points.AddY(0)
            If Chart1.Series(3).Points.Count = Limit Then
                Chart1.Series(3).Points.RemoveAt(0)
            End If

            Chart1.Series("D4").Points.AddY(0)
            If Chart1.Series(4).Points.Count = Limit Then
                Chart1.Series(4).Points.RemoveAt(0)
            End If

            Chart1.Series("D5").Points.AddY(0)
            If Chart1.Series(5).Points.Count = Limit Then
                Chart1.Series(5).Points.RemoveAt(0)
            End If
        Next
        Chart1.ChartAreas(0).AxisY.Maximum = 1200

    End Sub
End Class