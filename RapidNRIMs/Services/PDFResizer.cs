using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

namespace RapidNRIMs.Services
{
    public class PDFResizer
    {
        public void ResizePdf(string inputFilePath, string outputFilePath, float width, float height)
        {
            using (PdfReader reader = new PdfReader(inputFilePath))
            using (PdfWriter writer = new PdfWriter(outputFilePath))
            using (PdfDocument pdfDoc = new PdfDocument(reader, writer))
            {
                Document doc = new Document(pdfDoc);

                for (int pageNum = 1; pageNum <= pdfDoc.GetNumberOfPages(); pageNum++)
                {
                    pdfDoc.GetPage(pageNum).GetPageSize().SetWidth(width).SetHeight(height);
                }

                doc.Close();
            }
        }
    }
}
