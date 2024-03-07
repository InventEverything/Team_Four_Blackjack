using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_Four_Blackjack
{
    public partial class frmBlackjack : Form
    {
        bool DealtHandToggle = true;
        Random Shuffle = new Random(DateTime.Now.Millisecond);
        int DealtCard;
        PictureBox[] PlayerHand = new PictureBox[9];
        PictureBox[] DealerHand = new PictureBox[8];

        public frmBlackjack()
        {
            InitializeComponent();
            PlayerHand = new PictureBox[] { picPlayerCard1, picPlayerCard2, picPlayerCard3, picPlayerCard4, picPlayerCard5, picPlayerCard6, picPlayerCard7, picPlayerCard8, picPlayerCard9 };
            DealerHand = new PictureBox[] { picDealerCard1, picDealerCard2, picDealerCard3, picDealerCard4, picDealerCard5, picDealerCard6, picDealerCard7, picDealerCard8 };
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                DealtCard = Shuffle.Next(0, lstDeck.Items.Count);
                lstPlayerHand.Items.Add(lstDeck.Items[DealtCard]);
                lstDeck.Items.Remove(lstDeck.Items[DealtCard]);
                DealtCard = Shuffle.Next(0, lstDeck.Items.Count);
                lstDealerHand.Items.Add(lstDeck.Items[DealtCard]);
                lstDeck.Items.Remove(lstDeck.Items[DealtCard]);
            }
            btnDeal.Enabled = false;
            UpdateDisplayedCards(sender, e);
        }

        private void Clear_Table_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstDealerHand.Items.Count; i++)
            {
                lstDeck.Items.Add(lstDealerHand.Items[i]);
            }
            for (int i = 0; i < lstPlayerHand.Items.Count; i++)
            {
                lstDeck.Items.Add(lstPlayerHand.Items[i]);
            }
            lstPlayerHand.Items.Clear();
            lstDealerHand.Items.Clear();
            btnDeal.Enabled = true;
            btnClearTable.Enabled = false;
            UpdateDisplayedCards(sender, e);
        }
        private void UpdateDisplayedCards(object sender, EventArgs e)
        {
            for (int i = 0; i < lstPlayerHand.Items.Count; i++)
            {
                lstPlayerHand.SelectedIndex = i;
                int FaceCardCheck = lstPlayerHand.SelectedItem.ToString().Length;
                string value = lstPlayerHand.SelectedItem.ToString().Substring(0, 2);
                string suit = lstPlayerHand.SelectedItem.ToString().Substring(2, 1);
                if (FaceCardCheck == 4)
                {
                    string face = lstPlayerHand.SelectedItem.ToString().Substring(3, 1);
                    PlayerHand[i].Image = CardImageGetter(value, suit, face);
                    PlayerHand[i].Visible = true;
                    PlayerHand[i].BringToFront();
                }
                else
                {
                    PlayerHand[i].Image = CardImageGetter(value, suit);
                    PlayerHand[i].Visible = true;
                    PlayerHand[i].BringToFront();
                }
            }
            for (int i = lstPlayerHand.Items.Count; i < 9; i++)
            {
                PlayerHand[i].Image = null;
                PlayerHand[i].Visible = false;
            }
            for (int i = 0; i < lstDealerHand.Items.Count; i++)
            {
                lstDealerHand.SelectedIndex = i;
                int FaceCardCheck = lstDealerHand.SelectedItem.ToString().Length;
                string value = lstDealerHand.SelectedItem.ToString().Substring (0, 2);
                string suit = lstDealerHand.SelectedItem.ToString ().Substring (2, 1);
                if (FaceCardCheck == 4)
                {
                    string face = lstDealerHand.SelectedItem.ToString().Substring(3, 1);
                    DealerHand[i].Image = CardImageGetter (value, suit, face);
                    DealerHand[i].Visible = true;
                    DealerHand[i].BringToFront();
                }
                else
                {
                    DealerHand[i].Image = CardImageGetter(value, suit);
                    DealerHand[i].Visible = true;
                    DealerHand[i].BringToFront();
                }
            }
            for (int i = lstDealerHand.Items.Count; i < 8; i++)
            {
                DealerHand[i].Image = null;
                DealerHand[i].Visible = false;
            }
        }
        private Image CardImageGetter(string value, string suit)
        {
            if (suit == "♥")
            {
                if (value == "02")
                    return Properties.Resources._2_of_hearts;
                else if (value == "03")
                    return Properties.Resources._3_of_hearts;
                else if (value == "04")
                    return Properties.Resources._4_of_hearts;
                else if (value == "05")
                    return Properties.Resources._5_of_hearts;
                else if (value == "06")
                    return Properties.Resources._6_of_hearts;
                else if (value == "07")
                    return Properties.Resources._7_of_hearts;
                else if (value == "08")
                    return Properties.Resources._8_of_hearts;
                else if (value == "09")
                    return Properties.Resources._9_of_hearts;
                else if (value == "10")
                    return Properties.Resources._10_of_hearts;
                else //Ace
                    return Properties.Resources.ace_of_hearts;
            }
            else if (suit == "♦")
            {
                if (value == "02")
                    return Properties.Resources._2_of_diamonds;
                else if (value == "03")
                    return Properties.Resources._3_of_diamonds;
                else if (value == "04")
                    return Properties.Resources._4_of_diamonds;
                else if (value == "05")
                    return Properties.Resources._5_of_diamonds;
                else if (value == "06")
                    return Properties.Resources._6_of_diamonds;
                else if (value == "07")
                    return Properties.Resources._7_of_diamonds;
                else if (value == "08")
                    return Properties.Resources._8_of_diamonds;
                else if (value == "09")
                    return Properties.Resources._9_of_diamonds;
                else if (value == "10")
                    return Properties.Resources._10_of_diamonds;
                else //Ace
                    return Properties.Resources.ace_of_diamonds;
            }
            else if (suit == "♣")
            {
                if (value == "02")
                    return Properties.Resources._2_of_clubs;
                else if (value == "03")
                    return Properties.Resources._3_of_clubs;
                else if (value == "04")
                    return Properties.Resources._4_of_clubs;
                else if (value == "05")
                    return Properties.Resources._5_of_clubs;
                else if (value == "06")
                    return Properties.Resources._6_of_clubs;
                else if (value == "07")
                    return Properties.Resources._7_of_clubs;
                else if (value == "08")
                    return Properties.Resources._8_of_clubs;
                else if (value == "09")
                    return Properties.Resources._9_of_clubs;
                else if (value == "10")
                    return Properties.Resources._10_of_clubs;
                else //Ace
                    return Properties.Resources.ace_of_clubs;
            }
            else //spades
            {
                if (value == "02")
                    return Properties.Resources._2_of_spades;
                else if (value == "03")
                    return Properties.Resources._3_of_spades;
                else if (value == "04")
                    return Properties.Resources._4_of_spades;
                else if (value == "05")
                    return Properties.Resources._5_of_spades;
                else if (value == "06")
                    return Properties.Resources._6_of_spades;
                else if (value == "07")
                    return Properties.Resources._7_of_spades;
                else if (value == "08")
                    return Properties.Resources._8_of_spades;
                else if (value == "09")
                    return Properties.Resources._9_of_spades;
                else if (value == "10")
                    return Properties.Resources._10_of_spades;
                else //Ace
                    return Properties.Resources.ace_of_spades;
            }
        }
        private Image CardImageGetter(string value, string suit, string face)
        {
            if (suit == "♥")
            {
                if (face == "j")
                    return Properties.Resources.jack_of_hearts2;
                else if (face == "q")
                    return Properties.Resources.queen_of_hearts2;
                else //king
                    return Properties.Resources.king_of_hearts2;
            }
            else if (suit == "♦")
            {
                if (face == "j")
                    return Properties.Resources.jack_of_diamonds2;
                else if (face == "q")
                    return Properties.Resources.queen_of_diamonds2;
                else //king
                    return Properties.Resources.king_of_diamonds2;
            }
            else if (suit == "♣")
            {
                if (face == "j")
                    return Properties.Resources.jack_of_clubs2;
                else if (face == "q")
                    return Properties.Resources.queen_of_clubs2;
                else //king
                    return Properties.Resources.king_of_clubs2;
            }
            else //spades
            {
                if (face == "j")
                    return Properties.Resources.jack_of_spades2;
                else if (face == "q")
                    return Properties.Resources.queen_of_spades2;
                else //king
                    return Properties.Resources.king_of_spades2;
            }
        }
    }
}
