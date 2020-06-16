using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaStomatologiczna
{
    class Zmiana
    {
        private DateTime dataZmiany;
        public DateTime DataZmiany { get { return new DateTime(dataZmiany.Year, dataZmiany.Month, dataZmiany.Day); } }
        private List<Wizyta> wizyty;
        public void setTouched() { touched = true; }
        private bool touched;
        public bool Touched { get { return touched; } }

        public static bool KeysEqual(DateTime dataZmiany2, DateTime dataZmiany)
        {
            return dataZmiany.Year == dataZmiany2.Year && dataZmiany.Month == dataZmiany2.Month && dataZmiany.Day == dataZmiany2.Day;
        }

        public Zmiana(DateTime d)
        {
            dataZmiany = new DateTime(d.Year, d.Month, d.Day);
            wizyty = new List<Wizyta>();
            touched = true;
        }
        
        internal int[] zapelnijTabliceStringGrafiku(string[,] tablica, int kolumna,int[,] tab)
        {
            //pomocnicza metoda dla zapełniaczaDGV
            int[] kodyKolorow = new int[tablica.GetLength(0)];
            for(int iii=0;iii<kodyKolorow.GetLength(0);iii++)
            {
                //przygotowanie tablicy kolorów dla danego dnia
                kodyKolorow[iii] = 0;
            }
            int kolor = 1;
            foreach(Wizyta w in wizyty)
            {
                
                w.zapelnijTabliceStringGrafiku(tablica, kolumna,tab, kolor);
                if(kolor==1) //sąsiadujące wizyty w jednym dniu muszą mieć inne kolory by dało się odróżnić początek jednej wizyty od końca drugiej
                {
                    kolor = 2;
                }
                else
                { kolor = 1; }
                DateTime pocz = w.DataWizytyOd;
                int minutyOd = pocz.Hour * 4 + pocz.Minute / 15;
                DateTime kon = w.DataWizytyDo;
                int dlugoscKwadranse = kon.Hour * 4 + kon.Minute / 15 - minutyOd;
                for(int t=minutyOd; t<minutyOd + dlugoscKwadranse; t++)
                {
                    kodyKolorow[t] = kolor;
                }
            }
            return kodyKolorow; //zwróć do ZapełniaczaDGV kolumnę z infromacjami o kolorach
        }
        public bool MoznaDodacWizyte( KluczWizyty KluczWprawdzanejWizyty)
        {
            if(!KluczWprawdzanejWizyty.teSameDaty(DataZmiany))
            {
                return false;
            }
            
            foreach(Wizyta w in wizyty)
            {
                if(! Wizyta.brakKolizjiZInnaWizyta(KluczWprawdzanejWizyty, w.getKlucz()))
                {
                    return false;
                }
            }
            return true;
        }

        public bool DodajWizyte(Wizyta w)
        {
            if(!MoznaDodacWizyte(w.getKlucz()))
            {
                return false;
            }
            if(wizyty.Count == 0)
            {
                wizyty.Add(w);
                touched = true;
                return true;
            }
            int i = 0;
            for(i=0;i<wizyty.Count;i++)
            {
                if( Wizyta.Compare(w,wizyty.ElementAt(i) )<0)
                {
                    wizyty.Insert(i, w);
                    touched = true;
                    return true;
                }
            }
            wizyty.Add(w);
            touched = true;
            return true;
        }

        public Wizyta ElementAt(int i)
        {
            Wizyta w = wizyty.ElementAt(i);
            return  new Wizyta(w);
        }
        public int Count { get { return wizyty.Count;  } }


        public static Zmiana CzytajZPliku(string sciezka, List<Pacjent> pacjenci, List<Pacjent> pacjenciUsunieci)
        {
            

            BinaryReader br = new BinaryReader( File.Open(sciezka, FileMode.Open  ) );
            Zmiana wczytywanaZmiana = new Zmiana(Zmiana.CzytajDateZPliku(br));
            while ( br.BaseStream.Position != br.BaseStream.Length)
            {
                //wczytywanie wizyt
                Wizyta wczytanaWizyta = Wizyta.CzytajZPliku(br,pacjenci,pacjenciUsunieci);
                wczytywanaZmiana.DodajWizyte(wczytanaWizyta);
            }
            br.Close();
            wczytywanaZmiana.touched = false;

            return wczytywanaZmiana;
        }
        public static DateTime CzytajDateZPliku(BinaryReader br)
        {
            int rok = br.ReadInt32();
            int miesiac = br.ReadInt32();
            int dzien = br.ReadInt32();
            return new DateTime(rok, miesiac, dzien);
        }
        public static void ZapiszDateDoPliku(BinaryWriter bw, DateTime data)
        {
            bw.Write(data.Year);
            bw.Write(data.Month);
            bw.Write(data.Day);
        }
        public string NazwaPlikuZmiany { get { return String.Format("{0:yyyyMMdd}", DataZmiany); } }
        public void ZapiszDoPliku(string sciezka)
        {
            if(!File.Exists(sciezka))
            {
                FileStream f =  File.Create(sciezka);
                f.Close();
            }
            BinaryWriter bw = new BinaryWriter(File.Open(sciezka, FileMode.Truncate));
            Zmiana.ZapiszDateDoPliku(bw, this.dataZmiany);
            foreach(Wizyta w in wizyty)
            {
                w.ZapiszDoPliku(bw);
            }
            bw.Close();
            touched = false;
        }

        internal void usunWizyte(KluczWizyty k)
        {
            foreach(Wizyta w in wizyty)
            {
                if(k.Equals(w.getKlucz()))
                {
                    w.skasujWpisWizytyUPacjenta();
                    wizyty.Remove(w);
                    touched = true;
                    return;
                }
            }
        }

    }
}
