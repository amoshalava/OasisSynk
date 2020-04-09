Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary


Public Class frmOasisSynk

    <Serializable>
    Public Class SynkItems
        Public myList As List(Of SynkItemSQLDatabase)

        Public Sub New()
            myList = New List(Of SynkItemSQLDatabase)
        End Sub

        Public Sub Add(svr As SynkItemSQLDatabase)
            myList.Add(svr)
        End Sub

        ' no reason it cant also create server objects for you
        Public Sub Add(sname As String, uname As String, pw As String)
            myList.Add(New SynkItemSQLDatabase With {.Server = sname, .Username = uname, .Password = pw})
        End Sub

        'toDo Contains, Count, Item etc as needed

        Public Sub Save(mypath As String)
            Using fs As New FileStream(mypath, FileMode.OpenOrCreate)
                Dim bf As New BinaryFormatter
                bf.Serialize(fs, myList)
            End Using
        End Sub

        Public Function Load(mypath As String) As Int32
            'ToDo: check if file exists
            Try

                Using fs As New FileStream(mypath, FileMode.Open)
                    Dim bf As New BinaryFormatter
                    myList = CType(bf.Deserialize(fs), List(Of SynkItemSQLDatabase))
                End Using

                If myList IsNot Nothing Then
                    Return myList.Count
                Else
                    Return 0
                End If

            Catch ex As Exception
                Console.WriteLine("ERROR: " & ex.ToString)
                Return 0
            End Try


        End Function
    End Class


    <Serializable()> Public Class SynkItemSQLDatabase
        Public GUID As String = System.Guid.NewGuid.ToString()
        Public SynkName As String
        Public Server As String
        Public Database As String
        Public Username As String
        Public Password As String
        Public Query As String
        Public FromMidnightMins As Integer
        Public IntervalMins As Integer
        Public LastFired As Date
        Public Overrides Function ToString() As String
            If SynkName = "" Then SynkName = "(none)"
            Return SynkName
        End Function

    End Class

    Dim MySynkItems As New SynkItems
    Dim ConfigFileName As String = "OasisSynk.config"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim xSI As New SynkItemSQLDatabase
        xSI.SynkName = "JailTracker Inmate Sync"
        xSI.Server = "Jailtracker"
        xSI.Database = "That awesome databse"


        MySynkItems.Add(xSI)


        Dim xItem As ListViewItem = lstvSynkList.Items.Add(xSI.SynkName)
        xItem.Tag = xSI.GUID


    End Sub

    Private Sub lstvSynkList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstvSynkList.SelectedIndexChanged

    End Sub

    Private Sub lstvSynkList_KeyDown(sender As Object, e As KeyEventArgs) Handles lstvSynkList.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                If MsgBox("Delete Synk?", MsgBoxStyle.YesNo, "Delete") = vbYes Then
                    For Each xItem In lstvSynkList.SelectedItems
                        For Each xItem2 In MySynkItems.myList
                            If xItem2.GUID = xItem.Tag Then
                                MySynkItems.myList.Remove(xItem2)
                            End If
                        Next
                        lstvSynkList.Items.Remove(xItem)
                    Next
                End If
                MySynkItems.Save(ConfigFileName)

        End Select
    End Sub

    Private Sub frmOasisSynk_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim SynkCount = MySynkItems.Load(ConfigFileName)
        For Each xitem In MySynkItems.myList
            Dim xItemr As ListViewItem = lstvSynkList.Items.Add(xitem.SynkName)
            xItemr.Tag = xitem.GUID
        Next

    End Sub

    Private Sub frmOasisSynk_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MySynkItems.Save(ConfigFileName)
    End Sub
End Class
