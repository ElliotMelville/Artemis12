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
            this.picPaddle1 = new System.Windows.Forms.PictureBox();
            this.picPaddle2 = new System.Windows.Forms.PictureBox();
            this.tmrMovement = new System.Windows.Forms.Timer(this.components);
            this.ballMain = new Artemis12.Properties.Ball();
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballMain)).BeginInit();
            this.SuspendLayout();
            // 
            // picPaddle1
            // 
            this.picPaddle1.BackColor = System.Drawing.Color.Red;
            this.picPaddle1.Location = new System.Drawing.Point(0, 0);
            this.picPaddle1.Name = "picPaddle1";
            this.picPaddle1.Size = new System.Drawing.Size(15, 81);
            this.picPaddle1.TabIndex = 0;
            this.picPaddle1.TabStop = false;
            // 
            // picPaddle2
            // 
            this.picPaddle2.BackColor = System.Drawing.Color.Red;
            this.picPaddle2.Location = new System.Drawing.Point(650, 0);
            this.picPaddle2.Name = "picPaddle2";
            this.picPaddle2.Size = new System.Drawing.Size(15, 81);
            this.picPaddle2.TabIndex = 1;
            this.picPaddle2.TabStop = false;
            // 
            // tmrMovement
            // 
            this.tmrMovement.Enabled = true;
            this.tmrMovement.Interval = 16;
            this.tmrMovement.Tick += new System.EventHandler(this.tmrMovement_Tick);
            // 
            // ballMain
            // 
            this.ballMain.BackColor = System.Drawing.Color.Blue;
            this.ballMain.Location = new System.Drawing.Point(378, 175);
            this.ballMain.Name = "ballMain";
            this.ballMain.Size = new System.Drawing.Size(40, 40);
            this.ballMain.TabIndex = 2;
            this.ballMain.TabStop = false;
            // 
            // Artemis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 550);
            this.Controls.Add(this.ballMain);
            this.Controls.Add(this.picPaddle2);
            this.Controls.Add(this.picPaddle1);
            this.Name = "Artemis";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPaddle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPaddle1;
        private System.Windows.Forms.PictureBox picPaddle2;
        private System.Windows.Forms.Timer tmrMovement;
        private Properties.Ball ballMain;
    }
}

