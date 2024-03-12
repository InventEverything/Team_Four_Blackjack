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
        bool gameInProgress = false;
        Random shuffle = new Random(DateTime.Now.Millisecond);
        PictureBox[] PlayerHand = new PictureBox[9];
        PictureBox[] DealerHand = new PictureBox[8];
        string GameOver;
        string PlayerName;
        int PlayerTotal;
        int DealerTotal;
        int DealerScore;
        int PlayerScore;


        public frmBlackjack()
        {
            InitializeComponent();

            txtPlayerName.Visible = false;
            btnPlayerName.Enabled = false;

            PlayerHand = new PictureBox[] { picPlayerCard1, picPlayerCard2, picPlayerCard3, picPlayerCard4, picPlayerCard5, picPlayerCard6, picPlayerCard7, picPlayerCard8, picPlayerCard9 };
            DealerHand = new PictureBox[] { picDealerCard1, picDealerCard2, picDealerCard3, picDealerCard4, picDealerCard5, picDealerCard6, picDealerCard7, picDealerCard8 };
        }

        private void btnSubmitName_Click(object sender, EventArgs e)
        {
            btnSubmitName.Visible = false;

            txtPlayerName.Visible = true;
            btnPlayerName.Visible = true;

            btnPlayerName.Enabled = false;

            txtPlayerName.TextChanged += txtPlayerName_TextChanged;
        }

        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {
            btnPlayerName.Enabled = txtPlayerName.Text.Trim().Length >= 2;
        }

        private void btnPlayerName_Click(object sender, EventArgs e)
        {
            if (btnPlayerName.Enabled)
            {
                    PlayerName = txtPlayerName.Text.Trim();

                    lblPlayerName.Text = $"Player: {PlayerName}";

                    txtPlayerName.Visible = false;
                    btnPlayerName.Visible = false;
                    //Center the player name independent of name length
                    lblPlayerName.Location = new Point(this.Size.Width/2-lblPlayerName.Width/2, 433);
                    lblPlayerName.Visible = true;

                    txtPlayerName.TextChanged -= txtPlayerName_TextChanged;
                    btnDeal.Enabled = true;
            }
            lblPlayerTotal.Text = PlayerName + "'s total: ";
            lblPlayerWL.Text = PlayerName + "'s wins: 0";
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (!gameInProgress)
            {
                DealInitialCards();
                gameInProgress = true;
                btnDeal.Enabled = false;
                btnClearTable.Enabled = false;
                lblGameOver.Visible = false;
                UpdateDisplayedCards();
                DetermineWinner();
                if(DealerTotal==21)
                    EndGame();
            }
        }

        private void DealInitialCards()
        {
            for (int i = 0; i < 2; i++)
            {
                DealCard(lstPlayerHand);
                DealCard(lstDealerHand);
            }
            HandValue();
            DealerHandValue();
        }

        private void DealCard(ListBox hand)
        {
            int dealtCardIndex = shuffle.Next(0, lstDeck.Items.Count);
            hand.Items.Add(lstDeck.Items[dealtCardIndex]);
            lstDeck.Items.RemoveAt(dealtCardIndex);
        }

        private void ClearTable_Click(object sender, EventArgs e)
        {
            ClearHand(lstDealerHand);
            ClearHand(lstPlayerHand);
            HandValue();
            DealerHandValue();
            btnDeal.Enabled = true;
            btnClearTable.Enabled = false;
            lblGameOver.Visible = false;
            lblStatusMessage.Visible = false;
            UpdateDisplayedCards();
        }

        private void ClearHand(ListBox hand)
        {
            lstDeck.Items.AddRange(hand.Items);
            hand.Items.Clear();
        }

        private void UpdateDisplayedCards()
        {
            UpdateHandDisplay(lstPlayerHand, PlayerHand);
            UpdateHandDisplay(lstDealerHand, DealerHand);
        }

        private void UpdateHandDisplay(ListBox handList, PictureBox[] handPictureBoxes)
        {
            for (int i = 0; i < handList.Items.Count; i++)
            {
                handList.SelectedIndex = i;
                string card = handList.SelectedItem.ToString();
                if (card.Length == 4)
                    handPictureBoxes[i].Image = CardImageGetter(card.Substring(0, 2), card.Substring(2, 1), card.Substring(3, 1));
                else
                    handPictureBoxes[i].Image = CardImageGetter(card.Substring(0, 2), card.Substring(2, 1));
                handPictureBoxes[i].Visible = true;
                handPictureBoxes[i].BringToFront();
            }

            for (int i = handList.Items.Count; i < handPictureBoxes.Length; i++)
            {
                handPictureBoxes[i].Image = null;
                handPictureBoxes[i].Visible = false;
            }
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            if (gameInProgress)
            {
                DealCard(lstPlayerHand);
                HandValue();

                if (GetHandTotal(lstPlayerHand) > 21)
                {
                    UpdateDisplayedCards();
                    lblStatusMessage.Text = "Bust! " + PlayerName + "'s total exceeds 21.";
                    lblStatusMessage.Location = new Point(this.Width / 2 - lblStatusMessage.Width / 2, 330);
                    lblStatusMessage.Visible = true;
                    EndGame("Dealer wins!");
                }
                else
                {
                    UpdateDisplayedCards();
                }
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            if (gameInProgress)
            {
                while (GetHandTotal(lstDealerHand) < 17)
                {
                    DealCard(lstDealerHand);
                    UpdateDisplayedCards();
                    System.Threading.Thread.Sleep(500);
                }

                DealerHandValue();
                UpdateDisplayedCards();
                EndGame();
            }
        }

        private void DetermineWinner()
        {
            PlayerTotal = GetHandTotal(lstPlayerHand);
            DealerTotal = GetHandTotal(lstDealerHand);

            if (PlayerTotal > 21 || (DealerTotal <= 21 && DealerTotal > PlayerTotal))
            {
                 GameOver = "Dealer wins!";
            }
            else if (DealerTotal > 21 || PlayerTotal > DealerTotal)
            {
                 GameOver = PlayerName + " wins!";
            }
            else
            {
                 GameOver = "It's a tie!";
            }
        }

        private void EndGame(string message = "")
        {
            DetermineWinner();
            WinLoss(GameOver, PlayerName);
            gameInProgress = false;
            btnDeal.Enabled = false;
            btnClearTable.Enabled = true;
            lblGameOver.Text = "Game Over, " + GameOver;
            lblGameOver.Location = new Point(this.Width / 2 - lblGameOver.Width / 2, 354);
            lblGameOver.Visible = true;
        }

        private void HandValue()
        {
            int total = GetHandTotal(lstPlayerHand);
            lblPlayerTotal.Text = PlayerName + "'s total: " + total;
        }
        private void DealerHandValue()
        {
            int total = GetHandTotal(lstDealerHand);
            lblDealerTotal.Text = "Dealer total: " + total;
        }

        private int GetHandTotal(ListBox handList)
        {
            int total = 0;
            int numberOfAces = 0;

            for (int i = 0; i < handList.Items.Count; i++)
            {
                handList.SelectedIndex = i;
                int cardValue = int.Parse(handList.SelectedItem.ToString().Substring(0,2));

                // Ace always plays as 11
                if (cardValue == 11)
                {
                    numberOfAces++;
                }

                total += cardValue;
            }

            // Adjust the value of Aces if the total exceeds 21
            while (total > 21 && numberOfAces > 0)
            {
                total -= 10; // Convert an Ace from 11 to 1
                numberOfAces--;
            }

            return total;
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

        private void WinLoss(string gameover, string playername)
        {
            if(gameover == "Dealer wins!")
            {
                DealerScore++;
                lblDealerWL.Text = "Dealer wins: " + DealerScore;
            }
            else if (gameover == playername + " wins!")
            {
                PlayerScore++;
                lblPlayerWL.Text = playername + " wins: " + PlayerScore;
            }
            else if (gameover == "It's a tie!")
            {
                return;
            }


        }
    }
}