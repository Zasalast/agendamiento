using iText.IO.Font.Constants;

using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.controles
{
    public class Pdf
    {

        public class HeaderEventHandler : IEventHandler
        {
            control contrll = new control();
            string nombre = "";
            iText.Layout.Element.Image img;
            public HeaderEventHandler(iText.Layout.Element.Image imgc)
            {
                img = imgc;
            }

            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdf = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                Rectangle rootarea = new Rectangle(20, page.GetPageSize().GetTop() - 75, page.GetPageSize().GetRight() - 40, 65);
                Canvas canvas = new Canvas(page, rootarea);
                canvas.Add(getTable(docEvent));
                canvas.ShowTextAligned("Reporte Realizado por: " + app.Session.primer_nombre + " " + app.Session.primer_apellido, 140, 0, TextAlignment.CENTER);
                canvas.ShowTextAligned("Fecha de reporte: " + DateTime.Now.ToShortDateString(), 100, 15, TextAlignment.CENTER);
                canvas.ShowTextAligned("", 580, 0, TextAlignment.RIGHT);

                canvas.Close();

            }
            public iText.Layout.Element.Table getTable(PdfDocumentEvent docevent)
            {
                string nombre = "";
                float[] cellwidth = { 10f, 80f };
                iText.Layout.Element.Table tablevent = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(cellwidth)).UseAllAvailableWidth();
                iText.Layout.Style stylecell = new iText.Layout.Style();
                stylecell.SetBorder(Border.NO_BORDER);
                iText.Layout.Style styletext = new iText.Layout.Style();
                styletext.SetTextAlignment(TextAlignment.RIGHT).SetFontSize(10f);

                Cell cell = new Cell().Add(img.SetAutoScale(true));
                tablevent.AddCell(cell.AddStyle(stylecell).SetTextAlignment(TextAlignment.LEFT));
                PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
                cell = new Cell();
                cell.Add(new Paragraph("SISTEMA DE AGENDAMIENTO \n").SetFont(bold));
                nombre = contrll.controltraertiempo("select nombre_software from software where idsoftware=1;", nombre);
                cell.Add(new Paragraph(nombre));
                //  cell.Add(new Paragraph("Fecha de reporte: " + DateTime.Now.ToShortDateString()).SetFont(bold));
                cell.AddStyle(styletext);
                cell.AddStyle(stylecell);



                tablevent.AddCell(cell);
                return tablevent;
            }
        }

        public void crearpdf(GridView gridview1, string[] header, String titulo)
        {

            PdfWriter pdfwriter = new PdfWriter("C:/Users/Mauri/OneDrive/Documentos/german/Reporte.pdf");
            PdfDocument pdf = new PdfDocument(pdfwriter);
            Document documento = new Document(pdf, PageSize.LETTER);
            documento.SetMargins(80, 20, 55, 20);
            PdfFont fontcolumas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont fontheader = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            String logo = HttpContext.Current.Server.MapPath(@"//app//img//LogoOficial.png");
            iText.Layout.Element.Image imag = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(logo));
            pdf.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler(imag));

            iText.Layout.Element.Table tabla = new iText.Layout.Element.Table(gridview1.HeaderRow.Cells.Count).UseAllAvailableWidth();
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            tabla.AddHeaderCell(new Cell(1, gridview1.HeaderRow.Cells.Count).Add(new Paragraph(titulo)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.CENTER).SetFont(fontheader));
            foreach (string Header in header)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(Header).SetTextAlignment(TextAlignment.CENTER).SetFont(fontheader)));
            }
            for (int i = 0; i < gridview1.Rows.Count; i++)
            {

                for (int j = 0; j < gridview1.HeaderRow.Cells.Count; j++)
                {
                    tabla.AddCell(new Cell(1, 1).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[i].Cells[j].Text)).SetTextAlignment(TextAlignment.CENTER).SetFont(fontcolumas)));
                }
            }
            //int contfila1 = 0, contfila2 = 0,contfila3=0,contfila4=0,contfila5=0;
            //bool bandfil2 = false, bandfil3 = false, bandfil4 = false, bandfil5 = false ;
            //for (int i = 0; i < gridview1.Rows.Count; i++)
            //{
            //    for (int j = 0; j < gridview1.HeaderRow.Cells.Count; j++)
            //    {
            //        if (i > 0)
            //        {
            //            if (gridview1.Rows[i].Cells[j].Text == gridview1.Rows[i - 1].Cells[j].Text)
            //            {
            //                contfila1 = contfila1 + 1;
            //            }


            //                    if (gridview1.Rows[i].Cells[0].Text == gridview1.Rows[i - 1].Cells[0].Text && i>contfila1 )
            //                    {
            //                        contfila2 = contfila2 + 1;
            //                        bandfil2 = true;
            //                    }

            //if (gridview1.Rows[i].Cells[0].Text == gridview1.Rows[i - 1].Cells[0].Text && i > contfila2 && bandfil2==true)
            //{
            //    contfila3 = contfila3 + 1;
            //    bandfil3 = true;
            //}
            //if (gridview1.Rows[i].Cells[0].Text == gridview1.Rows[i - 1].Cells[0].Text && i > contfila3)
            //{
            //    contfila4 = contfila4 + 1;
            //    bandfil4 = true;
            //}
            //if (gridview1.Rows[i].Cells[0].Text == gridview1.Rows[i - 1].Cells[0].Text && i > contfila4)
            //{
            //    contfila5 = contfila5 + 1;
            //    bandfil5 = true;
            //}


            //        }

            //    }

            //}
            //tabla.AddHeaderCell(new Cell().Add(new Paragraph(header2)));
            //    for (int i = 1; i < gridview1.Rows.Count; i++)
            //{
            //int cont = 0;
            //int comp = 0;
            //tabla.AddCell(new Cell(contfila1, 1).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[1].Cells[0].Text)).SetTextAlignment(TextAlignment.CENTER).SetFont(fontcolumas)));
            //for (int i = 0; i < contfila1; i++)
            //{

            //        tabla.AddCell(new Cell(1, 1).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[i].Cells[1].Text)).SetTextAlignment(TextAlignment.CENTER).SetFont(fontcolumas)));

            //}
            //if (bandfil2 == true)
            //{


            //    tabla.AddCell(new Cell(contfila2, 1).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[contfila1].Cells[0].Text)).SetTextAlignment(TextAlignment.CENTER).SetFont(fontcolumas)));

            //for (int i =contfila1; i < contfila1+contfila2; i++)
            //{

            //            tabla.AddCell(new Cell(1, 1).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[i].Cells[1].Text)).SetTextAlignment(TextAlignment.CENTER).SetFont(fontcolumas)));

            //}
            //HttpContext.Current.Response.Write(Convert.ToString(contfila2));
            //}
            //if (bandfil3 == true)
            //{


            //    tabla.AddCell(new Cell(contfila3, 1).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[contfila2].Cells[0].Text)).SetTextAlignment(TextAlignment.CENTER).SetFont(fontcolumas)));

            //    for (int i = contfila2; i < contfila2 + contfila3; i++)
            //    {

            //            tabla.AddCell(new Cell(1, 1).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[i].Cells[1].Text)).SetTextAlignment(TextAlignment.CENTER).SetFont(fontcolumas)));

            //    }
            //    //HttpContext.Current.Response.Write(Convert.ToString(contfila2));
            //}
            //for (int j = 0; j < contfila1; j++)
            //{
            //    tabla.AddCell(new Cell(1, 1).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[i].Cells[1].Text)).SetHorizontalAlignment(HorizontalAlignment.CENTER).SetFont(fontcolumas)));

            //    //if (i > 0 && j > 0)
            //    //{
            //    //    if (gridview1.Rows[i].Cells[j].Text == gridview1.Rows[i - 1].Cells[j].Text)
            //    //    {
            //    //        cont = cont + 1;
            //    //        tabla.AddCell(new Cell(i, j + 1).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[i].Cells[j + 1].Text)).SetHorizontalAlignment(HorizontalAlignment.CENTER).SetFont(fontcolumas)));
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    tabla.AddCell(new Cell(i, j).Add(new Paragraph(HttpUtility.HtmlDecode(gridview1.Rows[i].Cells[j].Text)).SetHorizontalAlignment(HorizontalAlignment.CENTER).SetFont(fontcolumas)));
            //    //}




            //}

            //tabla.AddCell(new Cell(3, 1).Add(new Paragraph("pedro")));
            //tabla.AddCell(new Cell(1, 1).Add(new Paragraph("maria")));
            //tabla.AddCell(new Cell(1, 1).Add(new Paragraph("jose")));

            //}
            //string sql = "select primer_nombre, primer_apellido from usuario;";
            //MySqlConnection conexion = Conexion.getConexion();
            //conexion.Open();
            //MySqlCommand comando = new MySqlCommand(sql,conexion);
            //MySqlDataReader reader = comando.ExecuteReader();
            //while (reader.Read()) {
            //    tabla.AddCell(new Cell().Add(new Paragraph(reader["primer_nombre"].ToString())));
            //    tabla.AddCell(new Cell().Add(new Paragraph(reader["primer_apellido"].ToString())));
            //}
            documento.Add(tabla);
            documento.Close();
        }




    }
}