namespace Team_Four_Blackjack
{
    partial class frmBJ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBJ));
            this.picTable = new System.Windows.Forms.PictureBox();
            this.txtDealerWL = new System.Windows.Forms.TextBox();
            this.txtDealerScore = new System.Windows.Forms.TextBox();
            this.picDealer = new System.Windows.Forms.PictureBox();
            this.txtPlayerScore = new System.Windows.Forms.TextBox();
            this.txtPlayerWL = new System.Windows.Forms.TextBox();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDealer)).BeginInit();
            this.SuspendLayout();
            // 
            // picTable
            // 
            resources.ApplyResources(this.picTable, "picTable");
            this.picTable.Name = "picTable";
            this.picTable.TabStop = false;
            // 
            // txtDealerWL
            // 
            this.txtDealerWL.BackColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.txtDealerWL, "txtDealerWL");
            this.txtDealerWL.ForeColor = System.Drawing.SystemColors.Info;
            this.txtDealerWL.Name = "txtDealerWL";
            // 
            // txtDealerScore
            // 
            this.txtDealerScore.BackColor = System.Drawing.SystemColors.InfoText;
            resources.ApplyResources(this.txtDealerScore, "txtDealerScore");
            this.txtDealerScore.ForeColor = System.Drawing.SystemColors.Info;
            this.txtDealerScore.Name = "txtDealerScore";
            // 
            // picDealer
            // 
            resources.ApplyResources(this.picDealer, "picDealer");
            this.picDealer.Name = "picDealer";
            this.picDealer.TabStop = false;
            // 
            // txtPlayerScore
            // 
            this.txtPlayerScore.BackColor = System.Drawing.SystemColors.InfoText;
            resources.ApplyResources(this.txtPlayerScore, "txtPlayerScore");
            this.txtPlayerScore.ForeColor = System.Drawing.SystemColors.Info;
            this.txtPlayerScore.Name = "txtPlayerScore";
            // 
            // txtPlayerWL
            // 
            this.txtPlayerWL.BackColor = System.Drawing.SystemColors.InfoText;
            resources.ApplyResources(this.txtPlayerWL, "txtPlayerWL");
            this.txtPlayerWL.ForeColor = System.Drawing.SystemColors.Info;
            this.txtPlayerWL.Name = "txtPlayerWL";
            // 
            // btnHit
            // 
            this.btnHit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnHit, "btnHit");
            this.btnHit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHit.Name = "btnHit";
            this.btnHit.UseVisualStyleBackColor = false;
            // 
            // btnStand
            // 
            this.btnStand.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnStand, "btnStand");
            this.btnStand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStand.Name = "btnStand";
            this.btnStand.UseVisualStyleBackColor = false;
            // 
            // frmBJ
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.txtPlayerWL);
            this.Controls.Add(this.txtPlayerScore);
            this.Controls.Add(this.picDealer);
            this.Controls.Add(this.txtDealerScore);
            this.Controls.Add(this.txtDealerWL);
            this.Controls.Add(this.picTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBJ";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDealer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTable;
        private System.Windows.Forms.TextBox txtDealerWL;
        private System.Windows.Forms.TextBox txtDealerScore;
        private System.Windows.Forms.PictureBox picDealer;
        private System.Windows.Forms.TextBox txtPlayerScore;
        private System.Windows.Forms.TextBox txtPlayerWL;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
    }
}

