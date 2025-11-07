Trivia Millonaria — Proyecto Final C#
Descripción del proyecto

Trivia Millonaria es una aplicación de escritorio desarrollada en C# con Windows Forms y SQL Server.
Simula el juego de preguntas tipo “¿Quién quiere ser millonario?”, en el que el usuario responde preguntas de opción múltiple y acumula dinero virtual según su desempeño.

El objetivo principal es evaluar conocimientos generales y reforzar el manejo de bases de datos, programación orientada a objetos y conexión ADO.NET.

Características principales

Juego de preguntas con cuatro opciones de respuesta (A, B, C, D).

Registro automático de usuarios con nombre de usuario y nombre completo.

Base de datos relacional en SQL Server con tablas para usuarios, preguntas, opciones, partidas y respuestas.

Ranking de jugadores que muestra el dinero total y respuestas correctas acumuladas.

Administración de preguntas restringida solo al usuario autorizado (“Brady”).

Carga de preguntas desde archivo CSV o Excel (.xls).

Ayuda 50:50 implementada (elimina dos respuestas incorrectas).



Diseño de la base de datos

La base de datos MillonarioDB contiene las siguientes tablas:

Tabla	Descripción
Usuarios	Registra los jugadores (UsuarioId, NombreUsuario, NombreCompleto).
Preguntas	Contiene el texto de la pregunta, dificultad, premio y categoría.
Opciones	Guarda las opciones de cada pregunta e indica la correcta.
Partidas	Representa cada sesión de juego de un usuario.
RespuestasPartida	Almacena las respuestas seleccionadas por cada jugador.
Relaciones principales

Usuarios (1 - N) Partidas

Preguntas (1 - N) Opciones

Partidas (1 - N) RespuestasPartida

Preguntas (1 - N) RespuestasPartida

Pantallazo
diagrama entidad-relación exportado de SQL Server 



Interfaz gráfica

El sistema está compuesto por los siguientes formularios:

Formulario	Función
FormularioRegistroUsuario	Permite registrar o iniciar sesión con nombre de usuario.
FormularioPrincipal	Menú principal del juego.
FormularioJuego	Muestra las preguntas y controla el progreso.
FormularioRanking	Lista los mejores jugadores.
FormularioAdmin	Permite agregar, modificar o eliminar preguntas.

Pantallazos 

Pantalla de registro de usuario 

Menú principal 

Juego en ejecución 

Ranking de jugadores

Administración de preguntas 



Reglas de acceso

Solo el usuario Brady puede acceder al módulo de administración de preguntas.

Si otro usuario inicia sesión, el botón “Administrar preguntas” no aparece o se bloquea.

Carga de preguntas desde Excel o CSV

Para agregar preguntas masivamente:

Abrir la plantilla PlantillaPreguntas.xls incluida en la carpeta “Recursos”.

Completar las columnas de la siguiente manera:

| Texto | Categoria | Dificultad | Premio | Opcion1 | Opcion2 | Opcion3 | Opcion4 | Correcta |
|--------|------------|-------------|---------|----------|----------|----------|-----------|
| ¿Cuál es el planeta más grande? | Ciencia | 1 | 100 | Tierra | Marte | Júpiter | Venus | 2 |

Guardar el archivo.

Desde el formulario de administración, usar el botón “Cargar desde Excel” para importar los datos.

Flujo de funcionamiento

El usuario se registra o inicia sesión.

Se crea una nueva partida en la base de datos.

Se seleccionan preguntas aleatorias.

El jugador responde y acumula dinero si acierta.

Si falla, la partida termina y se guardan los resultados.

El ranking se actualiza con las estadísticas de todos los usuarios.

Tecnologías utilizadas
Tecnología	Descripción
C# (.NET Framework)	Lenguaje principal del proyecto
Windows Forms	Interfaz de usuario
SQL Server	Sistema de gestión de base de datos
ADO.NET	Comunicación entre la app y la base de datos
Visual Studio	Entorno de desarrollo
Ejecución del proyecto

Clonar el repositorio:

git clone https://github.com/tuusuario/Millonario-Challenge.git


Abrir el archivo .sln en Visual Studio.

Ejecutar el script MillonarioDB.sql en SQL Server para crear la base de datos.

Configurar la conexión en ConexionBD.cs:

private string cadenaConexion = "Data Source=TU_PC\\SQLEXPRESS;Initial Catalog=MillonarioDB;Integrated Security=True;";


Compilar y ejecutar el proyecto (Ctrl + F5).

Pruebas y evidencias

Agregar las imágenes de las pruebas en la carpeta /Recursos/.

Prueba	Evidencia
Registro de usuario	
Inicio de partida	
Respuesta correcta	
Fin del juego	
Exportar ranking	
Créditos

Desarrollado por:
Brady Alexander Moncada Jiménez
David Muños Suarez
Instituto Universitario Pascual Bravo
Programa: Tecnología en Desarrollo de Software
Año: 2025

Evaluación según rúbrica
Criterio	Descripción	Cumplimiento
Documentación	Descripción completa del proyecto, estructura y evidencias	Cumplido
Conexión a base de datos	Correcta configuración en SQL Server	Cumplido
Interfaz funcional	Formularios operativos y validados	Cumplido
Importación de datos	Implementada con carga desde Excel	Cumplido
Control de acceso	Módulo restringido a usuario autorizado	Cumplido
Registro de resultados	Guardado y ranking funcional	Cumplido
