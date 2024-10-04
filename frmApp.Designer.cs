namespace VPlay
{
    partial class frmApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApp));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewAPP = new System.Windows.Forms.DataGridView();
            this.btnCADASTRAR = new System.Windows.Forms.Button();
            this.btnDELETAR = new System.Windows.Forms.Button();
            this.txtAPP = new System.Windows.Forms.TextBox();
            this.txtIDAPP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAPP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "APP";
            // 
            // dataGridViewAPP
            // 
            this.dataGridViewAPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAPP.Location = new System.Drawing.Point(12, 76);
            this.dataGridViewAPP.Name = "dataGridViewAPP";
            this.dataGridViewAPP.Size = new System.Drawing.Size(260, 150);
            this.dataGridViewAPP.TabIndex = 1;
            this.dataGridViewAPP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAPP_CellClick);
            // 
            // btnCADASTRAR
            // 
            this.btnCADASTRAR.Location = new System.Drawing.Point(12, 232);
            this.btnCADASTRAR.Name = "btnCADASTRAR";
            this.btnCADASTRAR.Size = new System.Drawing.Size(127, 54);
            this.btnCADASTRAR.TabIndex = 2;
            this.btnCADASTRAR.Text = "CADASTRAR";
            this.btnCADASTRAR.UseVisualStyleBackColor = true;
            this.btnCADASTRAR.Click += new System.EventHandler(this.btnCADASTRAR_Click);
            // 
            // btnDELETAR
            // 
            this.btnDELETAR.Location = new System.Drawing.Point(145, 232);
            this.btnDELETAR.Name = "btnDELETAR";
            this.btnDELETAR.Size = new System.Drawing.Size(127, 54);
            this.btnDELETAR.TabIndex = 3;
            this.btnDELETAR.Text = "DELETAR";
            this.btnDELETAR.UseVisualStyleBackColor = true;
            this.btnDELETAR.Click += new System.EventHandler(this.btnDELETAR_Click);
            // 
            // txtAPP
            // 
            this.txtAPP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAPP.Location = new System.Drawing.Point(50, 40);
            this.txtAPP.Name = "txtAPP";
            this.txtAPP.Size = new System.Drawing.Size(202, 20);
            this.txtAPP.TabIndex = 4;
            // 
            // txtIDAPP
            // 
            this.txtIDAPP.Location = new System.Drawing.Point(50, 16);
            this.txtIDAPP.Name = "txtIDAPP";
            this.txtIDAPP.Size = new System.Drawing.Size(82, 20);
            this.txtIDAPP.TabIndex = 5;
            this.txtIDAPP.Visible = false;
            this.txtIDAPP.TextChanged += new System.EventHandler(this.txtIDAPP_TextChanged);
            // 
            // frmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 298);
            this.Controls.Add(this.txtIDAPP);
            this.Controls.Add(this.txtAPP);
            this.Controls.Add(this.btnDELETAR);
            this.Controls.Add(this.btnCADASTRAR);
            this.Controls.Add(this.dataGridViewAPP);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de App";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAPP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewAPP;
        private System.Windows.Forms.Button btnCADASTRAR;
        private System.Windows.Forms.Button btnDELETAR;
        private System.Windows.Forms.TextBox txtAPP;
        private System.Windows.Forms.TextBox txtIDAPP;
    }
}