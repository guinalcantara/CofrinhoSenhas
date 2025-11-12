# Cofrinho de Senhas

Sistema de gerenciamento de senhas desenvolvido em .NET 8 seguindo os princípios da Clean Architecture.

## Arquitetura

O projeto está organizado em camadas seguindo os princípios da Clean Architecture:

### CofrinhoSenhas.Dominio
- **Entidades**: Classes de domínio com regras de negócio
- **Interfaces**: Contratos para repositórios
- **Validacao**: Classes de validação de domínio

### CofrinhoSenhas.Aplicacao
- **DTOs**: Objetos de transferência de dados
- **Interfaces**: Contratos para serviços de aplicação
- **Servicos**: Implementação dos serviços de aplicação
- **Mapeamentos**: Configuração do AutoMapper

### CofrinhoSenhas.Infra.Dados
- **Contexto**: Contexto do Entity Framework
- **Repositorios**: Implementação dos repositórios

### CofrinhoSenhas.Infra.IoC
- **InjecaoDependencia**: Configuração de injeção de dependência em arquivo único

### CofrinhoSenhas.WebAPI
- **Controladores**: Controllers da API REST
- **Program.cs**: Configuração da aplicação
- **appsettings.json**: Configurações da aplicação

## Entidades

- **Usuario**: Gerenciamento de usuários com autenticação
- **Categoria**: Categorização de senhas
- **Senha**: Armazenamento seguro de senhas com criptografia AES
- **Etiqueta**: Sistema de tags para organização
- **LogEvento**: Auditoria e log de eventos do sistema

## Funcionalidades

✅ **CRUD Completo** para todas as entidades
✅ **Autenticação** com hash HMACSHA512
✅ **Criptografia AES** para senhas armazenadas
✅ **Sistema de Etiquetas** para organização
✅ **Log de Eventos** para auditoria
✅ **Validações de Domínio** robustas
✅ **AutoMapper** para mapeamento de objetos
✅ **Swagger** para documentação da API

## Tecnologias

- .NET 8
- Entity Framework Core
- MySQL
- AutoMapper
- Swagger/OpenAPI

## Controladores da API

### UsuariosControlador
- `GET /api/usuarios` - Listar usuários
- `GET /api/usuarios/{id}` - Obter usuário por ID
- `GET /api/usuarios/email/{email}` - Obter usuário por email
- `POST /api/usuarios` - Criar usuário
- `PUT /api/usuarios/{id}` - Atualizar usuário
- `DELETE /api/usuarios/{id}` - Excluir usuário
- `POST /api/usuarios/login` - Fazer login
- `POST /api/usuarios/{id}/alterar-senha` - Alterar senha

### CategoriasControlador
- `GET /api/categorias` - Listar categorias
- `GET /api/categorias/usuario/{idUsuario}` - Listar categorias por usuário
- `GET /api/categorias/{id}` - Obter categoria por ID
- `POST /api/categorias` - Criar categoria
- `PUT /api/categorias/{id}` - Atualizar categoria
- `DELETE /api/categorias/{id}` - Excluir categoria

### SenhasControlador
- `GET /api/senhas` - Listar senhas
- `GET /api/senhas/usuario/{idUsuario}` - Listar senhas por usuário
- `GET /api/senhas/categoria/{idCategoria}` - Listar senhas por categoria
- `GET /api/senhas/{id}` - Obter senha por ID
- `GET /api/senhas/{id}/descriptografada` - Obter senha descriptografada
- `POST /api/senhas` - Criar senha
- `PUT /api/senhas/{id}` - Atualizar senha
- `DELETE /api/senhas/{id}` - Excluir senha

### EtiquetasControlador
- `GET /api/etiquetas` - Listar etiquetas
- `GET /api/etiquetas/usuario/{idUsuario}` - Listar etiquetas por usuário
- `GET /api/etiquetas/{id}` - Obter etiqueta por ID
- `POST /api/etiquetas` - Criar etiqueta
- `PUT /api/etiquetas/{id}` - Atualizar etiqueta
- `DELETE /api/etiquetas/{id}` - Excluir etiqueta

### LogEventosControlador
- `GET /api/logeventos` - Listar logs de eventos
- `GET /api/logeventos/usuario/{idUsuario}` - Listar logs por usuário
- `GET /api/logeventos/{id}` - Obter log por ID
- `POST /api/logeventos` - Criar log de evento
- `DELETE /api/logeventos/{id}` - Excluir log de evento

## Configuração

1. Configure a string de conexão no `appsettings.json`
2. Execute as migrações do Entity Framework
3. Execute a aplicação

```bash
dotnet ef database update
dotnet run
```

## Segurança

- Senhas de usuários são hasheadas com HMACSHA512
- Senhas armazenadas são criptografadas com AES
- Validações de domínio em todas as entidades
- Log de eventos para auditoria

## Próximos Passos

1. Implementar autenticação JWT
2. Adicionar autorização baseada em roles
3. Implementar testes unitários
4. Adicionar middleware de log automático
5. Implementar cache Redis

