namespace Millonario_Challenge
{
    partial class FormularioAdmin
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
            this.lstPreguntas = new System.Windows.Forms.ListBox();
            this.txtPregunta = new System.Windows.Forms.TextBox();
            this.txtOpcionD = new System.Windows.Forms.TextBox();
            this.txtOpcionB = new System.Windows.Forms.TextBox();
            this.txtOpcionA = new System.Windows.Forms.TextBox();
            this.txtOpcionC = new System.Windows.Forms.TextBox();
            this.txtIndiceCorrecto = new System.Windows.Forms.TextBox();
            this.txtDificultad = new System.Windows.Forms.TextBox();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.lblIndice = new System.Windows.Forms.Label();
            this.lblOpcionD = new System.Windows.Forms.Label();
            this.lblOpcionC = new System.Windows.Forms.Label();
            this.lblOpcionB = new System.Windows.Forms.Label();
            this.lblOpcionA = new System.Windows.Forms.Label();
            this.btnCargarSemilla = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPreguntas
            // 
            this.lstPreguntas.FormattingEnabled = true;
            this.lstPreguntas.Location = new System.Drawing.Point(96, 51);
            this.lstPreguntas.Name = "lstPreguntas";
            this.lstPreguntas.Size = new System.Drawing.Size(336, 238);
            this.lstPreguntas.TabIndex = 0;
            // 
            // txtPregunta
            // 
            this.txtPregunta.Location = new System.Drawing.Point(578, 58);
            this.txtPregunta.Name = "txtPregunta";
            this.txtPregunta.Size = new System.Drawing.Size(100, 20);
            this.txtPregunta.TabIndex = 1;
            // 
            // txtOpcionD
            // 
            this.txtOpcionD.Location = new System.Drawing.Point(578, 224);
            this.txtOpcionD.Name = "txtOpcionD";
            this.txtOpcionD.Size = new System.Drawing.Size(100, 20);
            this.txtOpcionD.TabIndex = 2;
            // 
            // txtOpcionB
            // 
            this.txtOpcionB.Location = new System.Drawing.Point(578, 134);
            this.txtOpcionB.Name = "txtOpcionB";
            this.txtOpcionB.Size = new System.Drawing.Size(100, 20);
            this.txtOpcionB.TabIndex = 3;
            // 
            // txtOpcionA
            // 
            this.txtOpcionA.Location = new System.Drawing.Point(578, 94);
            this.txtOpcionA.Name = "txtOpcionA";
            this.txtOpcionA.Size = new System.Drawing.Size(100, 20);
            this.txtOpcionA.TabIndex = 4;
            // 
            // txtOpcionC
            // 
            this.txtOpcionC.Location = new System.Drawing.Point(578, 177);
            this.txtOpcionC.Name = "txtOpcionC";
            this.txtOpcionC.Size = new System.Drawing.Size(100, 20);
            this.txtOpcionC.TabIndex = 5;
            // 
            // txtIndiceCorrecto
            // 
            this.txtIndiceCorrecto.Location = new System.Drawing.Point(628, 270);
            this.txtIndiceCorrecto.Name = "txtIndiceCorrecto";
            this.txtIndiceCorrecto.Size = new System.Drawing.Size(50, 20);
            this.txtIndiceCorrecto.TabIndex = 6;
            // 
            // txtDificultad
            // 
            this.txtDificultad.Location = new System.Drawing.Point(628, 308);
            this.txtDificultad.Name = "txtDificultad";
            this.txtDificultad.Size = new System.Drawing.Size(50, 20);
            this.txtDificultad.TabIndex = 7;
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPregunta.Location = new System.Drawing.Point(481, 54);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(91, 24);
            this.lblPregunta.TabIndex = 8;
            this.lblPregunta.Text = "Pregunta:";
            // 
            // lblDificultad
            // 
            this.lblDificultad.AutoSize = true;
            this.lblDificultad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificultad.Location = new System.Drawing.Point(477, 308);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(90, 24);
            this.lblDificultad.TabIndex = 9;
            this.lblDificultad.Text = "Dificultad:";
            // 
            // lblIndice
            // 
            this.lblIndice.AutoSize = true;
            this.lblIndice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndice.Location = new System.Drawing.Point(477, 265);
            this.lblIndice.Name = "lblIndice";
            this.lblIndice.Size = new System.Drawing.Size(143, 24);
            this.lblIndice.TabIndex = 10;
            this.lblIndice.Text = "Indice Correcto:";
            // 
            // lblOpcionD
            // 
            this.lblOpcionD.AutoSize = true;
            this.lblOpcionD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcionD.Location = new System.Drawing.Point(477, 220);
            this.lblOpcionD.Name = "lblOpcionD";
            this.lblOpcionD.Size = new System.Drawing.Size(95, 24);
            this.lblOpcionD.TabIndex = 11;
            this.lblOpcionD.Text = "Opcion D:";
            // 
            // lblOpcionC
            // 
            this.lblOpcionC.AutoSize = true;
            this.lblOpcionC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcionC.Location = new System.Drawing.Point(477, 177);
            this.lblOpcionC.Name = "lblOpcionC";
            this.lblOpcionC.Size = new System.Drawing.Size(95, 24);
            this.lblOpcionC.TabIndex = 12;
            this.lblOpcionC.Text = "Opcion C:";
            // 
            // lblOpcionB
            // 
            this.lblOpcionB.AutoSize = true;
            this.lblOpcionB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcionB.Location = new System.Drawing.Point(477, 134);
            this.lblOpcionB.Name = "lblOpcionB";
            this.lblOpcionB.Size = new System.Drawing.Size(94, 24);
            this.lblOpcionB.TabIndex = 13;
            this.lblOpcionB.Text = "Opcion B:";
            // 
            // lblOpcionA
            // 
            this.lblOpcionA.AutoSize = true;
            this.lblOpcionA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcionA.Location = new System.Drawing.Point(477, 94);
            this.lblOpcionA.Name = "lblOpcionA";
            this.lblOpcionA.Size = new System.Drawing.Size(95, 24);
            this.lblOpcionA.TabIndex = 14;
            this.lblOpcionA.Text = "Opcion A:";
            // 
            // btnCargarSemilla
            // 
            this.btnCargarSemilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarSemilla.Location = new System.Drawing.Point(468, 354);
            this.btnCargarSemilla.Name = "btnCargarSemilla";
            this.btnCargarSemilla.Size = new System.Drawing.Size(220, 43);
            this.btnCargarSemilla.TabIndex = 15;
            this.btnCargarSemilla.Text = "Cargar Semilla";
            this.btnCargarSemilla.UseVisualStyleBackColor = true;
            this.btnCargarSemilla.Click += new System.EventHandler(this.btnCargarSemilla_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(335, 308);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 43);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(200, 308);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 43);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(65, 308);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 43);
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // FormularioAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCargarSemilla);
            this.Controls.Add(this.lblOpcionA);
            this.Controls.Add(this.lblOpcionB);
            this.Controls.Add(this.lblOpcionC);
            this.Controls.Add(this.lblOpcionD);
            this.Controls.Add(this.lblIndice);
            this.Controls.Add(this.lblDificultad);
            this.Controls.Add(this.lblPregunta);
            this.Controls.Add(this.txtDificultad);
            this.Controls.Add(this.txtIndiceCorrecto);
            this.Controls.Add(this.txtOpcionC);
            this.Controls.Add(this.txtOpcionA);
            this.Controls.Add(this.txtOpcionB);
            this.Controls.Add(this.txtOpcionD);
            this.Controls.Add(this.txtPregunta);
            this.Controls.Add(this.lstPreguntas);
            this.Name = "FormularioAdmin";
            this.Text = "FormularioAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPreguntas;
        private System.Windows.Forms.TextBox txtPregunta;
        private System.Windows.Forms.TextBox txtOpcionD;
        private System.Windows.Forms.TextBox txtOpcionB;
        private System.Windows.Forms.TextBox txtOpcionA;
        private System.Windows.Forms.TextBox txtOpcionC;
        private System.Windows.Forms.TextBox txtIndiceCorrecto;
        private System.Windows.Forms.TextBox txtDificultad;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.Label lblIndice;
        private System.Windows.Forms.Label lblOpcionD;
        private System.Windows.Forms.Label lblOpcionC;
        private System.Windows.Forms.Label lblOpcionB;
        private System.Windows.Forms.Label lblOpcionA;
        private System.Windows.Forms.Button btnCargarSemilla;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
    }
}