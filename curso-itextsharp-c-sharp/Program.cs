using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using System.IO;

namespace curso_itextsharp_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document(PageSize.A4);
            document.SetMargins(40, 40, 40, 80);
            string path = @"C:\temp\PrimeiroDocumento.pdf";

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            document.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.COURIER, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("teste\n\n");
            document.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL, 12));
            string conteudo = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam eget ligula eu lectus lobortis condimentum. Aliquam nonummy auctor massa. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla at risus. Quisque purus magna, auctor et, sagittis ac, posuere eu, lectus. Nam mattis, felis ut adipiscing.\n\n";
            paragrafo.Add(conteudo);
            document.Add(paragrafo);

            PdfPTable table = new PdfPTable(3);

            table.AddCell("Linha 1, Coluna 1");
            table.AddCell("Linha 1, Coluna 2");
            table.AddCell("Linha 1, Coluna 3");

            table.AddCell("Linha 2, Coluna 1");
            table.AddCell("Linha 2, Coluna 2");
            table.AddCell("Linha 2, Coluna 3");

            document.Add(table);

            string simg = "https://i.pinimg.com/originals/1c/ee/d0/1ceed098558380f5c4739bb878bd7bce.png";
            Image img = Image.GetInstance(simg);
            img.ScaleAbsolute(100, 130);
            img.SetAbsolutePosition(10, 30);

            document.Add(img);

            document.Close();
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true});
        }
    }
}
