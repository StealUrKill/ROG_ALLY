namespace Rog_Ally
{
    partial class MainForm
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
            this.ChangeResistry = new System.Windows.Forms.Button();
            this.BtnModifyRegistrySilentDisabled = new System.Windows.Forms.Button();
            this.BtnModifyRegistrySilentAgressive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeResistry
            // 
            this.ChangeResistry.Location = new System.Drawing.Point(12, 12);
            this.ChangeResistry.Name = "ChangeResistry";
            this.ChangeResistry.Size = new System.Drawing.Size(123, 23);
            this.ChangeResistry.TabIndex = 0;
            this.ChangeResistry.Text = "Change Registry";
            this.ChangeResistry.UseVisualStyleBackColor = true;
            this.ChangeResistry.Click += new System.EventHandler(this.BtnModifyRegistry_Click);
            // 
            // BtnModifyRegistrySilentDisabled
            // 
            this.BtnModifyRegistrySilentDisabled.Location = new System.Drawing.Point(12, 106);
            this.BtnModifyRegistrySilentDisabled.Name = "BtnModifyRegistrySilentDisabled";
            this.BtnModifyRegistrySilentDisabled.Size = new System.Drawing.Size(123, 23);
            this.BtnModifyRegistrySilentDisabled.TabIndex = 1;
            this.BtnModifyRegistrySilentDisabled.Text = "Silent Disabled";
            this.BtnModifyRegistrySilentDisabled.UseVisualStyleBackColor = true;
            this.BtnModifyRegistrySilentDisabled.Click += new System.EventHandler(this.BtnModifyRegistrySilentDisabled_Click);
            // 
            // BtnModifyRegistrySilentAgressive
            // 
            this.BtnModifyRegistrySilentAgressive.Location = new System.Drawing.Point(12, 135);
            this.BtnModifyRegistrySilentAgressive.Name = "BtnModifyRegistrySilentAgressive";
            this.BtnModifyRegistrySilentAgressive.Size = new System.Drawing.Size(123, 23);
            this.BtnModifyRegistrySilentAgressive.TabIndex = 2;
            this.BtnModifyRegistrySilentAgressive.Text = "Silent Agressive";
            this.BtnModifyRegistrySilentAgressive.UseVisualStyleBackColor = true;
            this.BtnModifyRegistrySilentAgressive.Click += new System.EventHandler(this.BtnModifyRegistrySilentAgressive_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 170);
            this.Controls.Add(this.BtnModifyRegistrySilentAgressive);
            this.Controls.Add(this.BtnModifyRegistrySilentDisabled);
            this.Controls.Add(this.ChangeResistry);
            this.Name = "MainForm";
            this.Text = "ROG ALLY";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChangeResistry;
        private System.Windows.Forms.Button BtnModifyRegistrySilentDisabled;
        private System.Windows.Forms.Button BtnModifyRegistrySilentAgressive;
    }
}

