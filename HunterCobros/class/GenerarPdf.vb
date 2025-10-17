Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class GenerarPdf


    Public Sub GenerarDocumento(ByVal nombre As String, ByVal ruta As String, ByVal detalle As dsHunterCobro.ANTICIPO_DETALLEDataTable, _
                                ByVal anticipo As String, ByVal identificacion As String, ByVal email As String, ByVal nombrerecibimos As String, ByVal total As String, _
                                ByVal observacion As String, ByVal cliente As String, ByVal nombreusuario As String, ByVal fecha As String, ByVal referencia As dsHunterCobro.REFERENCIA_DETALLEDataTable)
        Try
            Dim fonttitulo As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 12, iTextSharp.text.Font.BOLD, New BaseColor(128, 128, 128))
            Dim fontSubtitulo As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD, New BaseColor(128, 128, 128))
            Dim fontGruptitulo As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 9, iTextSharp.text.Font.BOLD, New BaseColor(128, 128, 128))
            Dim fontDetalle As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 8, iTextSharp.text.Font.NORMAL, New BaseColor(128, 128, 128))
            Dim fontSalto As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 5, iTextSharp.text.Font.NORMAL, New BaseColor(51, 51, 51))
            Dim fontFirma As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD, New BaseColor(128, 128, 128))
            Dim fontPie As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 8, iTextSharp.text.Font.NORMAL, New BaseColor(128, 128, 128))
            Dim fontPie2 As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 8, iTextSharp.text.Font.BOLD, New BaseColor(128, 128, 128))
            Dim documento As New Document(PageSize.A4, -40.0F, -40.0F, 100.0F, 30.0F)
            Dim file As String = String.Format("{0}Cobros_{1}", ruta, nombre)
            Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
            Dim paragraph As New iTextSharp.text.Paragraph(" ")
            Dim ev As New CreacionPdf()
            documento.Open()
            documento.NewPage()
            writer.PageEvent = ev
            documento.Add(paragraph)
            Dim dTDatos As DataSet
            dTDatos = Clsrecibo.DatosGeneralPdf(identificacion, anticipo.Substring(0, 19))
            If dTDatos.Tables.Count > 0 Then
                Dim tablaFactura As New PdfPTable(2)
                tablaFactura.SetWidths(New Single() {55.0F, 45.0F})
                Dim tituloFac0 As New PdfPCell(New Phrase(" ", fontSubtitulo))
                tituloFac0.Colspan = 2
                tituloFac0.Border = 0
                tituloFac0.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFactura.AddCell(tituloFac0)
                Dim tituloFac1 As New PdfPCell(New Phrase())
                tituloFac1.Phrase.Add(New Chunk(dTDatos.Tables(0).Rows(0).Item("NOM_EMPRESA").ToString, fonttitulo))
                tituloFac1.Border = 0
                tituloFac1.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFactura.AddCell(tituloFac1)
                Dim tituloFac2 As New PdfPCell(New Phrase())
                tituloFac2.Phrase.Add(New Chunk("ANTICIPO DE PAGO ", fonttitulo))
                tituloFac2.Border = 0
                tituloFac2.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFactura.AddCell(tituloFac2)

                Dim tituloFac3 As New PdfPCell(New Phrase())
                tituloFac3.Phrase.Add(New Chunk("R.U.C.: " + dTDatos.Tables(0).Rows(0).Item("RUC_EMPRESA").ToString, fonttitulo))
                tituloFac3.Border = 0
                tituloFac3.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFactura.AddCell(tituloFac3)
                Dim tituloFac4 As New PdfPCell(New Phrase())
                tituloFac4.Phrase.Add(New Chunk("No: " + anticipo, fonttitulo))
                tituloFac4.Border = 0
                tituloFac4.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFactura.AddCell(tituloFac4)
                documento.Add(tablaFactura)

                Dim tablaFacturacabecera As New PdfPTable(4)
                tablaFacturacabecera.SetWidths(New Single() {10.0F, 45.0F, 18.0F, 27.0F})
                Dim detalleform1 As New PdfPCell(New Phrase("Matriz: ", fontSubtitulo))
                detalleform1.Border = 0
                detalleform1.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(detalleform1)
                Dim detalleform2 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("DIREC_EMPRESA").ToString, fontDetalle))
                detalleform2.Border = 0
                detalleform2.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(detalleform2)
                Dim detalleform3 As New PdfPCell(New Phrase("Fecha de emisión: ", fontSubtitulo))
                detalleform3.Border = 0
                detalleform3.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(detalleform3)
                Dim detalleform4 As New PdfPCell(New Phrase(fecha.ToUpper, fontDetalle))
                detalleform4.Border = 0
                detalleform4.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(detalleform4)

                Dim detalleform5 As New PdfPCell(New Phrase("Teléfono: ", fontSubtitulo))
                detalleform5.Border = 0
                detalleform5.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(detalleform5)
                Dim detalleform6 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("TEL_EMPRESA").ToString, fontDetalle))
                detalleform6.Colspan = 3
                detalleform6.Border = 0
                detalleform6.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera.AddCell(detalleform6)
                Dim detalleform7 As New PdfPCell(New Phrase(" ", fontSalto))
                detalleform7.Colspan = 4
                detalleform7.Border = 0
                detalleform7.BorderWidthBottom = 1.5F
                tablaFacturacabecera.AddCell(detalleform7)
                documento.Add(tablaFacturacabecera)

                Dim tablaFacturacabecera2 As New PdfPTable(2)
                tablaFacturacabecera2.SetWidths(New Single() {25.0F, 75.0F})
                Dim detalleform14 As New PdfPCell(New Phrase("  ", fontSalto))
                detalleform14.Colspan = 2
                detalleform14.Border = 0
                detalleform14.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform14)
                Dim detalleform8 As New PdfPCell(New Phrase("Cliente: ", fontSubtitulo))
                detalleform8.Border = 0
                detalleform8.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform8)
                Dim detalleform9 As New PdfPCell(New Phrase(cliente.ToUpper, fontDetalle))
                detalleform9.Border = 0
                detalleform9.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform9)

                Dim detalleform10 As New PdfPCell(New Phrase("Ejecutiva/o comercial: ", fontSubtitulo))
                detalleform10.Border = 0
                detalleform10.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform10)
                Dim detalleform11 As New PdfPCell(New Phrase(nombreusuario.ToUpper, fontDetalle))
                detalleform11.Border = 0
                detalleform11.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform11)

                Dim detalleform12 As New PdfPCell(New Phrase("Ciudad: ", fontSubtitulo))
                detalleform12.Border = 0
                detalleform12.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform12)
                Dim detalleform13 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("CIUDAD"), fontDetalle))
                detalleform13.Border = 0
                detalleform13.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform13)
                'tablaFacturacabecera2.AddCell(detalleform14)
                'tablaFacturacabecera2.AddCell(detalleform14)

                Dim detalleform121 As New PdfPCell(New Phrase("Recibido de: ", fontSubtitulo))
                detalleform121.Border = 0
                detalleform121.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform121)
                Dim detalleform131 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("RECIBE_CLIENTE"), fontDetalle))
                detalleform131.Border = 0
                detalleform131.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform131)
                tablaFacturacabecera2.AddCell(detalleform14)
                tablaFacturacabecera2.AddCell(detalleform14)

                Dim detalleform15 As New PdfPCell(New Phrase("Monto recibido: ", fontSubtitulo))
                detalleform15.Border = 0
                detalleform15.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform15)
                Dim detalleform16 As New PdfPCell(New Phrase("$ " + Convert.ToString(total) + " USD", fontDetalle))
                detalleform16.Border = 0
                detalleform16.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform16)

                Dim detalleform17 As New PdfPCell(New Phrase("Cantidad letras: ", fontSubtitulo))
                detalleform17.Border = 0
                detalleform17.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform17)
                Dim detalleform18 As New PdfPCell(New Phrase((Numalet.ToCardinal(total).ToUpper + " USD"), fontDetalle))
                detalleform18.Border = 0
                detalleform18.HorizontalAlignment = Element.ALIGN_LEFT
                tablaFacturacabecera2.AddCell(detalleform18)
                tablaFacturacabecera2.AddCell(detalleform14)
                tablaFacturacabecera2.AddCell(detalleform14)
                documento.Add(tablaFacturacabecera2)

                Dim tablaConcepto As New PdfPTable(2)
                tablaConcepto.SetWidths(New Single() {3.0F, 97.0F})
                Dim grupo1Form1 As New PdfPCell(New Phrase(" " + "POR CONCEPTO DE ", fontGruptitulo))
                grupo1Form1.Colspan = 2
                grupo1Form1.Border = 0
                grupo1Form1.BackgroundColor = New BaseColor(228, 228, 228)
                grupo1Form1.BorderColor = New BaseColor(217, 217, 217)
                grupo1Form1.HorizontalAlignment = Element.ALIGN_LEFT
                tablaConcepto.AddCell(grupo1Form1)

                Dim grupo1Form2 As New PdfPCell(New Phrase(" ", fontDetalle))
                grupo1Form2.Border = 0
                grupo1Form2.BorderWidthTop = 0.4F
                grupo1Form2.BorderWidthBottom = 0.4F
                grupo1Form2.BorderWidthLeft = 0.4F
                grupo1Form2.BorderColorTop = New BaseColor(244, 244, 244)
                grupo1Form2.BorderColorBottom = New BaseColor(244, 244, 244)
                grupo1Form2.BorderColorLeft = New BaseColor(244, 244, 244)
                tablaConcepto.AddCell(grupo1Form2)
                Dim grupo1Form3 As New PdfPCell(New Phrase(dTDatos.Tables(0).Rows(0).Item("TIPO_SERVICIO").ToString, fontDetalle))
                grupo1Form3.Border = 0
                grupo1Form3.BorderWidthTop = 0.4F
                grupo1Form3.BorderWidthBottom = 0.4F
                grupo1Form3.BorderWidthRight = 0.4F
                grupo1Form3.BorderColorTop = New BaseColor(244, 244, 244)
                grupo1Form3.BorderColorBottom = New BaseColor(244, 244, 244)
               grupo1Form3.BorderColorRight = New BaseColor(244, 244, 244)
                grupo1Form3.HorizontalAlignment = Element.ALIGN_LEFT
                tablaConcepto.AddCell(grupo1Form3)

                Dim grupo1Form4 As New PdfPCell(New Phrase(" ", fontSalto))
                grupo1Form4.Colspan = 2
                grupo1Form4.Border = 0
                tablaConcepto.AddCell(grupo1Form4)
                tablaConcepto.AddCell(grupo1Form4)
                tablaConcepto.AddCell(grupo1Form4)
                documento.Add(tablaConcepto)

                Dim tablaGrupo3Sec1 As New PdfPTable(7)
                tablaGrupo3Sec1.SetWidths(New Single() {3.0F, 28.0F, 29.0F, 23.0F, 1.0F, 9.0F, 7.0F})
                Dim grupo3Form1 As New PdfPCell(New Phrase("DETALLE DE VALORES RECIBIDOS", fontGruptitulo))
                grupo3Form1.Colspan = 7
                grupo3Form1.Border = 0
                grupo3Form1.BackgroundColor = New BaseColor(228, 228, 228)
                grupo3Form1.HorizontalAlignment = Element.ALIGN_CENTER
                tablaGrupo3Sec1.AddCell(grupo3Form1)
                
                Dim grupo3Form5 As New PdfPCell(New Phrase(" " + "TIPO DE DOCUMENTO", fontGruptitulo))
                grupo3Form5.Colspan = 2
                grupo3Form5.Border = 0
                grupo3Form5.BorderWidthTop = 0.4F
                grupo3Form5.BorderColorTop = New BaseColor(244, 244, 244)
                grupo3Form5.BackgroundColor = New BaseColor(228, 228, 228)
                grupo3Form5.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo3Sec1.AddCell(grupo3Form5)
                Dim grupo3Form6 As New PdfPCell(New Phrase(" " + "BANCO", fontGruptitulo))
                grupo3Form6.Border = 0
                grupo3Form6.BorderWidthTop = 0.4F
                grupo3Form6.BorderColorTop = New BaseColor(244, 244, 244)
                grupo3Form6.BackgroundColor = New BaseColor(228, 228, 228)
                grupo3Form6.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo3Sec1.AddCell(grupo3Form6)
                Dim grupo3Form7 As New PdfPCell(New Phrase(" " + "No.DOCUMENTO", fontGruptitulo))
                grupo3Form7.Border = 0
                grupo3Form7.BorderWidthTop = 0.4F
                grupo3Form7.BorderColorTop = New BaseColor(244, 244, 244)
                grupo3Form7.BackgroundColor = New BaseColor(228, 228, 228)
                grupo3Form7.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo3Sec1.AddCell(grupo3Form7)
                Dim grupo3Form8 As New PdfPCell(New Phrase("", fontSubtitulo))
                grupo3Form8.Border = 0
                grupo3Form8.BorderWidthTop = 0.4F
                grupo3Form8.BorderColorTop = New BaseColor(244, 244, 244)
                grupo3Form8.BackgroundColor = New BaseColor(228, 228, 228)
                grupo3Form8.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo3Sec1.AddCell(grupo3Form8)
                Dim grupo3Form9 As New PdfPCell(New Phrase(" " + "VALOR", fontGruptitulo))
                grupo3Form9.Border = 0
                grupo3Form9.BorderWidthTop = 0.4F
                grupo3Form9.BorderColorTop = New BaseColor(244, 244, 244)
                grupo3Form9.BackgroundColor = New BaseColor(228, 228, 228)
                grupo3Form9.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo3Sec1.AddCell(grupo3Form9)
                Dim grupo3Form10 As New PdfPCell(New Phrase(" ", fontSubtitulo))
                grupo3Form10.Border = 0
                grupo3Form10.BorderWidthTop = 0.4F
                grupo3Form10.BorderColorTop = New BaseColor(244, 244, 244)
                grupo3Form10.BackgroundColor = New BaseColor(228, 228, 228)
                grupo3Form10.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo3Sec1.AddCell(grupo3Form10)

                If detalle.Rows.Count > 0 Then
                    For i As Integer = 0 To detalle.Rows.Count - 1
                        Dim grupo3Form17 As New PdfPCell(New Phrase("", fontDetalle))
                        grupo3Form17.Border = 0
                        grupo3Form17.BorderWidthTop = 0.4F
                        grupo3Form17.BorderWidthBottom = 0.4F
                        grupo3Form17.BorderWidthLeft = 0.4F
                        grupo3Form17.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo3Form17.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo3Form17.BorderColorLeft = New BaseColor(244, 244, 244)
                        tablaGrupo3Sec1.AddCell(grupo3Form17)
                        Dim grupo3Form11 As New PdfPCell(New Phrase(detalle.Rows(i).Item("FORMA_PAGO").ToString(), fontDetalle))
                        grupo3Form11.Border = 0
                        grupo3Form11.BorderWidthTop = 0.4F
                        grupo3Form11.BorderWidthBottom = 0.4F
                        grupo3Form11.BorderWidthRight = 0.4F
                        grupo3Form11.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo3Form11.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo3Form11.BorderColorRight = New BaseColor(244, 244, 244)
                        grupo3Form11.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaGrupo3Sec1.AddCell(grupo3Form11)
                        Dim grupo3Form12 As New PdfPCell(New Phrase(detalle.Rows(i).Item("BANCO").ToString(), fontDetalle))
                        grupo3Form12.Border = 0
                        grupo3Form12.BorderWidthTop = 0.4F
                        grupo3Form12.BorderWidthBottom = 0.4F
                        grupo3Form12.BorderWidthLeft = 0.4F
                        grupo3Form12.BorderWidthRight = 0.4F
                        grupo3Form12.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo3Form12.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo3Form12.BorderColorLeft = New BaseColor(244, 244, 244)
                        grupo3Form12.BorderColorRight = New BaseColor(244, 244, 244)
                        grupo3Form12.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaGrupo3Sec1.AddCell(grupo3Form12)
                        Dim grupo3Form13 As New PdfPCell(New Phrase(detalle.Rows(i).Item("DOCUMENTO").ToString(), fontDetalle))
                        grupo3Form13.Border = 0
                        grupo3Form13.BorderWidthTop = 0.4F
                        grupo3Form13.BorderWidthBottom = 0.4F
                        grupo3Form13.BorderWidthLeft = 0.4F
                        grupo3Form13.BorderWidthRight = 0.4F
                        grupo3Form13.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo3Form13.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo3Form13.BorderColorLeft = New BaseColor(244, 244, 244)
                        grupo3Form13.BorderColorRight = New BaseColor(244, 244, 244)
                        grupo3Form13.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaGrupo3Sec1.AddCell(grupo3Form13)
                        Dim grupo3Form14 As New PdfPCell(New Phrase("$ ", fontDetalle))
                        grupo3Form14.Border = 0
                        grupo3Form14.BorderWidthTop = 0.4F
                        grupo3Form14.BorderWidthBottom = 0.4F
                        grupo3Form14.BorderWidthLeft = 0.4F
                        grupo3Form14.BorderColorLeft = New BaseColor(244, 244, 244)
                        grupo3Form14.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo3Form14.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo3Form14.HorizontalAlignment = Element.ALIGN_RIGHT
                        tablaGrupo3Sec1.AddCell(grupo3Form14)
                        Dim grupo3Form15 As New PdfPCell(New Phrase(FormatNumber(detalle.Rows(i).Item("VALOR").ToString(), 2) & Space(4), fontDetalle))
                        grupo3Form15.Border = 0
                        grupo3Form15.BorderWidthTop = 0.4F
                        grupo3Form15.BorderWidthBottom = 0.4F
                        grupo3Form15.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo3Form15.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo3Form15.HorizontalAlignment = Element.ALIGN_RIGHT
                        tablaGrupo3Sec1.AddCell(grupo3Form15)
                        Dim grupo3Form18 As New PdfPCell(New Phrase("", fontDetalle))
                        grupo3Form18.Border = 0
                        grupo3Form18.BorderWidthTop = 0.4F
                        grupo3Form18.BorderWidthBottom = 0.4F
                        grupo3Form18.BorderWidthRight = 0.4F
                        grupo3Form18.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo3Form18.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo3Form18.BorderColorRight = New BaseColor(244, 244, 244)
                        tablaGrupo3Sec1.AddCell(grupo3Form18)
                    Next
                End If
                Dim grupo3Form16 As New PdfPCell(New Phrase(" ", fontSalto))
                grupo3Form16.Colspan = 7
                grupo3Form16.Border = 0
                grupo3Form16.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo3Sec1.AddCell(grupo3Form16)
                tablaGrupo3Sec1.AddCell(grupo3Form16)
                tablaGrupo3Sec1.AddCell(grupo3Form16)
                documento.Add(tablaGrupo3Sec1)

                Dim tablaGrupo4Sec1 As New PdfPTable(4)
                tablaGrupo4Sec1.SetWidths(New Single() {3.0F, 28.0F, 26.0F, 43.0F})
                Dim grupo4Form1 As New PdfPCell(New Phrase("DOCUMENTOS DE REFERENCIA", fontGruptitulo))
                grupo4Form1.Colspan = 4
                grupo4Form1.Border = 0
                grupo4Form1.BackgroundColor = New BaseColor(228, 228, 228)
                grupo4Form1.HorizontalAlignment = Element.ALIGN_CENTER
                tablaGrupo4Sec1.AddCell(grupo4Form1)

                Dim grupo4Form3 As New PdfPCell(New Phrase(" " + "TIPO DE DOCUMENTO", fontGruptitulo))
                grupo4Form3.Colspan = 2
                grupo4Form3.Border = 0
                grupo4Form3.BorderWidthTop = 0.4F
                grupo4Form3.BorderColorTop = New BaseColor(244, 244, 244)
                grupo4Form3.BackgroundColor = New BaseColor(228, 228, 228)
                grupo4Form3.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo4Sec1.AddCell(grupo4Form3)
                Dim grupo4Form4 As New PdfPCell(New Phrase(" " + "No. DOCUMENTO", fontGruptitulo))
                grupo4Form4.Border = 0
                grupo4Form4.BorderWidthTop = 0.4F
                grupo4Form4.BorderColorTop = New BaseColor(244, 244, 244)
                grupo4Form4.BackgroundColor = New BaseColor(228, 228, 228)
                grupo4Form4.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo4Sec1.AddCell(grupo4Form4)
                Dim grupo4Form9 As New PdfPCell(New Phrase(" " + "OBSERVACIÓN", fontGruptitulo))
                grupo4Form9.Border = 0
                grupo4Form9.BorderWidthTop = 0.4F
                grupo4Form9.BorderColorTop = New BaseColor(244, 244, 244)
                grupo4Form9.BackgroundColor = New BaseColor(228, 228, 228)
                grupo4Form9.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo4Sec1.AddCell(grupo4Form9)
             
                If referencia.Rows.Count > 0 Then
                    For i As Integer = 0 To referencia.Rows.Count - 1
                        Dim grupo4Form8 As New PdfPCell(New Phrase(" ", fontSalto))
                        grupo4Form8.Border = 0
                        grupo4Form8.BorderWidthTop = 0.4F
                        grupo4Form8.BorderWidthBottom = 0.4F
                        grupo4Form8.BorderWidthLeft = 0.4F
                        grupo4Form8.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo4Form8.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo4Form8.BorderColorLeft = New BaseColor(244, 244, 244)
                        tablaGrupo4Sec1.AddCell(grupo4Form8)
                        Dim grupo4Form6 As New PdfPCell(New Phrase(referencia.Rows(i).Item("DOC_REFERENCIA").ToString(), fontDetalle))
                        grupo4Form6.Border = 0
                        grupo4Form6.BorderWidthTop = 0.4F
                        grupo4Form6.BorderWidthBottom = 0.4F
                        grupo4Form6.BorderWidthRight = 0.4F
                        grupo4Form6.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo4Form6.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo4Form6.BorderColorRight = New BaseColor(244, 244, 244)
                        grupo4Form6.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaGrupo4Sec1.AddCell(grupo4Form6)
                        Dim grupo4Form7 As New PdfPCell(New Phrase(referencia.Rows(i).Item("REFERENCIA").ToString(), fontDetalle))
                        grupo4Form7.Border = 0
                        grupo4Form7.BorderWidthTop = 0.4F
                        grupo4Form7.BorderWidthBottom = 0.4F
                        grupo4Form7.BorderWidthLeft = 0.4F
                        grupo4Form7.BorderWidthRight = 0.4F
                        grupo4Form7.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo4Form7.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo4Form7.BorderColorLeft = New BaseColor(244, 244, 244)
                        grupo4Form7.BorderColorRight = New BaseColor(244, 244, 244)
                        grupo4Form7.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaGrupo4Sec1.AddCell(grupo4Form7)
                        Dim grupo4Form10 As New PdfPCell(New Phrase(referencia.Rows(i).Item("OBSERVACION").ToString(), fontDetalle))
                        grupo4Form10.Border = 0
                        grupo4Form10.BorderWidthTop = 0.4F
                        grupo4Form10.BorderWidthBottom = 0.4F
                        grupo4Form10.BorderWidthLeft = 0.4F
                        grupo4Form10.BorderWidthRight = 0.4F
                        grupo4Form10.BorderColorTop = New BaseColor(244, 244, 244)
                        grupo4Form10.BorderColorBottom = New BaseColor(244, 244, 244)
                        grupo4Form10.BorderColorLeft = New BaseColor(244, 244, 244)
                        grupo4Form10.BorderColorRight = New BaseColor(244, 244, 244)
                        grupo4Form10.HorizontalAlignment = Element.ALIGN_LEFT
                        tablaGrupo4Sec1.AddCell(grupo4Form10)
                    Next
                End If

                Dim grupo4Form5 As New PdfPCell(New Phrase(" ", fontSalto))
                grupo4Form5.Colspan = 4
                grupo4Form5.Border = 0
                grupo4Form5.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo4Sec1.AddCell(grupo4Form5)
                tablaGrupo4Sec1.AddCell(grupo4Form5)
                tablaGrupo4Sec1.AddCell(grupo4Form5)
                documento.Add(tablaGrupo4Sec1)

                Dim tablaGrupo5Sec1 As New PdfPTable(2)
                tablaGrupo5Sec1.SetWidths(New Single() {3.0F, 97.0F})
                Dim grupo5Form1 As New PdfPCell(New Phrase(" " + "OBSERVACIÓN", fontGruptitulo))
                grupo5Form1.Colspan = 2
                grupo5Form1.Border = 0
                grupo5Form1.BackgroundColor = New BaseColor(228, 228, 228)
                grupo5Form1.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo5Sec1.AddCell(grupo5Form1)

                Dim grupo5Form2 As New PdfPCell(New Phrase(" ", fontSalto))
                grupo5Form2.Border = 0
                grupo5Form2.BorderWidthTop = 0.4F
                grupo5Form2.BorderWidthBottom = 0.4F
                grupo5Form2.BorderWidthLeft = 0.4F
                grupo5Form2.BorderColorTop = New BaseColor(244, 244, 244)
                grupo5Form2.BorderColorBottom = New BaseColor(244, 244, 244)
                grupo5Form2.BorderColorLeft = New BaseColor(244, 244, 244)
                grupo5Form2.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo5Sec1.AddCell(grupo5Form2)
                Dim grupo5Form3 As New PdfPCell(New Phrase(observacion.ToUpper, fontDetalle))
                grupo5Form3.Border = 0
                grupo5Form3.BorderWidthTop = 0.4F
                grupo5Form3.BorderWidthBottom = 0.4F
                grupo5Form3.BorderWidthRight = 0.4F
                grupo5Form3.BorderColorTop = New BaseColor(244, 244, 244)
                grupo5Form3.BorderColorBottom = New BaseColor(244, 244, 244)
                grupo5Form3.BorderColorRight = New BaseColor(244, 244, 244)
                grupo5Form3.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo5Sec1.AddCell(grupo5Form3)

                Dim grupo5Form4 As New PdfPCell(New Phrase(" ", fontSalto))
                grupo5Form4.Colspan = 2
                grupo5Form4.Border = 0
                grupo5Form4.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo5Sec1.AddCell(grupo5Form4)
                tablaGrupo5Sec1.AddCell(grupo5Form4)
                documento.Add(tablaGrupo5Sec1)

                documento.Add(Chunk.NEWLINE)
                documento.Add(Chunk.NEWLINE)

                Dim tablaGrupo6 As New PdfPTable(5)
                tablaGrupo6.SetWidths(New Single() {10.0F, 24.0F, 18.0F, 38.0F, 10.0F})
                Dim grupo6Form As New PdfPCell(New Phrase(" ", fontSalto))
                grupo6Form.Border = 0
                grupo6Form.HorizontalAlignment = Element.ALIGN_LEFT
                tablaGrupo6.AddCell(grupo6Form)
                Dim grupo6Form1 As New PdfPCell(New Phrase())
                grupo6Form1.Phrase.Add(New Chunk(String.Format(" CARSEG S.A. "), fontFirma))
                grupo6Form1.Border = 0
                grupo6Form1.BorderColorTop = New BaseColor(128, 128, 128)
                grupo6Form1.BorderWidthTop = 1
                grupo6Form1.PaddingBottom = 1
                grupo6Form1.HorizontalAlignment = Element.ALIGN_CENTER
                tablaGrupo6.AddCell(grupo6Form1)
                tablaGrupo6.AddCell(grupo6Form)
                Dim cli1 As String = cliente.Replace(identificacion, "")
                Dim grupo6Form2 As New PdfPCell(New Phrase("Sr.(ta.) " + cli1.Replace("- ", "").ToUpper, fontFirma))
                grupo6Form2.Border = 0
                grupo6Form2.BorderColorTop = New BaseColor(128, 128, 128)
                grupo6Form2.BorderWidthTop = 1
                grupo6Form2.PaddingBottom = 1
                grupo6Form2.HorizontalAlignment = Element.ALIGN_CENTER
                tablaGrupo6.AddCell(grupo6Form2)
                tablaGrupo6.AddCell(grupo6Form)

                tablaGrupo6.AddCell(grupo6Form)
                tablaGrupo6.AddCell(grupo6Form)
                tablaGrupo6.AddCell(grupo6Form)
                Dim grupo6Form3 As New PdfPCell(New Phrase(identificacion, fontFirma))
                grupo6Form3.Border = 0
                grupo6Form3.HorizontalAlignment = Element.ALIGN_CENTER
                tablaGrupo6.AddCell(grupo6Form3)
                tablaGrupo6.AddCell(grupo6Form)
                documento.Add(tablaGrupo6)

                documento.Add(Chunk.NEWLINE)
                '*documento.Add(Chunk.NEWLINE)
                '*documento.Add(Chunk.NEWLINE)

                'Dim parrafo As String = "Una vez efectuado el pago por la renovación del servicio "
                'Dim parrafo2 As String = "el cliente se obliga a ingresar su vehículo al los talleres autorizados de CARSEG S.A., para revisión del equipo instalado, "
                'Dim parrafo3 As String = "de conformidad con lo establecido en el contrato de servicios. El incumplimiento del cliente a este requisito indispensable, exonerará de responsabilidad a CARSEG S.A., " _
                '                       + "frente al cliente y/o terceros, por el funcionamiento defectuoso del equipo CARSEG S.A. no prestará el servicio hasta la total cancelación del valor de la " _
                '                       + "instalación/renovación del producto. "
                'Dim tablaGrupo7 As New PdfPTable(3)
                'tablaGrupo7.SetWidths(New Single() {2.0F, 96.0F, 2.0F})
                'Dim grupo7Form0 As New PdfPCell(New Phrase(" ", fontSalto))
                'grupo7Form0.Colspan = 3
                'grupo7Form0.Border = 0
                'grupo7Form0.BorderWidthTop = 0.5F
                'grupo7Form0.BorderWidthLeft = 0.5F
                'grupo7Form0.BorderWidthRight = 0.5F
                'grupo7Form0.BorderColorTop = New BaseColor(228, 228, 228)
                'grupo7Form0.BorderColorLeft = New BaseColor(228, 228, 228)
                'grupo7Form0.BorderColorRight = New BaseColor(228, 228, 228)
                'tablaGrupo7.AddCell(grupo7Form0)

                'Dim grupo7Form1 As New PdfPCell(New Phrase("", fontPie))
                'grupo7Form1.Border = 0
                'grupo7Form1.BorderWidthLeft = 0.5F
                'grupo7Form1.BorderColorLeft = New BaseColor(228, 228, 228)
                'tablaGrupo7.AddCell(grupo7Form1)
                'Dim phrase As Phrase = Nothing
                'phrase = New Phrase()
                'phrase.Add(New Chunk(parrafo, fontPie))
                'phrase.Add(New Chunk(parrafo2, fontPie2))
                'phrase.Add(New Chunk(parrafo3, fontPie))
                'Dim grupo7Form2 As New PdfPCell(phrase)
                'grupo7Form2.Border = 0
                'grupo7Form2.HorizontalAlignment = Element.ALIGN_JUSTIFIED
                'tablaGrupo7.AddCell(grupo7Form2)
                'Dim grupo7Form3 As New PdfPCell(New Phrase("", fontPie))
                'grupo7Form3.Border = 0
                'grupo7Form3.BorderWidthRight = 0.5F
                'grupo7Form3.BorderColorRight = New BaseColor(228, 228, 228)
                'tablaGrupo7.AddCell(grupo7Form3)

                'Dim grupo7Form4 As New PdfPCell(New Phrase(" ", fontSalto))
                'grupo7Form4.Colspan = 3
                'grupo7Form4.Border = 0
                'grupo7Form4.BorderWidthBottom = 0.5F
                'grupo7Form4.BorderWidthLeft = 0.5F
                'grupo7Form4.BorderWidthRight = 0.5F
                'grupo7Form4.BorderColorBottom = New BaseColor(228, 228, 228)
                'grupo7Form4.BorderColorLeft = New BaseColor(228, 228, 228)
                'grupo7Form4.BorderColorRight = New BaseColor(228, 228, 228)
                'tablaGrupo7.AddCell(grupo7Form4)

                'documento.Add(tablaGrupo7)

                Dim parrafo2 As String = "El presente documento electrónico emitido garantizará el crédito, una vez que CARSEG S.A. en los casos que competa verifique las referencias del Cliente en el Buró de Crédito. "
                Dim parrafo3 As String = "Una vez efectuada el pago por la renovación del servicio, "
                Dim parrafo31 As String = "el cliente se obliga a ingresar su vehículo al los talleres autorizados de CARSEG S.A. "
                Dim parrafo4 As String = "Este documento constituye un recibo de pago del anticipo realizado. "

                Dim tablaGrupo7 As New PdfPTable(6)
                tablaGrupo7.SetWidths(New Single() {2.0F, 32.0F, 2.0F, 32.0F, 2.0F, 32.0F})
                Dim grupo7Form0 As New PdfPCell(New Phrase(" ", fontSalto))
                grupo7Form0.Colspan = 6
                grupo7Form0.Border = 0
                grupo7Form0.BorderWidthTop = 0.5F
                grupo7Form0.BorderWidthLeft = 0.5F
                grupo7Form0.BorderWidthRight = 0.5F
                grupo7Form0.BorderColorTop = New BaseColor(228, 228, 228)
                grupo7Form0.BorderColorLeft = New BaseColor(228, 228, 228)
                grupo7Form0.BorderColorRight = New BaseColor(228, 228, 228)
                tablaGrupo7.AddCell(grupo7Form0)

                Dim grupo7Form1 As New PdfPCell(New Phrase("1", fontPie2))
                grupo7Form1.Border = 0
                grupo7Form1.BorderWidthLeft = 0.5F
                grupo7Form1.BorderColorLeft = New BaseColor(228, 228, 228)
                tablaGrupo7.AddCell(grupo7Form1)
                Dim phrase2 As Phrase = Nothing
                phrase2 = New Phrase()
                phrase2.Add(New Chunk(parrafo2, fontPie))
                Dim grupo7Form2 As New PdfPCell(phrase2)
                grupo7Form2.Border = 0
                grupo7Form2.HorizontalAlignment = Element.ALIGN_JUSTIFIED
                tablaGrupo7.AddCell(grupo7Form2)

                Dim grupo7Form3 As New PdfPCell(New Phrase("2", fontPie2))
                grupo7Form3.Border = 0
                grupo7Form3.BorderWidthLeft = 0.5F
                grupo7Form3.BorderColorLeft = New BaseColor(228, 228, 228)
                tablaGrupo7.AddCell(grupo7Form3)
                Dim phrase3 As Phrase = Nothing
                phrase3 = New Phrase()
                phrase3.Add(New Chunk(parrafo3, fontPie))
                phrase3.Add(New Chunk(parrafo31, fontPie2))
                Dim grupo7Form4 As New PdfPCell(phrase3)
                grupo7Form4.Border = 0
                grupo7Form4.HorizontalAlignment = Element.ALIGN_JUSTIFIED
                tablaGrupo7.AddCell(grupo7Form4)


                Dim grupo7Form5 As New PdfPCell(New Phrase("3", fontPie2))
                grupo7Form5.Border = 0
                grupo7Form5.BorderWidthLeft = 0.5F
                grupo7Form5.BorderColorLeft = New BaseColor(228, 228, 228)
                tablaGrupo7.AddCell(grupo7Form5)

                Dim phrase4 As Phrase = Nothing
                phrase4 = New Phrase()
                phrase4.Add(New Chunk(parrafo4, fontPie))
                Dim grupo7Form6 As New PdfPCell(phrase4)
                grupo7Form6.Border = 0
                grupo7Form6.BorderWidthRight = 0.5F
                grupo7Form6.BorderColorRight = New BaseColor(228, 228, 228)
                grupo7Form6.HorizontalAlignment = Element.ALIGN_JUSTIFIED
                tablaGrupo7.AddCell(grupo7Form6)
               
                Dim grupo7Form7 As New PdfPCell(New Phrase(" ", fontSalto))
                grupo7Form7.Colspan = 6
                grupo7Form7.Border = 0
                grupo7Form7.BorderWidthBottom = 0.5F
                grupo7Form7.BorderWidthLeft = 0.5F
                grupo7Form7.BorderWidthRight = 0.5F
                grupo7Form7.BorderColorBottom = New BaseColor(228, 228, 228)
                grupo7Form7.BorderColorLeft = New BaseColor(228, 228, 228)
                grupo7Form7.BorderColorRight = New BaseColor(228, 228, 228)
                tablaGrupo7.AddCell(grupo7Form7)

                documento.Add(tablaGrupo7)

            End If
            documento.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'se procedio a generar otro pdf por diseño
    Public Sub GenerarDocumento2(ByVal nombre As String, ByVal ruta As String, ByVal detalle As dsHunterCobro.ANTICIPO_DETALLEDataTable, ByVal anticipo As String, _
                                ByVal identificacion As String, ByVal email As String, ByVal nombrerecibimos As String, ByVal referencia As String, _
                                ByVal total As String, ByVal observacion As String, ByVal cliente As String, ByVal nombreusuario As String, ByVal fecha As String)
        Try
            ' Dim fontcabecera As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 10, Font.BOLD, New BaseColor(128, 128, 128))
            Dim fonttitulo As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 17, iTextSharp.text.Font.BOLD, New BaseColor(51, 51, 51))
            Dim fontSubtitulo As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD, New BaseColor(51, 51, 51))
            Dim fontDetalle As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 9, iTextSharp.text.Font.NORMAL, New BaseColor(128, 128, 128))
            Dim fontSalto As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 5, iTextSharp.text.Font.NORMAL, New BaseColor(51, 51, 51))
            Dim fontFirma As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 11, iTextSharp.text.Font.BOLD, New BaseColor(51, 51, 51))
            'Dim fontCuadro As iTextSharp.text.Font = FontFactory.GetFont("Calibri", 2, iTextSharp.text.Font.NORMAL, New BaseColor(51, 51, 51))
            Dim documento As New Document(PageSize.A4, -40.0F, -40.0F, 100.0F, 30.0F)
            Dim file As String = String.Format("{0}Cobros_{1}", ruta, nombre)
            Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(file, FileMode.Create))
            Dim paragraph As New iTextSharp.text.Paragraph(" ")
            Dim ev As New CreacionPdf()
            documento.Open()
            documento.NewPage()
            writer.PageEvent = ev
            documento.Add(paragraph)
            Dim tablaFactura As New PdfPTable(1)
            tablaFactura.SetWidths(New Single() {100.0F})
            'TITULO DEL DOCUMENTO
            Dim tituloFac0 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            tituloFac0.Border = 0
            tituloFac0.HorizontalAlignment = Element.ALIGN_CENTER
            tablaFactura.AddCell(tituloFac0)
            Dim tituloFac1 As New PdfPCell(New Phrase())
            tituloFac1.Phrase.Add(New Chunk("ANTICIPO DE PAGO", fonttitulo))
            tituloFac1.Border = 0
            tituloFac1.BackgroundColor = New BaseColor(217, 217, 217)
            tituloFac1.BorderColor = New BaseColor(217, 217, 217)
            tituloFac1.HorizontalAlignment = Element.ALIGN_CENTER
            tablaFactura.AddCell(tituloFac1)
            Dim tituloFac2 As New PdfPCell(New Phrase(" ", fontSalto))
            tituloFac2.Border = 0
            tituloFac2.BackgroundColor = New BaseColor(217, 217, 217)
            tituloFac2.BorderColor = New BaseColor(217, 217, 217)
            tituloFac2.HorizontalAlignment = Element.ALIGN_CENTER
            tablaFactura.AddCell(tituloFac2)
            tablaFactura.AddCell(tituloFac0)
            tablaFactura.AddCell(tituloFac0)
            tablaFactura.AddCell(tituloFac0)
            documento.Add(tablaFactura)
            'documento.Add(Chunk.NEWLINE)
            Dim tablaFacturacabecera As New PdfPTable(4)
            tablaFacturacabecera.SetWidths(New Single() {10.0F, 28.0F, 53.0F, 9.0F})
            'salto superior
            Dim detallesalto1 As New PdfPCell(New Phrase(" ", fontSalto))
            detallesalto1.Colspan = 4
            detallesalto1.Border = 0
            'detallesalto1.CellEvent = New RoundedBorder()
            detallesalto1.BorderWidthTop = 0.5F
            detallesalto1.BorderWidthLeft = 0.5F
            detallesalto1.BorderWidthRight = 0.5F
            detallesalto1.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detallesalto1)

            'grupo 1
            Dim detalleform1 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform1.Border = 0
            detalleform1.BorderWidthLeft = 0.5F
            detalleform1.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform1)
            'tablaFacturacabecera.AddCell(detalleform1)
            Dim detalleform2 As New PdfPCell(New Phrase("CODIGO: ", fontSubtitulo))
            detalleform2.Border = 0
            detalleform2.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform2)
            Dim detalleform3 As New PdfPCell(New Phrase(anticipo, fontDetalle))
            detalleform3.Border = 0
            detalleform3.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform3)
            Dim detalleform4 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform4.Border = 0
            detalleform4.BorderWidthRight = 0.5F
            detalleform4.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform4)
            'tablaFacturacabecera.AddCell(detalleform4)

            Dim detalleform5 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform5.Border = 0
            detalleform5.BorderWidthLeft = 0.5F
            detalleform5.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform5)
            'tablaFacturacabecera.AddCell(detalleform5)
            Dim detalleform6 As New PdfPCell(New Phrase("FECHA DE EMISIÓN: ", fontSubtitulo))
            detalleform6.Border = 0
            detalleform6.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform6)
            Dim detalleform7 As New PdfPCell(New Phrase(fecha.ToUpper, fontDetalle))
            detalleform7.Border = 0
            detalleform7.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform7)
            Dim detalleform8 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform8.Border = 0
            detalleform8.BorderWidthRight = 0.5F
            detalleform8.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform8)
            'tablaFacturacabecera.AddCell(detalleform8)

            Dim detalleform9 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform9.Border = 0
            detalleform9.BorderWidthLeft = 0.5F
            detalleform9.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform9)
            'tablaFacturacabecera.AddCell(detalleform9)
            Dim detalleform10 As New PdfPCell(New Phrase("CLIENTE: ", fontSubtitulo))
            detalleform10.Border = 0
            detalleform10.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform10)
            Dim detalleform11 As New PdfPCell(New Phrase(cliente.ToUpper, fontDetalle))
            detalleform11.Border = 0
            detalleform11.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform11)
            Dim detalleform12 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform12.Border = 0
            detalleform12.BorderWidthRight = 0.5F
            detalleform12.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform12)
            'tablaFacturacabecera.AddCell(detalleform12)

            Dim detalleform13 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform13.Border = 0
            detalleform13.BorderWidthLeft = 0.5F
            detalleform13.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform13)
            'tablaFacturacabecera.AddCell(detalleform13)
            Dim detalleform14 As New PdfPCell(New Phrase("EJECUTIVA/O COMERCIAL: ", fontSubtitulo))
            detalleform14.Border = 0
            detalleform14.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform14)
            Dim detalleform15 As New PdfPCell(New Phrase(nombreusuario.ToUpper, fontDetalle))
            detalleform15.Border = 0
            detalleform15.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform15)
            Dim detalleform16 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform16.Border = 0
            detalleform16.BorderWidthRight = 0.5F
            detalleform16.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform16)
            'tablaFacturacabecera.AddCell(detalleform16)

            'salto inferior
            Dim detallesalto6 As New PdfPCell(New Phrase(" ", fontSalto))
            detallesalto6.Colspan = 4
            detallesalto6.Border = 0
            detallesalto6.BorderWidthLeft = 0.5F
            detallesalto6.BorderWidthBottom = 0.5F
            detallesalto6.BorderWidthRight = 0.5F
            detallesalto6.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detallesalto6)

            'salto de linea
            Dim detallesalto9 As New PdfPCell(New Phrase(" ", fontSalto))
            detallesalto9.Border = 0
            detallesalto9.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detallesalto9)
            Dim detallesalto10 As New PdfPCell(New Phrase(" ", fontSalto))
            detallesalto10.Colspan = 3
            detallesalto10.Border = 0
            detallesalto10.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detallesalto10)

            tablaFacturacabecera.AddCell(detallesalto9)
            tablaFacturacabecera.AddCell(detallesalto10)

            'grupo 2
            tablaFacturacabecera.AddCell(detallesalto1)

            Dim detalleform17 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform17.Border = 0
            detalleform17.BorderWidthLeft = 0.5F
            detalleform17.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform17)
            'tablaFacturacabecera.AddCell(detalleform17)
            Dim detalleform18 As New PdfPCell(New Phrase("MONTO RECIBIDO: ", fontSubtitulo))
            detalleform18.Border = 0
            detalleform18.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform18)
            Dim detalleform19 As New PdfPCell(New Phrase("$ " + Convert.ToString(total), fontDetalle))
            detalleform19.Border = 0
            detalleform19.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform19)
            Dim detalleform20 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform20.Border = 0
            detalleform20.BorderWidthRight = 0.5F
            detalleform20.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform20)
            'tablaFacturacabecera.AddCell(detalleform20)

            Dim detalleform21 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform21.Border = 0
            detalleform21.BorderWidthLeft = 0.5F
            detalleform21.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform21)
            'tablaFacturacabecera.AddCell(detalleform21)
            Dim detalleform22 As New PdfPCell(New Phrase("CANTIDAD LETRAS ", fontSubtitulo))
            detalleform22.Border = 0
            detalleform22.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform22)
            Dim detalleform23 As New PdfPCell(New Phrase((Numalet.ToCardinal(total).ToUpper), fontDetalle))
            detalleform23.Border = 0
            detalleform23.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform23)
            Dim detalleform24 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            detalleform24.Border = 0
            detalleform24.BorderWidthRight = 0.5F
            detalleform24.HorizontalAlignment = Element.ALIGN_LEFT
            tablaFacturacabecera.AddCell(detalleform24)
            'tablaFacturacabecera.AddCell(detalleform24)

            tablaFacturacabecera.AddCell(detallesalto6)

            'salto de linea
            tablaFacturacabecera.AddCell(detallesalto9)
            tablaFacturacabecera.AddCell(detallesalto10)

            tablaFacturacabecera.AddCell(detallesalto9)
            tablaFacturacabecera.AddCell(detallesalto10)

            documento.Add(tablaFacturacabecera)

            'grupo3
            Dim tablagrupo3 As New PdfPTable(3)
            tablagrupo3.SetWidths(New Single() {10.0F, 81.0F, 9.0F})
            'salto superior
            Dim grupo3Salto1 As New PdfPCell(New Phrase(" ", fontSalto))
            grupo3Salto1.Colspan = 3
            grupo3Salto1.Border = 0
            grupo3Salto1.BorderWidthTop = 0.5F
            grupo3Salto1.BorderWidthLeft = 0.5F
            grupo3Salto1.BorderWidthRight = 0.5F
            grupo3Salto1.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo3.AddCell(grupo3Salto1)

            Dim grupo3Salto10 As New PdfPCell(New Phrase(" ", fontSalto))
            grupo3Salto10.Colspan = 3
            grupo3Salto10.Border = 0
            grupo3Salto10.BorderWidthLeft = 0.5F
            grupo3Salto10.BorderWidthRight = 0.5F
            tablagrupo3.AddCell(grupo3Salto10)

            Dim grupo3Form1 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            grupo3Form1.Border = 0
            grupo3Form1.BorderWidthLeft = 0.5F
            grupo3Form1.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo3.AddCell(grupo3Form1)
            Dim grupo3Form2 As New PdfPCell(New Phrase("  DETALLE DE VALORES RECIBIDOS ", fontSubtitulo))
            grupo3Form2.Border = 0
            grupo3Form2.BackgroundColor = New BaseColor(217, 217, 217)
            grupo3Form2.BorderColor = New BaseColor(217, 217, 217)
            grupo3Form2.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo3.AddCell(grupo3Form2)
            Dim grupo3Form3 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            grupo3Form3.Border = 0
            grupo3Form3.BorderWidthRight = 0.5F
            grupo3Form3.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo3.AddCell(grupo3Form3)

            Dim grupo3Salto4 As New PdfPCell(New Phrase(" ", fontSalto))
            grupo3Salto4.Border = 0
            grupo3Salto4.Colspan = 3
            grupo3Salto4.BorderWidthLeft = 0.5F
            grupo3Salto4.BorderWidthRight = 0.5F
            grupo3Salto4.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo3.AddCell(grupo3Salto4)

            tablagrupo3.AddCell(grupo3Salto4)

            documento.Add(tablagrupo3)
            Dim tablaGrupo3Sec1 As New PdfPTable(7)
            tablaGrupo3Sec1.SetWidths(New Single() {10.0F, 26.0F, 27.0F, 18.0F, 2.0F, 8.0F, 9.0F})
            Dim grupo3Form4 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            grupo3Form4.Border = 0
            grupo3Form4.BorderWidthLeft = 0.5F
            grupo3Form4.HorizontalAlignment = Element.ALIGN_LEFT
            tablaGrupo3Sec1.AddCell(grupo3Form4)
            Dim grupo3Form5 As New PdfPCell(New Phrase("TIPO DE DOCUMENTO", fontSubtitulo))
            grupo3Form5.Border = 0
            grupo3Form5.HorizontalAlignment = Element.ALIGN_LEFT
            tablaGrupo3Sec1.AddCell(grupo3Form5)
            Dim grupo3Form6 As New PdfPCell(New Phrase("BANCO", fontSubtitulo))
            grupo3Form6.Border = 0
            grupo3Form6.HorizontalAlignment = Element.ALIGN_LEFT
            tablaGrupo3Sec1.AddCell(grupo3Form6)
            Dim grupo3Form7 As New PdfPCell(New Phrase("No.DOCUMENTO", fontSubtitulo))
            grupo3Form7.Border = 0
            grupo3Form7.HorizontalAlignment = Element.ALIGN_LEFT
            tablaGrupo3Sec1.AddCell(grupo3Form7)
            Dim grupo3Form8 As New PdfPCell(New Phrase("", fontSubtitulo))
            grupo3Form8.Border = 0
            grupo3Form8.HorizontalAlignment = Element.ALIGN_LEFT
            tablaGrupo3Sec1.AddCell(grupo3Form8)
            Dim grupo3Form9 As New PdfPCell(New Phrase("VALOR", fontSubtitulo))
            grupo3Form9.Border = 0
            grupo3Form9.HorizontalAlignment = Element.ALIGN_LEFT
            tablaGrupo3Sec1.AddCell(grupo3Form9)
            Dim grupo3Form10 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            grupo3Form10.Border = 0
            grupo3Form10.BorderWidthRight = 0.5F
            grupo3Form10.HorizontalAlignment = Element.ALIGN_LEFT
            tablaGrupo3Sec1.AddCell(grupo3Form10)
            If detalle.Rows.Count > 0 Then
                For i As Integer = 0 To detalle.Rows.Count - 1
                    tablaGrupo3Sec1.AddCell(grupo3Form4)
                    Dim grupo3Form11 As New PdfPCell(New Phrase(detalle.Rows(i).Item("FORMA_PAGO").ToString(), fontDetalle))
                    grupo3Form11.Border = 0
                    grupo3Form11.HorizontalAlignment = Element.ALIGN_LEFT
                    tablaGrupo3Sec1.AddCell(grupo3Form11)
                    Dim grupo3Form12 As New PdfPCell(New Phrase(detalle.Rows(i).Item("BANCO").ToString(), fontDetalle))
                    grupo3Form12.Border = 0
                    grupo3Form12.HorizontalAlignment = Element.ALIGN_LEFT
                    tablaGrupo3Sec1.AddCell(grupo3Form12)
                    Dim grupo3Form13 As New PdfPCell(New Phrase(detalle.Rows(i).Item("DOCUMENTO").ToString(), fontDetalle))
                    grupo3Form13.Border = 0
                    grupo3Form13.HorizontalAlignment = Element.ALIGN_LEFT
                    tablaGrupo3Sec1.AddCell(grupo3Form13)
                    Dim grupo3Form14 As New PdfPCell(New Phrase("$ ", fontDetalle))
                    grupo3Form14.Border = 0
                    grupo3Form14.HorizontalAlignment = Element.ALIGN_RIGHT
                    tablaGrupo3Sec1.AddCell(grupo3Form14)
                    Dim grupo3Form15 As New PdfPCell(New Phrase(FormatNumber(detalle.Rows(i).Item("VALOR").ToString(), 2) & Space(4), fontDetalle))
                    grupo3Form15.Border = 0
                    grupo3Form15.HorizontalAlignment = Element.ALIGN_RIGHT
                    tablaGrupo3Sec1.AddCell(grupo3Form15)
                    tablaGrupo3Sec1.AddCell(grupo3Form10)
                Next
            End If
            documento.Add(tablaGrupo3Sec1)
            Dim tablaGrupo3Sec2 As New PdfPTable(3)
            tablaGrupo3Sec2.SetWidths(New Single() {10.0F, 80.0F, 10.0F})
            tablaGrupo3Sec2.AddCell(grupo3Salto4)
            tablaGrupo3Sec2.AddCell(grupo3Salto4)

            Dim grupo3Salto7 As New PdfPCell(New Phrase(" ", fontSalto))
            grupo3Salto7.Colspan = 3
            grupo3Salto7.Border = 0
            grupo3Salto7.BorderWidthBottom = 0.5F
            grupo3Salto7.BorderWidthLeft = 0.5F
            grupo3Salto7.BorderWidthRight = 0.5F
            grupo3Salto7.HorizontalAlignment = Element.ALIGN_LEFT
            tablaGrupo3Sec2.AddCell(grupo3Salto7)
            documento.Add(tablaGrupo3Sec2)

            'grupo4
            Dim tablagrupo4 As New PdfPTable(3)
            tablagrupo4.SetWidths(New Single() {10.0F, 81.0F, 9.0F})
            tablagrupo4.AddCell(detallesalto10)
            tablagrupo4.AddCell(detallesalto10)

            'salto superior
            tablagrupo4.AddCell(grupo3Salto1)
            tablagrupo4.AddCell(grupo3Salto10)

            Dim grupo4Form1 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            grupo4Form1.Border = 0
            grupo4Form1.BorderWidthLeft = 0.5F
            grupo4Form1.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo4.AddCell(grupo4Form1)
            Dim grupo4Form2 As New PdfPCell(New Phrase("  OBSERVACIÓN ", fontSubtitulo))
            grupo4Form2.Border = 0
            grupo4Form2.BackgroundColor = New BaseColor(217, 217, 217)
            grupo4Form2.BorderColor = New BaseColor(217, 217, 217)
            grupo4Form2.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo4.AddCell(grupo4Form2)
            Dim grupo4Form3 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            grupo4Form3.Border = 0
            grupo4Form3.BorderWidthRight = 0.5F
            grupo4Form3.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo4.AddCell(grupo4Form3)

            Dim grupo4Form4 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            grupo4Form4.Border = 0
            grupo4Form4.BorderWidthLeft = 0.5F
            grupo4Form4.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo4.AddCell(grupo4Form4)
            Dim grupo4Form5 As New PdfPCell(New Phrase(observacion.ToUpper, fontDetalle))
            grupo4Form5.Border = 0
            grupo4Form5.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo4.AddCell(grupo4Form5)
            Dim grupo4Form6 As New PdfPCell(New Phrase(" ", fontSubtitulo))
            grupo4Form6.Border = 0
            grupo4Form6.BorderWidthRight = 0.5F
            grupo4Form6.HorizontalAlignment = Element.ALIGN_LEFT
            tablagrupo4.AddCell(grupo4Form6)

            tablagrupo4.AddCell(grupo3Salto10)
            tablagrupo4.AddCell(grupo3Salto7)

            documento.Add(tablagrupo4)

            'grupo5
            documento.Add(Chunk.NEWLINE)
            documento.Add(Chunk.NEWLINE)
            documento.Add(Chunk.NEWLINE)
            documento.Add(Chunk.NEWLINE)
            Dim tablaGrupo5 As New PdfPTable(5)
            tablaGrupo5.SetWidths(New Single() {10.0F, 30.0F, 20.0F, 30.0F, 10.0F})
            tablaGrupo5.AddCell(detallesalto9)
            Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/imagen/logoextranet.png"))
            logo.ScaleAbsolute(160.0F, 40.0F)
            Dim cell As New PdfPCell(logo)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.Border = 0
            tablaGrupo5.AddCell(cell)
            tablaGrupo5.AddCell(detallesalto9)
            tablaGrupo5.AddCell(detallesalto9)
            tablaGrupo5.AddCell(detallesalto9)

            tablaGrupo5.AddCell(detallesalto9)
            Dim grupo5Form1 As New PdfPCell(New Phrase())
            grupo5Form1.Phrase.Add(New Chunk(String.Format(" CARSEG S.A. "), fontFirma))
            grupo5Form1.Border = 0
            grupo5Form1.BorderColorTop = New BaseColor(128, 128, 128)
            grupo5Form1.BorderWidthTop = 1
            grupo5Form1.PaddingBottom = 1
            grupo5Form1.HorizontalAlignment = Element.ALIGN_CENTER
            tablaGrupo5.AddCell(grupo5Form1)
            tablaGrupo5.AddCell(detallesalto9)
            Dim cli1 As String = cliente.Replace(identificacion, "")
            Dim grupo5Form2 As New PdfPCell(New Phrase(cli1.Replace("- ", "").ToUpper, fontFirma))
            grupo5Form2.Border = 0
            grupo5Form2.BorderColorTop = New BaseColor(128, 128, 128)
            grupo5Form2.BorderWidthTop = 1
            grupo5Form2.PaddingBottom = 1
            grupo5Form2.HorizontalAlignment = Element.ALIGN_CENTER
            tablaGrupo5.AddCell(grupo5Form2)
            tablaGrupo5.AddCell(detallesalto9)

            documento.Add(tablaGrupo5)
            documento.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Class RoundedBorder
    '    Implements IPdfPCellEvent
    '    Public Sub CellLayout(cell As PdfPCell, rect As Rectangle, canvas As PdfContentByte())
    '        Dim cb As PdfContentByte = canvas(PdfPTable.BACKGROUNDCANVAS)
    '        cb.RoundRectangle(rect.Left + 1.5F, rect.Bottom + 1.5F, rect.Width - 3, rect.Height - 3, 4)
    '        cb.Stroke()
    '    End Sub
    'End Class

End Class
