# Taxi System
Estudo sobre acoplamento entre serviços em cima de um sistema apresentado em Clean Architecture (Capítulo 27).

### Part 1: Sistema acoplado
Sistema se apresenta engessado para possíveis alterações e extensões

### Part 2: Sistema desacoplado
Sistema se apresenta desacoplado permitindo alterações e extensões

## Comandos
### Criar solução e adicionar projetos
1. dotnet new sln -o TaxiSystem && cd TaxiSystem
1. dotnet new console -o TaxiFinder2
1. dotnet sln add TaxiFinder

### Adicionar referências
1. dotnet new classlib -o TaxiEntities
1. dotnet add TaxiSupplier reference TaxiEntities

## Run
 - Rodar projeto TaxiUI