namespace ApStomat
{
    partial class FormPacjent
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
            this.dataGridViewDane = new System.Windows.Forms.DataGridView();
            this.ColDana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDana2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDodZap = new System.Windows.Forms.Button();
            this.buttonDiagram = new System.Windows.Forms.Button();
            this.buttonZamknij = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDane)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDane
            // 
            this.dataGridViewDane.AllowUserToAddRows = false;
            this.dataGridViewDane.AllowUserToDeleteRows = false;
            this.dataGridViewDane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDane.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDana,
            this.ColDana2});
            this.dataGridViewDane.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewDane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDane.Name = "dataGridViewDane";
            this.dataGridViewDane.RowHeadersWidth = 51;
            this.dataGridViewDane.RowTemplate.Height = 24;
            this.dataGridViewDane.Size = new System.Drawing.Size(731, 327);
            this.dataGridViewDane.TabIndex = 0;
            // 
            // ColDana
            // 
            this.ColDana.HeaderText = "informacja";
            this.ColDana.MinimumWidth = 6;
            this.ColDana.Name = "ColDana";
            this.ColDana.ReadOnly = true;
            this.ColDana.Width = 75;
            // 
            // ColDana2
            // 
            this.ColDana2.HeaderText = "dana";
            this.ColDana2.MinimumWidth = 6;
            this.ColDana2.Name = "ColDana2";
            this.ColDana2.Width = 400;
            // 
            // buttonDodZap
            // 
            this.buttonDodZap.Location = new System.Drawing.Point(12, 388);
            this.buttonDodZap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDodZap.Name = "buttonDodZap";
            this.buttonDodZap.Size = new System.Drawing.Size(168, 50);
            this.buttonDodZap.TabIndex = 1;
            this.buttonDodZap.Text = "zapisz";
            this.buttonDodZap.UseVisualStyleBackColor = true;
            this.buttonDodZap.Click += new System.EventHandler(this.buttonDodZap_Click);
            // 
            // buttonDiagram
            // 
            this.buttonDiagram.Enabled = false;
            this.buttonDiagram.Location = new System.Drawing.Point(360, 388);
            this.buttonDiagram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDiagram.Name = "buttonDiagram";
            this.buttonDiagram.Size = new System.Drawing.Size(168, 50);
            this.buttonDiagram.TabIndex = 2;
            this.buttonDiagram.Text = "pokaż diagram";
            this.buttonDiagram.UseVisualStyleBackColor = true;
            this.buttonDiagram.Visible = false;
            this.buttonDiagram.Click += new System.EventHandler(this.buttonDiagram_Click);
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.Location = new System.Drawing.Point(187, 388);
            this.buttonZamknij.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(168, 50);
            this.buttonZamknij.TabIndex = 3;
            this.buttonZamknij.Text = "zamknij";
            this.buttonZamknij.UseVisualStyleBackColor = true;
            this.buttonZamknij.Click += new System.EventHandler(this.buttonZamknij_Click);
            // 
            // FormPacjent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonZamknij);
            this.Controls.Add(this.buttonDiagram);
            this.Controls.Add(this.buttonDodZap);
            this.Controls.Add(this.dataGridViewDane);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPacjent";
            this.Text = "Pacjent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPacjent_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDane;
        private System.Windows.Forms.Button buttonDodZap;
        private System.Windows.Forms.Button buttonDiagram;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDana;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDana2;
    }
}