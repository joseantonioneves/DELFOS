# DELFOS JWT SSO

## Visão Geral

Este projeto implementa um sistema de autenticação Single Sign-On (SSO) utilizando JWT (JSON Web Token) com ASP.NET Core. Ele permite que múltiplos aplicativos compartilhem um mecanismo centralizado de autenticação, facilitando o gerenciamento de usuários e permissões.

## Estrutura do Projeto

- **DELFOS.JWT.SSO.API**: API principal responsável pela autenticação, emissão de tokens JWT e gerenciamento de usuários, organizações e portfólios de aplicativos.
- **DELFOS.JWT.SSO.Adm**: Módulo administrativo para gerenciamento do sistema.
- **DELFOS.JWT.SSO.MODELS**: Contém os modelos de dados compartilhados entre os módulos.
- **SCRIPTS SQL**: Scripts para criação e manutenção do banco de dados.

## Funcionalidades

- Autenticação de usuários via endpoint `/api/Login`
- Emissão de tokens JWT para acesso autenticado
- Gerenciamento de usuários, organizações e portfólios de aplicativos
- Suporte a roles/perfis de usuário (ex: Administrador, Vendedor)
- Páginas Razor para interface web e endpoints RESTful para integração

## Como Executar

1. **Pré-requisitos**:
   - [.NET 6.0 SDK ou superior](https://dotnet.microsoft.com/download)
   - SQL Server (ou outro banco de dados compatível)

2. **Configuração**:
   - Configure as strings de conexão e parâmetros no arquivo `appsettings.json` de cada projeto.
   - Execute os scripts em `SCRIPTS SQL/` para criar o banco de dados.

3. **Build e Execução**:
   ```sh
   dotnet build DELFOS.sln
   dotnet run --project DELFOS.JWT.SSO.API/DELFOS.JWT.SSO.API.csproj
   ```

4. **Acesso**:
   - Acesse a API em `https://localhost:5001` (ou porta configurada).
   - Utilize ferramentas como Postman para testar o endpoint de login.

## Licença

Este projeto está licenciado sob a [GNU General Public License v3.0](LICENSE.txt).

---

**Observação:** Este projeto utiliza bibliotecas de terceiros como Bootstrap, jQuery e jQuery Validation, cujas licenças estão incluídas nas respectivas pastas em `wwwroot/lib/`.