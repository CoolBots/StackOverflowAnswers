Option Explicit On
Option Strict On
Option Infer On

Public Class Sprite
    Private _boundingBox As RectangleF

    Public Property BoundingBox As RectangleF
        Get
            Return _boundingBox
        End Get
        Set(value As RectangleF)
            _boundingBox = value
        End Set
    End Property

    Public Property Color As Color

    Public Property X As Single
        Get
            Return BoundingBox.X
        End Get
        Set(value As Single)
            _boundingBox.X = value
        End Set
    End Property
    Public Property Y As Single
        Get
            Return BoundingBox.Y
        End Get
        Set(ByVal value As Single)
            _boundingBox.Y = value
        End Set
    End Property

    Protected DrawAction As Action(Of Pen, RectangleF)
    Protected FillAction As Action(Of Brush, RectangleF)

    Public Sub New(ByVal boundingBox As RectangleF,
                   ByVal color As Color,
                   Optional ByVal drawAction As Action(Of Pen, RectangleF) = Nothing,
                   Optional ByVal fillAction As Action(Of Brush, RectangleF) = Nothing)

        Me.BoundingBox = boundingBox
        Me.Color = color
        Me.DrawAction = drawAction
        Me.FillAction = fillAction

    End Sub

    Public Overridable Sub Draw()

        FillAction?(New SolidBrush(Color), BoundingBox)
        DrawAction?(New Pen(Color), BoundingBox)

    End Sub

End Class
