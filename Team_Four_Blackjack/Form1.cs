using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_Four_Blackjack
{
    public partial class frmBJ : Form
    {
        bool DealtHandToggle = true;
        Random Shuffle = new Random(DateTime.Now.Millisecond);
        int DealtCard;

        public frmBJ()
        {
            InitializeComponent();
        }

        private void btnTestRandCard_Click(object sender, EventArgs e)
        {
            DealtCard = Shuffle.Next(0, lstDeck.Items.Count);
            if (DealtHandToggle)
            {
                lstPlayerHand.Items.Add(lstDeck.Items[DealtCard]);
                lstDeck.Items.Remove(lstDeck.Items[DealtCard]);
                DealtHandToggle = false;
            }
            else
            {
                lstDealerHand.Items.Add(lstDeck.Items[DealtCard]);
                lstDeck.Items.Remove(lstDeck.Items[DealtCard]);
                DealtHandToggle = true;
            }
        }

        private void btnClearTable_Click(object sender, EventArgs e)
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
        }
    }
}
