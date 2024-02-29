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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
