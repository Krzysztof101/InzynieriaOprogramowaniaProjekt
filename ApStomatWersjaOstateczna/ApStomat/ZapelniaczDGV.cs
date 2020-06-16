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
    
    internal class ZapelniaczDGV
    {
        DateTime pierwszyWyswietlanyDzien;
        DataGridView DGVgrafik;
        BuforZmian bufZmian;
        List<Zmiana> tydzien;





        public DateTime PierwszyWyswietlanyDzien { get { return new DateTime(pierwszyWyswietlanyDzien.Year, pierwszyWyswietlanyDzien.Month, pierwszyWyswietlanyDzien.Day, 0, 0, 0); } }




        DateTime najwczesniejszaGodzina, najpozniejszaGodzina;
        public DateTime NajwczesniejszaGodzina
        {
            get
            {
                return new DateTime(najwczesniejszaGodzina.Year, najwczesniejszaGodzina.Month, najwczesniejszaGodzina.Day,
              najwczesniejszaGodzina.Hour, najwczesniejszaGodzina.Minute, najwczesniejszaGodzina.Second);
            }
        }
        public DateTime NajpozniejszaGodzina
        {
            get
            {
                return new DateTime(najpozniejszaGodzina.Year, najpozniejszaGodzina.Month,
           najpozniejszaGodzina.Day, najpozniejszaGodzina.Hour, najpozniejszaGodzina.Minute,
           najpozniejszaGodzina.Second);
            }
        }










        internal ZapelniaczDGV(DateTime pierwszyWyswietlanyDzien, BuforZmian bufor, DataGridView grafik)
        {

            this.pierwszyWyswietlanyDzien = new DateTime(pierwszyWyswietlanyDzien.Year, pierwszyWyswietlanyDzien.Month, pierwszyWyswietlanyDzien.Day);
            this.DGVgrafik = grafik;
            tydzien = new List<Zmiana>();
            bufZmian = bufor;
            tydzien = bufor.zmianyDoWyswietlenia(this.pierwszyWyswietlanyDzien);
            zapelnijDGV();
            for (int i = 0; i < grafik.Columns.Count; i++)
            {
                grafik.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }










            ustawNajWczesniejszaINajpozniejszaGodzine();
        }











        private void ustawNajWczesniejszaINajpozniejszaGodzine()
        {
            DateTime t1 = bufZmian.GodzinaRozpoczeciaPracy;
            DateTime t2 = bufZmian.GodzinaZakonczeniaPracy;

            najwczesniejszaGodzina = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                                                  t1.Hour, t1.Minute, t1.Second);
            najpozniejszaGodzina = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                                                  t2.Hour, t2.Minute, t2.Second);


            foreach (Zmiana z in tydzien)
            {

                if (z.Count > 0)
                {


                    //if (DateTime.Compare( z.ElementAt(0).DataWizytyOd, najwczesniejszaGodzina) < 0 )
                    if (najwczesniejszaGodzina.Hour > z.ElementAt(0).GodzOd || (najwczesniejszaGodzina.Hour == z.ElementAt(0).GodzOd &&
                                                                                najwczesniejszaGodzina.Minute > z.ElementAt(0).MinOd))
                    {
                        DateTime tmp = z.ElementAt(0).DataWizytyOd;
                        DateTime tmp2 = z.DataZmiany;
                        najwczesniejszaGodzina = new DateTime(tmp2.Year, tmp2.Month, tmp2.Day,
                                                                tmp.Hour, tmp.Minute, tmp.Second);
                    }
                    //if (DateTime.Compare(z.ElementAt( z.Count -1 ).DataWizytyDo, najpozniejszaGodzina) > 0)
                    if (z.ElementAt(z.Count - 1).GodzDo > najpozniejszaGodzina.Hour || (z.ElementAt(z.Count - 1).GodzDo == najpozniejszaGodzina.Hour &&
                             z.ElementAt(z.Count - 1).MinDo > najpozniejszaGodzina.Minute))
                    {
                        DateTime tmp = z.ElementAt(z.Count - 1).DataWizytyDo;
                        DateTime tmp2 = z.DataZmiany;
                        najpozniejszaGodzina = new DateTime(tmp2.Year, tmp2.Month, tmp2.Day,
                                                                tmp.Hour, tmp.Minute, tmp.Second);
                    }
                }
            }
        }



        internal void zapelnijDGV()
        {

            DGVgrafik.Rows.Clear();
            int jednCzasu = 15;



            String[,] tablica = new string[24 * 4, 8];
            int[,] tablicaKolorow = new int[24 * 4, 8];
   
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                for (int j = 1; j < tablica.GetLength(1); j++)
                {
                    tablica[i, j] = "";
                    tablicaKolorow[i, j] = 0;


                }
            }
            DateTime pred = new DateTime(2000, 1, 1, 0, 0, 0);
            DateTime succ = new DateTime(2000, 1, 1, 0, 15, 0);
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                tablica[i, 0] = String.Format("{0:HH:mm}", pred) + "-" + String.Format("{0:HH:mm}", succ);
                tablicaKolorow[i, 0] = 0;

                pred = succ;
                succ = succ.AddMinutes(15);
            }
            DGVgrafik.Columns[0].HeaderText = "godziny";
            for (int i = 0; i < tydzien.Count; i++)
            {
                int[] kodyKolorow = tydzien.ElementAt(i).zapelnijTabliceStringGrafiku(tablica, i + 1,tablicaKolorow);
                for(int klkl= 0;klkl < tablicaKolorow.GetLength(0); klkl++)
                {
                    tablicaKolorow[klkl, i + 1] = kodyKolorow[klkl];
                }
            }
            for (int i = 0; i < tydzien.Count; i++)
            {
                DGVgrafik.Columns[i + 1].HeaderText = String.Format("{0:dd/MM/yyyy}", tydzien.ElementAt(i).DataZmiany);
            }

            int poczatkowyWiersz = 0;
            DateTime dolnaGranica = bufZmian.GodzinaRozpoczeciaPracy;
            DateTime itr = new DateTime(dolnaGranica.Year, dolnaGranica.Month, dolnaGranica.Day, 0, 0, 0);
            while (poczatkowyWiersz < tablica.GetLength(0) && DateTime.Compare(dolnaGranica, itr) > 0 && wierszPusty(tablica, poczatkowyWiersz))
            {
                poczatkowyWiersz++;
                itr = itr.AddMinutes(15);
            }
            DateTime gornaGranica = bufZmian.GodzinaZakonczeniaPracy;
            int koncowyWiersz = tablica.GetLength(0) - 1;
            DateTime itr2 = new DateTime(dolnaGranica.Year, dolnaGranica.Month, dolnaGranica.Day, 23, 45, 0);
            itr2 = itr2.AddMinutes(15);
            while (koncowyWiersz > poczatkowyWiersz && DateTime.Compare(itr2, gornaGranica) > 0 && wierszPusty(tablica, koncowyWiersz))
            {
                koncowyWiersz--;
                itr2 = itr2.AddMinutes(-15);
            }
            int k = 0;


            

                for (int i = poczatkowyWiersz; i <= koncowyWiersz; i++)
                {
                    DGVgrafik.Rows.Add();
                    for (int j = 0; j < tablica.GetLength(1); j++)
                    {
                        DGVgrafik.Rows[k].Cells[j].Value = tablica[i, j];

                        if (tablicaKolorow[i, j] == 1)
                        {
                            DGVgrafik.Rows[k].Cells[j].Style.BackColor = Color.LightBlue;
                        }
                        else if (tablicaKolorow[i, j] == 2)
                        {
                            DGVgrafik.Rows[k].Cells[j].Style.BackColor = Color.LightGreen;
                        }

                    }
                    k++;
                }





            ustawNajWczesniejszaINajpozniejszaGodzine();

        }

        private bool wierszPusty(string[,] tablica, int poczatkowyWiersz)
        {
            for(int i=1; i< tablica.GetLength(1); i++)
            {
                if(tablica[poczatkowyWiersz,i]!="")
                {
                    return false;
                }
            }
            return true;
        }

        internal void dzienPozniej()
        {
            pierwszyWyswietlanyDzien = pierwszyWyswietlanyDzien.AddDays(1);
            tydzien = bufZmian.zmianyDoWyswietlenia(pierwszyWyswietlanyDzien);
            zapelnijDGV();
        }
        internal void dzienWczesniej()
        {
            pierwszyWyswietlanyDzien = pierwszyWyswietlanyDzien.AddDays(-1);
            tydzien = bufZmian.zmianyDoWyswietlenia(pierwszyWyswietlanyDzien);
            zapelnijDGV();
        }
        internal void pokazDzien(DateTime dzienDoPokazania)
        {
            DateTime dzienDoPokazaniaPrzyciety = dzienDoPokazania.Date;
            pierwszyWyswietlanyDzien = dzienDoPokazaniaPrzyciety.AddDays(-3);
            tydzien = bufZmian.zmianyDoWyswietlenia(pierwszyWyswietlanyDzien);
            zapelnijDGV();
        }


    }
}



