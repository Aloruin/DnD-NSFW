using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DnD_0._3
{
    

    public partial class Form1 : Form
    {
        Random kostka = new Random();
        int utok, obrana;
        int x;
        int hpEnemy;
        int hpHrdina, zakladhpHrdina;
        int zraneniHrdiny, zraneneEnemy;
        int heal;
        int mana, EN;
        int p, pl, l, hl, h;
        int zkmin, zkmax, min, max;
        //lvl
        int lvlMec, lvlArmor, lvlRing;
        //kouzla
        int kouzlo,vyleceno,subt,kolo,dmgkolo;

        //up
        int upMec_cena, upMec_mult, upMec;
        int upArmor, upArmor_mult;

        private void rbEnch_CheckedChanged(object sender, EventArgs e)
        {
            kouzlo =2;
        }

        private void rbFireBomb_CheckedChanged(object sender, EventArgs e)
        {
            kouzlo = 3;
        }

        private void rbHeal_CheckedChanged(object sender, EventArgs e)
        {
            kouzlo = 1;
            
        }

        int upRing;
        //zranění
        int zmin_Hrdina, zmax_Hrdina, zkzmin_Hrdina, zkzmax_hrdina;
        //gold
        int gold_invetar, gold_Boj, gold_zkBoj, gold_mult;

        

        private void btnP_Click(object sender, EventArgs e)
        {
            min = zkmin + p;
            max = zkmax + p + 1;
            gold_Boj=5;
        }
        private void btnPL_Click(object sender, EventArgs e)
        {
            min = zkmin + pl;
            max = zkmax + pl + 1;
            gold_mult = 10;
        } 
        private void btnL_Click(object sender, EventArgs e)
        {
            min = zkmin + l;
            max = zkmax + l + 1;
            gold_Boj = 15;
        }

        private void btnHL_Click(object sender, EventArgs e)
        {
            min = zkmin + hl;
            max = zkmax + hl + 1;
            gold_Boj = 30;
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            min = zkmin + h;
            max = zkmax + h + 1;
            gold_Boj = 100;
        }

        
        public Form1()
        {
            InitializeComponent();
        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //mult
            
            p = 0;
            pl = 5;
            l = 15;
            hl = 30;
            h = 180;

            zkmin = 10;
            zkmax = 20;
            lvlMec = lvlMec + upMec;
            lvlArmor = lvlArmor + upArmor;
            lvlRing = lvlRing + upRing;
            

            //ZK_stat Hrdina
            zakladhpHrdina = 1000;
            EN = 5;
            mana = 10;

            //vypsání statu
            hpHrdina = zakladhpHrdina;
            tbHP.Text = hpHrdina.ToString();
            tbMANA.Text = mana.ToString();
            tbEN.Text = EN.ToString();

            //vypsání lvl vybavení
            tbLvMec.Text = lvlMec.ToString();
            tbLvArmor.Text = lvlArmor.ToString();
            tbLvRing.Text = lvlRing.ToString();

            //vypočet zranění hrdiny
            zkzmin_Hrdina = 1;
            zkzmax_hrdina = 7;
            zmin_Hrdina = zkzmin_Hrdina + lvlMec;
            zmax_Hrdina = zkzmax_hrdina + lvlMec;
            zraneniHrdiny = kostka.Next(zmin_Hrdina, zmax_Hrdina + 1);

            //zlato
            gold_invetar = 1000;
            gold_zkBoj = 5;
            gold_Boj = gold_zkBoj + gold_mult;
            tbgold.Text = gold_invetar.ToString();


            rtbInfo.Text = "Vyber lokaci a stiskni pokračovat pro nalezení protivnika.";
            //pbMapa.Image = Image.FromFile(@"C:\Users\ondrej.havlicek\Desktop\dnd2+mapa\dnd2\mapa2.png");
            pbMapa.Image = Image.FromFile(@"C:\Users\Havlas\Desktop\dnd2+mapa\dnd2\mapa2.png");
            pbMapa.SizeMode = PictureBoxSizeMode.StretchImage;


            btnUtok.Width = btnCast.Left = Stat.Width / 2;
            btnCast.Width = Stat.Width / 2;
        }

        private void btnUtok_Click(object sender, EventArgs e)
        {
            
            if (hpHrdina > 0)
            {
                if (hpEnemy > 0)
                {
                    utok = kostka.Next(1, 21);
                    obrana = kostka.Next(1, 21);
                    rtbInfo.Text = "netrefil nikdo";
                    if (utok > obrana)
                    {
                        utok = kostka.Next(1, 21);
                        obrana = kostka.Next(1, 21);
                        //cyklus trvání bonusu
                        do
                        {
                            zraneniHrdiny=zraneniHrdiny + 5;
                        } while (dmgkolo > 0);
                        rtbInfo.Text = ("zásah za " + (zraneniHrdiny));
                        hpEnemy = hpEnemy - zraneniHrdiny;
                        //odečitaní bonusu enchaanntu
                        dmgkolo = dmgkolo - 1;
                        tbHpEnemy.Text = hpEnemy.ToString();
                        if (utok > obrana)
                        {

                            rtbInfo.Text += (" a dostaváš damage za " + (zraneneEnemy));
                            hpHrdina = hpHrdina - zraneneEnemy;
                            tbHP.Text = hpHrdina.ToString();
                        }
                    }
                    else
                    {
                        utok = kostka.Next(1, 21);
                        obrana = kostka.Next(1, 21);
                        if (utok > obrana)
                        {

                            rtbInfo.Text = (" netrefil jsi a dostaváš damage za " + (zraneneEnemy));
                            hpHrdina = hpHrdina - zraneneEnemy;
                            tbHP.Text = hpHrdina.ToString();
                        }
                    }

                }
                else
                {
                    rtbInfo.Text = "nepřitel je mrtev";
                    rtbInfo.Text += " a dostávaš " + (gold_Boj) + " zlata";

                }

            }
            else
            {
                rtbInfo.Text = "Zemřel jsi";
            }
        }

        private void btnCast_Click(object sender, EventArgs e)
        {
            if (kouzlo == 1)
            {
                if (hpHrdina!=zakladhpHrdina)
                {
                    if (mana>0)
                    {
                        mana = mana - 1;
                        tbMANA.Text = mana.ToString();
                        vyleceno = kostka.Next(1, 10);
                        heal = kostka.Next(1, 21);
                    if (heal>19)
                    {
                        vyleceno = vyleceno * 2;
                        hpHrdina = hpHrdina + vyleceno;
                    }
                    if (hpHrdina>zakladhpHrdina)
                    {
                        subt = hpHrdina - zakladhpHrdina;
                        hpHrdina = hpHrdina - subt;
                    }
                    rtbInfo.Text = "byl jsi vylečen za" + vyleceno;
                    tbHP.Text = hpHrdina.ToString();

                    }
                    else
                    {
                    rtbInfo.Text = "Nemáš dostatek many.";
                    }

                }
                else
                {
                    rtbInfo.Text = "Máš maximum životů";
                }
                //heal
                
            }
            else if (kouzlo == 2)
            {
                //schocench
                if (mana>2)
                {
                    mana = mana - 2;
                    tbMANA.Text = mana.ToString();
                    //kolo = 3;
                    dmgkolo = 3;
                    
                }
                else
                {
                    rtbInfo.Text = "Nemáš dostatek many.";
                }
            }
            else if (kouzlo == 3)
            {
                //firebomb
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (hpEnemy < 1)
            {
                gold_invetar = gold_invetar + gold_Boj;
                tbgold.Text = gold_invetar.ToString();
                rtbInfo.Text = "Objevil se nový vyzyvatel";
                hpEnemy = kostka.Next(min, max);
                zraneneEnemy = kostka.Next(3, 7);
                tbHpEnemy.Text = hpEnemy.ToString();

            }
            else
            {
                rtbInfo.Text = "souboj ještě pokračuje";
            }
        }
        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            pbEnemy.Left = (enemy.Width / 2) - (pbEnemy.Width / 2);
            tbHpEnemy.Left = (enemy.Width / 2) - (tbHpEnemy.Width / 2);
            btnUtok.Width = btnCast.Left = Stat.Width / 2;
            btnCast.Width = Stat.Width / 2;

        }
    }
}
