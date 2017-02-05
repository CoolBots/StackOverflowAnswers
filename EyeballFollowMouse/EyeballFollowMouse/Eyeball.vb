Option Explicit On
Option Strict On
Option Infer On

Public Class Eyeball
    Inherits Sprite

    Private _pupil As Pupil
    Private _outline As Sprite


    Public Sub New(ByVal boundingBox As RectangleF,
                   ByVal fillColor As Color,
                   ByVal outlineColor As Color,
                   ByVal pupilColor As Color,
                   ByVal graphics As Graphics)
        MyBase.New(boundingBox, fillColor, Sub(pen, rectF) graphics.DrawEllipse(pen, rectF),
                                           Sub(brush, rectF) graphics.FillEllipse(brush, rectF))

        _pupil = New Pupil(New RectangleF(boundingBox.X + boundingBox.Width / 4,
                                          boundingBox.Y + boundingBox.Height / 4,
                                          boundingBox.Width / 2,
                                          boundingBox.Height / 2),
                           pupilColor,
                           Sub(brush, rectF) graphics.FillEllipse(brush, rectF))

        _outline = New Sprite(boundingBox, outlineColor, Sub(pen, rectF) graphics.DrawEllipse(pen, rectF))

    End Sub

    Public Sub Update(ByVal mouse As Point)
        _pupil.Update(mouse)
    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()

        _outline.Draw()
        _pupil.Draw()
    End Sub

    Private Class Pupil
        Inherits Sprite

        Private _movementRadius As PointF
        Private _center As PointF

        Public Sub New(boundingBox As RectangleF, color As Color, Optional fillAction As Action(Of Brush, RectangleF) = Nothing)
            MyBase.New(boundingBox, color, Nothing, fillAction)

            _movementRadius = New PointF(boundingBox.Width / 4, boundingBox.Height / 4)
            _center = New PointF(boundingBox.X + boundingBox.Width / 2,
                                 boundingBox.Y + boundingBox.Height / 2)
        End Sub

        Public Sub Update(ByVal mouse As Point)
            'Calculate angle to mouse position
            Dim distanceVector = New PointF(mouse.X - _center.X, mouse.Y - _center.Y)
            Dim angleToMouse = Math.Atan2(distanceVector.Y, distanceVector.X)

            'If the mouse is within the movement radius, restrict movement
            Dim absDistanceVector As PointF = distanceVector
            If absDistanceVector.X < 0 Then absDistanceVector.X *= -1
            If absDistanceVector.Y < 0 Then absDistanceVector.Y *= -1

            'Calculate scale
            Dim scale = New PointF(Math.Min(absDistanceVector.X, _movementRadius.X),
                                   Math.Min(absDistanceVector.Y, _movementRadius.Y))

            'Adjust X and Y of the pupil based on scaled vector to mouse cursor, offset by pupil origin
            X = CType(Math.Cos(angleToMouse), Single) * scale.X + _center.X - BoundingBox.Width / 2
            Y = CType(Math.Sin(angleToMouse), Single) * scale.Y + _center.Y - BoundingBox.Height / 2

        End Sub
    End Class

End Class
