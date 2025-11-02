namespace Millonario_Challenge
{
    partial class FormularioRanking
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
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRanking
            // 
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Location = new System.Drawing.Point(110, 47);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.Size = new System.Drawing.Size(538, 294);
            this.dgvRanking.TabIndex = 0;
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCsv.Location = new System.Drawing.Point(301, 347);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(146, 43);
            this.btnExportarCsv.TabIndex = 18;
            this.btnExportarCsv.Text = "Exportar CSV";
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click_1);
            // 
            // FormularioRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportarCsv);
            this.Controls.Add(this.dgvRanking);
            this.Name = "FormularioRanking";
            this.Text = "FormularioRanking";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.Button btnExportarCsv;
    }
}