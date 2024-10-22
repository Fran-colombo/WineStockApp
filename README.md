# WineStockApp

## Descripción

WineStock es una aplicación de gestión de inventario de vinos que permite registrar, actualizar y consultar la disponibilidad de vinos en una bodega. La aplicación cuenta con autenticación basada en **JWT** para asegurar las rutas de la API. El backend está desarrollado en **ASP.NET Core** y utiliza **SQLite** como sistema de gestión de base de datos, con **Entity Framework Core** como ORM para manejar la persistencia de datos.

## Características

- **Gestión de inventario de vinos**: Registrar nuevos vinos, actualizar el stock, consultar vinos disponibles, o consultar vinos a través de su variedad.
- **Creación de usuarios**: Registro de nuevos usuarios.
- **Autenticación y autorización con JWT**: Los usuarios deben autenticarse para realizar ciertas operaciones.
- **Base de datos SQLite**: Ligera y autocontenida, maneja todos los datos de manera eficiente en un único archivo.
- **Arquitectura**: Separación de responsabilidades en distintos proyectos para mantener el código limpio y escalable.

## Tecnologías Utilizadas

- **C#**: Lenguaje de programación principal.
- **ASP.NET Core**: Framework para la creación y manejo de APIs REST.
- **Entity Framework Core**: ORM utilizado para mapear las entidades a la base de datos.
- **SQLite**: Sistema de base de datos ligero y autocontenido.
- **JWT**: Autenticación segura basada en tokens.
