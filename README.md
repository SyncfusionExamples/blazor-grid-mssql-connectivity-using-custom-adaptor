# Blazor DataGrid — MSSQL connectivity using CustomAdaptor

A concise sample that demonstrates connecting the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) to a Microsoft SQL Server using the Grid's CustomAdaptor to perform data binding and CRUD operations.

## Overview

This repository contains a minimal Blazor Server sample showing how to wire a Syncfusion DataGrid to a SQL Server database using a custom adaptor. It demonstrates mapping Grid actions (read, insert, update, remove) to server-side database operations against the provided sample database.

## Features

- Server-side CRUD (Create, Read, Update, Delete) via a CustomAdaptor implementation
- Example mapping between Grid actions and database operations
- Minimal configuration — intended as a learning sample

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or later
- [Visual Studio Code](https://code.visualstudio.com/)

## Getting started
### Clone the repository

```bash
git clone https://github.com/SyncfusionExamples/blazor-dataform-localization.git
cd blazor-dataform-localization
```

### Run with Visual Studio

1. Open the solution file using Visual Studio 2022 or later.
2. Add NORTHWND.MDF database located in the App_Data folder into the project.
3.  Open `OrderData.cs` and update the connection string.
4. Restore the NuGet packages by rebuilding the solution.
5. Build the project to ensure there are no compilation errors.
6. Run the project.

### Run with .NET CLI

```bash
# Restore dependencies
dotnet restore

# Run the project
dotnet run
```

## References

- Documentation: https://blazor.syncfusion.com/documentation/datagrid/connecting-to-database/mysql-server
- Demo: https://blazor.syncfusion.com/demos/datagrid/overview?theme=fluent2



