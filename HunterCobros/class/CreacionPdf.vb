Imports iTextSharp.text.pdf
Imports iTextSharp.text

Public Class CreacionPdf
    Inherits PdfPageEventHelper


    Protected ReadOnly Property Footer() As Font
        Get
            Dim grey As New BaseColor(128, 128, 128)
            Dim font1 As Font = FontFactory.GetFont("Arial", 9, Font.NORMAL, grey)
            Return font1
        End Get
    End Property


    Public Overrides Sub OnEndPage(writer As PdfWriter, doc As Document)
        Try
            '**********************************************
            ' encabezado de pagina
            '**********************************************
            Dim headerTbl As New PdfPTable(1)
            headerTbl.TotalWidth = doc.PageSize.Width
            Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/imagen/ImagenCabecera.png"))
            logo.ScaleAbsolute(540.0F, 65.0F)
            Dim cell As New PdfPCell(logo)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.PaddingTop = 25
            cell.PaddingLeft = 25
            cell.PaddingRight = 20
            cell.Border = 0
            headerTbl.AddCell(cell)
            headerTbl.WriteSelectedRows(0, -1, 0, (doc.PageSize.Height), writer.DirectContent)
            Dim pdfContent As PdfContentByte
            Dim cb2 As PdfContentByte = writer.DirectContentUnder
            Dim baseFont2 As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED)
            cb2.BeginText()
            cb2.SetColorFill(BaseColor.LIGHT_GRAY)
            cb2.SetFontAndSize(baseFont2, 10)
            cb2.ShowTextAligned(Element.ALIGN_CENTER, "NO VALIDA PARA EFECTOS TRIBUTARIOS", doc.PageSize.Width - 10, doc.PageSize.Height / 2, -90)
            cb2.EndText()
            '**********************************************
            ' pie de pagina
            '**********************************************
            Dim footerTbl As New PdfPTable(2)
            footerTbl.TotalWidth = doc.PageSize.Width
            footerTbl.HorizontalAlignment = Element.ALIGN_CENTER
            Dim para0 As New iTextSharp.text.Paragraph("Fecha/Impresión: " & Format(Date.Now, "dd/MMM/yyyy HH:mm"), Footer)
            Dim para1 As New iTextSharp.text.Paragraph("Pág. " & writer.PageNumber, Footer)
            Dim cellpie0 As New PdfPCell(para0)
            cellpie0.HorizontalAlignment = Element.ALIGN_LEFT
            cellpie0.Border = 0
            cellpie0.PaddingLeft = 10
            footerTbl.AddCell(cellpie0)
            Dim cellpie1 As New PdfPCell(para1)
            cellpie1.HorizontalAlignment = Element.ALIGN_RIGHT
            cellpie1.Border = 0
            cellpie1.PaddingRight = 10
            footerTbl.AddCell(cellpie1)
            footerTbl.WriteSelectedRows(0, -1, 0, 25, writer.DirectContent)
            '***********************************************************************
            ' linea separador
            '***********************************************************************.
            pdfContent = writer.DirectContent
            pdfContent.MoveTo(10, doc.PageSize.Height - 810)
            pdfContent.LineTo(doc.PageSize.Width - 10, doc.PageSize.Height - 810)
            pdfContent.SetColorStroke(BaseColor.GRAY)
            pdfContent.Stroke()
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub

End Class
