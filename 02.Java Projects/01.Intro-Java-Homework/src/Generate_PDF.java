import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

import java.io.FileOutputStream;

public class Generate_PDF {

	public static void main(String[] args) {
		try {
			Document document = new Document();
			PdfWriter.getInstance(document, new FileOutputStream("MyFile.pdf"));
			document.open();

			PdfPTable table = new PdfPTable(4);
			table.setWidthPercentage(100);
			table.getDefaultCell().setFixedHeight(140);

			BaseFont baseFont = BaseFont.createFont("arial.ttf",
					BaseFont.IDENTITY_H, true);
			Font black = new Font(baseFont, 70f, 0, BaseColor.BLACK);
			Font red = new Font(baseFont, 70f, 0, BaseColor.RED);

			String card = "";
			char color = ' ';

			for (int i = 2; i <= 14; i++) {
				switch (i) {
				case 10:
					card = "10";
					break;
				case 11:
					card = " J";
					break;
				case 12:
					card = " Q";
					break;
				case 13:
					card = " K";
					break;
				case 14:
					card = " A";
					break;
				default:
					card = " " + i;
					break;
				}
				for (int j = 1; j <= 4; j++) {
					switch (j) {
					case 1:
						color = '♣';
						table.addCell(new Paragraph(card + color + " ", black));
						break;
					case 2:
						color = '♦';
						table.addCell(new Paragraph(card + color + " ", red));
						break;
					case 3:
						color = '♠';
						table.addCell(new Paragraph(card + color + " ", black));
						break;
					case 4:
						color = '♥';
						table.addCell(new Paragraph(card + color + " ", red));
						break;
					}
				}
			}
			document.add(table);
			document.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}