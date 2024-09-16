using iText.Barcodes;
using iText.Barcodes.Qrcode;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BC.Service
{
    public class Barcode : IBarcodeServices
    {
        public async Task<byte[]> GenerateBarcodeAsync(string CodeContent = "", BarcodeType type = BarcodeType.Code128)
        {
            await using var memoryStream = new MemoryStream();
            float x = 4f;
            float y = 2f;

            Rectangle one = new Rectangle(x.ToDpi(), y.ToDpi());

            PdfWriter writer = new PdfWriter(memoryStream);
            PdfDocument document = new PdfDocument(writer);
            document.SetDefaultPageSize(new PageSize(one));
            Document doc = new Document(document, new PageSize(one));
            doc.SetMargins(1, 1, 1, 1);




            //PdfPage page = document.AddNewPage();

            // PdfCanvas canvas = new PdfCanvas(page);
            float[] a = { 2,1 };
            Table table = new Table(UnitValue.CreatePercentArray(a)).UseAllAvailableWidth();
            Cell cell = new Cell();

            switch (type) {
                case BarcodeType.Code128:
                    //  Barcode128 barcode = new Barcode128(document);
                    // barcode.SetCodeType(Barcode128.CODE128);
                    // barcode.SetCode(CodeContent);
                    // barcode.PlaceBarcode(canvas, ColorConstants.BLACK, ColorConstants.BLACK);


                    Barcode128 code128 = new Barcode128(document);
                   
                    code128.SetSize(10);
                    code128.SetCode(CodeContent);
                    code128.SetCodeType(Barcode128.CODE128);
                    Image code128Image = new Image(code128.CreateFormXObject(document));


                    //doc.Add(code128Image.SetAutoScale(true));


                    // Notice that in iText5 in default PdfPCell constructor (new PdfPCell(Image img))
                    // this image does not fit the cell, but it does in addCell().
                    // In iText7 there is no*( constructor (new Cell(Image img)),
                    // so the image adding to the cell can be done only using method add().
                    cell.Add(code128Image.SetAutoScale(true));
                    // table.AddCell(cell);
                     doc.Add(table);
                    break;
                case BarcodeType.Datametrix:
                  
                    BarcodeDataMatrix barcodeDM = new BarcodeDataMatrix();
                    barcodeDM.SetCode(CodeContent);
                    
                    Image DMImage = new Image(barcodeDM.CreateFormXObject(document));

                    
                    cell.Add(DMImage.ScaleAbsolute(20, 20));
                    cell.Add(new Paragraph(CodeContent).SetFontSize(5));
                    //table.AddCell(cell1);
                    // barcode3.PlaceBarcode(canvas, ColorConstants.BLACK);
                    
                   // doc.Add(table);
                   

                    break;
                case BarcodeType.QRCode:
                    
                    BarcodeQRCode barcodeQR = new BarcodeQRCode(CodeContent);
                    
                    Image QRImage = new Image(barcodeQR.CreateFormXObject(document));

                    Paragraph p = new Paragraph().SetFontSize(6);
                    p.Add(QRImage.ScaleAbsolute(30, 30));
                    p.Add(CodeContent);
                   // cell.Add(QRImage.ScaleAbsolute(30, 30));
                    cell.Add(p);
                    
                    

                    // barcode1.PlaceBarcode(canvas, ColorConstants.BLACK);
                    break;
            }

            table.AddCell(cell);
            doc.Add(table);
            doc.Close();
            return memoryStream.ToArray();
        }

        private static Cell CreateBarcode(string code, PdfDocument pdfDoc)
        {
            Barcode128 barcode = new Barcode128(pdfDoc);
            barcode.SetCodeType(BarcodeEAN.EAN8);
            barcode.SetCode(code);

            // Create barcode object to put it to the cell as image
            PdfFormXObject barcodeObject = barcode.CreateFormXObject(null, null, pdfDoc);
            Cell cell = new Cell().Add(new Image(barcodeObject));
            cell.SetPaddingTop(10);
            cell.SetPaddingRight(10);
            cell.SetPaddingBottom(10);
            cell.SetPaddingLeft(10);

            return cell;
        }

    }
}
