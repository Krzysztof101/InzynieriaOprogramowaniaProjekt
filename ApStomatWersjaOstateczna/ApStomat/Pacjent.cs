using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaStomatologiczna
{

    internal class Pacjent
    {
        private int id;
        private static int licznik;
        private static int licznikZdjecia;
        private DateTime dataRejestracji;
        private string imie;
        private string nazwisko;
        private string adres;
        private string telefon;
        private string email;
        private string higiena;
        private string stanBlony;
        private string stanPrzyzebia;
        private string wywiadLeki;
        private string wywiadAlergie;
        private string wywiadChoroby;
        private string wywiadInne;

        public int Id { get { return id; } }
        public DateTime DataRejestracji { get { return new DateTime(dataRejestracji.Year, dataRejestracji.Month, dataRejestracji.Day); } }
        public string Imie { get { return imie; } }
        public string Nazwisko { get { return nazwisko; } }
        public string Adres { get { return adres; } }

        
        public static int LicznikZdjec { get { return ++Pacjent.licznikZdjecia; } }
        public string Telefon { get { return telefon; } }
        public string Email {  get { return email; } }
        public string Higiena { get { return higiena; } }
        public string StanBlony { get { return stanBlony; } }
        public string StanPrzyzebia { get { return stanPrzyzebia; } }
        public string WywiadLeki {  get { return wywiadLeki; } }
        public string WywiadAlergie { get { return wywiadAlergie; } }
        public string WywiadChoroby {  get { return wywiadChoroby; } }
        public string WywiadInne { get { return wywiadInne; } }

        public Zeby diagramZebowy;
        public List<KluczWizyty> przeprowadzoneZabiegi;
        private bool touched;

        internal void przekazNoweDane(string[] noweDane)
        {
            imie = noweDane[0];
            nazwisko = noweDane[1];
            adres = noweDane[2];
            telefon = noweDane[3];
            email = noweDane[4];
            higiena = noweDane[5];
            stanBlony = noweDane[6];
            stanPrzyzebia = noweDane[7];
            wywiadLeki = noweDane[8];
            wywiadAlergie = noweDane[9];
            wywiadChoroby = noweDane[10];
            wywiadInne = noweDane[11];
        }

        public bool Touched { get { return touched || diagramZebowy.Touched; } }
        public void setTouched() { touched = true; }

        public string NazwaFolderu { get { return Convert.ToString(Id); }  }

        public Pacjent(string[] tablicaDanych, Zeby diagram)
        {
            
            id = ++licznik;
            {
                DateTime dataRejestracji2 = DateTime.Now;
                dataRejestracji = new DateTime(dataRejestracji2.Year, dataRejestracji2.Month, dataRejestracji2.Day, dataRejestracji2.Hour, dataRejestracji2.Minute, 0);
            }
            imie = tablicaDanych[0];
            nazwisko = tablicaDanych[1];
            adres = tablicaDanych[2];
            telefon = tablicaDanych[3];
            email = tablicaDanych[4];
            higiena = tablicaDanych[5];
            stanBlony = tablicaDanych[6];
            stanPrzyzebia = tablicaDanych[7];
            wywiadLeki = tablicaDanych[8];
            wywiadAlergie = tablicaDanych[9];
            wywiadChoroby = tablicaDanych[10];
            wywiadInne = tablicaDanych[11];
            diagramZebowy = diagram;
            przeprowadzoneZabiegi = new List<KluczWizyty>();
            touched = true;
        }


        public void dodajDoListyWizyt(KluczWizyty k)
        {
            przeprowadzoneZabiegi.Add(k);
            touched = true;
            
        }
        


        public void UsunZListyWizyt(KluczWizyty k)
        {
            foreach(KluczWizyty kk in przeprowadzoneZabiegi )
            {
                if(k.Equals(kk))
                {

                    przeprowadzoneZabiegi.Remove(kk);
                    touched = true;
                    return;
                }
            }
            

        }
        public static void wczytajLicznik(string sciezkaPlikulicznikPacjent)
        {
            BinaryReader rdr = new BinaryReader(File.Open(sciezkaPlikulicznikPacjent, FileMode.Open));
            licznik = rdr.ReadInt32();
            licznikZdjecia = rdr.ReadInt32();
            rdr.Close();
        }


        public Pacjent(string sciezkaKatalogu)
        {
            BinaryReader br = new BinaryReader(File.Open(sciezkaKatalogu  + @"\dane", FileMode.Open));
            id = br.ReadInt32();
            if(licznik<id)
            {
                licznik = id;
            }
            dataRejestracji = Pacjent.CzytajDateZPliku(br);
            
            imie = Cipher.ReadString(br);
            nazwisko = Cipher.ReadString(br);
            adres = Cipher.ReadString(br);
            telefon = Cipher.ReadString(br);
            email = Cipher.ReadString(br);
            higiena = Cipher.ReadString(br);
            stanBlony = Cipher.ReadString(br);
            stanPrzyzebia = Cipher.ReadString(br);
            wywiadLeki = Cipher.ReadString(br);
            wywiadAlergie = Cipher.ReadString(br);
            wywiadChoroby = Cipher.ReadString(br);
            wywiadInne = Cipher.ReadString(br);
            

            br.Close();
            diagramZebowy = Zeby.CzytajZPliku(sciezkaKatalogu + @"\zeby");
            
            przeprowadzoneZabiegi = KluczWizyty.WczytajKluczeWizyt(sciezkaKatalogu + @"\wizyty");
            touched = false;
            
        }

        private static DateTime CzytajDateZPliku(BinaryReader br)
        {
            int rok = br.ReadInt32();
            int miesiac = br.ReadInt32();
            int dzien = br.ReadInt32();
            int godzina = br.ReadInt32();
            int minuta = br.ReadInt32();
            return new DateTime(rok, miesiac, dzien, godzina, minuta, 0);
        }

        public bool zapiszPacjenta(string sciezkaKataloguPacjenta)
        {
            try
            {
                
                if (!Directory.Exists(sciezkaKataloguPacjenta))
                {

                    Directory.CreateDirectory(sciezkaKataloguPacjenta);
                    FileStream fs;
                    fs = File.Create(sciezkaKataloguPacjenta + @"\dane");
                    fs.Close();
                    fs= File.Create(sciezkaKataloguPacjenta + @"\wizyty");
                    fs.Close();
                    fs = File.Create(sciezkaKataloguPacjenta + @"\zeby");
                    fs.Close();
                    Directory.CreateDirectory(sciezkaKataloguPacjenta + @"\zdjecia");
                }
                
                BinaryWriter bw = new BinaryWriter(File.Open(sciezkaKataloguPacjenta + @"\dane", FileMode.Truncate));

                bw.Write(id);
                Pacjent.ZapiszDateDoPliku(bw, dataRejestracji.Year, dataRejestracji.Month, dataRejestracji.Day, dataRejestracji.Hour, dataRejestracji.Minute);
                
                
                Cipher.Write(bw, imie);
                Cipher.Write(bw, nazwisko);
                Cipher.Write(bw, adres);
                Cipher.Write(bw, telefon);
                Cipher.Write(bw, email);
                Cipher.Write(bw, higiena);
                Cipher.Write(bw, stanBlony);
                Cipher.Write(bw, stanPrzyzebia);
                Cipher.Write(bw, wywiadLeki);
                Cipher.Write(bw, wywiadAlergie);
                Cipher.Write(bw, wywiadChoroby);
                Cipher.Write(bw, wywiadInne);
                

                bw.Close();

                diagramZebowy.ZapiszDoPliku(sciezkaKataloguPacjenta + @"\zeby");
                BinaryWriter bw2 = new BinaryWriter(File.Open(sciezkaKataloguPacjenta + @"\wizyty", FileMode.Truncate));
                foreach (KluczWizyty klucz in przeprowadzoneZabiegi)
                {
                    klucz.ZapiszDoPliku(bw2);
                }
                bw2.Close();
            }
            catch(Exception e)
            {
                touched = true;
                return false;
            }
            touched = false;
            return true;

        }

        internal static string[] pobierzNazwydanych()
        {
            string[] nazwyDanych = new string[] {"id", "imie", "nazwisko", "adres", "telefon", "email", "higiena",
            "stan błony", "stan przyzębia", "leki", "alergie", "choroby", "inne"};
            return nazwyDanych;
        }

        internal string[] pobierzDane()
        {
            string[] dane = new string[] {Convert.ToString(Id), Imie, Nazwisko, Adres, Telefon, Email,
            Higiena, StanBlony, StanPrzyzebia, WywiadLeki, WywiadAlergie, WywiadChoroby, wywiadInne};
            return dane;

        }

        private static void ZapiszDateDoPliku(BinaryWriter bw2, int year, int month, int day, int hour, int minute)
        {
            bw2.Write(year);
            bw2.Write(month);
            bw2.Write(day);
            bw2.Write(hour);
            bw2.Write(minute);
        }

        internal static void ZapiszDaneKonfiguracyjne(string sciezkaFolderuPlikowKonfiguracyjnych)
        {
            BinaryWriter bw = new BinaryWriter(File.Open(sciezkaFolderuPlikowKonfiguracyjnych + @"\licznikPacjenta", FileMode.Truncate));
            bw.Write(licznik);
            bw.Write(licznikZdjecia);
            bw.Close();
        }

        internal List<KluczWizyty> getKluczeWizyt()
        {
            List < KluczWizyty > zwrot = new List<KluczWizyty>();
            foreach(KluczWizyty k in  przeprowadzoneZabiegi)
            {
                zwrot.Add(new KluczWizyty(k));
            }
            return zwrot;
        }

        public bool Equals(Pacjent other)
        {
            if(other == null)
            { return false; }
            return this.id == other.id;
        }
        public override bool Equals(object obj)
        {
            if(obj == null)
            { return false; }
            if(obj is Pacjent)
            {
                return Equals(obj as Pacjent);
            }
            return false;
        }

    }
}
