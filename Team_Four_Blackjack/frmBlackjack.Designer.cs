namespace Team_Four_Blackjack
{
    partial class frmBlackjack
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstDeck = new System.Windows.Forms.ListBox();
            this.lstDealerHand = new System.Windows.Forms.ListBox();
            this.lstPlayerHand = new System.Windows.Forms.ListBox();
            this.btnTestRandCard = new System.Windows.Forms.Button();
            this.btnClearTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDeck
            // 
            this.lstDeck.FormattingEnabled = true;
            this.lstDeck.Items.AddRange(new object[] {
            "11♥",
            "02♥",
            "03♥",
            "04♥",
            "05♥",
            "06♥",
            "07♥",
            "08♥",
            "09♥",
            "10♥",
            "10j♥",
            "10q♥",
            "10k♥",
            "11♦",
            "02♦",
            "03♦",
            "04♦",
            "05♦",
            "06♦",
            "07♦",
            "08♦",
            "09♦",
            "10♦",
            "10j♦",
            "10q♦",
            "10k♦",
            "11♣",
            "02♣",
            "03♣",
            "04♣",
            "05♣",
            "06♣",
            "07♣",
            "08♣",
            "09♣",
            "10♣",
            "10j♣",
            "10q♣",
            "10k♣",
            "11♠",
            "02♠",
            "03♠",
            "04♠",
            "05♠",
            "06♠",
            "07♠",
            "08♠",
            "09♠",
            "10♠",
            "10j♠",
            "10q♠",
            "10k♠"});
            this.lstDeck.Location = new System.Drawing.Point(735, 12);
            this.lstDeck.Name = "lstDeck";
            this.lstDeck.Size = new System.Drawing.Size(53, 433);
            this.lstDeck.TabIndex = 0;
            // 
            // lstDealerHand
            // 
            this.lstDealerHand.FormattingEnabled = true;
            this.lstDealerHand.Location = new System.Drawing.Point(676, 12);
            this.lstDealerHand.Name = "lstDealerHand";
            this.lstDealerHand.Size = new System.Drawing.Size(53, 433);
            this.lstDealerHand.TabIndex = 1;
            // 
            // lstPlayerHand
            // 
            this.lstPlayerHand.FormattingEnabled = true;
            this.lstPlayerHand.Location = new System.Drawing.Point(617, 12);
            this.lstPlayerHand.Name = "lstPlayerHand";
            this.lstPlayerHand.Size = new System.Drawing.Size(53, 433);
            this.lstPlayerHand.TabIndex = 2;
            // 
            // btnTestRandCard
            // 
            this.btnTestRandCard.Location = new System.Drawing.Point(224, 89);
            this.btnTestRandCard.Name = "btnTestRandCard";
            this.btnTestRandCard.Size = new System.Drawing.Size(75, 23);
            this.btnTestRandCard.TabIndex = 3;
            this.btnTestRandCard.Text = "Deal 1 Card";
            this.btnTestRandCard.UseVisualStyleBackColor = true;
            this.btnTestRandCard.Click += new System.EventHandler(this.btnTestRandCard_Click);
            // 
            // btnClearTable
            // 
            this.btnClearTable.Location = new System.Drawing.Point(224, 145);
            this.btnClearTable.Name = "btnClearTable";
            this.btnClearTable.Size = new System.Drawing.Size(75, 23);
            this.btnClearTable.TabIndex = 4;
            this.btnClearTable.Text = "Clear Table";
            this.btnClearTable.UseVisualStyleBackColor = true;
            this.btnClearTable.Click += new System.EventHandler(this.btnClearTable_Click);
            // 
            // frmBlackjack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClearTable);
            this.Controls.Add(this.btnTestRandCard);
            this.Controls.Add(this.lstPlayerHand);
            this.Controls.Add(this.lstDealerHand);
            this.Controls.Add(this.lstDeck);
            this.Name = "frmBlackjack";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDeck;
        private System.Windows.Forms.ListBox lstDealerHand;
        private System.Windows.Forms.ListBox lstPlayerHand;
        private System.Windows.Forms.Button btnTestRandCard;
        private System.Windows.Forms.Button btnClearTable;
    }
}

