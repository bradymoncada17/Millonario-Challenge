# Trivia Millonaria — Proyecto Final en C#

## Descripción del proyecto

**Trivia Millonaria** es una aplicación de escritorio desarrollada en **C# con Windows Forms y SQL Server**.  
Simula un juego de preguntas tipo *“¿Quién quiere ser millonario?”*, en el cual el usuario responde preguntas de opción múltiple y acumula dinero virtual según su desempeño.  
El sistema incorpora registro de usuarios, control de partidas, ranking y un módulo de administración protegido.

---

## Objetivo general

Desarrollar una aplicación de escritorio en C# que permita realizar un juego de trivia con almacenamiento de datos en SQL Server y funcionalidades de registro, control de partidas y ranking de jugadores.

---

## Objetivos específicos

- Diseñar una base de datos relacional con las tablas necesarias.  
- Implementar una interfaz gráfica intuitiva con Windows Forms.  
- Desarrollar la lógica del juego y sus validaciones.  
- Aplicar los patrones de diseño **Factory**, **Singleton** y **Repository**.  
- Permitir la **carga masiva de preguntas** desde archivos Excel o CSV.  
- Incluir **control de acceso** al módulo de administración.

---

## Arquitectura técnica

| Capa | Contenido |
|------|------------|
| **Presentación** | Formularios de Windows Forms |
| **Lógica** | Clases del dominio del juego |
| **Datos** | Repositorios y conexión a SQL Server (Singleton + Repository) |
| **Base de datos** | SQL Server con claves primarias y foráneas |

---

## Formularios principales

| Formulario | Función principal |
|-------------|------------------|
| **FormularioRegistroUsuario** | Permite registrar nuevos usuarios o iniciar sesión |
| **FormularioPrincipal** | Muestra el menú principal del juego |
| **FormularioJuego** | Controla el desarrollo de las preguntas y el progreso del jugador |
| **FormularioRanking** | Muestra los mejores jugadores con opción de exportar a CSV |
| **FormularioAdmin** | Permite la administración de preguntas (acceso restringido a usuarios como *Brady* y *Profesor*) |

---

## Diseño de la base de datos

**Tablas principales:**  
- `Usuarios`  
- `Preguntas`  
- `Opciones`  
- `Partidas`  
- `RespuestasPartida`  

**Relaciones:**  
- `Usuarios (1 - N) Partidas`  
- `Preguntas (1 - N) Opciones`  
- `Partidas (1 - N) RespuestasPartida`

---

## Tecnologías utilizadas

- **Lenguaje:** C# (.NET Framework)  
- **Interfaz:** Windows Forms  
- **Base de datos:** SQL Server  
- **Acceso a datos:** ADO.NET  
- **Entorno de desarrollo:** Visual Studio  

---

## Ejecución del proyecto

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/tuusuario/Millonario-Challenge.git

Capturas de funcionamiento

Validación de conexión con la base de datos:
<img width="244" height="156" alt="Validación de conexión" src="https://github.com/user-attachments/assets/43191920-4f00-416a-a695-a714e7b6816e" />

Login:
<img width="726" height="432" alt="Login" src="https://github.com/user-attachments/assets/3dd513e1-aa71-4397-9e99-696d60f59490" />

Mensaje de bienvenida si el usuario ya está registrado:
<img width="727" height="488" alt="Bienvenida" src="https://github.com/user-attachments/assets/54ff212d-d9cc-4acc-b2f9-6c737c65cc4b" />

Menú principal:
<img width="699" height="742" alt="Menú principal" src="https://github.com/user-attachments/assets/57fcea47-b77f-41e2-be35-5905bda69799" />

Juego en progreso:
<img width="836" height="513" alt="Juego" src="https://github.com/user-attachments/assets/b0f528e7-aebf-4da3-bb0c-a32f30bd35bb" />

Uso del comodín 50:50:
<img width="839" height="512" alt="Comodín 50:50" src="https://github.com/user-attachments/assets/5794ba58-8f5a-444d-94c2-73deae363b18" />

Intento de uso duplicado del comodín:
<img width="834" height="512" alt="Comodín duplicado" src="https://github.com/user-attachments/assets/03e239cb-ce04-4892-acf7-9d7f8e83ce94" />

Respuesta incorrecta:
<img width="836" height="512" alt="Respuesta incorrecta" src="https://github.com/user-attachments/assets/813e36c1-0a0f-45f5-b038-1b406c3c7120" />

Resumen de partida:
<img width="835" height="512" alt="Resumen" src="https://github.com/user-attachments/assets/5027da8f-3b7e-4cbb-a24a-c3dded4d1e31" />

Ranking de jugadores:
<img width="775" height="496" alt="Ranking" src="https://github.com/user-attachments/assets/69f8e577-927b-4280-bb1d-71ef2775138e" />

Exportación del ranking a CSV:
<img width="1335" height="639" alt="Exportar CSV" src="https://github.com/user-attachments/assets/a17f64f7-cc8d-4910-9964-9399215ade10" />

Módulo de administración (solo Brady o Profesor):
<img width="804" height="482" alt="Administración" src="https://github.com/user-attachments/assets/1711284d-49b1-4163-b29b-5df4358964a0" />

Autores

Brady Alexander Moncada Jiménez
David Muños Suárez

Instituto Universitario Pascual Bravo
Programa: Tecnología en Desarrollo de Software — 2025
