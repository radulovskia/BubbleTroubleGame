﻿namespace BubbleTroubleGame
{
    partial class FormGame
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelPauseMenu = new System.Windows.Forms.Panel();
            this.btnLvlEditor = new System.Windows.Forms.Button();
            this.btnExitToDesktop = new System.Windows.Forms.Button();
            this.btnExitToMenu = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.panelEnd = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.panelPauseMenu.SuspendLayout();
            this.panelEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelPauseMenu
            // 
            this.panelPauseMenu.Controls.Add(this.btnLvlEditor);
            this.panelPauseMenu.Controls.Add(this.btnExitToDesktop);
            this.panelPauseMenu.Controls.Add(this.btnExitToMenu);
            this.panelPauseMenu.Controls.Add(this.btnResume);
            this.panelPauseMenu.Enabled = false;
            this.panelPauseMenu.Location = new System.Drawing.Point(240, 84);
            this.panelPauseMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelPauseMenu.Name = "panelPauseMenu";
            this.panelPauseMenu.Size = new System.Drawing.Size(313, 352);
            this.panelPauseMenu.TabIndex = 0;
            this.panelPauseMenu.Visible = false;
            // 
            // btnLvlEditor
            // 
            this.btnLvlEditor.BackColor = System.Drawing.Color.Firebrick;
            this.btnLvlEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnLvlEditor.ForeColor = System.Drawing.Color.White;
            this.btnLvlEditor.Location = new System.Drawing.Point(48, 234);
            this.btnLvlEditor.Margin = new System.Windows.Forms.Padding(4);
            this.btnLvlEditor.Name = "btnLvlEditor";
            this.btnLvlEditor.Size = new System.Drawing.Size(219, 64);
            this.btnLvlEditor.TabIndex = 0;
            this.btnLvlEditor.Text = "LEVEL EDITOR";
            this.btnLvlEditor.UseVisualStyleBackColor = false;
            this.btnLvlEditor.Click += new System.EventHandler(this.btnLvlEditor_Click);
            // 
            // btnExitToDesktop
            // 
            this.btnExitToDesktop.BackColor = System.Drawing.Color.Firebrick;
            this.btnExitToDesktop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnExitToDesktop.ForeColor = System.Drawing.Color.White;
            this.btnExitToDesktop.Location = new System.Drawing.Point(48, 169);
            this.btnExitToDesktop.Margin = new System.Windows.Forms.Padding(4);
            this.btnExitToDesktop.Name = "btnExitToDesktop";
            this.btnExitToDesktop.Size = new System.Drawing.Size(219, 58);
            this.btnExitToDesktop.TabIndex = 0;
            this.btnExitToDesktop.Text = "EXIT TO DESKTOP";
            this.btnExitToDesktop.UseVisualStyleBackColor = false;
            this.btnExitToDesktop.Click += new System.EventHandler(this.btnExitToDesktop_Click);
            // 
            // btnExitToMenu
            // 
            this.btnExitToMenu.BackColor = System.Drawing.Color.Firebrick;
            this.btnExitToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnExitToMenu.ForeColor = System.Drawing.Color.White;
            this.btnExitToMenu.Location = new System.Drawing.Point(48, 103);
            this.btnExitToMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnExitToMenu.Name = "btnExitToMenu";
            this.btnExitToMenu.Size = new System.Drawing.Size(219, 58);
            this.btnExitToMenu.TabIndex = 0;
            this.btnExitToMenu.Text = "EXIT TO MENU";
            this.btnExitToMenu.UseVisualStyleBackColor = false;
            this.btnExitToMenu.Click += new System.EventHandler(this.btnExitToMenu_Click);
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.Color.Firebrick;
            this.btnResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnResume.ForeColor = System.Drawing.Color.White;
            this.btnResume.Location = new System.Drawing.Point(48, 38);
            this.btnResume.Margin = new System.Windows.Forms.Padding(4);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(219, 58);
            this.btnResume.TabIndex = 0;
            this.btnResume.Text = "RESUME";
            this.btnResume.UseVisualStyleBackColor = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // panelEnd
            // 
            this.panelEnd.Controls.Add(this.label2);
            this.panelEnd.Controls.Add(this.label1);
            this.panelEnd.Controls.Add(this.btnBackToMenu);
            this.panelEnd.Enabled = false;
            this.panelEnd.Location = new System.Drawing.Point(119, 68);
            this.panelEnd.Name = "panelEnd";
            this.panelEnd.Size = new System.Drawing.Size(563, 111);
            this.panelEnd.TabIndex = 1;
            this.panelEnd.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(374, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "You lost... Koj saka neka 4estita";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "You won! Chess Tito";
            this.label1.Visible = false;
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.Location = new System.Drawing.Point(169, 75);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(219, 23);
            this.btnBackToMenu.TabIndex = 0;
            this.btnBackToMenu.Text = "Return to Menu";
            this.btnBackToMenu.UseVisualStyleBackColor = true;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BubbleTroubleGame.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(779, 543);
            this.Controls.Add(this.panelEnd);
            this.Controls.Add(this.panelPauseMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panelPauseMenu.ResumeLayout(false);
            this.panelEnd.ResumeLayout(false);
            this.panelEnd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelPauseMenu;
        private System.Windows.Forms.Button btnLvlEditor;
        private System.Windows.Forms.Button btnExitToDesktop;
        private System.Windows.Forms.Button btnExitToMenu;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Panel panelEnd;
        private System.Windows.Forms.Button btnBackToMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
