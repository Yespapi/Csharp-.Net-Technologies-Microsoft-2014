Imports System.Text.RegularExpressions
Imports System.IO


Public Class Form1

    Dim oRead As System.IO.StreamReader

    Private Sub FindFirstLetter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' Simplest Regex utilzation
        ' Searches data that is input into the textbox on the form and does not create Regex objects
        '
        'Finds the first occurance of the letter 'a'
        Dim x As String = Regex.Match(TextBox1.Text, ".").Value

        If x = "" Then
            MsgBox("You must enter text in the texbox to get results...")
        End If

        Label1.Text = x

    End Sub

    Private Sub FindFirstAClass(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ' Using Regex classes
        '
        'Finds the first occurrance of the letter 'a'
        'because the Match object only returns the first occurrance
        Dim r As Regex = New Regex("a")
        Dim m As Match = r.Match(TextBox1.Text)

        Label1.Text = m.Value & " : " & m.Index + 1

        If TextBox1.Text = "" Then
            Label1.Text = " "
            MsgBox("You must enter text in the texbox to get results...")

        End If
    End Sub

    Private Sub FindMultipleLetters(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ' Using Regex classes
        '
        'Searches the text file C:\sample.txt

        '--------------------------------------------------------
        'Find all occurences of the letter 'a'
        'because we are using MatchCollection object

        Dim r As Regex = New Regex("a", RegexOptions.Multiline)

        Dim m As String = ReadFile()

        Dim Mtch As MatchCollection = r.Matches(m)

        Dim result As String = ""
        Dim i As Integer
        For i = 0 To Mtch.Count - 1
            Dim mat As Match = Mtch.Item(i)
            result = result & vbCrLf & mat.Value
        Next

        MsgBox(result, , Button3.Text)
        'Uncomment the next line to make program end when you click ok on the message box
        'Application.Exit()

    End Sub

    Private Sub FindTheWordThis(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        '--------------------------------------------------------
        'Find all occurences of the word -This-
        Dim r As Regex = New Regex("\bThis\b", RegexOptions.Multiline)

        Dim m As String = ReadFile()

        Dim Mtch As MatchCollection = r.Matches(m)

        Dim result As String = ""
        Dim i As Integer
        For i = 0 To Mtch.Count - 1
            Dim mat As Match = Mtch.Item(i)
            result = result & vbCrLf & mat.Value
        Next

        MsgBox(result, , Button4.Text)
        'Uncomment the next line to make program end when you click ok on the message box
        'Application.Exit()

    End Sub

    Private Sub ThisBeginsNewLine(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        '--------------------------------------------------------
        'Find -This- when it is at the beginning of a line (requires RegexOptions.Multiline)
        Dim r As Regex = New Regex("^This", RegexOptions.Multiline)


        Dim m As String = ReadFile()

        Dim Mtch As MatchCollection = r.Matches(m)

        Dim result As String = ""
        Dim i As Integer
        For i = 0 To Mtch.Count - 1
            Dim mat As Match = Mtch.Item(i)
            result = result & vbCrLf & mat.Value
        Next

        MsgBox(result, , Button5.Text)
        'Uncomment the next line to make program end when you click ok on the message box
        'Application.Exit()

    End Sub

    Private Sub FirstWordOfEveryLine(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        '--------------------------------------------------------
        'Find the first word of every new line
        Dim r As Regex = New Regex("^\w*", RegexOptions.Multiline)

        '--------------------------------------------------------
        'Calling the GetMatches Sub instead of re-typing the same code each time in each button click event sub
        'We pass the Regex search info as a Regex object to the GetMatches sub and it processes it
        GetMatches(r, sender)

    End Sub

    Private Sub FindWordsThisIs(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        '--------------------------------------------------------
        'Find -This is-
        Dim r As Regex = New Regex("\bThis\b\s\bis\b", RegexOptions.Multiline)


        '--------------------------------------------------------
        'Calling the GetMatches Sub instead of re-typing the same code each time in each button click event sub
        'We pass the Regex search info as a Regex object to the GetMatches sub and it processes it
        GetMatches(r, sender)

    End Sub

    Private Sub FindEveryLetterInFile(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        '--------------------------------------------------------
        'Find every letter in the file
        Dim r As Regex = New Regex(".*", RegexOptions.Multiline)

        '--------------------------------------------------------
        'Calling the GetMatches Sub instead of re-typing the same code each time in each button click event sub
        'We pass the Regex search info as a Regex object to the GetMatches sub and it processes it
        GetMatches(r, sender)

    End Sub

    Private Sub AllFiveAndSixLetterWords(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        '--------------------------------------------------------
        'Find all 5 and 6 letter words
        Dim r As Regex = New Regex("\b\w{5,6}\b", RegexOptions.Multiline)

        '--------------------------------------------------------
        'Calling the GetMatches Sub instead of re-typing the same code each time in each button click event sub
        'We pass the Regex search info as a Regex object to the GetMatches sub and it processes it
        GetMatches(r, sender)

    End Sub

    Private Sub FindTenDigitTelNo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        'Find all ten digit telephone numbers
        Dim r As Regex = New Regex("\b\d{3}\s\d{3}-\d{4}", RegexOptions.Multiline)

        GetMatches(r, sender)


    End Sub

    Private Sub FindIPAddress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        'Find an IP Address
        Dim r As Regex = New Regex("(\d{1,3}\.){3}\d{1,3}", RegexOptions.Multiline)


        GetMatches(r, sender)

    End Sub

    Private Sub FindHTMLTag(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click


        'Find the H1 html tag and it's contents
        Dim r As Regex = New Regex("<(h1*)\b[^>]*>(.*?)</\1>", RegexOptions.Multiline)

        GetMatches(r, sender)

    End Sub

    Public Function ReadFile() As String
        Dim EntireFile As String
        oRead = File.OpenText("C:\sample.txt")
        EntireFile = oRead.ReadToEnd()
        Return EntireFile
    End Function

    Public Sub GetMatches(ByVal rx As Regex, ByVal x As Button)
        Dim m As String = ReadFile()

        Dim Mtch As MatchCollection = rx.Matches(m)

        Dim result As String = ""
        Dim i As Integer
        For i = 0 To Mtch.Count - 1
            Dim mat As Match = Mtch.Item(i)
            result = result & vbCrLf & mat.Value
        Next

        MsgBox(result, , x.Text)

        'Uncomment the next line to make program end when you click ok on the message box
        'Application.Exit()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
