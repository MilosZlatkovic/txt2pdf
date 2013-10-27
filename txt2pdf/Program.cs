using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace txt2pdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[0], Encoding.GetEncoding("windows-1250"));

            Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 20, 20, 20);
            PdfWriter pdfwr = PdfWriter.GetInstance(doc,
                                                    new FileStream(args[0].ToString().Substring(0, args[0].ToString().Length - 4) + ".pdf",
                                                    FileMode.Create));
            doc.Open();

            // Create my base font
            BaseFont base_font = BaseFont.CreateFont("consola.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            // Create my font
            Font my_font = new Font(base_font, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            Paragraph paragraph;
            foreach (string line in lines)
            {
                paragraph = new Paragraph(line, my_font);
                doc.Add(paragraph);
            }

            doc.Close();

            //System.Console.WriteLine("Done! \n");
            //Console.WriteLine("Press any key to exit.");
            //System.Console.ReadKey();  
        }
    }
}
