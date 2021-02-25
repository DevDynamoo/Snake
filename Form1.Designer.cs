
namespace Snakegame
{
    partial class GameForm
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
            this.Board = new System.Windows.Forms.PictureBox();
            this.score = new System.Windows.Forms.Label();
            this.labelGame = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Board)).BeginInit();
            this.SuspendLayout();
            // 
            // Board
            // 
            this.Board.BackColor = System.Drawing.Color.LightGray;
            this.Board.Location = new System.Drawing.Point(24, 38);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(547, 382);
            this.Board.TabIndex = 0;
            this.Board.TabStop = false;
            this.Board.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.ForeColor = System.Drawing.Color.Red;
            this.score.Location = new System.Drawing.Point(19, 9);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(86, 25);
            this.score.TabIndex = 1;
            this.score.Text = "Score: 0";
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
            this.labelGame.BackColor = System.Drawing.Color.LightGray;
            this.labelGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGame.ForeColor = System.Drawing.Color.Red;
            this.labelGame.Location = new System.Drawing.Point(143, 109);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(309, 55);
            this.labelGame.TabIndex = 2;
            this.labelGame.Text = "GAMEOVER";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(600, 454);
            this.Controls.Add(this.labelGame);
            this.Controls.Add(this.score);
            this.Controls.Add(this.Board);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyHandler);
            ((System.ComponentModel.ISupportInitialize)(this.Board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Board;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label labelGame;
    }
}

