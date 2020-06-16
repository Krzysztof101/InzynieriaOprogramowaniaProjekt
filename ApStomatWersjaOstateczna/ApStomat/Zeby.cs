using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace AplikacjaStomatologiczna
{
    public class Zeby
    {
        private bool touched = true;
        public bool Touched { get { return touched; }  }
        public void setTouched() { touched = true; }
        public int[,,] tabTrzonowe = new int[2, 16, 8]{
            {{35,35,35,35,35,35,35,35},{35,35,35,35,35,35,35,35},{35,35,35,35,35,35,35,35},{35,35,35,35,35,0,35,0},
            {35,35,35,35,35,35,0,35},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},
            {35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,35,0,35},
            {35,35,35,35,35,0,35,0},{35,35,35,35,35,35,35,35},{35,35,35,35,35,35,35,35},{35,35,35,35,35,35,35,35}},
            {{35,35,35,35,35,35,0,35},{35,35,35,35,35,35,0,35},{35,35,35,35,35,35,0,35},{35,35,35,35,35,0,35,0},
            {35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},
            {35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},
            {35,35,35,35,35,0,35,0},{35,35,35,35,35,35,0,35},{35,35,35,35,35,35,0,35},{35,35,35,35,35,35,0,35}}
            };
        public int[,,] tabMleczne = new int[2, 16, 8]{
            {{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{35,35,35,35,35,35,35,35},
            {35,35,35,35,35,35,35,35},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},
            {35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,35,35,35},
            {35,35,35,35,35,35,35,35},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0}},
            {{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{35,35,35,35,35,35,0,35},
            {35,35,35,35,35,35,0,35},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},
            {35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,0,35,0},{35,35,35,35,35,35,0,35},
            {35,35,35,35,35,35,0,35},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0}}
            };
        internal static Zeby CzytajZPliku(string sciezkaPlikuZeby)
        {
            Zeby ze = new Zeby();
            BinaryReader brZ = new BinaryReader(File.Open(sciezkaPlikuZeby, FileMode.Open));
            for (int a=0; a<2; a++)
            {
                for(int b=0; b<16; b++)
                {
                    for(int c=0; c<8; c++)
                    {
                        ze.tabTrzonowe[a, b, c] = brZ.ReadInt32();
                    }
                }
            }
            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 16; b++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        ze.tabMleczne[a, b, c] = brZ.ReadInt32();
                    }
                }
            }
            brZ.Close();
            ze.touched = false;
            return ze;
        }
        internal void ZapiszDoPliku(string sciezkaPlikuZeby)
        {
            Zeby ze = new Zeby();

            BinaryWriter bwZ = new BinaryWriter(File.Open(sciezkaPlikuZeby, FileMode.Open));
            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 16; b++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        bwZ.Write(tabTrzonowe[a,b,c]);
                    }
                }
            }
            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 16; b++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        bwZ.Write(tabMleczne[a, b, c]);
                    }
                }
            }
            bwZ.Close();
            ze.touched = false;
            return;
        }
        public Zeby DeepCopy()
        {
            Zeby temp = new Zeby();
            temp.tabMleczne = (int[,,])this.tabMleczne.Clone();
            temp.tabTrzonowe = (int[,,])this.tabTrzonowe.Clone();
            temp.touched = this.touched;
            return temp;
        }

        internal void generujIZapiszObraz(string nazwa_folderu)
        {
            int x = 1;
            int y = 350;
            FormDiagram formularzZebowy = new FormDiagram(this);
            Bitmap bmpTrzonowe = new Bitmap(formularzZebowy.canvas.Width, formularzZebowy.canvas.Height+100);
            formularzZebowy.canvas.DrawToBitmap(bmpTrzonowe, new Rectangle(0, 0, formularzZebowy.canvas.Width, formularzZebowy.canvas.Height+100));
            Graphics graphics1 = Graphics.FromImage(bmpTrzonowe);
            Font arialFont = new Font("Arial", 15, GraphicsUnit.Pixel);
            List<int> unikalneTrzonowe = new List<int>();
            for (int i=0; i<2;i++)
            {
                for(int j=0; j<16; j++)
                {
                    for(int k=0; k<8; k++)
                    {
                        if (!unikalneTrzonowe.Contains(tabTrzonowe[i, j, k]) && tabTrzonowe[i, j, k] != 0)
                            unikalneTrzonowe.Add(tabTrzonowe[i, j, k]);
                    }
                }
            }
            graphics1.DrawString("Legenda: ", arialFont, Brushes.White, x, y);
            y = y + 15;
            for (int v=0; v<unikalneTrzonowe.Count;v++)
            {
                string text = OpisStanu(unikalneTrzonowe[v]);
                if (unikalneTrzonowe[v]==1)
                {
                    var size = graphics1.MeasureString(text, arialFont);
                    var rect = new RectangleF(x, y, size.Width, size.Height);
                    graphics1.FillRectangle(Brushes.White, rect);
                }
                graphics1.DrawString(text, arialFont, formularzZebowy.StanZeba(unikalneTrzonowe[v]), x, y);
                x = x + text.Length*10;
                if (x > 1050)
                {
                    y = y + 15;
                    x = 1;
                }
            }
            bmpTrzonowe.Save(nazwa_folderu + @"\diagramTrzonowe.Bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            Bitmap bmpMleczne = new Bitmap(formularzZebowy.canvas.Width, formularzZebowy.canvas.Height + 100);
            formularzZebowy.czyMleczne=true;
            formularzZebowy.canvas.Invalidate();
            formularzZebowy.canvas.DrawToBitmap(bmpMleczne, new Rectangle(0, 0, formularzZebowy.canvas.Width, formularzZebowy.canvas.Height));
            x = 1;
            y = 350;
            Graphics graphics2 = Graphics.FromImage(bmpMleczne);
            List<int> unikalneMleczne = new List<int>();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (!unikalneMleczne.Contains(tabMleczne[i, j, k]) && tabMleczne[i, j, k] != 0)
                            unikalneMleczne.Add(tabMleczne[i, j, k]);
                    }
                }
            }
            graphics2.DrawString("Legenda: ", arialFont, Brushes.White, x, y);
            y = y + 15;
            for (int v = 0; v < unikalneMleczne.Count; v++)
            {
                string text = OpisStanu(unikalneMleczne[v]);
                if (unikalneMleczne[v] == 1)
                {
                    var size = graphics2.MeasureString(text, arialFont);
                    var rect = new RectangleF(x, y, size.Width, size.Height);
                    graphics2.FillRectangle(Brushes.White, rect);
                }
                graphics2.DrawString(text, arialFont, formularzZebowy.StanZeba(unikalneMleczne[v]), x, y);
                x = x+text.Length*10;
                if (x > 1050)
                {
                    y = y + 15;
                    x = 1;
                }
            }
            bmpMleczne.Save(nazwa_folderu + @"\diagramMleczne.Bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            formularzZebowy.Close();
        }

        string OpisStanu(int kolor)
        {
            string opisik = "";
            if (kolor == 1) //brak zęba (czarny)
                opisik = "brak zęba";
            else if (kolor == 2) //chirurgia (czerwony)
                opisik = "brak zęba";
            else if (kolor == 3) //dewitalizacja (zielony)
                opisik = "chirurgia";
            else if (kolor == 4) //do obserwacji (blue)
                opisik = "do obserwacji";
            else if (kolor == 5) //ekstrakcja (fiołkowy)
                opisik = "ekstrakcja";
            else if (kolor == 6) //hemisekcja (cyjan)
                opisik = "hemisekcja";
            else if (kolor == 7) //implant (brązowy)
                opisik = "implant";
            else if (kolor == 8) //kiretaż otwarty (oliwkowy)
                opisik = "kiretaż otwarty";
            else if (kolor == 9) //kiretaż ręczny (łososiowy)
                opisik = "kiretaż ręczny";
            else if (kolor == 10) //konsultacja stomatologiczna (szary)
                opisik = "konsultacja stomatologiczna";
            else if (kolor == 11) //korona pełnoceramiczna (indygo)
                opisik = "korona pełnoceramiczna";
            else if (kolor == 12) //korona porcelanowa na metalu (żółty)
                opisik = "korona porcelanowa na metalu";
            else if (kolor == 13) //korona protetyczna obca (fiolet)
                opisik = "korona protetyczna obca";
            else if (kolor == 14) //korona tymczasowa (złoty)
                opisik = "korona tymczasowa";
            else if (kolor == 15) //leczenie endod (srebrny)
                opisik = "leczenie endod";
            else if (kolor == 16) //most (turkusowy)
                opisik = "most";
            else if (kolor == 17) //mycie zęba-opłukiwanie (limonkowy)
                opisik = "mycie zęba-opłukiwanie";
            else if (kolor == 18) //opatrunek do kanału (magenta)
                opisik = "opatrunek do kanału";
            else if (kolor == 19) //opracowanie 1 kanału (pomarańczowy)
                opisik = "opracowanie 1 kanału";
            else if (kolor == 20) //piaskowanie (różowy)
                opisik = "piaskowanie";
            else if (kolor == 21) //proteza akrylowa (fuksja)
                opisik = "proteza akrylowa";
            else if (kolor == 22) //proteza szkieletowa (akwamaryna)
                opisik = "proteza szkieletowa";
            else if (kolor == 23) //próchnica głeboka (peru)
                opisik = "próchnica głeboka";
            else if (kolor == 24) //skaling (morski)
                opisik = "skaling";
            else if (kolor == 25) //skaling ultradźwiękowy szczęki (karmazynowy)
                opisik = "/skaling ultradźwiękowy szczęki";
            else if (kolor == 26) //ubytek próchnicowy (beis)
                opisik = "ubytek próchnicowy";
            else if (kolor == 27) //wypełnienie (bordo)
                opisik = "wypełnienie";
            else if (kolor == 28) //wypełnienie amalgamatowe (moccasin)
                opisik = "wypełnienie amalgamatowe";
            else if (kolor == 29) //wypełnienie amalgamatowe obce (czekoladowy)
                opisik = "wypełnienie amalgamatowe obce";
            else if (kolor == 30) //wypełnienie glasjonomerowe (khaki)
                opisik = "wypełnienie glasjonomerowe";
            else if (kolor == 31) //wypełnienie kanału (lawendowy) 
                opisik = "wypełnienie kanału";
            else if (kolor == 32) //wypełnienie tymczasowe (cytrynowy) 
                opisik = "wypełnienie tymczasowe";
            else if (kolor == 33) //wypełnienie uv (tan)
                opisik = "wypełnienie uv";
            else if (kolor == 34) //wypełnienie uv obce (pomidorowy);
                opisik = "wypełnienie uv obce";
            else if (kolor == 35) //zdrowy (biały)
                opisik = "zdrowy";
            else if (kolor == 36) //znieczulenie (śliwkowy)
                opisik = "znieczulenie";
            else if (kolor == 37) //znieczulenie nasiękowe (morska zieleń)
                opisik = "znieczulenie nasiękowe";
            else if (kolor == 38) //znieczulenie przewodowe (chartreuse)
                opisik = "znieczulenie przewodowe";

            return opisik;
        }
    }
}
