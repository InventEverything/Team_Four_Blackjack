namespace Team_Four_Blackjack
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            resources.GetString("lstDeck.Items"),
            resources.GetString("lstDeck.Items1"),
            resources.GetString("lstDeck.Items2"),
            resources.GetString("lstDeck.Items3"),
            resources.GetString("lstDeck.Items4"),
            resources.GetString("lstDeck.Items5"),
            resources.GetString("lstDeck.Items6"),
            resources.GetString("lstDeck.Items7"),
            resources.GetString("lstDeck.Items8"),
            resources.GetString("lstDeck.Items9"),
            resources.GetString("lstDeck.Items10"),
            resources.GetString("lstDeck.Items11"),
            resources.GetString("lstDeck.Items12"),
            resources.GetString("lstDeck.Items13"),
            resources.GetString("lstDeck.Items14"),
            resources.GetString("lstDeck.Items15"),
            resources.GetString("lstDeck.Items16"),
            resources.GetString("lstDeck.Items17"),
            resources.GetString("lstDeck.Items18"),
            resources.GetString("lstDeck.Items19"),
            resources.GetString("lstDeck.Items20"),
            resources.GetString("lstDeck.Items21"),
            resources.GetString("lstDeck.Items22"),
            resources.GetString("lstDeck.Items23"),
            resources.GetString("lstDeck.Items24"),
            resources.GetString("lstDeck.Items25"),
            resources.GetString("lstDeck.Items26"),
            resources.GetString("lstDeck.Items27"),
            resources.GetString("lstDeck.Items28"),
            resources.GetString("lstDeck.Items29"),
            resources.GetString("lstDeck.Items30"),
            resources.GetString("lstDeck.Items31"),
            resources.GetString("lstDeck.Items32"),
            resources.GetString("lstDeck.Items33"),
            resources.GetString("lstDeck.Items34"),
            resources.GetString("lstDeck.Items35"),
            resources.GetString("lstDeck.Items36"),
            resources.GetString("lstDeck.Items37"),
            resources.GetString("lstDeck.Items38"),
            resources.GetString("lstDeck.Items39"),
            resources.GetString("lstDeck.Items40"),
            resources.GetString("lstDeck.Items41"),
            resources.GetString("lstDeck.Items42"),
            resources.GetString("lstDeck.Items43"),
            resources.GetString("lstDeck.Items44"),
            resources.GetString("lstDeck.Items45"),
            resources.GetString("lstDeck.Items46"),
            resources.GetString("lstDeck.Items47"),
            resources.GetString("lstDeck.Items48"),
            resources.GetString("lstDeck.Items49"),
            resources.GetString("lstDeck.Items50"),
            resources.GetString("lstDeck.Items51")});
            resources.ApplyResources(this.lstDeck, "lstDeck");
            this.lstDeck.Name = "lstDeck";
            // 
            // lstDealerHand
            // 
            this.lstDealerHand.FormattingEnabled = true;
            resources.ApplyResources(this.lstDealerHand, "lstDealerHand");
            this.lstDealerHand.Name = "lstDealerHand";
            // 
            // lstPlayerHand
            // 
            this.lstPlayerHand.FormattingEnabled = true;
            resources.ApplyResources(this.lstPlayerHand, "lstPlayerHand");
            this.lstPlayerHand.Name = "lstPlayerHand";
            // 
            // btnTestRandCard
            // 
            resources.ApplyResources(this.btnTestRandCard, "btnTestRandCard");
            this.btnTestRandCard.Name = "btnTestRandCard";
            this.btnTestRandCard.UseVisualStyleBackColor = true;
            this.btnTestRandCard.Click += new System.EventHandler(this.btnTestRandCard_Click);
            // 
            // btnClearTable
            // 
            resources.ApplyResources(this.btnClearTable, "btnClearTable");
            this.btnClearTable.Name = "btnClearTable";
            this.btnClearTable.UseVisualStyleBackColor = true;
            this.btnClearTable.Click += new System.EventHandler(this.btnClearTable_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearTable);
            this.Controls.Add(this.btnTestRandCard);
            this.Controls.Add(this.lstPlayerHand);
            this.Controls.Add(this.lstDealerHand);
            this.Controls.Add(this.lstDeck);
            this.Name = "Form1";
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

