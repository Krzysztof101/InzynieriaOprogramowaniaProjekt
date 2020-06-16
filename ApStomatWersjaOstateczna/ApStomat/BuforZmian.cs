using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AplikacjaStomatologiczna
{
    public class BuforZmian
    {
        private List<Pacjent> pacjenci;
        private List<Pacjent> pacjenciUsunieci;
        private List<Zmiana> zmianyAktualne;
        private List<Zmiana> sterta;
        public string KatalogGlowny { get { return Path.GetPathRoot(Environment.SystemDirectory) + @"\Users\" + Environment.UserName + @"\aplikacjaStomatologiczna"; } }
        private int liczbaZmianWstecz, liczbaZmianNaprzod;
        private DateTime godzinaRozpoczeciaPracy, godzinaZakonczeniaPracy;
        private int jednostkaCzasu;

        private bool touched;
        public bool Touched { get { return touched; } }
        public void setTouched() { touched = true; }
        public int LiczbaZmianWstecz { get { return liczbaZmianWstecz; } }
        public int LiczbaZmianNaprzod { get { return liczbaZmianNaprzod; } }
        public DateTime GodzinaRozpoczeciaPracy { get { return new DateTime(2000, 1, 1, godzinaRozpoczeciaPracy.Hour, godzinaRozpoczeciaPracy.Minute, 0); } }
        public DateTime GodzinaZakonczeniaPracy { get { return new DateTime(2000, 1, 1, godzinaZakonczeniaPracy.Hour, godzinaZakonczeniaPracy.Minute, 0); } }

        internal BuforZmian(List<Pacjent> pacjenci, List<Pacjent> pacjenciUsunieci, int dniWstecz, int dniNaprzod, DateTime godzOtw, DateTime godzZam,//
                    int jednostkaCzasu)
        {
            string sciezkaKatGlownego = KatalogGlowny;

            this.jednostkaCzasu = jednostkaCzasu;
            this.pacjenci = pacjenci;
            this.pacjenciUsunieci = pacjenciUsunieci;
            liczbaZmianWstecz = dniWstecz;
            liczbaZmianNaprzod = dniNaprzod;
            godzinaRozpoczeciaPracy = new DateTime(2000, 1, 1, godzOtw.Hour, godzOtw.Minute, 0);
            godzinaZakonczeniaPracy = new DateTime(2000, 1, 1, godzZam.Hour, godzZam.Minute, 0);

            DateTime teraz = DateTime.Now;
            DateTime dzisiejszyDzien = new DateTime(teraz.Year, teraz.Month, teraz.Day);
            zmianyAktualne = new List<Zmiana>();
            sterta = new List<Zmiana>();

            DateTime najwczesniejszyWczytywany = dzisiejszyDzien.AddDays(-liczbaZmianWstecz);
            DateTime najpozniejszyDzien = dzisiejszyDzien.AddDays(liczbaZmianNaprzod);
            DateTime iterator = new DateTime(najwczesniejszyWczytywany.Year, najwczesniejszyWczytywany.Month, najwczesniejszyWczytywany.Day);
            
            while (DateTime.Compare(iterator, najpozniejszyDzien) <= 0)
            {
                Zmiana nowaZmiana;
                string nazwaPlikuZmiany = String.Format("{0:yyyyMMdd}", iterator);
                if (File.Exists(sciezkaKatGlownego + @"\zmiany\" + nazwaPlikuZmiany))
                {
                    //znaleziono plik ze zmianą - wczytaj jego zawartość
                    nowaZmiana = Zmiana.CzytajZPliku(sciezkaKatGlownego + @"\zmiany\" + nazwaPlikuZmiany, pacjenci, pacjenciUsunieci);
                    zmianyAktualne.Add(nowaZmiana);
                }
                else
                {
                    //nie znaleziono pliku ze zminą - utwórz nowy obiekt
                    nowaZmiana = new Zmiana(iterator);
                    zmianyAktualne.Add(nowaZmiana);
                }
                DateTime d= iterator.AddDays(1);
                iterator = d;
            }
            
        }

        internal void noweIlosciWczytywanychDni(int value1, int value2)
        {
            liczbaZmianWstecz = value1;
            liczbaZmianNaprzod = value2;
            setTouched();
        }

        internal void noweGodzinyOtwarcia(int godzRozp, int minRozp, int godzZak, int minZak)
        {
            godzinaRozpoczeciaPracy = new DateTime(2000, 1, 1, godzRozp, minRozp, 0);
            godzinaZakonczeniaPracy = new DateTime(2000, 1, 1, godzZak, minZak, 0);
            setTouched();
        }

        internal bool MoznaZapisacNaWizyte(DateTime dataZmiany, Wizyta umowionaWizyta)
        {
            return MoznaZapisacNaWizyte(dataZmiany, umowionaWizyta.Data, umowionaWizyta.GodzOd, umowionaWizyta.MinOd, umowionaWizyta.GodzDo, umowionaWizyta.MinDo);
        }


        public bool MoznaZapisacNaWizyte(DateTime dataZmiany,DateTime data, int _godzOd, int _minOd, int _godzDo, int _minDo)
        {
            DateTime dataZmianyPrzycieta = new DateTime(dataZmiany.Year, dataZmiany.Month, dataZmiany.Day);

            if(! (dataZmianyPrzycieta.Year == data.Year && dataZmianyPrzycieta.Month == data.Month && dataZmianyPrzycieta.Day == data.Day))
            {
                return false; //wizyta i zmiana nie są tego samego dnia
            }
            DateTime rozpoczecieZabiegu = new DateTime(data.Year, data.Month, data.Day //
                , _godzOd, _minOd, 0);
            DateTime zakonczenieZabiegu = new DateTime(data.Year, data.Month, data.Day //
                , _godzDo, _minDo, 0);
            if (DateTime.Compare(zakonczenieZabiegu, rozpoczecieZabiegu) <= 0)
            {
                return false;
            }

            bool znalezionoZmiane = false;
            Zmiana znalezionaZmiana = null;
            //przeszukaj zmianyAktualne i sterte by znaleźć dzień na który chcemy zapisać wizytę
            foreach (Zmiana z in zmianyAktualne)
            {
                if (Zmiana.KeysEqual(dataZmianyPrzycieta, z.DataZmiany))
                {
                    znalezionoZmiane = true;
                    znalezionaZmiana = z;
                    break;
                }

            }
            if (!znalezionoZmiane)
            {
                foreach (Zmiana z in sterta)
                {
                    if (Zmiana.KeysEqual(dataZmianyPrzycieta, z.DataZmiany))
                    {
                        znalezionoZmiane = true;
                        znalezionaZmiana = z;
                        break;
                    }
                }
            }
            if (!znalezionoZmiane)
            {//przeszukano obie listy i nie znaleziono zmiany - utwórz zmiany z okresu 3 wstecz i 3 dni po dniu wizyty
                sprowadzLubUtworzZmiany(data, 3, 3);
            }
            foreach (Zmiana z in zmianyAktualne)
            {//znowu przeszukaj zmianyAktualne i sterte
                if (Zmiana.KeysEqual(dataZmianyPrzycieta, z.DataZmiany))
                {
                    znalezionoZmiane = true;
                    znalezionaZmiana = z;
                    break;
                }

            }
            if (!znalezionoZmiane)
            {
                foreach (Zmiana z in sterta)
                {
                    if (Zmiana.KeysEqual(dataZmianyPrzycieta, z.DataZmiany))
                    {
                        znalezionoZmiane = true;
                        znalezionaZmiana = z;
                        break;
                    }
                }
            }

            KluczWizyty k = new KluczWizyty(data, _godzOd, _minOd, _godzDo, _minDo);
            return znalezionaZmiana.MoznaDodacWizyte(k);
        }

        internal void ZapiszDaneKonfiguracyjne(string sciezkaFolderuPlikowKonfiguracyjnych)
        {
            BinaryWriter bw = new BinaryWriter(File.Open(sciezkaFolderuPlikowKonfiguracyjnych + @"\buforZmian", FileMode.Truncate));
            bw.Write(godzinaRozpoczeciaPracy.Hour);
            bw.Write(godzinaRozpoczeciaPracy.Minute);
            bw.Write(godzinaZakonczeniaPracy.Hour);
            bw.Write(godzinaZakonczeniaPracy.Minute);
            bw.Write(liczbaZmianWstecz);
            bw.Write(liczbaZmianNaprzod);
            bw.Close();
        }

        private List<Zmiana> sprowadzLubUtworzZmiany2(DateTime dataZmiany, int dniWczesniej, int dniPozniej)
        {
            DateTime dataZmianyPrzycieta = new DateTime(dataZmiany.Year, dataZmiany.Month, dataZmiany.Day);

            DateTime dataDniWczesniej = dataZmianyPrzycieta.AddDays(-dniWczesniej);
            DateTime dataDniPozniej = dataZmianyPrzycieta.AddDays(dniPozniej);
            DateTime iterator = dataDniWczesniej;
            List<Zmiana> sprowadzoneZmiany = new List<Zmiana>();
            while (DateTime.Compare(dataDniPozniej, iterator) >= 0)
            {
                if (!ZmianaWczytanaDoBufora(iterator))
                {
                    string nazwaPlikuZmiany = String.Format("{0:yyyyMMdd}", iterator);
                    if (File.Exists(KatalogGlowny + @"\zmiany\" + nazwaPlikuZmiany))
                    {
                        Zmiana wczytanaZmiana = Zmiana.CzytajZPliku(KatalogGlowny + @"\zmiany\" + nazwaPlikuZmiany, pacjenci, pacjenciUsunieci);
                        sprowadzoneZmiany.Add(wczytanaZmiana);
                        UmiescZmianeWBuforze(wczytanaZmiana);
                    }
                    else
                    {
                        Zmiana nowaZmiana = new Zmiana(iterator);
                        sprowadzoneZmiany.Add(nowaZmiana);
                        UmiescZmianeWBuforze(nowaZmiana);
                    }
                }
                iterator = iterator.AddDays(1);
            }
            return sprowadzoneZmiany;
        }
        internal List<Zmiana> zmianyDoWyswietlenia(DateTime dzienPierwszy)
        {
            sprowadzLubUtworzZmiany(dzienPierwszy, 0, 6);
            List<Zmiana> tydzien = new List<Zmiana>();
            DateTime iterator = new DateTime(dzienPierwszy.Year, dzienPierwszy.Month, dzienPierwszy.Day);
            for(int i=1;i<=7;i++)
            {
                
                Zmiana z = zwrocReferencjeDoZmiany(iterator);
                tydzien.Add(z);
                iterator = iterator.AddDays(1);
            }
            return tydzien;
        }

        private Zmiana zwrocReferencjeDoZmiany(DateTime iterator)
        {
            foreach(Zmiana z in zmianyAktualne)
            {
                if(DateTime.Compare(iterator,z.DataZmiany)<0)
                {
                    break;
                }
                if(DateTime.Compare(iterator,z.DataZmiany)==0)
                {
                    return z;
                }
            }
            foreach(Zmiana z in sterta)
            {
                if(DateTime.Compare(z.DataZmiany, iterator)==0)
                {
                    return z;
                }
            }
            return null;
        }

        private void sprowadzLubUtworzZmiany(DateTime dataZmiany, int dniWczesniej, int dniPozniej)
        {
            
            DateTime dataZmianyPrzycieta = new DateTime(dataZmiany.Year, dataZmiany.Month, dataZmiany.Day);

            DateTime dataDniWczesniej = dataZmianyPrzycieta.AddDays(-dniWczesniej);
            DateTime dataDniPozniej = dataZmianyPrzycieta.AddDays(dniPozniej);
            DateTime iterator = dataDniWczesniej;
            while (DateTime.Compare(dataDniPozniej, iterator) >= 0)
            {
                if (!ZmianaWczytanaDoBufora(iterator))
                {
                    string nazwaPlikuZmiany = String.Format("{0:yyyyMMdd}", iterator);
                    if (File.Exists(KatalogGlowny + @"\zmiany\" + nazwaPlikuZmiany))
                    {
                        Zmiana wczytanaZmiana = Zmiana.CzytajZPliku(KatalogGlowny + @"\zmiany\" + nazwaPlikuZmiany, pacjenci, pacjenciUsunieci);
                        UmiescZmianeWBuforze(wczytanaZmiana);
                    }
                    else
                    {
                        Zmiana nowaZmiana = new Zmiana(iterator);
                        UmiescZmianeWBuforze(nowaZmiana);
                    }
                }
                iterator = iterator.AddDays(1);
            }

        }

        internal Wizyta ZnajdzWizyte(DateTime dataWizyty, DateTime godzinaOd, DateTime godzinaDo)
        {
            Wizyta poszukiwanaWizyta = null;
            KluczWizyty key = new KluczWizyty(dataWizyty, godzinaOd.Hour, godzinaOd.Minute, godzinaDo.Hour, godzinaDo.Minute);
            foreach(Zmiana z in zmianyAktualne)
            {
                if(DateTime.Compare( z.DataZmiany,dataWizyty)>0 )
                {
                    break;
                }
                else if( DateTime.Compare(z.DataZmiany, dataWizyty) == 0 )
                {
                    for(int i=0;i<z.Count; i++)
                    {
                        if(z.ElementAt(i).getKlucz().Equals(key))
                        {
                            poszukiwanaWizyta = new Wizyta(z.ElementAt(i));
                            return poszukiwanaWizyta;
                        }
                    }
                }
            }
            foreach (Zmiana z in sterta)
            {
                
                if (DateTime.Compare(z.DataZmiany, dataWizyty) == 0)
                {
                    for (int i = 0; i < z.Count; i++)
                    {
                        if (z.ElementAt(i).getKlucz().Equals(key))
                        {
                            poszukiwanaWizyta = new Wizyta(z.ElementAt(i));
                            return poszukiwanaWizyta;
                        }
                    }
                }
            }
            return null;
        }

        

        private void UmiescZmianeWBuforze(Zmiana wczytanaZmiana)
        {
            if (sterta.Count == 0)
            {
                sterta.Add(wczytanaZmiana);
                return;
            }
            for (int i = 0; i < sterta.Count; i++)
            {
                if (DateTime.Compare(wczytanaZmiana.DataZmiany, sterta.ElementAt(i).DataZmiany) < 0)
                {
                    sterta.Insert(i, wczytanaZmiana);
                    return;
                }
            }
            sterta.Add(wczytanaZmiana);
        }

        private bool ZmianaWczytanaDoBufora(DateTime data)
        {
            DateTime samaData = new DateTime(data.Year, data.Month, data.Day);
            foreach (Zmiana z in zmianyAktualne)
            {
                DateTime kluczZmiany = z.DataZmiany;
                if (DateTime.Compare(kluczZmiany, samaData) > 0)
                { break; }
                if (DateTime.Compare(kluczZmiany, samaData) == 0)
                {
                    return true;
                }
            }
            foreach (Zmiana z in sterta)
            {
                DateTime kluczZmiany = z.DataZmiany;
                if (DateTime.Compare(kluczZmiany, samaData) > 0)
                { break; }
                if (DateTime.Compare(kluczZmiany, samaData) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        internal void ZapiszNaWizyte(DateTime dataWizyty, Wizyta umowionaWizyta)
        {
            DateTime dataWizytyPrzycieta = new DateTime(dataWizyty.Year, dataWizyty.Month, dataWizyty.Day);
            
            if (!MoznaZapisacNaWizyte(dataWizytyPrzycieta, umowionaWizyta))
            {
                return;
            }
            
            
            foreach (Zmiana z in zmianyAktualne)
            {

                if (Zmiana.KeysEqual(z.DataZmiany, dataWizytyPrzycieta))
                {
                    z.DodajWizyte(umowionaWizyta);
                    return;
                }
            }
            foreach (Zmiana z in sterta)
            {
                if (Zmiana.KeysEqual(z.DataZmiany, dataWizytyPrzycieta))
                {
                    z.DodajWizyte(umowionaWizyta);
                    return;
                }
            }
        }

        

        internal void UsunWizyte(KluczWizyty k)
        {

            DateTime dataZmianyPrzycieta = k.Data;
            bool znalezionoZmiane = false;
            Zmiana zmianaZUsuwanaWizyta = null;
            foreach (Zmiana aktZmiana in zmianyAktualne)
            {
                if (DateTime.Compare(aktZmiana.DataZmiany, dataZmianyPrzycieta) == 0)
                {
                    zmianaZUsuwanaWizyta = aktZmiana;
                    znalezionoZmiane = true;
                    break;
                }
                /*
                if (DateTime.Compare(aktZmiana.DataZmiany, dataZmianyPrzycieta) > 0)
                {
                    break;
                }
                */
            }
            if (!znalezionoZmiane)
            {
                foreach (Zmiana aktZmiana in sterta)
                {
                    if (DateTime.Compare(aktZmiana.DataZmiany, dataZmianyPrzycieta) == 0)
                    {
                        zmianaZUsuwanaWizyta = aktZmiana;
                        znalezionoZmiane = true;
                        break;
                    }
                }
            }
            if(!znalezionoZmiane)
            {
                List<Zmiana> listaZmian =  sprowadzLubUtworzZmiany2(dataZmianyPrzycieta, 3, 3);
                foreach(Zmiana z in listaZmian)
                {
                    if(   DateTime.Compare(z.DataZmiany, dataZmianyPrzycieta)==0      /*   z.DataZmiany == dataZmianyPrzycieta */)
                    {
                        zmianaZUsuwanaWizyta = z;
                        znalezionoZmiane = true;
                        break;
                    }
                }

            }
            
            if (znalezionoZmiane)
            {
                zmianaZUsuwanaWizyta.usunWizyte(k);
            }



        }

        internal void ZapiszZmiany()
        {
            foreach (Zmiana z in zmianyAktualne)
            {
                if (z.Touched)
                {
                    z.ZapiszDoPliku(KatalogGlowny + @"\zmiany\" + z.NazwaPlikuZmiany);
                }
            }
            foreach (Zmiana z in sterta)
            {
                if (z.Touched)
                {
                    z.ZapiszDoPliku(KatalogGlowny + @"\zmiany\" + z.NazwaPlikuZmiany);
                }
            }

        }

        
        internal static List<int> WczytajGodzinyPracyIIlociDni(string sciezka)
        {
            List<int> tablicaDomyslna = new List<int>();
            if (!File.Exists(sciezka))
            {
                tablicaDomyslna.Add(8);
                tablicaDomyslna.Add(0);
                tablicaDomyslna.Add(16);
                tablicaDomyslna.Add(0);
                tablicaDomyslna.Add(20);
                tablicaDomyslna.Add(68);
                return tablicaDomyslna;
         
        }
            BinaryReader br = new BinaryReader(File.Open(sciezka, FileMode.Open));
            tablicaDomyslna.Add(br.ReadInt32());
            tablicaDomyslna.Add( br.ReadInt32() );
            tablicaDomyslna.Add( br.ReadInt32() );
            tablicaDomyslna.Add( br.ReadInt32() );
            tablicaDomyslna.Add( br.ReadInt32() );
            tablicaDomyslna.Add( br.ReadInt32() );
            br.Close();
            return tablicaDomyslna;
            
        }
       
    }
}