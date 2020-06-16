using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaStomatologiczna
{
    internal class Wizyta
    { 
        Pacjent pacj;
        internal DateTime dataWizytyOd;
        internal DateTime dataWizytyDo;
        internal string opis;
        internal double cena;
        
        public KluczWizyty getKlucz()
        {
            return new KluczWizyty(this);
        }
        public DateTime DataWizytyOd
        { get{ return new DateTime(dataWizytyOd.Year, dataWizytyOd.Month, dataWizytyOd.Day, dataWizytyOd.Hour,dataWizytyOd.Minute,0); } }
        public DateTime DataWizytyDo
        { get { return new DateTime(dataWizytyOd.Year,dataWizytyOd.Month,dataWizytyOd.Day,dataWizytyDo.Hour,dataWizytyDo.Minute,0); } }
        public DateTime Data { get { return new DateTime(dataWizytyOd.Year, dataWizytyOd.Month, dataWizytyOd.Day); } }
        public int GodzOd { get { return dataWizytyOd.Hour; } }
        public int MinOd { get { return dataWizytyOd.Minute; } }
        public int GodzDo { get { return dataWizytyDo.Hour; } }
        public int MinDo { get { return dataWizytyDo.Minute; } }
        public string Opis { get { return opis; } }
        public Pacjent Pacj { get {return pacj; } }

        public Wizyta( DateTime data, int godzOd, int minOd, int godzDo, int minDo, string _opis, double _cena, Pacjent p)
        {
            
            pacj = p;
            dataWizytyOd = new DateTime(data.Year, data.Month, data.Day, godzOd, minOd, 0);
            dataWizytyDo = new DateTime(data.Year, data.Month, data.Day, godzDo, minDo, 0);
            
            
            if(DateTime.Compare(dataWizytyDo,dataWizytyOd)<=0)
            {
                throw new Exception("konstruktor wizyta, godzina od wieksza lub rowna godzinie do");
            }
            opis = _opis;
            cena = _cena;
            p.dodajDoListyWizyt(new KluczWizyty(this));
        }

        private Wizyta()
        {
        }

        internal void zapelnijTabliceStringGrafiku(string[,] tablica, int indeksKolumny,int[,] tablicaKolorow,int kolor)
        {
            //pomocnicza metoda dla zapełniaczaDGV - zapełnia fragment przekazanej tablicy podzielonym na części opisem wizyty
            //zapisuje również w tablicy kolorów informację o tym jaki kolor ma miećdana komórka w grafiku
            int indeksPoczatku = DataWizytyOd.Hour * 4 + DataWizytyOd.Minute / 15;
            int DlugoscWizytyWKwadransach = DataWizytyDo.Hour*4 + (DataWizytyDo.Minute / 15) - indeksPoczatku;
            if (DlugoscWizytyWKwadransach == 1)
            {
                tablica[indeksPoczatku, indeksKolumny] = pacj.Imie + " " + pacj.Nazwisko +", "+ Opis;
            }
            else if (DlugoscWizytyWKwadransach == 2)
            {
                tablica[indeksPoczatku, indeksKolumny] = pacj.Imie + " " + pacj.Nazwisko;
                tablica[indeksPoczatku + 1, indeksKolumny] = Opis;
            }
            else
            {
                //jest dużo miejsca na opis - podziel opis na części i wpisz je do odpowiednich komórek
                tablica[indeksPoczatku, indeksKolumny] = pacj.Imie + " " + pacj.Nazwisko;
                
                string[] tablicaOpisu = potnijOpisNaKawalki(Opis, DlugoscWizytyWKwadransach - 1, Form1.szerokoscKolumnyDGVGrafik);
                for(int i=0; i< tablicaOpisu.Length;i++)
                {
                    tablica[indeksPoczatku + 1 + i,indeksKolumny] = tablicaOpisu[i];
                }

            }

            for (int p = indeksPoczatku; p < (indeksPoczatku + DlugoscWizytyWKwadransach); p++)
            {
                tablicaKolorow[p, indeksKolumny] = kolor;
                if(tablica[p,indeksKolumny] == "")
                {
                    tablica[p, indeksKolumny] = " ";
                }
                //przypisz kolory do komórek
            }
        }

        private string[] potnijOpisNaKawalki(string opis, int wielkoscTablicy, int szerokoscPola)
        {
            //metoda pomocnicza - rozdziela cały opis na słowa, tak by w jednej komórce grafiku nie znalazło się na tyle dużo słów,
            //że część z nich będzie przysłonięta
            //w przypadku, gdy opis będzie za długi, do ostatniej komórki grafiku trafią wszystkie pozostałe słowa
            //zwraca tablicę stringów ze słowami opisu
            string[] tablica = new string[wielkoscTablicy];
            for(int i=0; i< tablica.Length; i++) { tablica[i] = ""; }
            List<string> slowaOpisu = new List<string>();
            int itr1 = 0;
            while(true)
            {
                int spacePos = opis.IndexOf(' ', itr1);
                string slowo="";
                if(spacePos!=-1)
                {
                    slowo = opis.Substring(itr1, spacePos - itr1    +1);
                }
                else
                {
                    slowo = opis.Substring(itr1);
                }
                slowaOpisu.Add(slowo);
                itr1 = spacePos + 1;
                if (itr1>=opis.Length || spacePos==-1)
                {
                    break;
                }
            }
            int k = 0;
            while(slowaOpisu.Count!=0)
            {
                //wyjmuj po jednym słowie
                string slowo = slowaOpisu.ElementAt(0);
                slowaOpisu.RemoveAt(0);
                if(slowo.Length > szerokoscPola)
                {
                    //podziel słowo bo jest za długie
                    string nadmiar = slowo.Substring(szerokoscPola);
                    slowaOpisu.Insert(0, nadmiar);
                    slowo = slowo.Substring(0, szerokoscPola);
                }
                if(k<tablica.Length -1 )
                {
                    if(tablica[k].Length + slowo.Length <= szerokoscPola)
                    {
                        //słowo jeszcze mieści się w komórce datagridView
                        tablica[k] += slowo;
                    }
                    else
                    {
                        k++;
                    }
                }
                else
                {
                    //ostatnia komórka datagridView przeznaczona na tą wizytę - umieść w niej pozostałe słowa
                    tablica[k] += slowo;
                }

            }


            return tablica;
        }

        public Wizyta(Wizyta w)
        {
            //konstruktor kopiujący
            pacj = w.pacj;
            dataWizytyOd = w.DataWizytyOd;
            dataWizytyDo = w.DataWizytyDo;
            opis = w.opis;
            cena = w.cena;
        }
        public override string ToString()
        {
            string opisik = Convert.ToString(pacj.Id) + ", " +pacj.Imie+" "+pacj.Nazwisko+", "+ //
                String.Format("{0:yyyy/MM/dd HH:mm}", dataWizytyOd) + " - " +//
                String.Format("{0:HH:mm}", dataWizytyDo) + ", " + Convert.ToString(cena) + " zł, " + opis;
            return opisik;
        }

        public static bool brakKolizjiZInnaWizyta( KluczWizyty kluczTej, KluczWizyty kluczTamtej)
        {
            bool wariant1 = false, wariant2 = false;
            if(  DateTime.Compare( kluczTej.KluczOd,kluczTamtej.KluczDo)>=0)
            {
                wariant1 = true;
            }
            if( DateTime.Compare(kluczTej.KluczDo,kluczTamtej.KluczOd)<=0 )
            {
                wariant2 = true;
            }
            if(wariant1 || wariant2)
            {
                return true;
            }
            return false;
        }


        internal static int Compare(Wizyta w, Wizyta ww)
        {
            KluczWizyty kw = w.getKlucz();
            KluczWizyty kww = ww.getKlucz();

            if(!brakKolizjiZInnaWizyta(kw, kww))
            {
                return 0;
            }

            if(kw.KluczOd.Equals(kww.KluczDo))
            {
                return 1;
            }
            if (kw.KluczDo.Equals(kww.KluczOd))
            {
                return -1;
            }
            return DateTime.Compare(kw.KluczOd, kww.KluczOd);


        }

        internal static Wizyta CzytajZPliku(BinaryReader br, List<Pacjent> pacjenci, List<Pacjent> pacjenciUsunieci)
        {
            Wizyta wczytywanaWizyta = new Wizyta();
            int idPacjenta = br.ReadInt32();
            Pacjent pacpac = null;
            foreach(Pacjent p in pacjenci)
            {//odnajdź pacjenta o danym id w pacjentach lub w pacjentach usuniętych
                if( p.Id == idPacjenta)
                {
                    pacpac = p;
                    break;
                }
            }
            if(pacpac == null)
            {
                foreach (Pacjent p in pacjenciUsunieci)
                {
                    if (p.Id == idPacjenta)
                    {
                        pacpac = p;
                        break;
                    }
                }
            }
            wczytywanaWizyta.pacj = pacpac;
            //wczytaj resztę danych
            int[] daneCzasowe =  Wizyta.WczytajDaneCzasowe(br); 
            wczytywanaWizyta.dataWizytyOd = new DateTime(daneCzasowe[0], daneCzasowe[1], daneCzasowe[2], daneCzasowe[3], daneCzasowe[4], 0);
            wczytywanaWizyta.dataWizytyDo = new DateTime(daneCzasowe[0], daneCzasowe[1], daneCzasowe[2], daneCzasowe[5], daneCzasowe[6], 0);

            wczytywanaWizyta.opis = Cipher.ReadString(br);

            wczytywanaWizyta.cena = br.ReadDouble();
            return wczytywanaWizyta;
        }

        private static int[] WczytajDaneCzasowe(BinaryReader br)
        {
            int[] daneCzasowe = new int[7];
            daneCzasowe[0] = br.ReadInt32();
            daneCzasowe[1] = br.ReadInt32();
            daneCzasowe[2] = br.ReadInt32();
            daneCzasowe[3] = br.ReadInt32();
            daneCzasowe[4] = br.ReadInt32();
            daneCzasowe[5] = br.ReadInt32();
            daneCzasowe[6] = br.ReadInt32();
            return daneCzasowe;
        }

        internal void skasujWpisWizytyUPacjenta()
        {
            pacj.UsunZListyWizyt(this.getKlucz());
        }

        internal void ZapiszDoPliku(BinaryWriter bw)
        {
            bw.Write(pacj.Id);

            bw.Write(dataWizytyOd.Year);
            bw.Write(dataWizytyOd.Month);
            bw.Write(dataWizytyOd.Day);
            bw.Write(dataWizytyOd.Hour);
            bw.Write(dataWizytyOd.Minute);
            bw.Write(dataWizytyDo.Hour);
            bw.Write(dataWizytyDo.Minute);

            Cipher.Write(bw, opis);
            
            bw.Write(cena);
        }

        public bool Equals(Wizyta other)
        {
            if(other == null)
            { return false; }
            return pacj.Equals(other.pacj) && getKlucz().Equals(other.getKlucz());
        }

    }


    internal class KluczWizyty
    {
        private DateTime kluczOd;
        private DateTime kluczDo;
        

        public DateTime KluczOd { get { return new DateTime(kluczOd.Ticks); } }
        public DateTime KluczDo { get { return new DateTime(kluczDo.Ticks); } }

        public DateTime Data { get { return new DateTime(kluczOd.Year, kluczOd.Month, kluczOd.Day); } }

        private KluczWizyty() { }
        public KluczWizyty(DateTime data, int godzOd, int mimOd, int godzDo, int minDo)
        {
            kluczOd = new DateTime(data.Year, data.Month, data.Day, godzOd, mimOd, 0);
            kluczDo = new DateTime(data.Year, data.Month, data.Day, godzDo, minDo, 0);

            

        }


        public KluczWizyty(Wizyta w)
        {
            DateTime dataWizyty = w.Data;

            kluczOd = new DateTime(dataWizyty.Year, dataWizyty.Month,dataWizyty.Day, w.GodzOd, w.MinOd, 0);
            kluczDo = new DateTime(dataWizyty.Year, dataWizyty.Month, dataWizyty.Day, w.GodzDo, w.MinDo, 0);
        }

        public KluczWizyty(KluczWizyty k)
        {
            kluczOd = new DateTime(k.kluczOd.Year, k.kluczOd.Month, k.kluczOd.Day, k.kluczOd.Hour, k.kluczOd.Minute, 0);
            kluczDo = new DateTime(k.kluczOd.Year, k.kluczOd.Month, k.kluczOd.Day, k.kluczDo.Hour, k.kluczDo.Minute, 0);
        }

        public bool Equals(KluczWizyty kw)
        {
            if(kw == null)
            { return false; }
            return this.kluczOd.Year == kw.kluczOd.Year && kluczOd.Month == kw.kluczOd.Month &&
                kluczOd.Day == kw.kluczOd.Day && kluczOd.Hour == kw.kluczOd.Hour && kluczOd.Minute == kw.kluczOd.Minute &&
                kluczDo.Hour == kw.kluczDo.Hour && kluczDo.Minute == kw.kluczDo.Minute;
            
        }
        public override bool Equals(object obj)
        {
            if(obj==null)
            {
                return false;
            }
            if(obj is Wizyta)
            {
                return this.Equals(obj as Wizyta);
            }
            return false;
        }


        internal static List<KluczWizyty> WczytajKluczeWizyt(string sciezkaPLiku)
        {
            //metoda używana przez klasę Pacjent
            List<KluczWizyty> przeprowadzoneZabiegi = new List<KluczWizyty>();
            if(File.Exists(sciezkaPLiku))
            {
                BinaryReader br = new BinaryReader(File.Open(sciezkaPLiku, FileMode.Open));
                while( br.BaseStream.Position!=br.BaseStream.Length )
                {
                    KluczWizyty wczytanyKlucz = KluczWizyty.CzytajZPliku(br);
                    przeprowadzoneZabiegi.Add(wczytanyKlucz);
                }
                br.Close();

            }
            return przeprowadzoneZabiegi;

        }

        
        private static KluczWizyty CzytajZPliku(BinaryReader br)
        {
            int rok = br.ReadInt32();
            int miesiac = br.ReadInt32();
            int dzien = br.ReadInt32();
            int godzinaOd = br.ReadInt32();
            int minutaOd = br.ReadInt32();
            int godzinaDo = br.ReadInt32();
            int minutaDo = br.ReadInt32();
            return new KluczWizyty(new DateTime(rok, miesiac, dzien), godzinaOd, minutaOd, godzinaDo, minutaDo);
            
        }

        internal void ZapiszDoPliku(BinaryWriter bw2)
        {
            bw2.Write(kluczOd.Year);
            bw2.Write(kluczOd.Month);
            bw2.Write(kluczOd.Day);
            bw2.Write(kluczOd.Hour);
            bw2.Write(kluczOd.Minute);
            bw2.Write(kluczDo.Hour);
            bw2.Write(kluczDo.Minute);
        }
        

        internal bool teSameDaty(DateTime dataZmiany)
        {
            return kluczOd.Year == dataZmiany.Year && kluczOd.Month == dataZmiany.Month && kluczOd.Day == dataZmiany.Day;
        }

        public KluczWizyty(DateTime DataOd, DateTime DataDo)
        {

            kluczOd = new DateTime(DataOd.Year, DataOd.Month, DataOd.Day, DataOd.Hour, DataOd.Minute, 0);
            kluczOd = new DateTime(DataOd.Year, DataOd.Month, DataOd.Day, DataDo.Hour, DataDo.Minute, 0);
            if (!(kluczOd.Year == kluczDo.Year && kluczOd.Month == kluczDo.Month && kluczOd.Day == kluczDo.Day))
            {
                throw new Exception("Daty maja rozne dni");
            }

        }



    }

}
