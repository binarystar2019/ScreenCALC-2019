﻿Public Class Form1

    ' SCREEN SIZE AND THROW CALCULATOR'
    ' Guy Tittley @ LST - The University of Edinburgh'
    ' April 2018'

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim lw As Single    'lens ratio - wide'
        Dim lt As Single    'lens ratio - tele'
        Dim sw As Single    'screen width'
        Dim mvd As Single   'Maximum Viewing Distance'
        Dim X As Single
        Dim Z As Single
        Dim B As Single     'throw midpoint'
        Dim AL As Single    'ANSI Lumens'
        Dim SA As Single    'Screen Area'
        Dim LPA As Single   'Lumens per Screen Area'
        Dim AMB As Single   'Ambient light LUX'
        Dim SG As Single    'Screen Gain'
        Dim CR As Single    'Contrast Ratio'

        'Enter Input Data'
        lw = Val(TextBox1.Text)  'Lens Ratio WIDE'
        lt = Val(TextBox2.Text)  'Lens Ratio TELE'
        sw = Val(TextBox3.Text)  'Screen Width'

        'Calculate Results - Lens Throw'
        X = lw * sw
        Z = lt * sw
        B = ((Z - X) / 2) + X

        'Display Lens Throw Results'
        TextBox4.Text = Math.Round(X, 2)  'Throw Wide - shortest'
        TextBox6.Text = Math.Round(Z, 2)  'Throw Tele - longest'
        TextBox5.Text = Math.Round(B, 2)  'Throw - midpoint'

        'Calculate Results - Screen Height + Diagonal'
        '4:3 Aspect Ratio'
        Dim H As Single    'Screen Height'
        Dim D As Single    'Screen Diagonal'
        H = (sw / 4) * 3
        D = Math.Sqrt((sw * sw) + (H * H))

        '16:9 Aspect Ratio'
        Dim HH As Single    'Screen Height'
        Dim DD As Single    'Screen Diagonal'
        HH = (sw / 16) * 9
        DD = Math.Sqrt((sw * sw) + (HH * HH))

        '16:10 Aspect Ratio'
        Dim HX As Single    'Screen Height'
        Dim DX As Single    'Screen Diagonal'
        HX = (sw / 16) * 10
        DX = Math.Sqrt((sw * sw) + (HX * HX))

        'Display Results - Screen Height + Diagonal; rounded to 3 decimal places'
        ' Val(TextBox9.Text) = Max viewing distance (default is Screen Diag * 5)'

        If RadioButton1.Checked = True Then
            TextBox7.Text = Math.Round(H, 2)       'Screen H 4:3'
            TextBox8.Text = Math.Round(D, 2)       'Screen Diag 4:3'

        ElseIf RadioButton2.Checked = True Then
            TextBox7.Text = Math.Round(HX, 2)      'Screen H 16:10'
            TextBox8.Text = Math.Round(DX, 2)      'Screen Diag 16:10'

        ElseIf RadioButton3.Checked = True Then
            TextBox7.Text = Math.Round(HH, 2)      'Screen H 16:9'
            TextBox8.Text = Math.Round(DD, 2)      'Screen Diag 16:9'

        End If

        mvd = Math.Round(Val(TextBox7.Text) * Val(ComboBox1.Text), 1)   'Max Viewing Distance = screen height * mvd factor' - (recommended 6 x h)
        TextBox10.Text = mvd                                            'Display Max Viewing Distance'
        TextBox11.Text = Math.Round(((Val(TextBox7.Text) / 3) * 4), 2)  'Calc and display 4:3 Width on widescreen'
        TextBox12.Text = Math.Round(Val(TextBox7.Text), 2)              '4:3 Height'

        'Calculate ANSI Lumens per square metre (ANSI Lumens / screen Area)'

        AL = Val(TextBox13.Text)                        'Projector ANSI Lumens'
        SA = (Val(TextBox3.Text) * Val(TextBox7.Text))  'Screen Area (Width * Height)
        LPA = AL / SA                                   'Lumens / Screen Area = LPA'
        SG = Val(TextBox18.Text)                        'Screen Gain'
        AMB = Val(TextBox16.Text)                       'Ambient Light'


        TextBox14.Text = Math.Round(LPA, 0)             'LPA (Lumens / Screen Area)'


        If TextBox16.Text = "" Then
            AMB = 100
            TextBox16.Text = "100"                      'Default Ambient Light value of 100 lumens'

        End If

        CR = (Val(TextBox14.Text) / AMB) * SG   'Contrast Ratio = (Proj Lumens / Ambient) * Screen Gain'

        TextBox15.Text = Math.Round(CR, 2)      'Contrast Ratio'

        Beep()

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        PrintDialog1.Document = PrintDocument1 'PrintDialog associate with PrintDocument.

        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            ' PrintDocument1.Print()
            PrintForm1.Print()

        End If

        Beep()

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox15_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox15.TextChanged

        Dim TXBC As Single  'VAL of TextBox15.Text'
        TXBC = Val(TextBox15.Text)

        ' ideal contrast ratio > 15:1 '

        ' Change textbox bacground colour to Red if contrast ratio < 10 '
        ' Change textbox bacground colour to LightGreen if contrast ratio > 10 '

        If TXBC = 0 Then

            TextBox15.BackColor = SystemColors.Control

        ElseIf TXBC >= 15 Then

            TextBox15.BackColor = Color.LightGreen

        ElseIf TXBC <= 15 And TXBC >= 8 Then

            TextBox15.BackColor = Color.Orange

        ElseIf TXBC < 8 Then

            TextBox15.BackColor = Color.Red

        End If


    End Sub

    Private Sub TextBox17_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox17.TextChanged

    End Sub
    Private Sub Label19_Click(sender As System.Object, e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub TextBox16_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox16.TextChanged


    End Sub

    Private Sub Label20_Click(sender As System.Object, e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub TextBox18_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox18.TextChanged

    End Sub

    Private Sub TextBox13_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox13.TextChanged

    End Sub
End Class



