Trivia Millonaria — Proyecto Final en C#
Descripción del proyecto

Trivia Millonaria es una aplicación de escritorio desarrollada en C# con Windows Forms y SQL Server.
Simula un juego de preguntas tipo “¿Quién quiere ser millonario?”, en el que el usuario responde preguntas de opción múltiple y acumula dinero virtual según su desempeño.

Objetivo general

Desarrollar una aplicación de escritorio en C# que permita realizar un juego de trivia con almacenamiento de datos en SQL Server y funcionalidades de registro, control de partidas y ranking de jugadores.

Objetivos específicos

Diseñar una base de datos relacional con las tablas necesarias.

Implementar una interfaz gráfica en Windows Forms.

Desarrollar la lógica del juego y sus validaciones.

Aplicar los patrones Factory, Singleton y Repository.

Permitir carga masiva de preguntas desde Excel o CSV.

Incluir control de acceso al módulo de administración.

Arquitectura técnica
Capa	Contenido
Presentación	Formularios de Windows Forms
Lógica	Clases del dominio del juego
Datos	Repositorios y conexión a SQL (Singleton + Repository)
BD	SQL Server con claves primarias y foráneas
Formularios principales
Formulario	Función
FormularioRegistroUsuario	Permite registrar o iniciar sesión
FormularioPrincipal	Menú principal
FormularioJuego	Muestra las preguntas y controla el progreso
FormularioRanking	Muestra los mejores jugadores
FormularioAdmin	Permite administrar preguntas (solo usuario Brady)
Diseño de la base de datos

Tablas: Usuarios, Preguntas, Opciones, Partidas, RespuestasPartida.
Relaciones:

Usuarios (1 - N) Partidas

Preguntas (1 - N) Opciones

Partidas (1 - N) RespuestasPartida

Tecnologías utilizadas

C# (.NET Framework)

Windows Forms

SQL Server

ADO.NET

Visual Studio

Ejecución del proyecto

Clonar el repositorio:

git clone https://github.com/tuusuario/Millonario-Challenge.git


Abrir el archivo .sln en Visual Studio.

Ejecutar el script MillonarioDB.sql en SQL Server.

Configurar la cadena de conexión en ConexionBD.cs.

Ejecutar el proyecto con Ctrl + F5.

Capturas, 
Validar conexión con base de datos:
<img width="244" height="156" alt="image" src="https://github.com/user-attachments/assets/43191920-4f00-416a-a695-a714e7b6816e" />
Login
<img width="726" height="432" alt="image" src="https://github.com/user-attachments/assets/3dd513e1-aa71-4397-9e99-696d60f59490" />
Si ya está registrado dice bienvenido de nuevo
<img width="727" height="488" alt="image" src="https://github.com/user-attachments/assets/54ff212d-d9cc-4acc-b2f9-6c737c65cc4b" />
Menu
<img width="699" height="742" alt="image" src="https://github.com/user-attachments/assets/57fcea47-b77f-41e2-be35-5905bda69799" />
Juego
<img width="836" height="513" alt="image" src="https://github.com/user-attachments/assets/b0f528e7-aebf-4da3-bb0c-a32f30bd35bb" />
50:50
<img width="839" height="512" alt="image" src="https://github.com/user-attachments/assets/5794ba58-8f5a-444d-94c2-73deae363b18" />
50:50 no se puede usar dos veces:
<img width="834" height="512" alt="image" src="https://github.com/user-attachments/assets/03e239cb-ce04-4892-acf7-9d7f8e83ce94" />
Repuesta incorrecta:
<img width="836" height="512" alt="image" src="https://github.com/user-attachments/assets/813e36c1-0a0f-45f5-b038-1b406c3c7120" />
Resumen:
<img width="835" height="512" alt="image" src="https://github.com/user-attachments/assets/5027da8f-3b7e-4cbb-a24a-c3dded4d1e31" />
Ranking
<img width="775" height="496" alt="image" src="https://github.com/user-attachments/assets/69f8e577-927b-4280-bb1d-71ef2775138e" />
btn exportar csv
<img width="1335" height="639" alt="image" src="https://github.com/user-attachments/assets/a17f64f7-cc8d-4910-9964-9399215ade10" />
Solo usuarios como Brady y Profesor, pueden entrar al apartado de administración
<img width="804" height="482" alt="image" src="https://github.com/user-attachments/assets/1711284d-49b1-4163-b29b-5df4358964a0" />







Autores

Brady Alexander Moncada Jiménez
David Muños Suárez
Instituto Universitario Pascual Bravo
Tecnología en Desarrollo de Software — 2025
