namespace Artemis12
{
    partial class Artemis
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
            this.components = new System.ComponentModel.Container();
            this.tmrMovement = new System.Windows.Forms.Timer(this.components);
            this.pnlGame = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnStory = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrPowers = new System.Windows.Forms.Timer(this.components);
            this.tmrSeconds = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.picGameOver = new System.Windows.Forms.PictureBox();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.picStory = new System.Windows.Forms.PictureBox();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.pnlGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGameOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrMovement
            // 
            this.tmrMovement.Interval = 16;
            this.tmrMovement.Tick += new System.EventHandler(this.tmrMovement_Tick);
            // 
            // pnlGame
            // 
            this.pnlGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGame.Controls.Add(this.picGameOver);
            this.pnlGame.Controls.Add(this.btnBack);
            this.pnlGame.Controls.Add(this.btnHelp);
            this.pnlGame.Controls.Add(this.btnStory);
            this.pnlGame.Controls.Add(this.btnStart);
            this.pnlGame.Controls.Add(this.picHome);
            this.pnlGame.Controls.Add(this.picHelp);
            this.pnlGame.Controls.Add(this.picStory);
            this.pnlGame.Controls.Add(this.picBackground);
            this.pnlGame.Controls.Add(this.lblScore);
            this.pnlGame.Location = new System.Drawing.Point(0, 0);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(784, 550);
            this.pnlGame.TabIndex = 3;
            this.pnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGame_Paint);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.ForestGreen;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(698, 520);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(63, 18);
            this.btnBack.TabIndex = 5;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.LightGreen;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Location = new System.Drawing.Point(609, 256);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(152, 86);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnStory
            // 
            this.btnStory.BackColor = System.Drawing.Color.LightGreen;
            this.btnStory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStory.Location = new System.Drawing.Point(46, 256);
            this.btnStory.Name = "btnStory";
            this.btnStory.Size = new System.Drawing.Size(152, 86);
            this.btnStory.TabIndex = 2;
            this.btnStory.UseVisualStyleBackColor = false;
            this.btnStory.Click += new System.EventHandler(this.btnStory_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(318, 256);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 86);
            this.btnStart.TabIndex = 0;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrPowers
            // 
            this.tmrPowers.Interval = 10000;
            this.tmrPowers.Tick += new System.EventHandler(this.tmrPowers_Tick);
            // 
            // tmrSeconds
            // 
            this.tmrSeconds.Interval = 1000;
            this.tmrSeconds.Tick += new System.EventHandler(this.tmrSeconds_Tick);
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.Black;
            this.lblScore.Font = new System.Drawing.Font("MS PGothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScore.Location = new System.Drawing.Point(232, 490);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(330, 39);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "SCORE: 0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picGameOver
            // 
            this.picGameOver.Image = global::Artemis12.Properties.Resources.ArtemisGameOver1;
            this.picGameOver.Location = new System.Drawing.Point(0, 0);
            this.picGameOver.Name = "picGameOver";
            this.picGameOver.Size = new System.Drawing.Size(784, 550);
            this.picGameOver.TabIndex = 9;
            this.picGameOver.TabStop = false;
            // 
            // picHome
            // 
            this.picHome.Image = global::Artemis12.Properties.Resources.ArtemisHome;
            this.picHome.Location = new System.Drawing.Point(0, 0);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(784, 550);
            this.picHome.TabIndex = 1;
            this.picHome.TabStop = false;
            // 
            // picHelp
            // 
            this.picHelp.Image = global::Artemis12.Properties.Resources.ArtemisHelp1;
            this.picHelp.Location = new System.Drawing.Point(0, 0);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(784, 550);
            this.picHelp.TabIndex = 4;
            this.picHelp.TabStop = false;
            // 
            // picStory
            // 
            this.picStory.Image = global::Artemis12.Properties.Resources.ArtemisStory;
            this.picStory.Location = new System.Drawing.Point(0, 0);
            this.picStory.Name = "picStory";
            this.picStory.Size = new System.Drawing.Size(784, 550);
            this.picStory.TabIndex = 6;
            this.picStory.TabStop = false;
            // 
            // picBackground
            // 
            this.picBackground.Image = global::Artemis12.Properties.Resources.ArtemisBackground;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(784, 550);
            this.picBackground.TabIndex = 7;
            this.picBackground.TabStop = false;
            // 
            // Artemis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 550);
            this.Controls.Add(this.pnlGame);
            this.Name = "Artemis";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.pnlGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGameOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrMovement;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Timer tmrPowers;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnStory;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox picStory;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.Timer tmrSeconds;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox picGameOver;
    }
}

