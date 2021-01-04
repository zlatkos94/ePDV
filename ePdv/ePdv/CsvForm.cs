using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ePdv
{
    public partial class CsvForm : Form
    {
        StoredProcedure sp = new StoredProcedure();

        public CsvForm()
        {
            InitializeComponent();
        }

        private void btnCsv_Click(object sender, EventArgs e)
        {
            DateTime datumKreiranja = DateTime.Now;

            var datum = PoreskiPeriod.Value;

            string poreskiPeriod = PoreskiPeriod.Value.ToString("yyMM");

            var startOfMonth = new DateTime(datum.Year, datum.Month, 1);
            var DaysInMonth = DateTime.DaysInMonth(datum.Year, datum.Month);
            var lastDay = new DateTime(datum.Year, datum.Month, DaysInMonth);

            var kontrolaPDV = sp.KontrolaPDV(startOfMonth, lastDay);


            List<string> ListakontrolaPDV = new List<string>();

            foreach (DataRow row in kontrolaPDV.Rows)
            {
                string naziv_partnera = row["naziv_partnera"].ToString();

                //string mjesto = row["mjesto"].ToString();

                string porezni_broj = row["porezni_broj"].ToString();

                string jib = row["identifikacijski_broj"].ToString();

                if (porezni_broj.Length > 12 || jib.Length > 13)
                {
                    ListakontrolaPDV.Add(naziv_partnera);

                }
            }

            if (ListakontrolaPDV.Any())

            {
                MessageBox.Show("Navedeni partneri imaju JIB broj veći od 13 ili PDV broj veći od 12, te Vas molimo da promjenite podatke da bi mogli izgenerirat CSV dokument \n\n" + string.Join(Environment.NewLine, ListakontrolaPDV.ToArray()), "UPOZORENJE !!!");
            }

            else
            {
                sp.Insert_eNabavke(poreskiPeriod, startOfMonth, lastDay);

                sp.Insert_eZaglavlje(poreskiPeriod, datumKreiranja);

                var eNabavke = sp.DohvatiEnabavke();

                var eNabavkeZaglavlje = sp.DohvatiEnabavkeZaglavlje();

                var sumEnabavke = sp.SumEnabavke();

                Preview.PregledEnabavkeZaglavlje = eNabavkeZaglavlje;

                Preview.PregledEnabavke = eNabavke;

                Preview.PregledEnabavkeSum = sumEnabavke;


                if (eNabavke.Rows.Count == 0 || eNabavke == null || eNabavke.Rows == null)
                {
                    MessageBox.Show("Za navedeni mjesec nema podataka");
                }

                else
                {

                    var kontrolaEnabavke = sp.KontrolaEnabavke(startOfMonth, lastDay);


                    List<string> listaDobavljacaBezSjedistaNabavke = new List<string>();

                    List<string> listaDobavljacaBezValidnogPdvBrojaNabavke = new List<string>();

                    List<string> listaDobavljacaBezValidnogIdentifikacijskogBroja = new List<string>();

                    List<string> listaDobavljacaBezValidnogPDViJIBbroja = new List<string>(); //svaka firma koja ima pdv broj mora imati i jib broj


                    foreach (DataRow row in kontrolaEnabavke.Rows)
                    {
                        string pdv_broj = row["Porezni_broj"].ToString();

                        string sjediste = row["mjesto"].ToString();

                        string dobavljac = row["Naziv_partnera"].ToString();

                        string identifikacijski_broj = row["identifikacijski_broj"].ToString();

                        if (String.IsNullOrEmpty(sjediste))
                        {
                            listaDobavljacaBezSjedistaNabavke.Add(dobavljac);
                        }

                        if (pdv_broj.Length != 12 && pdv_broj.Length != 0)
                        {
                            listaDobavljacaBezValidnogPdvBrojaNabavke.Add(dobavljac);
                        }

                        if (identifikacijski_broj.Length != 13 && identifikacijski_broj.Length != 0)
                        {
                            listaDobavljacaBezValidnogIdentifikacijskogBroja.Add(dobavljac);
                        }

                        if ((!String.IsNullOrEmpty(pdv_broj) && String.IsNullOrEmpty(identifikacijski_broj)) || (String.IsNullOrEmpty(pdv_broj) && !String.IsNullOrEmpty(identifikacijski_broj)))
                        {
                            listaDobavljacaBezValidnogPDViJIBbroja.Add(dobavljac);
                        }
                    }

                    if (listaDobavljacaBezValidnogPDViJIBbroja.Any())
                    {
                        MessageBox.Show("Dobavljač koji ima PDV broj mora imati JIB broj, i obrnuto.\nDobavljači koji nemaju navedenu karakteristiku: \n\n" + string.Join(Environment.NewLine, listaDobavljacaBezValidnogPDViJIBbroja.ToArray()), "UPOZORENJE !!!");

                    }

                    if (listaDobavljacaBezSjedistaNabavke.Any() || listaDobavljacaBezValidnogPdvBrojaNabavke.Any() || listaDobavljacaBezValidnogIdentifikacijskogBroja.Any())

                    {
                        if (listaDobavljacaBezSjedistaNabavke.Any())

                        {
                            MessageBox.Show("Naziv dobavljača mora sadržavati sjedište.\n Navedeni dobavljači nemaju sjedište: \n\n" + string.Join(Environment.NewLine, listaDobavljacaBezSjedistaNabavke.ToArray()), "UPOZORENJE !!!");

                        }

                        if (listaDobavljacaBezValidnogPdvBrojaNabavke.Any())
                        {
                            MessageBox.Show("PDV broj sadrži (12 znamenkasti broj).\n Navedeni dobavljači nemaju ispravan PDV broj: \n\n" + string.Join(Environment.NewLine, listaDobavljacaBezValidnogPdvBrojaNabavke.ToArray()), "UPOZORENJE !!!");

                        }
                        if (listaDobavljacaBezValidnogIdentifikacijskogBroja.Any())
                        {
                            MessageBox.Show("JIB broj sadrži (13 znamenkasti broj).\n Navedeni dobavljači nemaju ispravan JIB broj: \n\n" + string.Join(Environment.NewLine, listaDobavljacaBezValidnogIdentifikacijskogBroja.ToArray()), "UPOZORENJE !!!");

                        }

                    }



                    FolderBrowserDialog fbd = new FolderBrowserDialog();

                    fbd.SelectedPath = $"C:";

                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                    {

                        string path = fbd.SelectedPath;

                        try
                        {
                            string filePath = $"{path}{"\\"}{eNabavkeZaglavlje.Rows[0][1].ToString()}_{eNabavkeZaglavlje.Rows[0][2].ToString()}_{eNabavkeZaglavlje.Rows[0][3].ToString()}_{eNabavkeZaglavlje.Rows[0][4].ToString()}.csv";

                            if (File.Exists(filePath))
                            {

                                File.Delete(filePath);

                                StreamWriter sw = new StreamWriter(File.Open(filePath, FileMode.CreateNew), Encoding.Default, 1000000);
                                //headers  
                                foreach (DataRow dr in eNabavkeZaglavlje.Rows)
                                {
                                    for (int i = 0; i < eNabavkeZaglavlje.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();
                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < eNabavkeZaglavlje.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }

                                foreach (DataRow dr in eNabavke.Rows)
                                {
                                    for (int i = 0; i < eNabavke.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {

                                            var test = dr[i];
                                            string value = dr[i].ToString();



                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);

                                                // sw.Write(test);

                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());

                                                // sw.Write(test);

                                            }
                                        }
                                        if (i < eNabavke.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }
                                foreach (DataRow dr in sumEnabavke.Rows)
                                {
                                    for (int i = 0; i < sumEnabavke.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();
                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < sumEnabavke.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }
                                sw.Close();

                                //MessageBox.Show("Datoteka uspješno kreirana. Nalazi se na lokaciji: \n" + filePath);
                            }
                            else
                            {
                                StreamWriter sw = new StreamWriter(File.Open(filePath, FileMode.CreateNew), Encoding.Default, 1000000);
                                //headers  
                                foreach (DataRow dr in eNabavkeZaglavlje.Rows)
                                {
                                    for (int i = 0; i < eNabavkeZaglavlje.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();
                                            if (value.Contains(';'))
                                            {
                                                //value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < eNabavkeZaglavlje.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                }
                                sw.Write(sw.NewLine);
                                foreach (DataRow dr in eNabavke.Rows)
                                {
                                    for (int i = 0; i < eNabavke.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();

                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < eNabavke.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }
                                foreach (DataRow dr in sumEnabavke.Rows)
                                {
                                    for (int i = 0; i < sumEnabavke.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();
                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < sumEnabavke.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }
                                sw.Close();

                                // MessageBox.Show("Datoteka uspješno kreirana. Nalazi se na lokaciji: \n" + filePath);

                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("Csv sa istim nazivom je trenutno u uporabi, molimo izgasite Csv datoteku.");
                        }





                        //eIsporuke
                        sp.Insert_eIsporuke(poreskiPeriod, startOfMonth, lastDay);

                        var eIsporuke = sp.Dohvati_eIsporuke();

                        var eIsporukeZaglavlje = sp.Dohvati_eIsporukeZaglavlje();

                        var sum_eIsporuke = sp.Sum_eIsporuke();

                        Preview.PregledEisporukeZaglavlje = eIsporukeZaglavlje;

                        Preview.PregledEisporuke = eIsporuke;

                        Preview.PregledEisporukeSum = sum_eIsporuke;


                        var kontrolaEisporuke = sp.KontrolaEisporuke(startOfMonth, lastDay);

                        List<string> listaDobavljacaBezSjedistaIsporuke = new List<string>();

                        List<string> listaDobavljacaBezValidnogPdvBrojaIsporuke = new List<string>();

                        List<string> listaDobavljacaBezValidnogIdentifikacijskogBrojaIsporuke = new List<string>();


                        foreach (DataRow row in kontrolaEisporuke.Rows)
                        {
                            string pdv_broj = row["Porezni_broj"].ToString();

                            string sjediste = row["mjesto"].ToString();

                            string dobavljac = row["naziv_partnera"].ToString();

                            string identifikacijski_broj = row["identifikacijski_broj"].ToString();

                            if (String.IsNullOrEmpty(sjediste))
                            {
                                listaDobavljacaBezSjedistaIsporuke.Add(dobavljac);
                            }


                            if (pdv_broj.Length != 12 && pdv_broj.Length != 0)
                            {
                                listaDobavljacaBezValidnogPdvBrojaIsporuke.Add(dobavljac);
                            }

                            if (identifikacijski_broj.Length != 13 && identifikacijski_broj.Length != 0)
                            {
                                listaDobavljacaBezValidnogIdentifikacijskogBrojaIsporuke.Add(dobavljac);
                            }

                        }

                        if (listaDobavljacaBezSjedistaIsporuke.Any() || listaDobavljacaBezValidnogPdvBrojaIsporuke.Any() || listaDobavljacaBezValidnogIdentifikacijskogBrojaIsporuke.Any())

                        {
                            if (listaDobavljacaBezSjedistaIsporuke.Any())

                            {
                                MessageBox.Show("Naziv dobavljača mora sadržavati sjedište.\n Navedeni dobavljači nemaju sjedište: \n\n" + string.Join(Environment.NewLine, listaDobavljacaBezSjedistaIsporuke.ToArray()), "UPOZORENJE !!!");

                            }

                            if (listaDobavljacaBezValidnogPdvBrojaIsporuke.Any())
                            {
                                MessageBox.Show("PDV broj sadrži (12 znamenkasti broj).\n Navedeni dobavljači nemaju ispravan PDV broj: \n\n" + string.Join(Environment.NewLine, listaDobavljacaBezValidnogPdvBrojaIsporuke.ToArray()), "UPOZORENJE !!!");

                            }
                            if (listaDobavljacaBezValidnogIdentifikacijskogBrojaIsporuke.Any())
                            {
                                MessageBox.Show("JIB broj sadrži (13 znamenkasti broj).\n Navedeni dobavljači nemaju ispravan JIB broj: \n\n" + string.Join(Environment.NewLine, listaDobavljacaBezValidnogIdentifikacijskogBrojaIsporuke.ToArray()), "UPOZORENJE !!!");

                            }

                        }



                        try
                        {
                            string filePath = $"{path}{"\\"}{eIsporukeZaglavlje.Rows[0][1].ToString()}_{eIsporukeZaglavlje.Rows[0][2].ToString()}_{eIsporukeZaglavlje.Rows[0][3].ToString()}_{eIsporukeZaglavlje.Rows[0][4].ToString()}.csv";

                            if (File.Exists(filePath))
                            {

                                File.Delete(filePath);

                                StreamWriter sw = new StreamWriter(File.Open(filePath, FileMode.CreateNew), Encoding.Default, 1000000);
                                //headers  
                                foreach (DataRow dr in eIsporukeZaglavlje.Rows)
                                {
                                    for (int i = 0; i < eIsporukeZaglavlje.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();
                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < eIsporukeZaglavlje.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }

                                foreach (DataRow dr in eIsporuke.Rows)
                                {
                                    for (int i = 0; i < eIsporuke.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();
                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < eIsporuke.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }
                                foreach (DataRow dr in sum_eIsporuke.Rows)
                                {
                                    for (int i = 0; i < sum_eIsporuke.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();
                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < sum_eIsporuke.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }
                                sw.Close();

                                MessageBox.Show($"Csv dokumenti za {datum.ToString("MMMM-yyyy")} godinu uspješno kreirani.\nNalaze se na lokaciji:" + path);
                            }
                            else
                            {
                                StreamWriter sw = new StreamWriter(File.Open(filePath, FileMode.CreateNew), Encoding.Default, 1000000);
                                //headers  
                                foreach (DataRow dr in eIsporukeZaglavlje.Rows)
                                {
                                    for (int i = 0; i < eIsporukeZaglavlje.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();
                                            if (value.Contains(';'))
                                            {
                                                //value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < eIsporukeZaglavlje.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                }
                                sw.Write(sw.NewLine);
                                foreach (DataRow dr in eIsporuke.Rows)
                                {
                                    for (int i = 0; i < eIsporuke.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();

                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < eIsporuke.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }
                                foreach (DataRow dr in sum_eIsporuke.Rows)
                                {
                                    for (int i = 0; i < sum_eIsporuke.Columns.Count; i++)
                                    {
                                        if (!Convert.IsDBNull(dr[i]))
                                        {
                                            string value = dr[i].ToString();
                                            if (value.Contains(';'))
                                            {
                                                value = String.Format("\"{0}\"", value);
                                                sw.Write(value);
                                            }
                                            else
                                            {
                                                sw.Write(dr[i].ToString());
                                            }
                                        }
                                        if (i < sum_eIsporuke.Columns.Count - 1)
                                        {
                                            sw.Write(";");
                                        }
                                    }
                                    sw.Write(sw.NewLine);
                                }
                                sw.Close();

                                MessageBox.Show($"Csv dokumenti za {datum.ToString("MMMM-yyyy")} uspješno kreirani.\n Nalaze se na lokaciji:" + path);

                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("Csv sa istim nazivom je trenutno u uporabi, molimo izgasite Csv datoteku.");
                        }
                    }
                }
            }



            //var kontrolaEnabavke = sp.KontrolaEnabavke(startOfMonth, lastDay);

            //var kontrolaEisporuke = sp.KontrolaEisporuke(startOfMonth, lastDay);


            //List<string> listaDobavljacaBezSjedista = new List<string>();

            //List<string> listaDobavljacaBezValidnogPdvBroja = new List<string>();

            //foreach (DataRow row in kontrolaEnabavke.Rows)
            //{
            //    string pdv_broj = row["Porezni_broj"].ToString();

            //    string sjediste = row["mjesto"].ToString();

            //    string dobavljac = row["Naziv_partnera"].ToString();

            //    if (String.IsNullOrEmpty(sjediste))
            //    {
            //        listaDobavljacaBezSjedista.Add(dobavljac);
            //    }

            //    var pdv_kontrola = pdv_broj.Length;

            //    if (pdv_kontrola != 12)
            //    {
            //        listaDobavljacaBezValidnogPdvBroja.Add(dobavljac);
            //    }

            //}

            //if (!listaDobavljacaBezSjedista.Any() && !listaDobavljacaBezValidnogPdvBroja.Any())

            //{
            //    MessageBox.Show("Dobro je");
            //}

            //else
            //{
            //    MessageBox.Show("Naziv dobavljača mora sadržavati sjedište.\n Navedeni dobavljači nemaju sjedište: \n\n" + string.Join(Environment.NewLine, listaDobavljacaBezSjedista), "UPOZORENJE !!!");
            //    MessageBox.Show("PDV broj sadrži (12 znamenkasti broj).\n Navedeni dobavljači nemaju ispravan PDV broj: \n\n" + string.Join(Environment.NewLine, listaDobavljacaBezValidnogPdvBroja), "UPOZORENJE !!!");
            //}

            this.Close();
        }
        public void SetMyCustomFormat()
        {
            PoreskiPeriod.Format = DateTimePickerFormat.Custom;
            PoreskiPeriod.CustomFormat = "MM/yyyy";
        }

        private void CsvForm_Load(object sender, EventArgs e)
        {
            SetMyCustomFormat();
        }
    }
}
