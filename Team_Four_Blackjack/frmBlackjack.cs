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
        private string playerName = "Player";
        private bool gameInProgress = false;
        private Random shuffle = new Random(DateTime.Now.Millisecond);
        private List<PictureBox> playerHand = new List<PictureBox>();
        private List<PictureBox> dealerHand = new List<PictureBox>();

        public frmBlackjack()
        {
            InitializeComponent();

            txtPlayerName.Visible = false;
            btnPlayerName.Enabled = false;

            playerHand.AddRange(new PictureBox[] { picPlayerCard1, picPlayerCard2, picPlayerCard3, picPlayerCard4, picPlayerCard5, picPlayerCard6, picPlayerCard7, picPlayerCard8, picPlayerCard9 });
            dealerHand.AddRange(new PictureBox[] { picDealerCard1, picDealerCard2, picDealerCard3, picDealerCard4, picDealerCard5, picDealerCard6, picDealerCard7, picDealerCard8 });
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
                if (txtPlayerName.Text.Trim().Length >= 2)
                {
                    playerName = txtPlayerName.Text.Trim();

                    lblPlayerName.Text = $"Player: {playerName}";

                    txtPlayerName.Visible = false;
                    btnPlayerName.Visible = false;

                    lblPlayerName.Visible = true;

                    txtPlayerName.TextChanged -= txtPlayerName_TextChanged;
                }
                else
                {
                    MessageBox.Show("Please enter a valid name with at least 2 characters before proceeding.");
                }
            }
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            if (!gameInProgress)
            {
                DealInitialCards();
                gameInProgress = true;
                btnDeal.Enabled = false;
                btnClearTable.Enabled = false;
                UpdateDisplayedCards();
            }
        }

        private void DealInitialCards()
        {
            for (int i = 0; i < 2; i++)
            {
                DealCard(lstPlayerHand);
                DealCard(lstDealerHand);
            }
            HandValue(lstPlayerHand, lblPlayerTotal);
            HandValue(lstDealerHand, lblDealerTotal);
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
            btnDeal.Enabled = true;
            btnClearTable.Enabled = false;
            gameInProgress = false;
            UpdateDisplayedCards();
        }

        private void ClearHand(ListBox hand)
        {
            lstDeck.Items.AddRange(hand.Items);
            hand.Items.Clear();
        }

        private void UpdateDisplayedCards()
        {
            UpdateHandDisplay(lstPlayerHand, playerHand);
            UpdateHandDisplay(lstDealerHand, dealerHand);
        }

        private void UpdateHandDisplay(ListBox handList, List<PictureBox> handPictureBoxes)
        {
            for (int i = 0; i < handList.Items.Count; i++)
            {
                handList.SelectedIndex = i;
                string card = handList.SelectedItem.ToString();
                Image cardImage = CardImageGetter(card.Substring(0, 2), card.Substring(2, 1), card.Length == 4 ? card.Substring(3, 1) : null);
                handPictureBoxes[i].Image = cardImage;
                handPictureBoxes[i].Visible = true;
                handPictureBoxes[i].BringToFront();
            }

            for (int i = handList.Items.Count; i < handPictureBoxes.Count; i++)
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
                HandValue(lstPlayerHand, lblPlayerTotal);

                if (GetHandTotal(lstPlayerHand) > 21)
                {
                    MessageBox.Show("Bust! Player total exceeds 21.");
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

                HandValue(lstDealerHand, lblDealerTotal);
                UpdateDisplayedCards();
                DetermineWinner();
                EndGame();
            }
        }

        private void DetermineWinner()
        {
            int playerTotal = GetHandTotal(lstPlayerHand);
            int dealerTotal = GetHandTotal(lstDealerHand);

            lblPlayerTotal.Text = "Player Total: " + playerTotal;
            lblDealerTotal.Text = "Dealer Total: " + dealerTotal;

            if (playerTotal > 21 || (dealerTotal <= 21 && dealerTotal > playerTotal))
            {
                MessageBox.Show("Dealer wins!");
            }
            else if (dealerTotal > 21 || playerTotal > dealerTotal)
            {
                MessageBox.Show("Player wins!");
            }
            else
            {
                MessageBox.Show("It's a tie!");
            }
        }

        private void EndGame(string message = "")
        {
            gameInProgress = false;
            btnDeal.Enabled = true;
            btnClearTable.Enabled = true;
            MessageBox.Show(message, "Game Over");
        }

        private void HandValue(ListBox handList, Label totalLabel)
        {
            int total = GetHandTotal(handList);
            totalLabel.Text = "Total: " + total;
        }

        private int GetHandTotal(ListBox handList)
        {
            int total = 0;
            int numberOfAces = 0;

            for (int i = 0; i < handList.Items.Count; i++)
            {
                handList.SelectedIndex = i;
                int cardValue = GetCardValue(handList.SelectedItem.ToString());

                // Ace always plays as 11
                if (cardValue == 1)
                {
                    cardValue = 11;
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

        private int GetCardValue(string card)
        {
            int value = int.Parse(card.Substring(0, 2));

            // Face cards and 10 have a value of 10
            if (value > 10)
            {
                return 10;
            }
            // Ace has a value of 11
            else if (value == 1)
            {
                return 11;
            }
            // Other cards have their face value
            else
            {
                return value;
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