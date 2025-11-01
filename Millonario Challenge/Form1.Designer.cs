namespace Millonario_Challenge
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnRanking = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(274, 136);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(220, 43);
            this.btnIniciar.TabIndex = 3;
            this.btnIniciar.Text = "Iniciar Juego";
            this.btnIniciar.UseVisualStyleBackColor = true;
            // 
            // btnRanking
            // 
            this.btnRanking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRanking.Location = new System.Drawing.Point(274, 203);
            this.btnRanking.Name = "btnRanking";
            this.btnRanking.Size = new System.Drawing.Size(220, 43);
            this.btnRanking.TabIndex = 4;
            this.btnRanking.Text = "Ranking";
            this.btnRanking.UseVisualStyleBackColor = true;
            // 
            // btnAdmin
            // 
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.Location = new System.Drawing.Point(274, 268);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(220, 43);
            this.btnAdmin.TabIndex = 5;
            this.btnAdmin.Text = "Administrar Preguntas";
            this.btnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(274, 336);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(220, 43);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(269, 74);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 25);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Millonario Challenge";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnRanking);
            this.Controls.Add(this.btnIniciar);
            this.Name = "MainForm";
            this.Text = "Trivia - Millonario Challenge";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnRanking;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTitle;
    }
}

