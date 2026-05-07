

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private int pocetRadku;
        private int pocetSloupcu;
        private PictureBox[,] gameGrid;
        private int velikostKostickyX; // Velikost jedné kostičky v pixelech na ose x
        private int velikostKostickyY; //Velikost jedné kostičky v pixelech na ose y
        private TypTvaru aktualniTyp;
        private Random rnd = new Random();
        private int pocetClenu;
        public int pocetBodu;
        private string prezdivka;
        List<Hrac> seznamHracu;
        Image obrazekHerce = Image.FromFile(@"C:\Users\JirkaKuta\OneDrive - Univerzita Pardubice\upce\C#\WinFormsApp1\herec.jpg");
        Image ObrazekHomer = Image.FromFile(@"C:\Users\JirkaKuta\OneDrive - Univerzita Pardubice\upce\C#\WinFormsApp1\homer.png");

        // Pro VICE ------- KOSTICEK
        List<Point> aktivniTvar = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Aby formulář zachytil stisky kláves
            pocetRadku = 20;
            pocetSloupcu = 10;
            this.DoubleBuffered = true; // Pro plynulejší vykreslování
            kresliHerniPanel();
            gameGrid = new PictureBox[pocetRadku, pocetSloupcu];
            CreateGrid();
            listView1.Columns.Add("Hráč");
            listView1.Columns.Add("Body");
            kresliHerniPlochu();
            VyberNovyTvar();
            timer1.Interval = 200;
            pocetBodu = 0;
            labelBody.Text = $"{pocetBodu} bodů";
            prezdivka = null;
            listView1.View = View.Details;
            
            seznamHracu = new List<Hrac>();

        }



        private void CreateGrid()
        {


            for (int r = 0; r < pocetRadku; r++) // Řádky
            {
                for (int c = 0; c < pocetSloupcu; c++) // Sloupce
                {
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(velikostKostickyX, velikostKostickyY);
                    pb.Location = new Point(c * velikostKostickyX, r * velikostKostickyY);
                    pb.BackColor = Color.Black; // Pozadí prázdného pole
                    pb.BorderStyle = BorderStyle.FixedSingle; // Aby byla vidět mřížka
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Image = obrazekHerce;
                    pb.Tag = "herec";
                    // Přidáme ho do formuláře a do našeho pole pro pozdější přístup
                    hraciPanel.Controls.Add(pb);
                    gameGrid[r, c] = pb;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            posuv(pocetClenu, e);
            if (e.KeyCode == Keys.R && (aktualniTyp == TypTvaru.Tycka || aktualniTyp == TypTvaru.Elko || aktualniTyp == TypTvaru.SkoroPlusko))
            {
                RotujTvar();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1. Smazání
            foreach (Point p in aktivniTvar)
            {
                gameGrid[p.Y, p.X].Image = obrazekHerce;
                gameGrid[p.Y, p.X].Tag = "herec";
            }

            // 2. Kontrola pádu
            bool muzePadat = true;
            foreach (Point p in aktivniTvar)
            {
                if (p.Y + 1 >= pocetRadku || gameGrid[p.Y + 1, p.X].Tag.ToString() == "homer_fixed")
                {
                    muzePadat = false;
                    break;
                }
            }

            if (muzePadat)
            {
                for (int i = 0; i < aktivniTvar.Count; i++)
                    aktivniTvar[i] = new Point(aktivniTvar[i].X, aktivniTvar[i].Y + 1);

                // --- LOGIKA VYNOŘOVÁNÍ PODLE TYPU ---
                switch (aktualniTyp)
                {
                    case TypTvaru.Kosticka:
                        if (aktivniTvar.Count == 0) aktivniTvar.Add(new Point(5, 0));
                        break;

                    case TypTvaru.Tycka:
                        if (aktivniTvar.Count < 3) aktivniTvar.Add(new Point(5, 0));
                        break;

                    case TypTvaru.Kriz:
                        if (aktivniTvar.Count == 0) aktivniTvar.Add(new Point(5, 0));
                        else if (aktivniTvar.Count == 1)
                        {
                            aktivniTvar.Add(new Point(4, 0));
                            aktivniTvar.Add(new Point(5, 0));
                            aktivniTvar.Add(new Point(6, 0));
                        }
                        else if (aktivniTvar.Count == 4) aktivniTvar.Add(new Point(5, 0));
                        break;

                    case TypTvaru.Elko:
                        if (aktivniTvar.Count == 0)
                        {
                            aktivniTvar.Add(new Point(4, 0));
                            aktivniTvar.Add(new Point(5, 0));
                            aktivniTvar.Add(new Point(6, 0));
                        }
                        else if (aktivniTvar.Count == 3)
                        {
                            aktivniTvar.Add(new Point(4, 0));
                        }
                        else if (aktivniTvar.Count == 4)
                        {
                            aktivniTvar.Add(new Point(4, 0));
                        }
                        break;

                    case TypTvaru.SkoroPlusko:
                        if (aktivniTvar.Count == 0)
                        {
                            aktivniTvar.Add(new Point(5, 0));
                        }
                        else if (aktivniTvar.Count == 1)
                        {
                            aktivniTvar.Add(new Point(5, 0));
                            aktivniTvar.Add(new Point(6, 0));
                        }
                        else if (aktivniTvar.Count == 3)
                        {
                            aktivniTvar.Add(new Point(5, 0));
                        }
                        break;
                }
                VykresliAktivniTvar();
            }
            else
            {
                ZafixujADopln();
            }
        }

        private void RotujTvar()
        {
            if (aktivniTvar.Count < pocetClenu) return; // Čekáme na celý tvar
            Point stred = aktivniTvar[1]; // Střed otáčení (může být upraven podle typu tvaru)
            List<Point> novaPozice = new List<Point>();
            foreach (Point p in aktivniTvar)
            {
                int dx = p.X - stred.X;
                int dy = p.Y - stred.Y;

                int noveX = stred.X - dy;
                int noveY = stred.Y + dx;


                if (noveX < 0 || noveX >= pocetSloupcu || noveY < 0 || noveY >= pocetRadku || gameGrid[noveY, noveX].Tag.ToString() == "homer_fixed")
                {
                    return; // Nelze rotovat kvůli kolizi
                }
                novaPozice.Add(new Point(noveX, noveY));
            }

            foreach (Point p in aktivniTvar)
            {
                gameGrid[p.Y, p.X].Image = obrazekHerce;
                gameGrid[p.Y, p.X].Tag = "herec";
            }

            aktivniTvar = novaPozice;

            VykresliAktivniTvar();
        }



        private void posuv(int pocetClenu, KeyEventArgs e)
        {
            if (aktivniTvar.Count < pocetClenu) return; // Čekáme na celý kříž

            int smerX = 0;
            if (e.KeyCode == Keys.Left) smerX = -1;
            else if (e.KeyCode == Keys.Right) smerX = 1;

            if (smerX != 0)
            {
                // Smazat (přesně jak to máš)
                foreach (Point p in aktivniTvar)
                {
                    gameGrid[p.Y, p.X].Image = obrazekHerce;
                    gameGrid[p.Y, p.X].Tag = "herec";
                }

                // Kontrola kolize pro všech 5 bodů
                bool lzePosunout = true;
                foreach (Point p in aktivniTvar)
                {
                    int noveX = p.X + smerX;
                    if (noveX < 0 || noveX >= pocetSloupcu || gameGrid[p.Y, noveX].Tag.ToString() == "homer_fixed")
                    {
                        lzePosunout = false;
                        break;
                    }
                }

                if (lzePosunout)
                {
                    for (int i = 0; i < aktivniTvar.Count; i++)
                    {
                        aktivniTvar[i] = new Point(aktivniTvar[i].X + smerX, aktivniTvar[i].Y);
                    }
                }

                // Vykreslit (přesně jak to máš)
                foreach (Point p in aktivniTvar)
                {
                    gameGrid[p.Y, p.X].Image = ObrazekHomer;
                    gameGrid[p.Y, p.X].Tag = "homer_pohyblivy";
                }
            }
        }

        private void ZkontrolujSmazaniRad()
        {
            // Projdeme řádky odspoda nahoru
            for (int r = pocetRadku - 1; r >= 0; r--)
            {
                bool jeRadaPlna = true;

                // Zjistíme, jestli jsou v řádku jen fixní Homery
                for (int c = 0; c < pocetSloupcu; c++)
                {
                    if (gameGrid[r, c].Tag.ToString() != "homer_fixed")
                    {
                        jeRadaPlna = false;
                        break;
                    }
                }

                if (jeRadaPlna)
                {
                    // Smažeme aktuální řadu a posuneme vše nad ní dolů
                    OdstranRadu(r);

                    pocetBodu++;
                    if (pocetBodu == 1)
                    {
                        labelBody.Text = $"{pocetBodu} bod";
                    }
                    else if (pocetBodu > 1 && pocetBodu < 5)
                    {
                        labelBody.Text = $"{pocetBodu} body";
                    }
                    else
                    {
                        labelBody.Text = $"{pocetBodu} bodů";
                    }



                    // Protože se vše posunulo dolů, musíme ten samý řádek zkontrolovat znovu
                    r++;
                }
            }
        }

        private void OdstranRadu(int radekKSmazani)
        {
            // Projdeme všechny řádky od toho smazaného směrem nahoru
            for (int r = radekKSmazani; r > 0; r--)
            {
                for (int c = 0; c < pocetSloupcu; c++)
                {
                    // Překopírujeme vzhled a Tag z řádku nad ním
                    gameGrid[r, c].Image = gameGrid[r - 1, c].Image;
                    gameGrid[r, c].Tag = gameGrid[r - 1, c].Tag;
                }
            }

            // Úplně horní řádek (0) musíme vyčistit
            for (int c = 0; c < pocetSloupcu; c++)
            {
                gameGrid[0, c].Image = obrazekHerce;
                gameGrid[0, c].Tag = "herec";
            }
        }

        private void VykresliAktivniTvar()
        {
            foreach (Point p in aktivniTvar)
            {
                gameGrid[p.Y, p.X].Image = ObrazekHomer;
                gameGrid[p.Y, p.X].Tag = "homer_pohyblivy";
            }
        }

        // Pomocná metoda pro zafixování
        private void ZafixujADopln()
        {
            bool prohra = false;
            foreach (Point p in aktivniTvar)
            {
                gameGrid[p.Y, p.X].Image = ObrazekHomer;
                gameGrid[p.Y, p.X].Tag = "homer_fixed";
                if (p.Y == 0) prohra = true;
            }

            aktivniTvar.Clear();
            ZkontrolujSmazaniRad();

            if (prohra)
            {
                timer1.Stop();

                Form2 form2 = new Form2(pocetBodu);
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    Hrac novyHrac = new Hrac(form2.Prezdivka(), pocetBodu);
                    seznamHracu.Add(novyHrac);
                    listView1.Items.Clear();
                    seznamHracu.Sort((h1, h2) => h2.PocetBodu.CompareTo(h1.PocetBodu)); // Seřadí hráče podle bodů sestupně
                    foreach (Hrac hrac in seznamHracu)
                    {
                        ListViewItem radek = new ListViewItem(hrac.Prezdivka);
                        radek.SubItems.Add(hrac.PocetBodu.ToString());
                        listView1.Items.Add(radek);
                    }

                    ResetujHru();
                    return;

                }
            }

            VyberNovyTvar();
        }

        private void VyberNovyTvar()
        {
            int volba = rnd.Next(0, 5);
            aktualniTyp = (TypTvaru)volba;
            if (aktualniTyp == TypTvaru.Kosticka)
            {
                pocetClenu = 0;
            }
            else if (aktualniTyp == TypTvaru.Tycka)
            {
                pocetClenu = 3;
            }
            else if (aktualniTyp == TypTvaru.Kriz)
            {
                pocetClenu = 5;
            }
            else if (aktualniTyp == TypTvaru.Elko)
            {
                pocetClenu = 5;
            }
            else if (aktualniTyp == TypTvaru.SkoroPlusko)
            {
                pocetClenu = 4;
            }
        }


        private void kresliHerniPanel()
        {
            int mezera = 30;
            hraciPanel.Left = mezera;
            hraciPanel.Top = mezera;
            hraciPanel.Width = (int)(this.ClientSize.Width * 0.66);
            hraciPanel.Height = this.ClientSize.Height - 2 * mezera;
            velikostKostickyX = hraciPanel.Width / pocetSloupcu;
            velikostKostickyY = hraciPanel.Height / pocetRadku;
            hraciPanel.Width = velikostKostickyX * pocetSloupcu;
            hraciPanel.Height = velikostKostickyY * pocetRadku;

            navigacniPanel.Left = hraciPanel.Right + mezera;
            navigacniPanel.Top = mezera;
            navigacniPanel.Width = this.ClientSize.Width - navigacniPanel.Left - mezera;
            navigacniPanel.Height = this.ClientSize.Height - 2 * mezera;

        }



        private void kresliHerniPlochu()
        {
            kresliHerniPanel();
            for (int r = 0; r < pocetRadku; r++) // Řádky
            {
                for (int c = 0; c < pocetSloupcu; c++) // Sloupce
                {
                    gameGrid[r, c].Size = new Size(velikostKostickyX, velikostKostickyY);
                    gameGrid[r, c].Location = new Point(c * velikostKostickyX, r * velikostKostickyY);
                }
            }

            

            int mezera2 = 10;
            listView1.Left = mezera2;
            listView1.Top = mezera2;
            listView1.Width = navigacniPanel.Width - 2 * mezera2;
            int listViewVyska = (int)(navigacniPanel.Height * 0.5);
            listView1.Height = listViewVyska;
            if (listView1.Columns.Count > 1) { 
                listView1.Columns[0].Width = (int)(listView1.Width*0.66);
                listView1.Columns[1].Width = -2;  // Tady mám -2 , protože chci, aby druhý sloupec zabral zbytek prostoru
            }
            
            
            float velikostSkore = (float)(navigacniPanel.Width * 0.04);
            labelSkore.Font = new Font("Segoe UI", Math.Max(velikostSkore, 6f), FontStyle.Bold); // 0.04 je 4% šířky navigačního panelu což mi přišlo OK
            labelSkore.Left = (int)(navigacniPanel.Width * 0.25) - (labelSkore.Width / 2);
            labelSkore.Top = 4 * mezera2 + listViewVyska;

            
            float velikostBody = (float)(navigacniPanel.Width * 0.04);
            labelBody.Font = new Font("Segoe UI", Math.Max(velikostBody, 6f), FontStyle.Bold); // 0.04 je 4% šířky navigačního panelu což mi přišlo OK
            labelBody.Left = (int)(navigacniPanel.Width * 0.75) - (labelBody.Width / 2);
            labelBody.Top = 4 * mezera2 + listViewVyska;

            button1.Left = (int)(navigacniPanel.Width * 0.1); // Začne na 10 % šířky
            button1.Width = (int)(navigacniPanel.Width * 0.8); // Bude široké 80 % šířky

            // Umístíme ho 20 pixelů pod labelBody
            button1.Top = labelBody.Bottom + 20;
            button1.Height = (int)(navigacniPanel.Height * 0.1);
            if (button1.Height < 30) button1.Height = 30;

            // Text bude mít velikost cca 3 % šířky panelu
            float velikostPisma = (float)(navigacniPanel.Width * 0.03);
            button1.Font = new Font("Segoe UI", Math.Max(velikostPisma, 8f), FontStyle.Bold);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            kresliHerniPlochu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void ResetujHru()
        {
            for (int r = 0; r < pocetRadku; r++)
            {
                for (int c = 0; c < pocetSloupcu; c++)
                {
                    gameGrid[r, c].Image = obrazekHerce;
                    gameGrid[r, c].Tag = "herec";
                }
            }

            pocetBodu = 0;
            labelBody.Text = $"{pocetBodu} bodů";
            aktivniTvar.Clear();
            button1.Text = "play again";
            VyberNovyTvar();

        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.Selected = false;
        }
    }
}
