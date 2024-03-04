using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_Four_Blackjack
{
    public partial class Form1 : Form
    {
        bool DealtHandToggle = true;
        Random Shuffle = new Random(DateTime.Now.Millisecond);
        int DealtCard;
        bool gameinprogress = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            for (int i = 0;i < 2; i++)
            {
                DealtCard = Shuffle.Next(0, lstDeck.Items.Count);
                lstPlayerHand.Items.Add(lstDeck.Items[DealtCard]);
                lstDeck.Items.Remove(lstDeck.Items[DealtCard]);
                DealtCard = Shuffle.Next(0, lstDeck.Items.Count);
                lstDealerHand.Items.Add(lstDeck.Items[DealtCard]);
                lstDeck.Items.Remove(lstDeck.Items[DealtCard]);
                
            }
            btnDeal.Enabled = false;
            gameinprogress = true;
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
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
           if(gameinprogress == true)
            {
                DealtCard = Shuffle.Next(0, lstDeck.Items.Count);
                lstPlayerHand.Items.Add(lstDeck.Items[DealtCard]);
                lstDeck.Items.Remove(lstDeck.Items[DealtCard]);
                //requires victory check 
                //requires card animation update
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            gameinprogress = false;
            for (int i = 0; i < lstPlayerHand.Items.Count; i++)
            {
                //1stPlayerHand.SelectedIndex = i;
                //int FaceCardCheck = 1stPlayerHand.SelectedItem.ToString().length;
                //MessageBox.Show(1stPlayerHand.SelectedItem.ToString().Substring(0, 2));
                //MessageBox.Show(1stPlayerHand.SelectedItem.ToString().Substring(2, 1));
                //if (FaceCardCheck == 4)
                //{
                //    MessageBox.Show(1stPlayerHand.SelectedItem.ToString().Substring(3, 1));
                //}
            }
            //requires dealer auto-play
        }
    }
}
